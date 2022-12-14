using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ElsieBudget.Models;
using System.IO;

namespace ElsieBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing() //overide parent class's property
        {
            var expenses = new List<Expense>();
            var files = Directory.EnumerateFiles(
                Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData),
                "*.expense.notes.txt");//go to the directory and find the files named something.notes.txt

            foreach (var file in files)
            {
                var expense = new Expense
                {
                    Text = File.ReadAllText(file),
                    Date = File.GetCreationTime(file),
                    FileName = file
                };
                expenses.Add(expense);
            }
            ExpenseListView.ItemsSource = expenses.OrderByDescending(t => t.Date);
            //binding the source 



            var budgetfiles = Directory.EnumerateFiles(
                Environment.GetFolderPath
                (Environment.SpecialFolder.LocalApplicationData),
               "*.budget.notes.txt");
            var budgets = new List<Budget>();
            foreach (var budgetfile in budgetfiles)
            {
                var budget = new Budget
                {
                    Text = File.ReadAllText(budgetfile),
                    Date = File.GetCreationTime(budgetfile),
                    FileName = budgetfile
                };
                budgets.Add(budget);
            }
            BudgetListView.ItemsSource = budgets;

            if (budgetfiles.Count() > 0)
            {
                BudgetButton.IsVisible = false;
            } else
            {
                BudgetButton.IsVisible = true;
            }
            //var i = BudgetListView.ItemsSource;    
            //if (i ==  )
            // {
            //  BudgetButton.IsVisible = false;
            //}
            //if (Navigation.ModalStack.Count > 0)
            //{ BudgetButton.IsVisible = false; }

        }
           
        private async void ExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            await Navigation.PushModalAsync(new ExpensePage
            {
                BindingContext = (Expense)e.SelectedItem //pass the content to the new page
            });
        }

        

     

        private async void BudgetButton_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new BudgetPage());
        }

        private async void BudgetListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new BudgetPage
            {
                BindingContext = (Budget)e.SelectedItem //pass the content to the new page
            });
        }
    }
}
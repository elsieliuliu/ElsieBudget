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
                "*.notes.txt");//go to the directory and find the files named something.notes.txt
            
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
               "*.notes.txt");
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

            var budgettxt = (Expense)BindingContext;
            if (budgettxt != null )
            {
                BudgetButton.IsVisible = false;

            }

        }
        private async void ExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            await Navigation.PushModalAsync(new ExpensePage
            {
                BindingContext = (Expense)e.SelectedItem //pass the content to the new page
            });
        }

        

        private void BudgetListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void BudgetButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BudgetPage()).Wait();
        }
    }
}
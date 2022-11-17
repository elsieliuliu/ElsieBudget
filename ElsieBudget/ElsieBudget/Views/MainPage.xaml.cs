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
                
            foreach(var file in files)
            {
                var expense = new Expense
                {
                    Text = File.ReadAllText(file),
                    Date = File.GetCreationTime(file),
                    FileName = file
                };
                expenses.Add(expense);
            }
            ExpenseListView.ItemsSource = expenses.OrderByDescending(t => t.Date);//binding the source 
        }
        private async void ExpenseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            await Navigation.PushModalAsync(new ExpensePage
            {
                BindingContext = (Expense)e.SelectedItem //pass the content to the new page
            });
        }
    }
}
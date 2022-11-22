using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ElsieBudget.Models;

namespace ElsieBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage : ContentPage
    {
        private List<CategoryIcon> categoryIcons;
        public ExpensePage()
        {
            InitializeComponent();

            //categoryIcons = new List<CategoryIcon>();
            //categoryIcons.Add(new CategoryIcon
            //{
                //IconFile = "Assets/Entertainment.png",
                //Category = ExpenseCategory.Entertainment
            //});
        }
         
        protected override void OnAppearing()
        {
            var expense = (Expense)BindingContext;
            if (expense != null && !string.IsNullOrEmpty(expense.FileName))
            {
                ExpenseText.Text = File.ReadAllText(expense.FileName);
            }
            //try FromFile
            

            

        }
        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (expense == null || string.IsNullOrEmpty(expense.FileName))
            {
                expense = new Expense();
                expense.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"{Path.GetRandomFileName()}.expense.notes.txt"); //create a file with random name
                                                            
            }
            File.WriteAllText(expense.FileName, ExpenseText.Text);// write the texts into the file
            if (Navigation.ModalStack.Count > 0)
            { 
                await Navigation.PopModalAsync(); //this line takes you back where you cAME(the mainpage)
            } else
            {
                Shell.Current.CurrentItem = (Shell.Current as AppShell).MainPageContent;
            }
               
        }

        private async void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (File.Exists(expense.FileName))
            {
                File.Delete(expense.FileName);
            }
            ExpenseText.Text = string.Empty;
            await Navigation.PopModalAsync();

        }

        private void grocery_Clicked(object sender, EventArgs e)
        {

        }

        private void Medical_Clicked(object sender, EventArgs e)
        {

        }

        private void Housing_Clicked(object sender, EventArgs e)
        {

        }

        private void Grocery_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Entertainment_Clicked(object sender, EventArgs e)
        {

        }

        private void Shopping_Clicked(object sender, EventArgs e)
        {

        }

        private void Other_Clicked(object sender, EventArgs e)
        {

        }
    }
    

}
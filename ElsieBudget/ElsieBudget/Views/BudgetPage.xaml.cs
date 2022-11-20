using ElsieBudget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace ElsieBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BudgetPage : ContentPage
    {
        public BudgetPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var budget = (Budget)BindingContext;
            if (budget != null && !string.IsNullOrEmpty(budget.FileName))
            {
                BudgetText.Text = File.ReadAllText(budget.FileName);
            }

        }





        private async void BudgetSave_Clicked_1(object sender, EventArgs e)
        {
            var budget = new Budget();
            budget.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
             $"{Path.GetRandomFileName()}.budget.notes.txt"); //create a file with random name


            File.WriteAllText(budget.FileName, BudgetText.Text);

            if (Navigation.ModalStack.Count > 0)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                Shell.Current.CurrentItem = (Shell.Current as AppShell).MainPageContent;
            }

        }

        private async void BudgetDelete_Clicked(object sender, EventArgs e)
        {
            {
                var budget = (Budget)BindingContext;
                if (File.Exists(budget.FileName))
                {
                    File.Delete(budget.FileName);
                }
                BudgetText.Text = string.Empty;
                await Navigation.PopModalAsync();

            }
        }
    }
}
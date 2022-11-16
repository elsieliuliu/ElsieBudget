using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ElsieBudget.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensePage : ContentPage
    {
        public ExpensePage()
        {
            InitializeComponent();
        }

        private void OnSaveButton_Clicked(object sender, EventArgs e)
        {
         var filename1 =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"{Path.GetRandomFileName()}.notes.txt"); 
         File.WriteAllText(filename1,ExpenseName.Text);
         var filename2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                           $"{Path.GetRandomFileName()}.notes.txt");
            File.WriteAllText(filename2, ExpenseAmount.Text);

        }

        private void OnCancelButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
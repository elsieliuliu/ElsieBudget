using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ElsieBudget.Models
{
    internal enum ExpenseCategory
    {
        Grocery,
       
        Entertainment,
        Housing,
        Medical,
        Shopping,
        Other
       
    }
    internal class Expense
    {
       
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public ExpenseCategory Category { get; set; }

        
           // string filename)
        //{
          //  Text = text;
           // Category = category;
           // Date = date;
           // FileName = filename;
        //}

  
    }
}

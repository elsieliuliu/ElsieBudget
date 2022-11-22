using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ElsieBudget.Models
{
    internal enum ExpenseCategory
    {
        Grocery,
        Transportation,
        Entertainment,
        Housing,
        Medical,
        Shopping,
        Other
       
    }
    internal class Expense
    {
        //public string Name { get; set; }
        //public string Amount { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public ExpenseCategory Category { get; set; }
        //public Expense(string text, ExpenseCategory category, DateTime date,
           // string filename)
        //{
          //  Text = text;
           // Category = category;
           // Date = date;
           // FileName = filename;
        //}

       
    }
}

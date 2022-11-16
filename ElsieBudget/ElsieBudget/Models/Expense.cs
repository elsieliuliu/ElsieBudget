using System;
using System.Collections.Generic;
using System.Text;

namespace ElsieBudget.Models
{
    internal class Expense
    {
        public string ExpenseName { get; set; }
        public string ExpenseAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string FileName { get; set; }
    }
}

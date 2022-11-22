using System;
using System.Collections.Generic;
using System.Text;

namespace ElsieBudget.Models
{
    internal class CategoryIcon
    {
        public string IconFile { get; set; }
        public ExpenseCategory Category { get; set; } 
        public CategoryIcon(string iconFile, ExpenseCategory category)
        {
            IconFile = iconFile;
            Category = category;
        }
    }
}

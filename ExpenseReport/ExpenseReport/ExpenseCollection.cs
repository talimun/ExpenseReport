using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport
{
    class ExpenseCollection
    {
        public List<ExpenseItem> ExpenseItems = new List<ExpenseItem>();
        public List<string> Categories = new List<string>();

        public ExpenseCollection(ExpenseItem expenseItem)
        {
            AddExpense(expenseItem);
        }

        public void AddExpense(ExpenseItem expenseItem)
        {
            ExpenseItems.Add(expenseItem);
        }
        public void AddCategory(string category)
        {
            if (!Categories.Contains(category))
            {
                Categories.Add(category);
            }
        }
    }
}

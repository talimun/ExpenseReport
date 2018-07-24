using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport
{
    public class ExpenseCollection
    {
        public List<ExpenseItem> ExpenseItems;
        public List<string> Categories;
        public string ExpenseName;

        public ExpenseCollection()
        {
            ExpenseItems = new List<ExpenseItem>();
            Categories = new List<string>();
            ExpenseName = "";

        }
        public ExpenseCollection(ExpenseItem expenseItem)
        {

            ExpenseItems = new List<ExpenseItem>();
            Categories = new List<string>();
            ExpenseName = "";
            AddExpense(expenseItem);
            ExpenseName = expenseItem.Name;
        }

        public void AddExpense(ExpenseItem expenseItem)
        {
            bool dupe = false;
            foreach (ExpenseItem item in ExpenseItems)
            {
                if (item.Equals(expenseItem))
                {
                    dupe = true;
                    break;
                }
            }
            if (!dupe)
            {
                ExpenseItems.Add(expenseItem);
            }
        }
        public void AddCategory(string category)
        {
            if (!Categories.Contains(category))
            {
                Categories.Add(category);
            }
        }
        public void RemoveCategory(string category)
        {
            Categories.Remove(category);
        }

        public bool IsCategorised()
        {
            return Categories.Count > 0;
        }

    }
}

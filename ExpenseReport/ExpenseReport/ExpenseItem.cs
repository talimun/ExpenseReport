using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport
{
    public class ExpenseItem
    {
        public ExpenseItem()
        {

        }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public ExpenseItem(string date, string name, string cost)
        {
            Date = Convert.ToDateTime(date);
            Name = name;
            Cost = decimal.Parse(cost, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
        }
        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            ExpenseItem item = (ExpenseItem)obj;
            return Date.Equals(item.Date) && Name.Equals(item.Name) && Cost.Equals(item.Cost);
        }
    }
}

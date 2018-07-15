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
        
    }
}

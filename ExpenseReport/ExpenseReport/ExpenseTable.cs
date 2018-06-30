using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic.FileIO;

namespace ExpenseReport
{
    class ExpenseTable
    {
        const string DATE = "date";
        const string DESC = "description"; 
        const string COST = "cost";
        public DataTable Table {  get; }
        private Dictionary<string, List<ExpenseItem> > myExpenseItemsByName;
        private Form1 myParent;

        public ExpenseTable()
        {
            Table = new DataTable();
            myExpenseItemsByName = new Dictionary<string, List<ExpenseItem>>();

        }
        public ExpenseTable(Form1 parent)
        {
            myParent = parent;
            Table = new DataTable();
            myExpenseItemsByName = new Dictionary<string, List<ExpenseItem> >();

        }

        public string GetExpenseItemName(int index)
        {
            return myExpenseItemsByName.ElementAt(index).Key;

        }

        public int TotalUniqueExpenses()
        {
            return myExpenseItemsByName.Count();
        }
        public int TotalRows()
        {
            return Table.Rows.Count;
        }
        public int TotalCategories()
        {
            return Table.Rows.Count;
        }
        public int UndefinedRows()
        {
            return Table.Rows.Count;
        }
        public bool LoadFromFile(string filename)
        {
            try
            {


                FileStream stream = new FileStream(filename, FileMode.Open);
                TextFieldParser reader = new TextFieldParser(stream);
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(",");

                string[] data = reader.ReadFields();
                if(!data[0].Equals(DATE))
                {
                    throw new Exception("Error parsing Date column");
                }

                if (!data[1].Equals(DESC))
                {
                    throw new Exception("Error parsing Description column");
                }


                if (!data[2].Equals(COST))
                {
                    throw new Exception("Error parsing Date column");
                }

                while (!reader.EndOfData)
                {

                    string[] AllRows = reader.ReadFields();
                    try
                    {
                        ExpenseItem expenseItem = new ExpenseItem(AllRows[0], AllRows[1], AllRows[2]);
                        if (myExpenseItemsByName.ContainsKey(expenseItem.Name))
                        {
                            myExpenseItemsByName[expenseItem.Name].Add(expenseItem);
                        }
                        else
                        {
                            myExpenseItemsByName.Add(expenseItem.Name, new List<ExpenseItem>() { expenseItem });
                        }
                    }
                    catch (Exception ex)
                    {
                        myParent.Log(ex.Message);
                    }
                }

                GenerateReport();

                return true;
            }
            catch(Exception ex)
            {
                myParent.Log(ex.Message);
            }
            return false;
        }
        void GenerateReport()
        {

            Table.Clear();
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = DATE;
            column.ReadOnly = true;
            column.Unique = false;
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = DESC;
            column.ReadOnly = true;
            column.Unique = false;
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = COST;
            column.ReadOnly = true;
            column.Unique = false;
            Table.Columns.Add(column);

            foreach (string name in myExpenseItemsByName.Keys)
            {
                List<ExpenseItem> expenseItems = myExpenseItemsByName[name];
                foreach (ExpenseItem expenseItem in expenseItems)
                {
                    DataRow row = Table.NewRow();
                    row[DATE] = expenseItem.Date;
                    row[DESC] = expenseItem.Name;
                    row[COST] = expenseItem.Cost;

                    Table.Rows.Add(row);
                }
            }
            
        }
    }
}

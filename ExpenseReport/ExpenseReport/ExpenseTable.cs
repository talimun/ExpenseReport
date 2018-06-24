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
        public DataTable Table {  get; }

        private Form1 myParent;
        
        public ExpenseTable(Form1 parent)
        {
            myParent = parent;
            Table = new DataTable();

        }

        public bool LoadFromFile(string filename)
        {
            Table.Clear(); 
            FileStream stream = new FileStream(filename, FileMode.Open);
            TextFieldParser reader = new TextFieldParser(stream);
            reader.TextFieldType = FieldType.Delimited;
            reader.SetDelimiters(",");

            string[] data = reader.ReadFields();

            Table.Columns.Add(data[0], Type. 
            foreach (string columnName in data)
            {
                if (columnName.Length > 0)
                {
                }
            }


            while (!reader.EndOfData)
            {

                string[] AllRows = reader.ReadFields();
                try
                {
                    ExpenseItem expenseItem = new ExpenseItem(AllRows[0], AllRows[1], AllRows[2]);

                    Table.Rows.Add(expenseItem.ToArray());
                }
                catch (Exception ex)
                {
                    myParent.Log(ex.Message);
                }
            }


            return true;
        }
    }
}

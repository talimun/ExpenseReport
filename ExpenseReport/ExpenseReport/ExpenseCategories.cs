using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport
{
    class ExpenseCategories
    {
        private static string FILENAME = "categories.csv";
        private Form1 myParent;

        public List<string> CategoryList;
        public ExpenseCategories(Form1 parent)
        {
            CategoryList = new List<string>();
            myParent = parent;
        }

        public void LoadFromFile()
        {
            try
            {

                FileStream stream = new FileStream(FILENAME, FileMode.Open);
                TextFieldParser reader = new TextFieldParser(stream);
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(",");

                string[] data = reader.ReadFields();
                CategoryList.AddRange(data);
            }
            catch (Exception ex)
            {
                myParent.Log(ex.Message);
            }

            
        }
    }
}

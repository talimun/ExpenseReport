using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic.FileIO;

namespace ExpenseReport
{
    class ExpenseTable
    {
        const string DATE = "date";
        const string DESC = "description"; 
        const string COST = "cost";
        public DataTable Table;
        private SortedDictionary<string, ExpenseCollection > myExpenseItemsByName;
        private Form1 myParent;
        
        public ExpenseTable(Form1 parent)
        {
            myParent = parent;
            Table = new DataTable();
            myExpenseItemsByName = new SortedDictionary<string, ExpenseCollection>();

        }

        public ExpenseCollection GetExpenseItems(int index)
        {
            return myExpenseItemsByName.ElementAt(index).Value;

        }

        public int TotalUniqueExpenses()
        {
            return myExpenseItemsByName.Count();
        }
        public int TotalRows()
        {
            return Table.Rows.Count;
        }
        public int TotalUncategorised()
        {
            int categorised = 0;
            foreach (ExpenseCollection expense in myExpenseItemsByName.Values)
            {
                categorised = expense.IsCategorised() ? categorised+1 : categorised;
            }
            return TotalUniqueExpenses() - categorised;
        }
        public int UndefinedRows()
        {
            return Table.Rows.Count;
        }

        public int GetNextUncategorised(int currentIndex)
        {
            int startingIndex = currentIndex++;
            currentIndex = (currentIndex) % myExpenseItemsByName.Count();

            while (myExpenseItemsByName.ElementAt(currentIndex).Value.IsCategorised())
            {

                currentIndex = (++currentIndex) % myExpenseItemsByName.Count();
                if (currentIndex == startingIndex)
                {
                    break;
                }
            }
            
            return currentIndex;
        }

        public int GetPreviousUncategorised(int currentIndex)
        {
            int startingIndex = currentIndex--;
            currentIndex = currentIndex < 0 ? myExpenseItemsByName.Count() - 1 : currentIndex;

            while (myExpenseItemsByName.ElementAt(currentIndex).Value.IsCategorised())
            {

                currentIndex = --currentIndex < 0 ? myExpenseItemsByName.Count() - 1 : currentIndex;
                if (currentIndex == startingIndex)
                {
                    break;
                }
            }

            return currentIndex;
        }

        public bool AddExpenseFromFile(string filename)
        {
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open);
                TextFieldParser reader = new TextFieldParser(stream);
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(",");

                /*string[] data = reader.ReadFields();
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
                */
                while (!reader.EndOfData)
                {

                    string[] AllRows = reader.ReadFields();
                    try
                    {
                        ExpenseItem expenseItem = new ExpenseItem(AllRows[0], AllRows[1], AllRows[2]);
                        if (myExpenseItemsByName.ContainsKey(expenseItem.Name))
                        {
                            myExpenseItemsByName[expenseItem.Name].AddExpense(expenseItem);
                        }
                        else
                        {
                            myExpenseItemsByName.Add(expenseItem.Name, new ExpenseCollection( expenseItem ));
                        }
                    }
                    catch (Exception ex)
                    {
                        myParent.Log(ex.Message);
                    }
                }
                stream.Close();
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

            Table = new DataTable();
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
                ExpenseCollection expenseCollection = myExpenseItemsByName[name];
                foreach (ExpenseItem expenseItem in expenseCollection.ExpenseItems)
                {
                    DataRow row = Table.NewRow();
                    row[DATE] = expenseItem.Date;
                    row[DESC] = expenseItem.Name;
                    row[COST] = expenseItem.Cost;

                    Table.Rows.Add(row);
                }
            }
            
        }

        public void AddCategoryToExpense(int index, string category)
        {
            myExpenseItemsByName.ElementAt(index).Value.AddCategory(category);
        }

        public void LoadFromFile(string filename)
        {

            List<ExpenseCollection> collectionsList; 

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filename);
                string xmlString = xmlDocument.OuterXml;
                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(List<ExpenseCollection>);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        collectionsList = (List<ExpenseCollection>)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                    myExpenseItemsByName.Clear();
                    foreach (ExpenseCollection collection in collectionsList)
                    {
                        myExpenseItemsByName.Add(collection.ExpenseName, collection);
                    }

                    GenerateReport();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                myParent.Log(ex.Message);
            }
        }

        public void SaveToFile(string filename)
        {
            StreamWriter outstream = new StreamWriter(filename);

            List<ExpenseCollection> collectionsList = new List<ExpenseCollection>();

            collectionsList.AddRange(myExpenseItemsByName.Values);
            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(collectionsList.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, collectionsList);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(outstream);

                stream.Close();
            }

        }
        
        
    }
}

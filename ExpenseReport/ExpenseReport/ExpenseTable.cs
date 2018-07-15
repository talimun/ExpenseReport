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
        public DataTable Table {  get; }
        private Dictionary<string, ExpenseCollection > myExpenseItemsByName;
        private Form1 myParent;

        public ExpenseTable()
        {
            Table = new DataTable();
            myExpenseItemsByName = new Dictionary<string, ExpenseCollection>();

        }
        public ExpenseTable(Form1 parent)
        {
            myParent = parent;
            Table = new DataTable();
            myExpenseItemsByName = new Dictionary<string, ExpenseCollection>();

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



        public void SaveToFile(string filename)
        {
            StreamWriter outstream = new StreamWriter(filename);

            foreach (ExpenseCollection collection in myExpenseItemsByName.Values)
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(collection.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, collection);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(outstream);

                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fileName"></param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {

                myParent.Log(ex.Message);
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                myParent.Log(ex.Message);
            }

            return objectOut;
        }
    }
}

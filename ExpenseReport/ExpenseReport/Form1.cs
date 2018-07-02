using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseReport
{
    public partial class Form1 : Form
    {
        ExpenseTable myRawData = new ExpenseTable();
        ExpenseCategories myCategories;
        private int myIndex = 0;
        private int myTotalRows = 0;
        private DataTable myTable = new DataTable();
        private NewCategory CategoryWindow;

        const string DATE = "date";
        const string DESC = "description";
        const string COST = "cost";

        public Form1()
        {
            InitializeComponent();
            myCategories = new ExpenseCategories(this);
            myCategories.LoadFromFile();
            UpdateComboBox();

            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = DATE;
            column.ReadOnly = true;
            column.Unique = false;
            myTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = COST;
            column.ReadOnly = true;
            column.Unique = false;
            myTable.Columns.Add(column);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRawData = new ExpenseTable(this);
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                myRawData.LoadFromFile(openFileDialog1.FileName);
                myTotalRows = myRawData.TotalUniqueExpenses();
                dataGridView1.DataSource = myRawData.Table;
                UpdateSummary();
                ShowNextExpense();
            }

        }
        private void UpdateComboBox()
        {
            foreach (string category in myCategories.CategoryList)
            {
                categoryComboBox.Items.Add(category);
            }
        }

        private bool DataLoaded()
        {
            return (myRawData.TotalRows() > 0);
        }
        
        public void Log(string logline)
        {
            logFile.AppendText(logline);
        }

        public void ShowNextExpense()
        {
            if (DataLoaded())
            {
                myIndex = (++myIndex) % myTotalRows;
                PopulateExpenseDetails(myIndex);
            }
        }

        public void ShowPreviousExpense()
        {
            if (DataLoaded())
            {
                myIndex = --myIndex < 0?  myTotalRows-1: myIndex;
                PopulateExpenseDetails(myIndex);
            }
        }

        private void PopulateExpenseDetails(int index)
        {
            string expenseItemName = myRawData.GetExpenseItemName(myIndex);
            ExpenseCollection expenseCollection = myRawData.GetExpenseItems(expenseItemName);

            expenseNameTextBox.Text = expenseItemName;

            myTable.Clear();

            foreach (ExpenseItem expenseItem in expenseCollection.ExpenseItems)
            {
                DataRow row = myTable.NewRow();
                row[DATE] = expenseItem.Date;
                row[COST] = expenseItem.Cost;

                myTable.Rows.Add(row);
            }
            setCategoryDataGridView.DataSource = myTable;

            categoryListBox.Items.Clear();
            foreach (string category in expenseCollection.Categories)
            {
                categoryListBox.Items.Add(category);
            }

        }
        public void UpdateSummary()
        {
            int catagories = myRawData.TotalCategories();
            int underfinedRows = myRawData.UndefinedRows();
            UncatagorisedNumberLabel.Text = myTotalRows + " Rows loaded";

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ShowNextExpense();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            ShowPreviousExpense();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!DataLoaded())
            {
                return;
            }

            if (categoryComboBox.SelectedItem.ToString() == "Create New...")
            {
                CategoryWindow = new NewCategory();
                DialogResult results = CategoryWindow.ShowDialog();
                if (results == DialogResult.OK)
                {
                    if (!myCategories.CategoryList.Contains(CategoryWindow.Category))
                    {
                        myCategories.CategoryList.Add(CategoryWindow.Category);
                        categoryComboBox.Items.Add(CategoryWindow.Category);
                        categoryComboBox.SelectedItem= CategoryWindow.Category;
                    }
                }
                CategoryWindow.Dispose();
            }
            else
            {
                AddCategoryToExpense(categoryComboBox.SelectedItem.ToString());
            }
        }

        private void AddCategoryToExpense(string category)
        {
            myRawData.AddCategoryToExpense(myIndex, category);
            PopulateExpenseDetails(myIndex);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myCategories.SaveToFile();
        }
    }
}

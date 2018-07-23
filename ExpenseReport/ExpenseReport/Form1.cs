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
        ExpenseTable myRawData;
        
        private NewCategory myCategoryWindow;
        private int myIndex = 0;
        private int myTotalRows = 0;
        private DataTable myTable = new DataTable();

        const string DATE = "date";
        const string DESC = "description";
        const string COST = "cost";

        public Form1()
        {
            InitializeComponent();

            myRawData = new ExpenseTable(this);
            myCategoryWindow = new NewCategory(this);

            myCategoryWindow.LoadCategories();
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


        private void UpdateComboBox()
        {
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Add("Manage Categories");
            foreach (string category in myCategoryWindow.Categories.CategoryList)
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
            ExpenseCollection expenseCollection = myRawData.GetExpenseItems(myIndex);

            expenseNameTextBox.Text = expenseCollection.ExpenseName;

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

            if (categoryComboBox.SelectedIndex==0)
            {
                DialogResult results = myCategoryWindow.ShowDialog();

                UpdateComboBox();
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

        private void DeleteSelectedButton_Click(object sender, EventArgs e)
        {
            if (categoryListBox.SelectedIndex >= 0)
            {
                ExpenseCollection expenseCollection = myRawData.GetExpenseItems(myIndex);
                expenseCollection.RemoveCategory(categoryListBox.SelectedItem.ToString());
                categoryListBox.Items.Remove(categoryListBox.SelectedItem);
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myRawData = new ExpenseTable(this);
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                myRawData.LoadFromFile(openFileDialog2.FileName);
                myTotalRows = myRawData.TotalUniqueExpenses();
                dataGridView1.DataSource = myRawData.Table;
                categoryComboBox.Enabled = true;
                UpdateSummary();
                ShowNextExpense();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myRawData.SaveToFile(saveFileDialog1.FileName);
            }
        }


        private void addExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myRawData.AddExpenseFromFile(openFileDialog1.FileName);
                myTotalRows = myRawData.TotalUniqueExpenses();
                dataGridView1.DataSource = myRawData.Table;
                categoryComboBox.Enabled = true;
                UpdateSummary();
                myIndex = 0;
                ShowNextExpense();
            }
        }
    }
}

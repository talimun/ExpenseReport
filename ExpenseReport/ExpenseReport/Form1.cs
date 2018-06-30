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
        private Form CategoryWindow = new NewCategory();

        const string DATE = "date";
        const string DESC = "description";
        const string COST = "cost";

        public Form1()
        {
            InitializeComponent();
            myCategories = new ExpenseCategories(this);
            myCategories.LoadFromFile();


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

        public void Log(string logline)
        {
            logFile.AppendText(logline);
        }

        public void ShowNextExpense()
        {
            if (myRawData.TotalRows() > 0)
            {
                myIndex = (++myIndex) % myTotalRows;
                PopulateExpenseDetails(myIndex);
            }
        }

        public void ShowPreviousExpense()
        {
            if (myRawData.TotalRows() > 0)
            {
                myIndex = --myIndex < 0?  myTotalRows-1: myIndex;
                PopulateExpenseDetails(myIndex);
            }
        }

        private void PopulateExpenseDetails(int index)
        {
            string expenseItemName = myRawData.GetExpenseItemName(myIndex);
            List<ExpenseItem> expenseItems = myRawData.GetExpenseItems(expenseItemName);

            expenseNameTextBox.Text = expenseItemName;

            myTable.Clear();

            foreach (ExpenseItem expenseItem in expenseItems)
            {
                DataRow row = myTable.NewRow();
                row[DATE] = expenseItem.Date;
                row[COST] = expenseItem.Cost;

                myTable.Rows.Add(row);
            }

            setCategoryDataGridView.DataSource = myTable;

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
            if (comboBox1.SelectedItem == "Create New...")
            {
                CategoryWindow.ShowDialog();
            }
        }
    }
}

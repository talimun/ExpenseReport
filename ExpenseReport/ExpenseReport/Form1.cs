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
        
        public Form1()
        {
            InitializeComponent();
            myCategories = new ExpenseCategories(this);
            myCategories.LoadFromFile();
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
            expenseNameTextBox.Text = myRawData.GetExpenseItemName(myIndex);
        }
        public void UpdateSummary()
        {
            int totalRows = myRawData.TotalRows();
            int catagories = myRawData.TotalCategories();
            int underfinedRows = myRawData.UndefinedRows();
            UncatagorisedNumberLabel.Text = totalRows+ " Rows loaded";

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ShowNextExpense();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            ShowPreviousExpense();
        }
    }
}

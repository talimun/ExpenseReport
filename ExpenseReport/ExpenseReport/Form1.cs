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
        ExpenseCategories myCategories;
        
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
                dataGridView1.DataSource = myRawData.Table;
                UpdateSummary();
            }

        }

        public void Log(string logline)
        {
            logFile.AppendText(logline);
        }

        public void UpdateSummary()
        {
            int totalRows = myRawData.TotalRows();
            int catagories = myRawData.TotalCategories();
            int underfinedRows = myRawData.UndefinedRows();
            UncatagorisedNumberLabel.Text = totalRows+ " Rows loaded";

        }
    }
}

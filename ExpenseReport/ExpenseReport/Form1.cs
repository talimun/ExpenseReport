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
        ExpenseTable myTable;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myTable = new ExpenseTable(this);
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                myTable.LoadFromFile(openFileDialog1.FileName);
                dataGridView1.DataSource = myTable.Table;
            }

        }

        public void Log(string logline)
        {
            logFile.AppendText(logline);
        }
    }
}

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
using Microsoft.VisualBasic.FileIO;

namespace ExpenseReport
{
    public partial class Form1 : Form
    {
        DataTable myTable;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            { 
                Stream stream = openFileDialog1.OpenFile();
                //StreamReader reader = new StreamReader(stream);
                TextFieldParser reader = new TextFieldParser(stream);
                reader.TextFieldType = FieldType.Delimited;
                reader.SetDelimiters(",");

                string[] data = reader.ReadFields();

                myTable = new DataTable();
                foreach (string columnName in data)
                {
                    if(columnName.Length>0)
                    {
                        myTable.Columns.Add(columnName);
                    }
                }
                    
                
                while (!reader.EndOfData)
                {

                    string[] AllRows = reader.ReadFields();
                    List<string> rows = new List<string>();
                    foreach (string row in AllRows)
                    {
                        if (row.Length > 0)
                        {
                            rows.Add(row);
                        }
                    }
                    myTable.Rows.Add(rows.ToArray<string>());
                }

                dataGridView1.DataSource = myTable;
            }

        }
    }
}

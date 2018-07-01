using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseReport
{
    public partial class NewCategory : Form
    {
        public string Category;
        public NewCategory()
        {
            InitializeComponent();
            Category = "";
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Category = categoryTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (categoryTextBox.Text.Length > 0)
            {
                createButton.Enabled = true;
            }
            else
            {
                createButton.Enabled = false;
            }
        }

    }
}

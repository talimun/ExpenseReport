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
        public string SelectedCategory;
        public NewCategory(ExpenseCategories categories)
        {
            InitializeComponent();
            SelectedCategory = "";
            foreach (string category in categories.CategoryList)
            currentCategoryListBox.Items.Add(category);
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            SelectedCategory = categoryTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (categoryTextBox.Text.Length > 0)
            {
                CreateNewButton.Enabled = true;
            }
            else
            {
                CreateNewButton.Enabled = false;
            }
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
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

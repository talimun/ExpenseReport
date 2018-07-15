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
        public ExpenseCategories Categories;
        Form1 myParent;
        public NewCategory(Form1 parent)
        {
            InitializeComponent();
            CreateNewButton.Enabled = false;
            myParent = parent;
        }

        public void LoadCategories()
        {

            Categories = new ExpenseCategories(myParent);
            Categories.LoadFromFile();

            foreach (string category in Categories.CategoryList)
            {
                currentCategoryListBox.Items.Add(category);
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Categories.SaveToFile();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            CreateNewButton.Enabled = categoryTextBox.Text.Length > 0;
            
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            if (categoryTextBox.Text.Length > 0)
            {
                AddNewCategory(categoryTextBox.Text);
            }
        }

        private void AddNewCategory(string category)
        {
            Categories.CategoryList.Add(category);
            if (!currentCategoryListBox.Items.Contains(category))
            {
                currentCategoryListBox.Items.Add(category);
            }
            categoryTextBox.Clear();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (currentCategoryListBox.SelectedIndex>=0)
            {
                Categories.CategoryList.Remove(currentCategoryListBox.SelectedItem.ToString());
                currentCategoryListBox.Items.RemoveAt(currentCategoryListBox.SelectedIndex);
            }
        }

        private void categoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (categoryTextBox.Text.Length > 0)
                {
                    AddNewCategory(categoryTextBox.Text);
                }
            }
        }
    }
}

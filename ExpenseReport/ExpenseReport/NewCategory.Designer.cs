namespace ExpenseReport
{
    partial class NewCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.doneButton = new System.Windows.Forms.Button();
            this.currentCategoryListBox = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.CreateNewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(242, 348);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(176, 32);
            this.doneButton.TabIndex = 1;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // currentCategoryListBox
            // 
            this.currentCategoryListBox.FormattingEnabled = true;
            this.currentCategoryListBox.ItemHeight = 20;
            this.currentCategoryListBox.Location = new System.Drawing.Point(240, 63);
            this.currentCategoryListBox.Name = "currentCategoryListBox";
            this.currentCategoryListBox.Size = new System.Drawing.Size(178, 184);
            this.currentCategoryListBox.TabIndex = 3;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(240, 265);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(178, 38);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete Selected";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(25, 63);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(195, 26);
            this.categoryTextBox.TabIndex = 0;
            this.categoryTextBox.TextChanged += new System.EventHandler(this.categoryTextBox_TextChanged);
            this.categoryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categoryTextBox_KeyDown);
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Location = new System.Drawing.Point(25, 265);
            this.CreateNewButton.Name = "CreateNewButton";
            this.CreateNewButton.Size = new System.Drawing.Size(188, 37);
            this.CreateNewButton.TabIndex = 5;
            this.CreateNewButton.Text = "Create New";
            this.CreateNewButton.UseVisualStyleBackColor = true;
            this.CreateNewButton.Click += new System.EventHandler(this.CreateNewButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Categories";
            // 
            // NewCategory
            // 
            this.AcceptButton = this.CreateNewButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 392);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateNewButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.currentCategoryListBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.doneButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCategory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "NewCategory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.ListBox currentCategoryListBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Button CreateNewButton;
        private System.Windows.Forms.Label label1;
    }
}
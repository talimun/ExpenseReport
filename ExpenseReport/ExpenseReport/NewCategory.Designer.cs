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
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.currentCategoryListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.CreateNewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(25, 348);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(195, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(242, 348);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(176, 32);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Add Selected";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Delete Selected";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(25, 101);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(195, 26);
            this.categoryTextBox.TabIndex = 0;
            this.categoryTextBox.TextChanged += new System.EventHandler(this.categoryTextBox_TextChanged);
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Location = new System.Drawing.Point(25, 161);
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
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(449, 392);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateNewButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentCategoryListBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.cancelButton);
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

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ListBox currentCategoryListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Button CreateNewButton;
        private System.Windows.Forms.Label label1;
    }
}
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
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(25, 68);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 32);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createButton.Enabled = false;
            this.createButton.Location = new System.Drawing.Point(275, 68);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(144, 32);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create and Set";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(25, 23);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(394, 26);
            this.categoryTextBox.TabIndex = 0;
            this.categoryTextBox.TextChanged += new System.EventHandler(this.categoryTextBox_TextChanged);
            // 
            // NewCategory
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(450, 119);
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
        private System.Windows.Forms.TextBox categoryTextBox;
    }
}
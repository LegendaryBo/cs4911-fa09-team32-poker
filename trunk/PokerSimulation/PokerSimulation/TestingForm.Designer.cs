namespace PokerSimulation
{
    partial class TestingForm
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
            this.testCardsList = new System.Windows.Forms.ListBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.generateTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // testCardsList
            // 
            this.testCardsList.FormattingEnabled = true;
            this.testCardsList.Location = new System.Drawing.Point(13, 13);
            this.testCardsList.Name = "testCardsList";
            this.testCardsList.Size = new System.Drawing.Size(259, 160);
            this.testCardsList.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(102, 229);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // generateTextBox
            // 
            this.generateTextBox.AcceptsTab = true;
            this.generateTextBox.Location = new System.Drawing.Point(89, 203);
            this.generateTextBox.Name = "generateTextBox";
            this.generateTextBox.Size = new System.Drawing.Size(100, 20);
            this.generateTextBox.TabIndex = 2;
            this.generateTextBox.Text = "Enter Hand";
            this.generateTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.generateTextBox_MouseClick);
            this.generateTextBox.Enter += new System.EventHandler(this.generateTextBox_Enter);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.generateTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.testCardsList);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox testCardsList;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox generateTextBox;
    }
}
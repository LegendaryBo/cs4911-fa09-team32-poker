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
            this.testCardsBox = new System.Windows.Forms.ListBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testCardsBox
            // 
            this.testCardsBox.FormattingEnabled = true;
            this.testCardsBox.Location = new System.Drawing.Point(13, 13);
            this.testCardsBox.Name = "testCardsBox";
            this.testCardsBox.Size = new System.Drawing.Size(259, 160);
            this.testCardsBox.TabIndex = 0;
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
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.testCardsBox);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox testCardsBox;
        private System.Windows.Forms.Button generateButton;
    }
}
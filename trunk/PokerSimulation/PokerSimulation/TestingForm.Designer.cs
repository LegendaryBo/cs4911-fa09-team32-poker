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
            this.numCards = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCards)).BeginInit();
            this.SuspendLayout();
            // 
            // testCardsList
            // 
            this.testCardsList.FormattingEnabled = true;
            this.testCardsList.ItemHeight = 16;
            this.testCardsList.Location = new System.Drawing.Point(17, 16);
            this.testCardsList.Margin = new System.Windows.Forms.Padding(4);
            this.testCardsList.Name = "testCardsList";
            this.testCardsList.Size = new System.Drawing.Size(344, 196);
            this.testCardsList.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(136, 282);
            this.generateButton.Margin = new System.Windows.Forms.Padding(4);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 28);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // generateTextBox
            // 
            this.generateTextBox.AcceptsTab = true;
            this.generateTextBox.Location = new System.Drawing.Point(49, 249);
            this.generateTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.generateTextBox.Name = "generateTextBox";
            this.generateTextBox.Size = new System.Drawing.Size(132, 22);
            this.generateTextBox.TabIndex = 2;
            this.generateTextBox.Text = "Enter Hand";
            this.generateTextBox.Leave += new System.EventHandler(this.generateTextBox_Leave);
            this.generateTextBox.Enter += new System.EventHandler(this.generateTextBox_Enter);
            // 
            // numCards
            // 
            this.numCards.Location = new System.Drawing.Point(285, 250);
            this.numCards.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numCards.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numCards.Name = "numCards";
            this.numCards.Size = new System.Drawing.Size(37, 22);
            this.numCards.TabIndex = 3;
            this.numCards.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Cards";
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCards);
            this.Controls.Add(this.generateTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.testCardsList);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            ((System.ComponentModel.ISupportInitialize)(this.numCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox testCardsList;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox generateTextBox;
        private System.Windows.Forms.NumericUpDown numCards;
        private System.Windows.Forms.Label label1;
    }
}
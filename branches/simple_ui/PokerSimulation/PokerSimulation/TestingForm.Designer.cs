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
            this.closeButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.sessionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCards)).BeginInit();
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
            this.generateButton.Location = new System.Drawing.Point(197, 228);
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
            this.generateTextBox.Location = new System.Drawing.Point(81, 202);
            this.generateTextBox.Name = "generateTextBox";
            this.generateTextBox.Size = new System.Drawing.Size(100, 20);
            this.generateTextBox.TabIndex = 2;
            this.generateTextBox.Text = "Enter Hand";
            this.generateTextBox.Leave += new System.EventHandler(this.generateTextBox_Leave);
            this.generateTextBox.Enter += new System.EventHandler(this.generateTextBox_Enter);
            // 
            // numCards
            // 
            this.numCards.Location = new System.Drawing.Point(214, 203);
            this.numCards.Margin = new System.Windows.Forms.Padding(2);
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
            this.numCards.Size = new System.Drawing.Size(28, 20);
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
            this.label1.Location = new System.Drawing.Point(186, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Cards";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(197, 255);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 234);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(46, 13);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "Enter ID";
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Location = new System.Drawing.Point(10, 261);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(72, 13);
            this.sessionLabel.TabIndex = 7;
            this.sessionLabel.Text = "Enter Session";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(81, 231);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 8;
            this.idTextBox.Text = "ID#";
            this.idTextBox.Click += new System.EventHandler(this.idTextBox_Click);
            this.idTextBox.Leave += new System.EventHandler(this.idTextBox_Leave);
            // 
            // sessionTextBox
            // 
            this.sessionTextBox.Location = new System.Drawing.Point(81, 258);
            this.sessionTextBox.Name = "sessionTextBox";
            this.sessionTextBox.Size = new System.Drawing.Size(100, 20);
            this.sessionTextBox.TabIndex = 9;
            this.sessionTextBox.Text = "Session#";
            this.sessionTextBox.Click += new System.EventHandler(this.sessionTextBox_Click);
            this.sessionTextBox.Leave += new System.EventHandler(this.sessionTextBox_Leave);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 301);
            this.Controls.Add(this.sessionTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.sessionLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCards);
            this.Controls.Add(this.generateTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.testCardsList);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestingForm_FormClosing);
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
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox sessionTextBox;
    }
}
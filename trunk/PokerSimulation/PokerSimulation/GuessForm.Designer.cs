namespace PokerSimulation
{
    partial class GuessForm
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
            this.components = new System.ComponentModel.Container();
            this.cardsListBox = new System.Windows.Forms.ListBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.guessLabel = new System.Windows.Forms.Label();
            this.guessTextBox = new System.Windows.Forms.TextBox();
            this.finishButton = new System.Windows.Forms.Button();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.sessionTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.timerTextBox = new System.Windows.Forms.TextBox();
            this.guessTimer = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.feedbackTextBox = new System.Windows.Forms.TextBox();
            this.reactionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cardsListBox
            // 
            this.cardsListBox.FormattingEnabled = true;
            this.cardsListBox.Location = new System.Drawing.Point(152, 12);
            this.cardsListBox.Name = "cardsListBox";
            this.cardsListBox.Size = new System.Drawing.Size(120, 134);
            this.cardsListBox.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(104, 152);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Next Hand";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // guessLabel
            // 
            this.guessLabel.AutoSize = true;
            this.guessLabel.Location = new System.Drawing.Point(58, 213);
            this.guessLabel.Name = "guessLabel";
            this.guessLabel.Size = new System.Drawing.Size(40, 13);
            this.guessLabel.TabIndex = 2;
            this.guessLabel.Text = "Guess:";
            // 
            // guessTextBox
            // 
            this.guessTextBox.Location = new System.Drawing.Point(104, 210);
            this.guessTextBox.Name = "guessTextBox";
            this.guessTextBox.ReadOnly = true;
            this.guessTextBox.Size = new System.Drawing.Size(100, 20);
            this.guessTextBox.TabIndex = 3;
            this.guessTextBox.Text = "Enter Text";
            this.guessTextBox.Click += new System.EventHandler(this.guessTextBox_Click);
            this.guessTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.guessTextBox_KeyDown);
            this.guessTextBox.Leave += new System.EventHandler(this.guessTextBox_Leave);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(104, 181);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 4;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(12, 31);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 5;
            this.idTextBox.Text = "ID#";
            this.idTextBox.Click += new System.EventHandler(this.idTextBox_Click);
            this.idTextBox.Leave += new System.EventHandler(this.idTextBox_Leave);
            // 
            // sessionTextBox
            // 
            this.sessionTextBox.Location = new System.Drawing.Point(12, 80);
            this.sessionTextBox.Name = "sessionTextBox";
            this.sessionTextBox.Size = new System.Drawing.Size(100, 20);
            this.sessionTextBox.TabIndex = 6;
            this.sessionTextBox.Text = "Session#";
            this.sessionTextBox.Click += new System.EventHandler(this.sessionTextBox_Click);
            this.sessionTextBox.Leave += new System.EventHandler(this.sessionTextBox_Leave);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(12, 12);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(21, 13);
            this.idLabel.TabIndex = 7;
            this.idLabel.Text = "ID:";
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Location = new System.Drawing.Point(12, 64);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(47, 13);
            this.sessionLabel.TabIndex = 8;
            this.sessionLabel.Text = "Session:";
            // 
            // timerTextBox
            // 
            this.timerTextBox.Location = new System.Drawing.Point(165, 232);
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.ReadOnly = true;
            this.timerTextBox.Size = new System.Drawing.Size(107, 20);
            this.timerTextBox.TabIndex = 9;
            // 
            // guessTimer
            // 
            this.guessTimer.Interval = 1000;
            this.guessTimer.Tick += new System.EventHandler(this.guessTimer_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(9, 235);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(33, 13);
            this.timerLabel.TabIndex = 10;
            this.timerLabel.Text = "Time:";
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(9, 259);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(58, 13);
            this.feedbackLabel.TabIndex = 11;
            this.feedbackLabel.Text = "Feedback:";
            // 
            // feedbackTextBox
            // 
            this.feedbackTextBox.Location = new System.Drawing.Point(73, 256);
            this.feedbackTextBox.Name = "feedbackTextBox";
            this.feedbackTextBox.ReadOnly = true;
            this.feedbackTextBox.Size = new System.Drawing.Size(199, 20);
            this.feedbackTextBox.TabIndex = 12;
            // 
            // reactionTextBox
            // 
            this.reactionTextBox.Location = new System.Drawing.Point(73, 232);
            this.reactionTextBox.Name = "reactionTextBox";
            this.reactionTextBox.ReadOnly = true;
            this.reactionTextBox.Size = new System.Drawing.Size(86, 20);
            this.reactionTextBox.TabIndex = 13;
            // 
            // GuessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 284);
            this.Controls.Add(this.reactionTextBox);
            this.Controls.Add(this.feedbackTextBox);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.timerTextBox);
            this.Controls.Add(this.sessionLabel);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.sessionTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.guessTextBox);
            this.Controls.Add(this.guessLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.cardsListBox);
            this.Name = "GuessForm";
            this.Text = "GuessForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuessForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cardsListBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label guessLabel;
        private System.Windows.Forms.TextBox guessTextBox;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox sessionTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.TextBox timerTextBox;
        private System.Windows.Forms.Timer guessTimer;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label feedbackLabel;
        private System.Windows.Forms.TextBox feedbackTextBox;
        private System.Windows.Forms.TextBox reactionTextBox;
    }
}
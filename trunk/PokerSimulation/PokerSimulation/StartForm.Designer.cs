namespace PokerSimulation
{
    partial class StartForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsSplit = new System.Windows.Forms.SplitContainer();
            this.beginButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.entryTimerSplit = new System.Windows.Forms.SplitContainer();
            this.answerEntryText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.responseDisplayText = new System.Windows.Forms.TextBox();
            this.reactionDisplayText = new System.Windows.Forms.TextBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.pokerSimulationLabel = new System.Windows.Forms.Label();
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.handText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.buttonsSplit.Panel1.SuspendLayout();
            this.buttonsSplit.Panel2.SuspendLayout();
            this.buttonsSplit.SuspendLayout();
            this.entryTimerSplit.Panel1.SuspendLayout();
            this.entryTimerSplit.Panel2.SuspendLayout();
            this.entryTimerSplit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.BoardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.39971F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.60029F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.Controls.Add(this.buttonsSplit, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.entryTimerSplit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pokerSimulationLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BoardPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.93182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.06818F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 625);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonsSplit
            // 
            this.buttonsSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsSplit.Location = new System.Drawing.Point(4, 532);
            this.buttonsSplit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonsSplit.Name = "buttonsSplit";
            // 
            // buttonsSplit.Panel1
            // 
            this.buttonsSplit.Panel1.Controls.Add(this.beginButton);
            // 
            // buttonsSplit.Panel2
            // 
            this.buttonsSplit.Panel2.Controls.Add(this.optionsButton);
            this.buttonsSplit.Size = new System.Drawing.Size(1012, 40);
            this.buttonsSplit.SplitterDistance = 506;
            this.buttonsSplit.SplitterWidth = 5;
            this.buttonsSplit.TabIndex = 2;
            // 
            // beginButton
            // 
            this.beginButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.beginButton.Location = new System.Drawing.Point(0, 0);
            this.beginButton.Margin = new System.Windows.Forms.Padding(4);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(506, 40);
            this.beginButton.TabIndex = 1;
            this.beginButton.Text = "Click Here to Begin Simulation";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsButton.Location = new System.Drawing.Point(0, 0);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(4);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(501, 40);
            this.optionsButton.TabIndex = 0;
            this.optionsButton.Text = "Click Here for Testing Form";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // entryTimerSplit
            // 
            this.entryTimerSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryTimerSplit.Location = new System.Drawing.Point(4, 580);
            this.entryTimerSplit.Margin = new System.Windows.Forms.Padding(4);
            this.entryTimerSplit.Name = "entryTimerSplit";
            // 
            // entryTimerSplit.Panel1
            // 
            this.entryTimerSplit.Panel1.Controls.Add(this.answerEntryText);
            // 
            // entryTimerSplit.Panel2
            // 
            this.entryTimerSplit.Panel2.Controls.Add(this.panel1);
            this.entryTimerSplit.Size = new System.Drawing.Size(1012, 41);
            this.entryTimerSplit.SplitterDistance = 336;
            this.entryTimerSplit.SplitterWidth = 5;
            this.entryTimerSplit.TabIndex = 3;
            // 
            // answerEntryText
            // 
            this.answerEntryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerEntryText.Location = new System.Drawing.Point(0, 0);
            this.answerEntryText.Margin = new System.Windows.Forms.Padding(4);
            this.answerEntryText.Name = "answerEntryText";
            this.answerEntryText.Size = new System.Drawing.Size(336, 22);
            this.answerEntryText.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.handText);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.responseDisplayText);
            this.panel1.Controls.Add(this.reactionDisplayText);
            this.panel1.Controls.Add(this.timerLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 41);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // responseDisplayText
            // 
            this.responseDisplayText.Location = new System.Drawing.Point(310, 13);
            this.responseDisplayText.Margin = new System.Windows.Forms.Padding(4);
            this.responseDisplayText.Name = "responseDisplayText";
            this.responseDisplayText.Size = new System.Drawing.Size(132, 22);
            this.responseDisplayText.TabIndex = 2;
            // 
            // reactionDisplayText
            // 
            this.reactionDisplayText.Location = new System.Drawing.Point(170, 13);
            this.reactionDisplayText.Margin = new System.Windows.Forms.Padding(4);
            this.reactionDisplayText.Name = "reactionDisplayText";
            this.reactionDisplayText.Size = new System.Drawing.Size(132, 22);
            this.reactionDisplayText.TabIndex = 1;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(121, 16);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(44, 17);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "Timer";
            // 
            // pokerSimulationLabel
            // 
            this.pokerSimulationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pokerSimulationLabel.AutoSize = true;
            this.pokerSimulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pokerSimulationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pokerSimulationLabel.Location = new System.Drawing.Point(386, 15);
            this.pokerSimulationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pokerSimulationLabel.Name = "pokerSimulationLabel";
            this.pokerSimulationLabel.Size = new System.Drawing.Size(247, 32);
            this.pokerSimulationLabel.TabIndex = 0;
            this.pokerSimulationLabel.Text = "Poker Simulation";
            this.pokerSimulationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BoardPanel
            // 
            this.BoardPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoardPanel.Controls.Add(this.pictureBox5);
            this.BoardPanel.Controls.Add(this.pictureBox4);
            this.BoardPanel.Controls.Add(this.pictureBox3);
            this.BoardPanel.Controls.Add(this.pictureBox2);
            this.BoardPanel.Controls.Add(this.pictureBox1);
            this.BoardPanel.Location = new System.Drawing.Point(330, 247);
            this.BoardPanel.Margin = new System.Windows.Forms.Padding(4);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(360, 96);
            this.BoardPanel.TabIndex = 4;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = global::PokerSimulation.Properties.Resources.b1fv;
            this.pictureBox5.InitialImage = global::PokerSimulation.Properties.Resources.b1fv;
            this.pictureBox5.Location = new System.Drawing.Point(288, 0);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(72, 96);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox4.Image = global::PokerSimulation.Properties.Resources.b2fv;
            this.pictureBox4.InitialImage = global::PokerSimulation.Properties.Resources.b2fv;
            this.pictureBox4.Location = new System.Drawing.Point(216, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(72, 96);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = global::PokerSimulation.Properties.Resources.b1fv;
            this.pictureBox3.InitialImage = global::PokerSimulation.Properties.Resources.b1fv;
            this.pictureBox3.Location = new System.Drawing.Point(144, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 96);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::PokerSimulation.Properties.Resources.b2fv;
            this.pictureBox2.InitialImage = global::PokerSimulation.Properties.Resources.b2fv;
            this.pictureBox2.Location = new System.Drawing.Point(72, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 96);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::PokerSimulation.Properties.Resources.b1fv;
            this.pictureBox1.InitialImage = global::PokerSimulation.Properties.Resources.b1fv;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 96);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // handText
            // 
            this.handText.Location = new System.Drawing.Point(487, 10);
            this.handText.Name = "handText";
            this.handText.Size = new System.Drawing.Size(100, 22);
            this.handText.TabIndex = 3;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PokerSimulation.Properties.Resources.ft_green_poker_skin2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1020, 625);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartForm";
            this.Text = "Poker Simulation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.buttonsSplit.Panel1.ResumeLayout(false);
            this.buttonsSplit.Panel2.ResumeLayout(false);
            this.buttonsSplit.ResumeLayout(false);
            this.entryTimerSplit.Panel1.ResumeLayout(false);
            this.entryTimerSplit.Panel1.PerformLayout();
            this.entryTimerSplit.Panel2.ResumeLayout(false);
            this.entryTimerSplit.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.BoardPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label pokerSimulationLabel;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.SplitContainer buttonsSplit;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.SplitContainer entryTimerSplit;
        private System.Windows.Forms.TextBox answerEntryText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox reactionDisplayText;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.TextBox responseDisplayText;
        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox handText;


    }
}


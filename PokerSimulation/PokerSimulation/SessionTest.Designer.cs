namespace PokerSimulation
{
    partial class SessionTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sessionID = new System.Windows.Forms.TextBox();
            this.subjectID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nuts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject ID:";
            // 
            // sessionID
            // 
            this.sessionID.Location = new System.Drawing.Point(228, 28);
            this.sessionID.Name = "sessionID";
            this.sessionID.Size = new System.Drawing.Size(100, 22);
            this.sessionID.TabIndex = 2;
            // 
            // subjectID
            // 
            this.subjectID.Location = new System.Drawing.Point(228, 63);
            this.subjectID.Name = "subjectID";
            this.subjectID.Size = new System.Drawing.Size(100, 22);
            this.subjectID.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Load Session";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nuts
            // 
            this.nuts.FormattingEnabled = true;
            this.nuts.HorizontalScrollbar = true;
            this.nuts.ItemHeight = 16;
            this.nuts.Location = new System.Drawing.Point(12, 155);
            this.nuts.Name = "nuts";
            this.nuts.Size = new System.Drawing.Size(316, 132);
            this.nuts.TabIndex = 6;
            // 
            // SessionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 299);
            this.Controls.Add(this.nuts);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subjectID);
            this.Controls.Add(this.sessionID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SessionTest";
            this.Text = "Session Loader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sessionID;
        private System.Windows.Forms.TextBox subjectID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox nuts;

    }
}
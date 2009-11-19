using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PokerSimulation
{
    public partial class SessionTest : Form
    {
        public SessionTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nuts.Items.Clear();
            Session s = new Session(subjectID.Text, sessionID.Text);

            foreach (Block b in s.Blocks)
            {
                foreach (Trial t in b.Trials)
                {
                    string item = "Nuts: " + t.Nuts;
                    foreach (Card c in t.Hand.ToArray())
                        item += " " + c.ToString();
                    nuts.Items.Add(item);
                }
            }
        }
    }
}

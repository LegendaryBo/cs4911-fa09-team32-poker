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
    public partial class TestingForm : Form
    {
        Hand testHand = new Hand();
        HandGenerator testGenerator = new HandGenerator();
        public TestingForm()
        {
            InitializeComponent();
            Deck.Instance.MakeShuffledDeck();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            testCardsBox.Items.Clear();
            testHand = PokerSimulation.HandGenerator.genTK();
            testCardsBox.Items.AddRange(testHand.ToArray());
            //testCardsBox.Update();
        }
    }
}

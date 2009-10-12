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
        string generatedText = "";
        public TestingForm()
        {
            InitializeComponent();
            Deck.Instance.MakeShuffledDeck();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            testCardsList.Items.Clear();
            testHand = generateHand();

            if (testHand.Count != 0)
            {
                //testHand = PokerSimulation.HandGenerator.genST();
                testCardsList.Items.AddRange(testHand.ToArray());
            }
            //testCardsBox.Update();
        }

        private Hand generateHand()
        {
            generatedText = generateTextBox.Text;
            testHand = new Hand();
            if((generatedText.Length == 0) || generatedText.Equals("Enter Hand"))
            {
                MessageBox.Show("You must enter a valid two-letter hand");
            }
            else if (generatedText.Equals("HC"))
                testHand = PokerSimulation.HandGenerator.genHC();
            else if (generatedText.Equals("OP"))
                testHand = PokerSimulation.HandGenerator.genOP();
            else if (generatedText.Equals("TP"))
                testHand = PokerSimulation.HandGenerator.genTP();
            else if (generatedText.Equals("TK"))
                testHand = PokerSimulation.HandGenerator.genTK();
            else if (generatedText.Equals("ST"))
                testHand = PokerSimulation.HandGenerator.genST();
            else if (generatedText.Equals("FL"))
                testHand = PokerSimulation.HandGenerator.genFL();
            else if (generatedText.Equals("FH"))
                testHand = PokerSimulation.HandGenerator.genFH();
            else if (generatedText.Equals("SF"))
                testHand = PokerSimulation.HandGenerator.genSF();
            else if (generatedText.Equals("FK"))
                testHand = PokerSimulation.HandGenerator.genFK();
            else if (generatedText.Equals("RF"))
                testHand = PokerSimulation.HandGenerator.genRF();
            else
                MessageBox.Show("You must enter a valid two-letter hand");


            return testHand;
            //if(generateTextBox.
        }

        private void generateTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            generateTextBox.Clear();
        }

        private void generateTextBox_Enter(object sender, EventArgs e)
        {
            generateHand();
        }
    }
}

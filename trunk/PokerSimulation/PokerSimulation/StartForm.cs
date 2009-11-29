using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Timers;

namespace PokerSimulation
{
    public partial class StartForm : Form 
    {
        public StartForm()
        {
            InitializeComponent();
            game = new Game();
        }

        #region Variables
        private List<Card> fullDeck;
        private List<Card> boardCards;
        private string debugText;
        private Game game;
        private System.Timers.Timer timer;
        #endregion

        #region Events

        private void beginButton_Click(object sender, EventArgs e)
        {
            GuessForm form = new GuessForm();
            form.Show();

            //drawOnBoard();
            //timer = new System.Timers.Timer();
            //timer.Start();
            //timer.Stop();
            //reactionDisplayText.Text = timer.;
            //game.UserSession.
        }
        #endregion
        
        #region Methods
        public void drawOnBoard()
        {
            generateHand();
            //pictureBox1.Image = (Image)boardCards[0].Image;
            //pictureBox2.Image = (Image)boardCards[1].Image;
            //pictureBox3.Image = (Image)boardCards[2].Image;
            //pictureBox4.Image = (Image)boardCards[3].Image;
            //pictureBox5.Image = (Image)boardCards[4].Image;
            
            //debugText = boardCards.ToString();
            //answerEntryText.Text = debugText;
            
                
        }
        #endregion

        private void optionsButton_Click(object sender, EventArgs e)
        {
            TestingForm form = new TestingForm();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawOnBoard();
        }

        private void generateHand()
        {
            String generatedText = handText.Text;
            int numOfCards = 5;

            Hand testHand = new Hand();
            if ((generatedText.Length == 0) || generatedText.Equals("Enter Hand"))
            {
                MessageBox.Show("You must enter a valid two-letter straightFlush");
            }
            else if (generatedText.ToUpper().Equals("HC"))
                testHand = PokerSimulation.PokerHand.MakeHighCard(numOfCards);
            else if (generatedText.ToUpper().Equals("OP"))
                testHand = PokerSimulation.PokerHand.MakeOnePair(numOfCards);
            else if (generatedText.ToUpper().Equals("TP"))
                testHand = PokerSimulation.PokerHand.MakeTwoPair(numOfCards);
            else if (generatedText.ToUpper().Equals("TK"))
                testHand = PokerSimulation.PokerHand.MakeThreeOfAKind(numOfCards);
            else if (generatedText.ToUpper().Equals("ST"))
                testHand = PokerSimulation.PokerHand.MakeStraight(numOfCards);
            else if (generatedText.ToUpper().Equals("FL"))
                testHand = PokerSimulation.PokerHand.MakeFlush(numOfCards);
            else if (generatedText.ToUpper().Equals("FH"))
                testHand = PokerSimulation.PokerHand.MakeFullHouse(numOfCards);
            else if (generatedText.ToUpper().Equals("SF"))
                testHand = PokerSimulation.PokerHand.MakeStraightFlush(numOfCards);
            else if (generatedText.ToUpper().Equals("FK"))
                testHand = PokerSimulation.PokerHand.MakeFourOfAKind(numOfCards);
            else if (generatedText.ToUpper().Equals("RF"))
                testHand = PokerSimulation.PokerHand.MakeRoyalFlush(numOfCards);
            else
                MessageBox.Show("You must enter a valid two-letter straightFlush");

            boardCards = testHand.Cards;
        }
    }
}

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
            setupCards();
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
        public void setupCards()
        {
            boardCards = new List<Card>(3);
            //boardCards.Add(new Card());
            //boardCards.Add(new Card("Ace_Club"));
            //boardCards.Add(new Card("Five_Spade"));

            
        }
        public void drawOnBoard()
        {
            
            //pictureBox1.Image = (Image)boardCards[0].Image;
            //pictureBox2.Image = (Image)boardCards[1].Image;
            //pictureBox3.Image = (Image)boardCards[2].Image;
            debugText = boardCards.ToString();
            answerEntryText.Text = debugText;
            
                
        }
        #endregion

        private void optionsButton_Click(object sender, EventArgs e)
        {
            TestingForm form = new TestingForm();
            form.Show();
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace PokerSimulation
{
    public partial class StartForm : Form 
    {
        public StartForm()
        {
            InitializeComponent();
            setupCards();
        }

        #region Variables
        private List<Card> fullDeck;
        private List<Card> boardCards;
        private string debugText;
        #endregion

        #region Events
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
        
        #region Methods
        public void setupCards()
        {
            boardCards = new List<Card>(3);
            boardCards.Add(new Card());
            boardCards.Add(new Card("Ace_Club"));
            boardCards.Add(new Card("Five_Spade"));
            
        }
        public void drawOnBoard()
        {
            
            pictureBox1.Image = (Image)boardCards[0].Image;
            pictureBox2.Image = (Image)boardCards[1].Image;
            pictureBox3.Image = (Image)boardCards[2].Image;
            debugText = boardCards.ToString();
            answerEntryText.Text = debugText;
            
                
        }
        #endregion

        private void beginButton_Click(object sender, EventArgs e)
        {
            drawOnBoard();
        }

    }
}

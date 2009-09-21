using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;

namespace PokerSimulation
{
    public class Card
    {
        #region Constructors
        public Card()
        {
            _name = "Joker";
            //Image = Image.FromFile("C:/Users/EJ/Documents/Visual Studio 2008/Projects/PokerSimulation/PokerSimulation/Resources/Joker.png");
            Image = Properties.Resources.Joker;
        }

        public Card(string cardName)
        {
            string[] temp = cardName.Split('_');
            _name = cardName;
            Image = Image.FromFile("C:/Users/EJ/Documents/Visual Studio 2008/Projects/PokerSimulation/PokerSimulation/Resources/" + cardName + ".png");
        }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public Card(Suit suit, Rank rank, string cardName)
        {

        }
        #endregion

        #region Variables

        private string _name;
        private Image _image;

        #endregion
        #region Properties

        public Suit Suit 
        {
            get; 
            internal set; 
        }
        public Rank Rank 
        { 
            get; 
            internal set; 
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        #endregion
        #region Methods
        public string toString()
        {
            return Name;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;

namespace PokerSimulation
{
    class Card
    {
        #region Constructors
        public Card()
        {
            value = 0;
            name = "Joker";
            Image = Image.FromFile("C:/Users/EJ/Documents/Visual Studio 2008/Projects/PokerSimulation/PokerSimulation/Resources/Joker.png");
            
        }

        public Card(string cardName)
        {
            string[] temp = cardName.Split('_');
            name = cardName;
            value = 0;
            Image = Image.FromFile("C:/Users/EJ/Documents/Visual Studio 2008/Projects/PokerSimulation/PokerSimulation/Resources/" + cardName + ".png");
        }
        #endregion

        #region Variables

        private int value;
        private string name;
        private Image image;

        #endregion
        #region Properties

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
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

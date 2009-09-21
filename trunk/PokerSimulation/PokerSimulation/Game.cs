using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    class Game
    {
        #region Fields
        private Deck _deck;
        private Hand _hand;
        private Board _board;
        private UserSession _userSession;

        #endregion

        #region Constructors

        public Game()
        {
            _deck = Deck.Instance;
            //_hand = new Hand();
            _board = new Board();
            _userSession = new UserSession();
        }

        #endregion

        #region Methods
        #endregion

        #region Properties
        public UserSession UserSession
        {
            get { return _userSession; }
            set { _userSession = value; }
        }
        #endregion

    }
}

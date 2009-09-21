using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PokerSimulation
{
    class Hand
    {
        List<Card> _hand;

        public Hand() : this(null) { }

        public Hand(params Card[] cards)
        {
            _hand = new List<Card>();

            foreach (Card c in cards)
            {
                _hand.Add(c);
            }
        }

        public bool Contains(Card card)
        {
            return _hand.Contains(card);
        }

        public bool Contains(Suit suit, Rank rank)
        {
            return Contains(new Card(suit, rank));
        }

        public bool Contains(Rank rank)
        {
            for (int i = 0; i < Deck.NUMBER_OF_SUITS; i++)
            {
                if (this.Contains((Suit)i, rank))
                {
                    return true;
                }
            }

            return false;
        }

        public int CountOf(Suit suit)
        {
            int count = 0;

            foreach (Card c in _hand)
            {
                if (c.Suit == suit)
                {
                    count++;
                }
            }

            return count;
        }

        public int CountOf(Rank rank)
        {
            int count = 0;

            foreach (Card c in _hand)
            {
                if (c.Rank == rank)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OrderAscending()
        {
            _hand = _hand.OrderBy<Card, int>((card) => (int)card.Rank).ToList<Card>();
        }

        public void OrderDescending()
        {
            _hand = _hand.OrderByDescending<Card, int>((card) => (int)card.Rank).ToList<Card>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// True if the hand contains only cards of sequential value, otherwise false.
        /// </returns>
        /// <remarks>
        /// Note that a hand consisting of only one card is NOT a straight.  In order
        /// for HasStraight() to return true, there must be at least two cards in hand,
        /// and they must be of consecutive rank.
        /// </remarks>
        public bool HasStraight()
        {
            this.OrderAscending();

            for (int i = 0; i < (_hand.Count - 1); i++)
            {
            }

            return false;
        }

        public bool HasStraight(int minimumNumberOfCards)
        {
            return false;
        }

        public bool HasFlush()
        {
            for (int i = 0; i < Deck.NUMBER_OF_SUITS; i++)
            {
                if (_hand.Count == this.CountOf((Suit)i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class Hand
    {
        private List<Card> _hand;
        private static Random _random = new Random();

        public List<Card> Cards
        {
            get { return _hand; }
            internal set { _hand = value; }
        }

        public bool IsEmpty
        {
            get
            {
                return (_hand.Count == 0);
            }
        }

        public int Count
        {
            get
            {
                return _hand.Count;
            }
        }

        public Hand() : this(null) { }

        public Hand(params Card[] cards)
        {
            _hand = new List<Card>();

            if (cards != null)
            {
                foreach (Card c in cards)
                {
                    _hand.Add(c);
                }
            }

            _hand.DefaultIfEmpty(null);
        }

        public override string ToString()
        {
            StringBuilder handString = new StringBuilder();

            for (int i = 0; i < _hand.Count; ++i)
            {
                if (i != 0)
                {
                    handString.Append(", ");
                }
                handString.Append(_hand.ElementAt(i));
            }

            return handString.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType() && (this == (Hand)obj);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() |
                    _hand.GetHashCode());
        }

        public static bool operator ==(Hand x, Hand y)
        {
            if ((Object)x == null && (Object)y == null)
            {
                return true;
            }
            else if ((Object)x == null || (Object)y == null)
            {
                return false;
            }

            if (x._hand.Count == y._hand.Count)
            {
                Hand yCopy = (Hand)y.MemberwiseClone();

                foreach (Card c in x._hand)
                {
                    if (!yCopy.RemoveCard(c))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(Hand x, Hand y)
        {
            return !(x == y);
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

        public void InsertCard(Card card)
        {
            _hand.Add(card);
        }

        public void InsertCards(params Card[] cards)
        {
            if (cards != null)
            {
                foreach (Card c in cards)
                {
                    this.InsertCard(c);
                }
            }
        }

        public void Shuffle()
        {
            List<Card> tempCards = new List<Card>();

            while (_hand.Count > 0)
            {
                // select a card from the cards left in the straightFlush
                int randomIndex = _random.Next(_hand.Count);
                // add the selected card to the temp straightFlush
                tempCards.Add(_hand[randomIndex]);
                // remove the selected card from the current straightFlush
                _hand.RemoveAt(randomIndex);
            }

            // set the current straightFlush to the shuffled straightFlush
            _hand = tempCards;
        }

        public void RemoveAllCards()
        {
            _hand.RemoveRange(0, _hand.Count);
        }

        public bool RemoveCard(Card card)
        {
            return _hand.Remove(card);
        }

        public bool RemoveCards(params Card[] cards)
        {
            bool removeSucceeded = true;

            if (cards != null)
            {
                foreach (Card c in cards)
                {
                    if (!this.RemoveCard(c))
                    {
                        removeSucceeded = false;
                    }
                }
            }

            return removeSucceeded;
        }

        public void Combine(Hand hand)
        {
            this.InsertCards(hand.ToArray());
        }

        public int CountOf(Card card)
        {
            int count = 0;

            foreach (Card c in _hand)
            {
                if (c.Suit == card.Suit && c.Rank == card.Rank)
                {
                    ++count;
                }
            }

            return count;
        }

        /// <summary>
        /// Determines the number of cards of a given suit within the straightFlush.
        /// </summary>
        /// <param name="beginRank">
        /// The suit of the cards the method should count.
        /// </param>
        /// <returns>
        /// The number of cards of the given suit within the straightFlush.  If no cards of the given
        /// suit are held in the straightFlush, then the method returns 0.
        /// </returns>
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

        /// <summary>
        /// Determines the number of cards of a given beginRank within the straightFlush.
        /// </summary>
        /// <param name="beginRank">
        /// The beginRank of the cards the method should count.
        /// </param>
        /// <returns>
        /// The number of cards of the given beginRank within the straightFlush.  If no cards of the given
        /// beginRank are held in the straightFlush, then the method returns 0.
        /// </returns>
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
        /// Orders the straightFlush in ascending beginRank.
        /// </summary>
        public void OrderAscending()
        {
            _hand = _hand.OrderBy<Card, int>((card) => (int)card.Rank).ToList<Card>();
        }

        /// <summary>
        /// Orders the straightFlush in descending beginRank.
        /// </summary>
        public void OrderDescending()
        {
            _hand = _hand.OrderByDescending<Card, int>((card) => (int)card.Rank).ToList<Card>();
        }

        public Card PeekHighCard()
        {
            Hand ordered = new Hand(_hand.ToArray());
            ordered.OrderAscending();

            if (ordered.Count > 0)
            {
                return ordered.ToArray()[ordered.Count - 1];
            }
            else
            {
                return null;
            }
        }

        public List<Card> ToList()
        {
            return _hand.ToList<Card>();
        }

        public Card[] ToArray()
        {
            return _hand.ToArray();
        }

        public Hand GetSuitCards(Suit suit)
        {
            Hand hand = new Hand();

            foreach (Card c in _hand)
            {
                if (c.Suit == suit)
                {
                    hand.InsertCard(c);
                }
            }

            return hand;
        }

        public Hand GetClubs()
        {
            return GetSuitCards(Suit.CLUBS);
        }

        public Hand GetDiamonds()
        {
            return GetSuitCards(Suit.DIAMONDS);
        }

        public Hand GetHearts()
        {
            return GetSuitCards(Suit.HEARTS);
        }

        public Hand GetSpades()
        {
            return GetSuitCards(Suit.SPADES);
        }

        public Hand GetCardsOfRank(Rank rank)
        {
            Hand hand = new Hand();

            foreach (Card c in _hand)
            {
                if (c.Rank == rank)
                {
                    hand.InsertCard(c);
                }
            }

            return hand;
        }
    }
}

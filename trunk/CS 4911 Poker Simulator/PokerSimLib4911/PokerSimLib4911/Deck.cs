﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PokerSimLib4911
{
    public class Deck
    {
        private static Deck _instance;
        private List<Card> _cards = new List<Card>();

        public static readonly int NUMBER_OF_RANKS = 4;
        public static readonly int NUMBER_OF_SUITS = 13;

        public static Deck Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Deck();
                }
                return _instance;
            }

            private set
            {
                _instance = value;
            }
        }

        private Deck() : this(Deck.NUMBER_OF_RANKS, Deck.NUMBER_OF_SUITS) { }

        private Deck(int numberOfRanks, int numberOfSuits)
        {
            // construct the deck
            // outer loop is for suit
            for (int i = 0; i < numberOfSuits; i++)
            {
                // inner loop is for rank
                for (int j = 0; j < numberOfRanks; j++)
                {
                    Card c = new Card((Suit)i, (Rank)j);
                    _cards.Add(c);
                }
            }
        }

        public void MakeFreshDeck()
        {
            _instance = null;
        }

        public void MakeShuffledDeck()
        {
            _instance = null;
            Deck.Instance.Shuffle();
        }

        public void Shuffle()
        {
            List<Card> tempCards = new List<Card>();
            Random rand = new Random();

            while (_cards.Count > 0)
            {
                // select a card from the cards left in the deck
                int randomIndex = rand.Next(_cards.Count);
                // add the selected card to the temp deck
                tempCards.Add(_cards[randomIndex]);
                // remove the selected card from the current deck
                _cards.RemoveAt(randomIndex);
            }

            // set the current deck to the shuffled deck
            _cards = tempCards;
        }

        public Card RemoveCard(Card card)
        {
            if (_cards.Remove(card))
            {
                return card;
            }
            else
            {
                return null;
            }
        }

        public void ReplaceCards(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                if (!_cards.Contains(c))
                {
                    _cards.Add(c);
                }
            }
        }

        public Card DealCard()
        {
            Card returnCard = null;

            if (_cards.Count > 0)
            {
                returnCard = _cards[0];
                _cards.RemoveAt(0);
            }
            else
            {
                throw new InvalidOperationException("You cannot deal a card from an empty deck.");
            }

            return returnCard;
        }
    }

    public class Card
    {
        public Suit Suit { get; internal set; }
        public Rank Rank { get; internal set; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }

    public class Hand
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

    /// <summary>
    /// The Suit enumeration contains all of the valid suit values for a Deck.
    /// </summary>
    public enum Suit
    {
        CLUB,
        DIAMOND,
        HEART,
        SPADE
    }

    /// <summary>
    /// The Rank enumeration contains all of the valid card values for a Deck, in ascending order.
    /// </summary>
    /// <remarks>
    /// Note that the lowest rank in this deck is 2 and the highest is an ace.
    /// </remarks>
    public enum Rank
    {
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE
    }

    public class HandGenerator
    {
        //Royal Flush
        static public Hand genRF()
        {
            return null;
        }

        //Straight Flush//JSS
        static public Hand genSF()
        {
            
            //pick a suit
            //pick a 7, 8, or 9 - must always include at least one of these
            //remove that card
            //choose ascending or descending order
            //fill the rest of the cards in the SF
            //random two cards
            return null;
        }

        //Four of a Kind//JSS
        static public Hand genFK()
        {
            //pick the rank of the FK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);
            //Card card1 = Deck.RemoveCard(new Card((Suit)0, (Rank)rank);  //NEED INSTANCE OF DECK
            //Card card2 = Deck.RemoveCard(new Card((Suit)1, (RANK)rank);  //NEED INSTANCE OF DECK
            //Card card3 = Deck.RemoveCard(new Card((Suit)2, (RANK)rank);  //NEED INSTANCE OF DECK
            //Card card4 = Deck.RemoveCard(new Card((Suit)3, (RANK)rank);  //NEED INSTANCE OF DECK

            //random 3 cards
            int suit = 0;

            rank = rand.Next(0, 12);
            suit = rand.Next(0, 3);
            //Card card5 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            suit = rand.Next(0, 3);
            //Card card6 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            suit = rand.Next(0, 3);
            //Card card7 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK

            //Card[] cards = { card1, card2, card3, card4, card5, card6, card7 }; //NEED CARDS
            //return new Hand(cards); //NEED cards
            return null; //remove later
        }

        //Full House
        static public Hand genFH()
        {
            return null;
        }

        //Flush//JSS
        static public Hand genFL()
        {
            //pick the suit of the FL
            int suit = 0;
            int rank = 0;
            Random rand = new Random();
            suit = rand.Next(0, 3);

            //choose five cards of that suit
            rank = rand.Next(0, 12);
            //Card card1 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            //Card card2 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            //Card card3 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            //Card card4 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            //Card card5 = Deck.RemoveCard(new Card((Suit)suit, (RANK)rank);  //NEED INSTANCE OF DECK


            //random 2 cards NOT OF THAT SUIT
            int suit2 = 0;
            do
            {
                suit2 = rand.Next(0, 2);
            }while(suit2 == suit);

            rank = rand.Next(0, 12);
            //Card card6 = Deck.RemoveCard(new Card((Suit)suit2, (RANK)rank);  //NEED INSTANCE OF DECK
            rank = rand.Next(0, 12);
            //Card card7 = Deck.RemoveCard(new Card((Suit)suit2, (RANK)rank);  //NEED INSTANCE OF DECK


            //Card[] cards = { card1, card2, card3, card4, card5, card6, card7 }; //NEED CARDS
            //return new Hand(cards); //NEED cards
            return null; //remove later
        }

        //Straight
        static public Hand genST()
        {
            return null;
        }

        //Three of a Kind//JSS
        static public Hand genTK()
        {
            //pick the rank of the TK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            //pick three of the four cards of that rank
            int suit = 0;
            suit = rand.Next(0, 3);
            for (int i = 0; i < 4; i++)
                //////stopped here///////////////////////////

            //random 4 cards NOT OF THAT RANK

            return null;
        }

        //Two Pair
        static public Hand genTP()
        {
            return null;
        }

        //One Pair//JSS
        static public Hand genOP()
        {
            //pick the rank of the OP
            //pick two of the four cards of that rank
            //random 5 cards NOT OF THAT RANK
            return null;
        }

        //High Card
        static public Hand genHC()
        {
            return null;
        }
    }
}
using System;
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
        private List<Card> _dealtCards = new List<Card>();

        public static readonly int NUMBER_OF_RANKS = 13;
        public static readonly int NUMBER_OF_SUITS = 4;

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

        private Deck() : this(Deck.NUMBER_OF_SUITS, Deck.NUMBER_OF_RANKS) { }

        private Deck(int numberOfSuits, int numberOfRanks)
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

        public bool RemoveCard(Card card)
        {
            if (_cards.Remove(card))
            {
                _dealtCards.Add(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertCards(params Card[] cards)
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
                _dealtCards.Add(returnCard);
            }
            else
            {
                throw new InvalidOperationException("You cannot deal a card from an empty deck.");
            }

            return returnCard;
        }

        public Card[] ToArray()
        {
            return _cards.ToArray();
        }

        public override string ToString()
        {
            StringBuilder deckString = new StringBuilder();

            deckString.Append("Deck Cards: ");
            for (int i = 0; i < _cards.Count; ++i)
            {
                if (i != 0)
                {
                    deckString.Append(", ");
                }
                deckString.Append(_cards.ElementAt(i));
            }

            deckString.Append("Dealt Cards: ");
            for (int i = 0; i < _dealtCards.Count; ++i)
            {
                if (i != 0)
                {
                    deckString.Append(", ");
                }
                deckString.Append(_dealtCards.ElementAt(i));
            }

            return deckString.ToString();
        }

        public bool Contains(Card card)
        {
            return _cards.Contains(card);
        }

        public bool HasBeenDealt(Card card)
        {
            return _dealtCards.Contains(card);
        }
    }

    /// <summary>
    /// A card has a certain suit and rank, or is a wild card.
    /// </summary>
    public class Card
    {
        public Suit Suit { get; internal set; }
        public Rank Rank { get; internal set; }
        public bool IsWild
        {
            get
            {
                return (Suit == Suit.UNKNOWN || Rank == Rank.UNKNOWN);
            }
        }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            string s = Suit.ToString().Substring(0, 1);
            string r;

            switch((int)Rank)
            {
                case 8:
                    r = "T";
                    break;
                case 9:
                    r = "J";
                    break;
                case 10:
                    r = "Q";
                    break;
                case 11:
                    r = "K";
                    break;
                case 12:
                    r = "A";
                    break;
                default:
                    r = ((int)Rank + 2).ToString().Substring(0, 1);
                    break;
            }

            return r + s;
        }

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType() && (this == (Card)obj);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() |
                    Suit.GetHashCode() |
                    Rank.GetHashCode());
        }

        public static bool operator ==(Card x, Card y)
        {
            if ((Object)x == null && (Object)y == null)
            {
                return true;
            }
            else if ((Object)x == null || (Object)y == null)
            {
                return false;
            }

            return (x.Rank == y.Rank &&
                    x.Suit == y.Suit);
        }

        public static bool operator !=(Card x, Card y)
        {
            return !(x == y);
        }
    }

    public class Hand
    {
        private List<Card> _hand;

        public bool IsEmpty
        {
            get
            {
                return (_hand.Count == 0);
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

        public bool RemoveCard(Card card)
        {
            return _hand.Remove(card);
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
        /// Determines the number of cards of a given suit within the hand.
        /// </summary>
        /// <param name="rank">
        /// The suit of the cards the method should count.
        /// </param>
        /// <returns>
        /// The number of cards of the given suit within the hand.  If no cards of the given
        /// suit are held in the hand, then the method returns 0.
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
        /// Determines the number of cards of a given rank within the hand.
        /// </summary>
        /// <param name="rank">
        /// The rank of the cards the method should count.
        /// </param>
        /// <returns>
        /// The number of cards of the given rank within the hand.  If no cards of the given
        /// rank are held in the hand, then the method returns 0.
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
        /// Orders the hand in ascending rank.
        /// </summary>
        public void OrderAscending()
        {
            _hand = _hand.OrderBy<Card, int>((card) => (int)card.Rank).ToList<Card>();
        }

        /// <summary>
        /// Orders the hand in descending rank.
        /// </summary>
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

        public Card PeekHighCard()
        {
            this.OrderAscending();
            return _hand.LastOrDefault();
        }

        public Card[] ToArray()
        {
            return _hand.ToArray();
        }

        public Hand GetClubs()
        {
            Hand clubs = new Hand();

            return clubs;
        }

        public Hand GetDiamonds()
        {
            Hand diamonds = new Hand();

            return diamonds;
        }

        public Hand GetHearts()
        {
            Hand hearts = new Hand();

            return hearts;
        }

        public Hand GetSpades()
        {
            Hand spades = new Hand();

            return spades;
        }
    }

    /// <summary>
    /// The Suit enumeration contains all of the valid suit values for a Deck.
    /// </summary>
    public enum Suit
    {
        CLUBS,
        DIAMONDS,
        HEARTS,
        SPADES,
        UNKNOWN
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
        ACE,
        UNKNOWN
    }

    public class HandGenerator
    {
        //Royal Flush
        static public Hand genRF()
        {
            int randomSuit = new Random().Next(Deck.NUMBER_OF_SUITS);
            return GetRoyalFlushHand((Suit)randomSuit);
        }

        //Royal Flush
        static public Hand GetRoyalFlushHand(Suit suit)
        {
            // first, create a new + shuffled deck
            Deck.Instance.MakeShuffledDeck();
            Hand royalFlush = new Hand();

            // a royal flush contains the cards ten through ace, all of the same suit
            Card ace = new Card(suit, Rank.ACE);
            Card king = new Card(suit, Rank.KING);
            Card queen = new Card(suit, Rank.QUEEN);
            Card jack = new Card(suit, Rank.JACK);
            Card ten = new Card(suit, Rank.TEN);

            // normally, the return value of RemoveCard would have to be checked,
            // but we know the deck is brand new and has all cards because it was
            // re-instantiated and shuffled at the beginning of this method
            Deck.Instance.RemoveCard(ace);
            royalFlush.InsertCard(ace);

            Deck.Instance.RemoveCard(king);
            royalFlush.InsertCard(king);

            Deck.Instance.RemoveCard(queen);
            royalFlush.InsertCard(queen);

            Deck.Instance.RemoveCard(jack);
            royalFlush.InsertCard(jack);

            Deck.Instance.RemoveCard(ten);
            royalFlush.InsertCard(ten);

            return royalFlush;
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
            //for (int i = 0; i < 4; i++)
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

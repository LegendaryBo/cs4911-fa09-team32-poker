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

        public bool ReturnCard(Card card)
        {
            if (_dealtCards.Remove(card))
            {
                _cards.Add(card);
                this.Shuffle();
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

        public void RemoveCards(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                if (_cards.Contains(c))
                {
                    this.RemoveCard(c);
                }
            }
        }

        public void ReturnCards(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                if (_dealtCards.Contains(c))
                {
                    this.ReturnCard(c);
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

        //assumes two character input; Rank first, then Suit.
        public Card(char cardCodeRank, char cardCodeSuit)
        {
            //check for rank
            if (cardCodeRank == 'A')
            {
                Rank = Rank.ACE;
            }
            else if (cardCodeRank == '2')
            {
                Rank = Rank.TWO;
            }
            else if (cardCodeRank == '3')
            {
                Rank = Rank.THREE;
            }
            else if (cardCodeRank == '4')
            {
                Rank = Rank.FOUR;
            }
            else if (cardCodeRank == '5')
            {
                Rank = Rank.FIVE;
            }
            else if (cardCodeRank == '6')
            {
                Rank = Rank.SIX;
            }
            else if (cardCodeRank == '7')
            {
                Rank = Rank.SEVEN;
            }
            else if (cardCodeRank == '8')
            {
                Rank = Rank.EIGHT;
            }
            else if (cardCodeRank == '9')
            {
                Rank = Rank.NINE;
            }
            else if (cardCodeRank == '0')
            {
                Rank = Rank.TEN;
            }
            else if (cardCodeRank == 'J')
            {
                Rank = Rank.JACK;
            }
            else if (cardCodeRank == 'Q')
            {
                Rank = Rank.QUEEN;
            }
            else if (cardCodeRank == 'K')
            {
                Rank = Rank.KING;
            }
            else{Rank = Rank.UNKNOWN;}

            //check for suit
            if (cardCodeSuit == 'H')
            {
                Suit = Suit.HEARTS;
            }
            else if (cardCodeSuit == 'S')
            {
                Suit = Suit.SPADES;
            }
            else if (cardCodeSuit == 'D')
            {
                Suit = Suit.DIAMONDS;
            }
            else if (cardCodeSuit == 'C')
            {
                Suit = Suit.CLUBS;
            }
            else { Rank = Rank.UNKNOWN; }
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
        /// True if the hand contains at least 5 cards of sequential rank, otherwise false.
        /// </returns>
        public bool HasStraight()
        {
            if (this.HasStraight(5, Rank.ACE))
            {
                return true;
            }
            else
            {
                for (int i = 0; i < (int)Rank.ACE - 4; ++i)
                {
                    if (this.HasStraight(5, (Rank)i))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasStraight(int minimumNumberOfCards, Rank startingWithRank)
        {
            Hand hand = new Hand();
            return this.HasStraight(minimumNumberOfCards, startingWithRank, ref hand);
        }

        public bool HasStraight(int minimumNumberOfCards, Rank startingWithRank, ref Hand matchedHand)
        {
            // an ACE can be a low card or high card
            // in the Rank enumeration, it has the highest value other than UNKNOWN
            // therefore, we handle the ACE being a low card as a special case
            // first, when we've got an ACE in our hand
            if (startingWithRank == Rank.ACE && this.GetCardsOfRank(Rank.ACE).Count > 0 && minimumNumberOfCards > 1)
            {
                matchedHand.InsertCard(this.GetCardsOfRank(Rank.ACE).ToArray()[0]);
                return this.HasStraight(minimumNumberOfCards - 1, Rank.TWO, ref matchedHand);
            }
            // second, when we've got no ACE, but we do have a wild card (UNKNOWN)
            else if (startingWithRank == Rank.ACE && this.GetCardsOfRank(Rank.UNKNOWN).Count > 0 && minimumNumberOfCards > 1)
            {
                matchedHand.InsertCard(this.GetCardsOfRank(Rank.UNKNOWN).ToArray()[0]);
                return this.HasStraightHelper(minimumNumberOfCards - 1, Rank.TWO, this.GetCardsOfRank(Rank.UNKNOWN).Count - 1, ref matchedHand);
            }
            // if we're looking for a straight, consider a straight starting with a wild card to be invalid
            else if (startingWithRank == Rank.UNKNOWN)
            {
                return false;
            }
            // we've handled the special cases, now just apply the normal algorithm
            else
            {
                return this.HasStraightHelper(minimumNumberOfCards, startingWithRank, this.GetCardsOfRank(Rank.UNKNOWN).Count, ref matchedHand);
            }
        }

        private bool HasStraightHelper(int minimumNumberOfCards, Rank startingWithRank, int numberOfWildcards)
        {
            Hand hand = new Hand();
            return this.HasStraightHelper(minimumNumberOfCards, startingWithRank, numberOfWildcards, ref hand);
        }

        private bool HasStraightHelper(int minimumNumberOfCards, Rank startingWithRank, int numberOfWildcards, ref Hand matchedHand)
        {
            int highestRank = (int)Rank.ACE;
            int endRank = (int)startingWithRank + minimumNumberOfCards - 1;

            // cannot form a straight with less than one card
            if(minimumNumberOfCards < 1)
            {
                return false;
            }

            // cannot form an X card straight from less than X number of cards
            if(highestRank < endRank)
            {
                return false;
            }

            if (this.GetCardsOfRank(startingWithRank).Count > 0)
            {
                matchedHand.InsertCard(this.GetCardsOfRank(startingWithRank).PeekHighCard());
                if (minimumNumberOfCards > 1)
                {
                    return this.HasStraightHelper(minimumNumberOfCards - 1, startingWithRank + 1, numberOfWildcards, ref matchedHand);
                }
                else
                {
                    return true;
                }
            }
            else if (numberOfWildcards > 0)
            {
                matchedHand.InsertCard(new Card(Suit.UNKNOWN, Rank.UNKNOWN));
                if (minimumNumberOfCards > 1)
                {
                    return this.HasStraightHelper(minimumNumberOfCards - 1, startingWithRank + 1, numberOfWildcards - 1, ref matchedHand);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool HasFlush()
        {
            return HasFlush(5);
        }

        public bool HasFlush(int minimumNumberOfCards)
        {
            for (int i = 0; i < 4; ++i)
            {
                if (HasFlush(minimumNumberOfCards, (Suit)i))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasFlush(int minimumNumberOfCards, Suit suit)
        {
            Hand hand = new Hand();
            return this.HasFlush(minimumNumberOfCards, suit, ref hand);
        }

        public bool HasFlush(int minimumNumberOfCards, Suit suit, ref Hand matchedHand)
        {
            int count = this.GetSuitCards(suit).Count;

            // have to have at least a single card for a flush
            if (minimumNumberOfCards < 1)
            {
                return false;
            }

            // if the suit isn't unknown, then we can add the wild cards to the suit's total number of cards
            if (suit != Suit.UNKNOWN)
            {
                count = this.GetSuitCards(suit).Count + this.GetSuitCards(Suit.UNKNOWN).Count;
            }
            // make sure the the total number of cards of this suit is adequate
            if ((this.GetSuitCards(suit).Count + this.GetSuitCards(Suit.UNKNOWN).Count) >= minimumNumberOfCards)
            {
                matchedHand = GetSuitCards(suit);
                if (suit != Suit.UNKNOWN)
                {
                    matchedHand.Combine(GetSuitCards(Suit.UNKNOWN));
                }
                return true;
            }

            return false;
        }

        public bool HasRoyalFlush(int minimumNumberOfCards, Suit suit, ref Hand matchedHand)
        {
            Rank highestRank = Rank.ACE;
            Rank startingWithRank = highestRank - minimumNumberOfCards + 1;
            Hand flush = new Hand();
            Hand royalFlush = new Hand();

            if (this.HasFlush(minimumNumberOfCards, suit, ref flush))
            {
                if (flush.HasStraight(minimumNumberOfCards, startingWithRank, ref royalFlush))
                {
                    matchedHand = royalFlush;
                    return true;
                }
            }

            return false;
        }

        public bool HasStraightFlush(int minimumNumberOfCards, Rank startingWithRank, Suit suit, ref Hand matchedHand)
        {
            Hand flush = new Hand();
            Hand straightFlush = new Hand();

            if (this.HasFlush(minimumNumberOfCards, suit, ref flush))
            {
                if (flush.HasStraight(minimumNumberOfCards, startingWithRank, ref straightFlush))
                {
                    matchedHand = straightFlush;
                    return true;
                }
            }

            return false;
        }

        public bool HasFourOfAKind(Rank ofRank, ref Hand matchedHand)
        {
            return HasXOfAKind(ofRank, 4, ref matchedHand);
        }

        public bool HasThreeOfAKind(Rank ofRank, ref Hand matchedHand)
        {
            return HasXOfAKind(ofRank, 3, ref matchedHand);
        }

        public bool HasTwoOfAKind(Rank ofRank, ref Hand matchedHand)
        {
            return HasPairOf(ofRank, ref matchedHand);
        }

        public bool HasPairOf(Rank ofRank, ref Hand matchedHand)
        {
            return HasXOfAKind(ofRank, 2, ref matchedHand);
        }

        public bool HasXOfAKind(Rank ofRank, int x, ref Hand matchedHand)
        {
            if (GetCardsOfRank(ofRank).Count == x)
            {
                matchedHand.InsertCards(GetCardsOfRank(ofRank).ToArray());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTwoPair(Rank firstRank, Rank secondRank, ref Hand matchedHand)
        {
            return (HasPairOf(firstRank, ref matchedHand) && HasPairOf(secondRank, ref matchedHand));
        }

        public bool HasFullHouse(Rank tripleRank, Rank pairRank, ref Hand matchedHand)
        {
            return (HasThreeOfAKind(tripleRank, ref matchedHand) && HasPairOf(pairRank, ref matchedHand));
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
        public HandGenerator()
        {

        }

        //Royal Flush//JC
        static public Hand genRF()
        {
            int suit = new Random().Next(Deck.NUMBER_OF_SUITS);

            // first, create a new + shuffled deck
            Deck.Instance.MakeShuffledDeck();
            Hand royalFlush = new Hand();

            // a royal flush contains the cards ten through ace, all of the same suit
            Card ace = new Card((Suit)suit, Rank.ACE);
            Card king = new Card((Suit)suit, Rank.KING);
            Card queen = new Card((Suit)suit, Rank.QUEEN);
            Card jack = new Card((Suit)suit, Rank.JACK);
            Card ten = new Card((Suit)suit, Rank.TEN);

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
            //pick a 5, 6, 7, 8, or 9 - must always include at least one of these
            //remove that card
            //choose ascending or descending order
            //fill the rest of the cards in the SF
            //random two cards

            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand straightFlush = new Hand();

            //pick the suit of the Straight Flush
            int suit = 0;
            Random rand = new Random();
            suit = rand.Next(0, 3);

            //pick a 5, 6, 7, 8, or 9 
            int rank = 0;
            rank = rand.Next(5, 9);
            Card card1 = new Card((Suit)suit, (Rank)rank);
            straightFlush.InsertCard(card1);

            //pick ascending or descending order, where ascending = 1, descending = 0;
            int direction = 0;
            direction = rand.Next(0, 1);

            Card sfCard = null;

            for (int i = 1; i < 5; i++)
            {
                if (direction == 1)
                {
                    sfCard = new Card((Suit)suit, (Rank)rank + i);
                    straightFlush.InsertCard(sfCard);
                }
                else
                {
                    sfCard = new Card((Suit)suit, (Rank)rank - i);
                    straightFlush.InsertCard(sfCard);
                }
            }

            //fill the rest of the cards in the SF
            //Can be any cards except for a card of the same suit, 1 higher than the highest card in the hand.
            //Could also be done by removing all cards of the chosen suit.

            //Remove cards from deck of the same suit.
            for (int i = 0; i < 12; i++)
            {
                if (Deck.Instance.Contains(new Card((Suit)suit, (Rank)i)))
                {
                    Card card = new Card((Suit)suit, (Rank)i);
                    Deck.Instance.RemoveCard(card);
                }
            }

            //Deal 2 random cards, as they can no longer be of the same suit as the first 5 cards.
            Card card6 = Deck.Instance.DealCard();
            straightFlush.InsertCard(card6);
            Card card7 = Deck.Instance.DealCard();
            straightFlush.InsertCard(card7);

            return straightFlush;
        }

        //Four of a Kind//JSS
        static public Hand genFK()
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand fourKind = new Hand();

            //pick the rank of the FK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            Card card1 = new Card((Suit)0, (Rank)rank);
            Card card2 = new Card((Suit)1, (Rank)rank);
            Card card3 = new Card((Suit)2, (Rank)rank);
            Card card4 = new Card((Suit)3, (Rank)rank);

            Deck.Instance.RemoveCard(card1);
            fourKind.InsertCard(card1);
            Deck.Instance.RemoveCard(card2);
            fourKind.InsertCard(card2);
            Deck.Instance.RemoveCard(card3);
            fourKind.InsertCard(card3);
            Deck.Instance.RemoveCard(card4);
            fourKind.InsertCard(card4);


            //random 3 cards
            //can be random because no cards that are dealt will make the hand better than a 4-Kind

            Card card5 = Deck.Instance.DealCard();
            fourKind.InsertCard(card5);
            Card card6 = Deck.Instance.DealCard();
            fourKind.InsertCard(card6);
            Card card7 = Deck.Instance.DealCard();
            fourKind.InsertCard(card7);

            return fourKind; //return completed hand
        }

        //Full House//Ruslan
        static public Hand genFH()
        {
            Deck deck = Deck.Instance;
            Hand hand = new Hand();
            Random r = new Random();

            deck.MakeShuffledDeck();

            Card[] c = new Card[] { deck.DealCard(), deck.DealCard() };
            while (c[0].Rank == c[1].Rank)
            {
                deck.ReturnCard(c[1]);
                c[1] = deck.DealCard();
            }

            Suit[,] suits = {{ Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES },
                            { Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES }};
            int[] suitLast = { 3, 3 };

            int rank = c.Rank;

            hand.InsertCards(c);

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a > 2; a++)
                {
                    int index = r.Next(0, suitLast[a]);
                    Suit suit = suits[a, index];
                    suits[a, index] = suits[a, suitLast[a]];
                    suits[a, suitLast[a]] = suit;
                    suitLast[a] = suitLast[a] - 1;

                    c[a] = new Card((Suit)suit, (Rank)rank);
                }

                if (i < 2) hand.InsertCards(c);
                if (i == 2) hand.InsertCards(c[0]);
                deck.RemoveCards(c);
            }

            for (int i = 0; i < 2; i++)
                hand.InsertCard(deck.DealCard());

            return hand;
        }

        //Flush//JSS
        static public Hand genFL()
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand flushHand = new Hand();

            //pick the suit of the FL
            int suit = 0;
            int rank = 0;
            Random rand = new Random();
            suit = rand.Next(0, 3);

            //choose five cards of that suit
            //get the first card in the flush
            rank = rand.Next(0, 12);
            Card card = new Card((Suit)suit, (Rank)rank);
            flushHand.InsertCard(card);
            Deck.Instance.RemoveCard(card);

            do//Gets the other 4 cards of the flush
            {
                rank = rand.Next(0, 12);
                card = new Card((Suit)suit, (Rank)rank);
                if (!flushHand.Contains(card))
                {
                    flushHand.InsertCard(card);
                    Deck.Instance.RemoveCard(card);
                }

            } while (flushHand.Count < 5);
            //while your flush Hand has 5 or less cards in it.

            //Remove cards from deck of the same suit.
            for (int i = 0; i < 12; i++)
            {
                if (Deck.Instance.Contains(new Card((Suit)suit, (Rank)i)))
                {
                    card = new Card((Suit)suit, (Rank)i);
                    Deck.Instance.RemoveCard(card);
                }
            }

            //Deal 2 random cards, as they can no longer be of the same suit as the first 5 cards.
            Card card6 = Deck.Instance.DealCard();
            flushHand.InsertCard(card6);
            Card card7 = Deck.Instance.DealCard();
            flushHand.InsertCard(card7);

            return flushHand; //remove later
        }

        //Straight//Ruslan
        static public Hand genST()
        {
            Random r = new Random();
            Deck deck = Deck.Instance;
            Hand hand = null;

            deck.MakeShuffledDeck();

            Rank rank = (Rank)r.Next(3, 12);
            Boolean invalid = false;

            do
            {
                if (hand != null) deck.ReturnCards(hand.ToArray());
                hand = new Hand();

                for (int i = 0; i < 5; i++)
                {
                    Rank cardRank = rank - i;
                    if ((Rank)rank == Rank.FIVE) cardRank = Rank.ACE;

                    hand.InsertCard(new Card((Suit)r.Next(0, 3), cardRank));
                };

                deck.RemoveCards(hand.ToArray());

                invalid = hand.HasFlush();
            } while (invalid);

            return hand;
        }

        //Three of a Kind//JSS
        static public Hand genTK()
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand threeKind = new Hand();

            //pick the rank of the TK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            //Get all four cards of that rank, and randomly choose one to remove from the hand.
            //This takes care of finding that card later to remove it from the deck so you won't
            //end up with a 4-Kind.
            int suit = 0;
            suit = rand.Next(0, 3);

            Card card1 = new Card((Suit)0, (Rank)rank);
            threeKind.InsertCard(card1);
            Deck.Instance.RemoveCard(card1);
            Card card2 = new Card((Suit)1, (Rank)rank);
            threeKind.InsertCard(card2);
            Deck.Instance.RemoveCard(card2);
            Card card3 = new Card((Suit)2, (Rank)rank);
            threeKind.InsertCard(card3);
            Deck.Instance.RemoveCard(card3);
            Card card4 = new Card((Suit)3, (Rank)rank);
            threeKind.InsertCard(card4);
            Deck.Instance.RemoveCard(card4);

            threeKind.RemoveCard(new Card((Suit)suit, (Rank)rank));

            //Generate 4 cards, knowing that a Full House, 4-Kind of a different rank, straight, flush,
            //Straight flush and Royal Flush will beat 3-Kind.

            Hand randHand = null;
            Boolean invalid = false;

            do
            {
                if (randHand != null) Deck.Instance.ReturnCards(randHand.ToArray());
                randHand = new Hand(threeKind.ToArray());

                for (int i = 0; i < 4; i++)
                {
                    randHand.InsertCard(Deck.Instance.DealCard());
                }

                //checks to see how many of each rank are in the hand.
                for (int j = 0; j < 12; j++)
                {
                    //If there are 2 or more of a rank, and that rank is not the 3-Kind rank, hand is invalid
                    if ((randHand.CountOf((Rank)j) >= 2) && (j != rank))
                    {
                        invalid = true;
                    }
                }
                //checks for Straight and Flush in hand
                if (invalid == false)
                    invalid = randHand.HasStraight() || randHand.HasFlush(3);

            } while (invalid);

            return randHand;
        }

        //Two Pair//Ruslan
        static public Hand genTP()
        {
            Deck deck = Deck.Instance;
            Hand hand = new Hand();
            Random r = new Random();

            deck.MakeShuffledDeck();

            Card[] c = new Card[] { deck.DealCard(), deck.DealCard() };
            while (c[0].Rank == c[1].Rank)
            {
                deck.ReturnCard(c[1]);
                c[1] = deck.DealCard();
            }

            Suit[,] suits = {{ Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES },
                            { Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES }};
            int[] suitLast = { 3, 3 };

            int rank = c.Rank;

            hand.InsertCards(c);

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a > 2; a++)
                {
                    int index = r.Next(0, suitLast[a]);
                    Suit suit = suits[a, index];
                    suits[a, index] = suits[a, suitLast[a]];
                    suits[a, suitLast[a]] = suit;
                    suitLast[a] = suitLast[a] - 1;

                    c[a] = new Card((Suit)suit, (Rank)rank);
                }

                if (i < 2) hand.InsertCards(c);
                deck.RemoveCards(c);
            }

            Hand randHand = null;
            Boolean invalid = false;

            do
            {
                if (randHand != null) deck.ReturnCards(randHand.ToArray());
                randHand = new Hand(hand.ToArray());

                for (int i = 0; i < 3; i++)
                    randHand.InsertCard(deck.DealCard());

                invalid = randHand.HasStraight() || randHand.HasFlush();

            } while (invalid);

            return hand;
        }

        //One Pair//JSS
        static public Hand genOP()
        {
            //pick the rank of the OP
            //pick two of the four cards of that rank
            //Remove the other 2 cards of that rank from deck
            //random 5 cards NOT OF THAT RANK

            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand onePair = new Hand();

            //pick the rank of the TK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            //Get all four cards of that rank, and randomly choose twp to remove from the hand.
            //This takes care of finding those cards later to remove them from the deck so you won't
            //end up with a 4-Kind or 3-Kind.
            int suit, suit2 = 0;
            suit = rand.Next(0, 3);
            do
            {
                suit2 = rand.Next(0, 3);
            } while (suit2 == suit);

            Card card1 = new Card((Suit)0, (Rank)rank);
            onePair.InsertCard(card1);
            Deck.Instance.RemoveCard(card1);
            Card card2 = new Card((Suit)1, (Rank)rank);
            onePair.InsertCard(card2);
            Deck.Instance.RemoveCard(card2);
            Card card3 = new Card((Suit)2, (Rank)rank);
            onePair.InsertCard(card3);
            Deck.Instance.RemoveCard(card3);
            Card card4 = new Card((Suit)3, (Rank)rank);
            onePair.InsertCard(card4);
            Deck.Instance.RemoveCard(card4);

            onePair.RemoveCard(new Card((Suit)suit, (Rank)rank));
            onePair.RemoveCard(new Card((Suit)suit2, (Rank)rank));

            //Generate 4 cards, knowing that a Full House, 4-Kind of a different rank, straight, flush,
            //Straight flush and Royal Flush will beat 3-Kind.

            Hand randHand = null;
            Boolean invalid = false;

            do
            {
                if (randHand != null) Deck.Instance.ReturnCards(randHand.ToArray());
                randHand = new Hand(onePair.ToArray());

                for (int i = 0; i < 5; i++)
                {
                    randHand.InsertCard(Deck.Instance.DealCard());
                }

                //checks to see how many of each rank are in the hand.
                for (int j = 0; j < 12; j++)
                {
                    //If there are 2 or more of a rank, and that rank is not the One Pair rank, hand is invalid
                    if ((randHand.CountOf((Rank)j) >= 2) && (j != rank))
                    {
                        invalid = true;
                    }
                }
                //checks for Straight and Flush in hand
                if (!invalid)
                    invalid = randHand.HasStraight() || randHand.HasFlush(3);

            } while (invalid);

            return randHand;
        }

        //High Card//Ruslan
        static public Hand genHC()
        {
            Hand hand;
            Deck deck = Deck.Instance;
            Boolean invalid = false;

            do
            {

                deck.MakeShuffledDeck();

                hand = new Hand();

                for (int i = 0; i < 5; i++) hand.InsertCard(deck.DealCard());

                Boolean hasPair = false;
                for (int i = 0; i < 13; i++)
                {
                    if (hand.CountOf((Rank)i) > 1)
                    {
                        hasPair = true;
                        break;
                    }
                }

                invalid = hand.HasFlush() || hand.HasStraight() || hasPair;
            } while (invalid);

            return hand;
        }
    }
}

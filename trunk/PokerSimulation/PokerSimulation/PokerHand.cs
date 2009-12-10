﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerSimulation
{
    /// <summary>
    /// A card hand class that is specific to poker.
    /// </summary>
    public class PokerHand : Hand
    {
        /// <summary>
        /// These private constants map to the REQ_CARDS array
        /// </summary>
        private const int RF = 0;
        private const int SF = 1;
        private const int FK = 2;
        private const int FH = 3;
        private const int FL = 4;
        private const int ST = 5;
        private const int TK = 6;
        private const int TP = 7;
        private const int OP = 8;

        /// <summary>
        /// An array that holds the minimum number of cards the specific hand must have.
        /// For example, Straight Flush is 1st element in the array (look for SF in the mapping above).
        /// A straight flush must have at least 5 cards (ex. 3H, 4H, 5H, 6H, 7H).
        /// </summary>
        private static int[] REQ_CARDS = { 5, 5, 4, 5, 5, 5, 3, 4, 2 };

        /// <summary>
        /// Random instance that is used for hand generation.
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Basic constructors for PokerHand
        /// </summary>
        public PokerHand() : this(null) { }
        public PokerHand(params Card[] cards):base(cards){}
        
        /// <summary>
        /// A helper property that uses all available evaluator methods to find out what is the best rank (poker pattern) for this hand.
        /// </summary>
        public HandRank MaxRank
        {
            get
            {
                if (this.Count == 0)
                {
                    return HandRank.None;
                }
                else if (this.HasRoyalFlush())
                {
                    return HandRank.RoyalFlush;
                }
                else if (this.HasStraightFlush())
                {
                    return HandRank.StraightFlush;
                }
                else if (this.HasFourOfAKind())
                {
                    return HandRank.FourOfAKind;
                }
                else if (this.HasFullHouse())
                {
                    return HandRank.FullHouse;
                }
                else if (this.HasFlush())
                {
                    return HandRank.Flush;
                }
                else if (this.HasStraight())
                {
                    return HandRank.Straight;
                }
                else if (this.HasThreeOfAKind())
                {
                    return HandRank.ThreeOfAKind;
                }
                else if (this.HasTwoPair())
                {
                    return HandRank.TwoPair;
                }
                else if (this.HasPair())
                {
                    return HandRank.OnePair;
                }
                else
                {
                    return HandRank.HighCard;
                }
            }
        }

        /// <summary>
        /// Generates a hand that cointains a random royal flush as it's best poker pattern.
        /// </summary>
        /// <param name="numCards">The number of cards that the hand should have as a result.</param>
        /// <returns>A PokerHand instance that has a royal flush as it's best pattern.</returns>
        static public PokerHand MakeRoyalFlush(int numCards)
        {
            int suit = _random.Next(Deck.NUMBER_OF_SUITS);

            // first, create a new deck
            Deck.Instance.MakeShuffledDeck();

            //this is an instance of hand that will be returned
            PokerHand royalFlush = new PokerHand();

            // a royal flush contains the cards ten through ace, all of the same suit
            for (int i = 0; i < REQ_CARDS[RF]; i++)
                royalFlush.InsertCard(new Card((Suit)suit, Rank.TEN + i));

            //remove the cards from the deck so they aren't chosen again
            Deck.Instance.RemoveCards(royalFlush.ToArray());

            //add additional random cards so we have numCards number of cards
            for (int i = 0; i < numCards - REQ_CARDS[RF]; i++)
                royalFlush.InsertCard(Deck.Instance.DealCard());

            //shuffle the resulting hand for randomness
            royalFlush.Shuffle();

            return royalFlush;
        }

        /// <summary>
        /// Generates a hand that cointains a random straight flush as it's best poker pattern.
        /// </summary>
        /// <param name="numCards">The number of cards that the hand should have as a result.</param>
        /// <returns>A PokerHand instance that has a straight flush as it's best pattern.</returns>
        static public PokerHand MakeStraightFlush(int numCards)
        {
            // choose a _random suit
            Suit suit = (Suit)(_random.Next(0, Deck.NUMBER_OF_SUITS));

            // next, choose a starting card hr
            // let -1 mean that we start with an Ace-low flush
            // also, make sure that the range does not allow a royal flush to be dealt
            Rank beginRank = (Rank)(_random.Next(-1, (Deck.NUMBER_OF_RANKS - (REQ_CARDS[SF] + 2))));

            PokerHand straightFlush = new PokerHand();

            Deck.Instance.MakeShuffledDeck();

            for (int i = (int)beginRank; i < REQ_CARDS[SF] + (int)beginRank; i++)
            {
                //Checking if the starting card is Ace
                Rank rank = i == -1 ? Rank.ACE : (Rank)i;

                straightFlush.InsertCard(new Card(suit, rank));
            }

            // remove straight flush cards from the deck
            Deck.Instance.RemoveCards(straightFlush.ToArray());

            // fill the rest of the hand with _random cards
            for (int i = 0; i < numCards - REQ_CARDS[SF]; i++)
                straightFlush.InsertCard(Deck.Instance.DealCard());

            //shuffle the hand before returning
            straightFlush.Shuffle();
            return straightFlush;
        }

        /// <summary>
        /// Generates a hand that cointains a random four of a kind as it's best poker pattern.
        /// </summary>
        /// <param name="numCards">The number of cards that the hand should have as a result.</param>
        /// <returns>A PokerHand instance that has a four of a kind as it's best pattern.</returns>
        static public PokerHand MakeFourOfAKind(int numCards)
        {
            //Initializes the deck
            Deck.Instance.MakeShuffledDeck();

            PokerHand fourKind = new PokerHand();

            //pick the beginRank of the FK
            int rank = _random.Next(0, Deck.NUMBER_OF_RANKS);

            for (int i = 0; i < REQ_CARDS[FK]; i++)
                fourKind.InsertCard(new Card((Suit)i, (Rank)rank));

            Deck.Instance.RemoveCards(fourKind.ToArray());

            //_random 3 cards
            //can be _random because no cards that are dealt will make the straightFlush or royal flush better than a 4-Kind
            for (int i = 0; i < numCards - REQ_CARDS[FK]; i++)
                fourKind.InsertCard(Deck.Instance.DealCard());

            //shuffles the cards in the hand
            fourKind.Shuffle();
            return fourKind; //return completed four of a kind
        }

        /// <summary>
        /// Generates a hand that cointains a random full house as it's best poker pattern.
        /// </summary>
        /// <param name="numCards">The number of cards that the hand should have as a result.</param>
        /// <returns>A PokerHand instance that has a full house as it's best pattern.</returns>
        static public PokerHand MakeFullHouse(int numCards)
        {
            Deck deck = Deck.Instance;
            PokerHand hand = new PokerHand();

            //cards that are dealt back
            Card[] dealBack = new Card[2];

            //initialize a random deck
            deck.MakeShuffledDeck();

            //dealing two random cards and making sure that their rank is different
            //these two cards will be used to make the full house
            Card[] c = new Card[] { deck.DealCard(), deck.DealCard() };
            while (c[0].Rank == c[1].Rank)
            {
                deck.ReturnCard(c[1]);
                c[1] = deck.DealCard();
            }

            //quick and dirty way to get random suits, explained in inner loop
            Suit[,] suits = {{ Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES },
                            { Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES }};

            //keeping track of the last valid suit in the suits array
            int suitLast = 3;

            //our two ranks for the full house
            Rank[] ranks = { c[0].Rank, c[1].Rank };

            //this four times for each suit of ranks in rank array
            for (int i = 0; i < 4; i++)
            {
                //the inner loop is for each separate rank
                //these sort of confusing manipulations are there to make sure that
                //the same suit doesnt get selected twice 
                for (int a = 0; a < 2; a++)
                {
                    //the index point to the next random index within the suits array
                    int index = _random.Next(0, suitLast);
                    //this is the actual suit
                    Suit suit = suits[a, index];
                    //the suit is placed in the swapped with the last valid suit
                    suits[a, index] = suits[a, suitLast];
                    suits[a, suitLast] = suit;

                    //the array holds the 2 new cards created for the two ranks
                    c[a] = new Card((Suit)suit, ranks[a]);
                }

                //the pointer to the last valid suit is decremented to exclude the used suit
                //from the valid range
                suitLast--;

                //the two cards are inserted for the first 2 iterations of the loop
                //since we need 3 cards of 1st rank and 2 cards of the 2nd rank,
                //one card gets to be dealt back, thus the deal back array
                if (i < 2) hand.InsertCards(c);
                else dealBack[i - 2] = c[1];

                //inserting the 3rd card for only one of the ranks
                if (i == 2) hand.InsertCard(c[0]);

                //all cards of the chosen ranks are removed so four of a kind
                //is not generated when picking random cards 
                deck.RemoveCards(c);
            }

            //dealing back
            deck.ReturnCard(dealBack[_random.Next(0, 1)]);

            for (int i = 0; i < numCards - REQ_CARDS[FH]; i++)
                hand.InsertCard(deck.DealCard());

            hand.Shuffle();
            return hand;
        }

        //Flush//JSS
        static public PokerHand MakeFlush(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand flushHand = new PokerHand();

            //pick the suit of the FL
            int suit = 0;
            suit = _random.Next(0, Deck.NUMBER_OF_SUITS);
            Boolean invalid = false;

            Card card;

            do
            {
                if (flushHand != null) Deck.Instance.ReturnCards(flushHand.ToArray());
                flushHand = new PokerHand();

                for (int i = 0; i < REQ_CARDS[FL]; i++)
                {
                    //choose five cards of that suit
                    do
                    {
                        card = new Card((Suit)suit, (Rank)_random.Next(0, 12));
                    } while (flushHand.Contains(card));

                    flushHand.InsertCard(card);
                }

                Deck.Instance.RemoveCards(flushHand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[FL]; i++)
                    flushHand.InsertCard(Deck.Instance.DealCard());

                invalid = flushHand.HasStraight();
            } while (invalid);

            flushHand.Shuffle();
            return flushHand; //remove later
        }

        //Straight//Ruslan
        static public PokerHand MakeStraight(int numCards)
        {
            Deck deck = Deck.Instance;
            PokerHand hand = null;

            deck.MakeShuffledDeck();

            Rank rank = (Rank)_random.Next(3, 12);
            Boolean invalid = false;

            do
            {
                if (hand != null) deck.ReturnCards(hand.ToArray());
                hand = new PokerHand();

                for (int i = 0; i < REQ_CARDS[ST]; i++)
                {
                    Rank cardRank = rank - i;
                    if (cardRank < 0) cardRank = Rank.ACE;

                    hand.InsertCard(new Card((Suit)_random.Next(0, 3), cardRank));
                }

                deck.RemoveCards(hand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[ST]; i++)
                    hand.InsertCard(deck.DealCard());

                invalid = hand.HasFlush();
            } while (invalid);

            hand.Shuffle();
            return hand;
        }

        //Three of a Kind//JSS
        static public PokerHand MakeThreeOfAKind(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand threeKind = new PokerHand();
            Card card;

            //pick the beginRank of the TK
            int rank = 0;
            rank = _random.Next(0, 12);

            //Get all four cards of that beginRank, and randomly choose one to remove from the straightFlush.
            //This takes care of finding that card later to remove it from the deck so you won't
            //end up with a 4-Kind.
            for (int i = 0; i < REQ_CARDS[TK] + 1; i++)
            {
                card = new Card((Suit)i, (Rank)rank);
                if (i < 3) threeKind.InsertCard(card);
                Deck.Instance.RemoveCard(card);
            }

            //Generate 4 cards, knowing that a Full House, 4-Kind of a different beginRank, straight, flush,
            //Straight flush and Royal Flush will beat 3-Kind.

            PokerHand randHand = null;
            Boolean invalid = false;

            do
            {
                invalid = false;
                if (randHand != null) Deck.Instance.ReturnCards(randHand.ToArray());
                randHand = new PokerHand(threeKind.ToArray());
                Deck.Instance.RemoveCards(randHand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[TK]; i++)
                    randHand.InsertCard(Deck.Instance.DealCard());

                //checks to see how many of each beginRank are in the straightFlush.
                for (int j = 0; j < 12; j++)
                {
                    //If there are 2 or more of a beginRank, and that beginRank is not the 3-Kind beginRank, straightFlush is invalid
                    if ((randHand.CountOf((Rank)j) >= 2) && (j != rank))
                    {
                        invalid = true;
                    }
                }

                //checks for Straight, Flush and Full House in straightFlush
                if (invalid == false)
                    invalid = randHand.HasStraight() || randHand.HasFlush(3) || randHand.HasFullHouse();

            } while (invalid);

            randHand.Shuffle();
            return randHand;
        }

        //Two Pair//Ruslan
        static public PokerHand MakeTwoPair(int numCards)
        {
            Deck deck = Deck.Instance;
            PokerHand hand = new PokerHand();
            Card[] dealBack = new Card[2];

            deck.MakeShuffledDeck();

            Card[] c = new Card[] { deck.DealCard(), deck.DealCard() };
            while (c[0].Rank == c[1].Rank)
            {
                deck.ReturnCard(c[1]);
                c[1] = deck.DealCard();
            }

            Suit[,] suits = {{ Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES },
                            { Suit.CLUBS, Suit.DIAMONDS, Suit.HEARTS, Suit.SPADES }};

            int suitLast = 3;

            Rank[] ranks = new Rank[] { c[0].Rank, c[1].Rank };
            deck.ReturnCards(c);

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 2; a++)
                {
                    int index = _random.Next(0, suitLast);
                    Suit suit = suits[a, index];
                    suits[a, index] = suits[a, suitLast];
                    suits[a, suitLast] = suit;

                    c[a] = new Card((Suit)suit, (Rank)ranks[a]);
                }

                suitLast--;

                if (i < 2) hand.InsertCards(c);
                deck.RemoveCards(c);
            }

            PokerHand randHand = null;
            Boolean invalid = false;

            do
            {
                if (randHand != null) deck.ReturnCards(randHand.ToArray());
                randHand = new PokerHand(hand.ToArray());
                deck.RemoveCards(hand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[TP]; i++)
                    randHand.InsertCard(deck.DealCard());

                invalid = randHand.HasStraight() || randHand.HasFlush() || randHand.HasThreeOfAKind();

            } while (invalid);

            randHand.Shuffle();
            return randHand;
        }

        //One Pair//JSS
        static public PokerHand MakeOnePair(int numCards)
        {
            //pick the beginRank of the OP
            //pick two of the four cards of that beginRank
            //Remove the other 2 cards of that beginRank from deck
            //_random 5 cards NOT OF THAT RANK

            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand onePair = new PokerHand();

            //pick the beginRank of the TK
            int rank = _random.Next(0, 12);

            //Get all four cards of that beginRank, and randomly choose twp to remove from the straightFlush.
            //This takes care of finding those cards later to remove them from the deck so you won't
            //end up with a 4-Kind or 3-Kind.
            int suit, suit2 = 0;
            suit = _random.Next(0, 3);
            do
            {
                suit2 = _random.Next(0, 3);
            } while (suit2 == suit);



            for (int i = 0; i < REQ_CARDS[OP] + 2; i++)
                onePair.InsertCard(new Card((Suit)i, (Rank)rank));

            Deck.Instance.RemoveCards(onePair.ToArray());

            onePair.RemoveCard(new Card((Suit)suit, (Rank)rank));
            onePair.RemoveCard(new Card((Suit)suit2, (Rank)rank));

            //Generate 5 cards, knowing that a Full House, 4-Kind of a different beginRank, straight, flush,
            //Straight flush and Royal Flush will beat 2-Kind.

            PokerHand randHand = null;
            Boolean invalid = false;

            do
            {
                invalid = false;
                if (randHand != null) Deck.Instance.ReturnCards(randHand.ToArray());
                randHand = new PokerHand(onePair.ToArray());
                Deck.Instance.RemoveCards(randHand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[OP]; i++)
                    randHand.InsertCard(Deck.Instance.DealCard());

                //checks to see how many of each beginRank are in the straightFlush.
                for (int j = 0; j < 12; j++)
                {
                    //If there are 2 or more of a beginRank, and that beginRank is not the One Pair beginRank, straightFlush is invalid
                    if ((randHand.CountOf((Rank)j) >= 2) && (j != rank))
                    {
                        invalid = true;
                    }
                }
                //checks for Straight and Flush in straightFlush
                if (!invalid)
                    invalid = randHand.HasStraight() || randHand.HasFlush(3) || randHand.HasTwoPair();

            } while (invalid);

            randHand.Shuffle();
            return randHand;
        }

        //High Card//Ruslan
        static public PokerHand MakeHighCard(int numCards)
        {
            PokerHand hand;
            Boolean invalid = false;

            do
            {
                Deck.Instance.MakeShuffledDeck();

                hand = new PokerHand();

                for (int i = 0; i < numCards; i++) hand.InsertCard(Deck.Instance.DealCard());

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

            hand.Shuffle();
            return hand;
        }

        /// <summary>
        /// Does the Hand contain a 5-card straight?
        /// </summary>
        /// <returns>
        /// True if the straightFlush contains at least 5 cards of sequential beginRank, otherwise false.
        /// </returns>
        public bool HasStraight()
        {
            // Special case: the ace may be a high card or low card for the straight
            // First, test to see if the straightFlush has a straight starting with an ace
            if (this.HasStraight(5, Rank.ACE))
            {
                return true;
            }
            // Now test to see if the straightFlush has any other straight
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
            PokerHand hand = new PokerHand();
            return this.HasStraight(minimumNumberOfCards, startingWithRank, ref hand);
        }

        public bool HasStraight(int minimumNumberOfCards, Rank startingWithRank, ref PokerHand matchedHand)
        {
            // an ACE can be a low card or high card
            // in the Rank enumeration, it has the highest value other than UNKNOWN
            // therefore, we handle the ACE being a low card as a special case
            // first, when we've got an ACE in our straightFlush
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
            // we've handled the special case, now just apply the normal algorithm
            else
            {
                return this.HasStraightHelper(minimumNumberOfCards, startingWithRank, this.GetCardsOfRank(Rank.UNKNOWN).Count, ref matchedHand);
            }
        }

        private bool HasStraightHelper(int minimumNumberOfCards, Rank startingWithRank, int numberOfWildcards)
        {
            PokerHand hand = new PokerHand();
            return this.HasStraightHelper(minimumNumberOfCards, startingWithRank, numberOfWildcards, ref hand);
        }

        private bool HasStraightHelper(int minimumNumberOfCards, Rank startingWithRank, int numberOfWildcards, ref PokerHand matchedHand)
        {
            int highestRank = (int)Rank.ACE;
            int endRank = (int)startingWithRank + minimumNumberOfCards - 1;

            // cannot form a straight with less than one card
            if (minimumNumberOfCards < 1)
            {
                return false;
            }

            // cannot form an X card straight from less than X number of cards
            if (highestRank < endRank)
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
            PokerHand hand = new PokerHand();
            return this.HasFlush(minimumNumberOfCards, suit, ref hand);
        }

        public bool HasFlush(int minimumNumberOfCards, Suit suit, ref PokerHand matchedHand)
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
                matchedHand = new PokerHand(GetSuitCards(suit).ToArray());
                if (suit != Suit.UNKNOWN)
                {
                    matchedHand.Combine(GetSuitCards(Suit.UNKNOWN));
                }
                return true;
            }

            return false;
        }

        public bool HasRoyalFlush()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < Deck.NUMBER_OF_SUITS; i++)
            {
                if (HasRoyalFlush(5, (Suit)i, ref hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasRoyalFlush(int minimumNumberOfCards, Suit suit, ref PokerHand matchedHand)
        {
            Rank highestRank = Rank.ACE;
            Rank startingWithRank = highestRank - minimumNumberOfCards + 1;
            PokerHand flush = new PokerHand();
            PokerHand royalFlush = new PokerHand();

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

        public bool HasStraightFlush()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < Deck.NUMBER_OF_SUITS; i++)
            {
                // first check for an ace-low straight flush
                if (HasStraightFlush(5, Rank.ACE, (Suit)i, ref hand))
                {
                    return true;
                }
                for (int j = 0; j < Deck.NUMBER_OF_RANKS - 5; j++)
                {
                    if (HasStraightFlush(5, (Rank)j, (Suit)i, ref hand))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasStraightFlush(int minimumNumberOfCards, Rank startingWithRank, Suit suit, ref PokerHand matchedHand)
        {
            PokerHand flush = new PokerHand();
            PokerHand straightFlush = new PokerHand();

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

        public bool HasFourOfAKind(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasXOfAKind(ofRank, 4, ref matchedHand);
        }

        public bool HasFourOfAKind()
        {
            PokerHand hand = new PokerHand();
            for (int i = 0; i < Deck.NUMBER_OF_RANKS; i++)
            {
                if (HasFourOfAKind((Rank)i, ref hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasThreeOfAKind(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasXOfAKind(ofRank, 3, ref matchedHand);
        }

        public bool HasThreeOfAKind()
        {
            PokerHand hand = new PokerHand();
            for (int i = 0; i < Deck.NUMBER_OF_RANKS; i++)
            {
                if (HasThreeOfAKind((Rank)i, ref hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasTwoOfAKind(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasXOfAKind(ofRank, 2, ref matchedHand);
        }

        public bool HasPairOf(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasXOfAKind(ofRank, 2, ref matchedHand);
        }

        public bool HasPair()
        {
            PokerHand hand = new PokerHand();
            for (int i = 0; i < Deck.NUMBER_OF_RANKS; i++)
            {
                if (HasTwoOfAKind((Rank)i, ref hand))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasXOfAKind(Rank ofRank, int x, ref PokerHand matchedHand)
        {
            List<Card> allMatches = GetCardsOfRank(ofRank).ToList();
            allMatches.AddRange(GetCardsOfRank(Rank.UNKNOWN).ToList());

            if (allMatches.Count >= x)
            {
                IEnumerable<Card> matched = allMatches.Take(x);
                foreach (Card c in matched)
                {
                    matchedHand.InsertCard(c);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTwoPair(Rank firstRank, Rank secondRank, ref PokerHand matchedHand)
        {
            return (HasPairOf(firstRank, ref matchedHand) && HasPairOf(secondRank, ref matchedHand));
        }

        public bool HasTwoPair()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < Deck.NUMBER_OF_RANKS; i++)
            {
                for (int j = 0; j < Deck.NUMBER_OF_RANKS; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (HasTwoPair((Rank)i, (Rank)j, ref hand))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasFullHouse(Rank tripleRank, Rank pairRank, ref PokerHand matchedHand)
        {
            return (HasThreeOfAKind(tripleRank, ref matchedHand) && HasPairOf(pairRank, ref matchedHand));
        }

        public bool HasFullHouse()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < Deck.NUMBER_OF_RANKS; i++)
            {
                for (int j = 0; j < Deck.NUMBER_OF_RANKS; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (HasFullHouse((Rank)i, (Rank)j, ref hand))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

        public enum HandRank
        {
            None,
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }
}

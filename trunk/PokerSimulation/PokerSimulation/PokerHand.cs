﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimulation
{
    public class PokerHand : Hand
    {
        private const int RF = 0;
        private const int SF = 1;
        private const int FK = 2;
        private const int FH = 3;
        private const int FL = 4;
        private const int ST = 5;
        private const int TK = 6;
        private const int TP = 7;
        private const int OP = 8;

        private static int[] REQ_CARDS = { 5, 5, 4, 5, 5, 5, 3, 4, 2 };

        public PokerHand() : this(null) { }
        public PokerHand(params Card[] cards):base(cards){}

        //Royal Flush//JC
        static public PokerHand makeRoyalFlush(int numCards)
        {
            int suit = new Random().Next(Deck.NUMBER_OF_SUITS);

            // first, create a new + shuffled deck
            Deck.Instance.MakeShuffledDeck();
            PokerHand royalFlush = new PokerHand();

            // a royal flush contains the cards ten through ace, all of the same suit
            for (int i = 0; i < REQ_CARDS[RF]; i++)
                royalFlush.InsertCard(new Card((Suit)suit, Rank.TEN + i));

            Deck.Instance.RemoveCards(royalFlush.ToArray());

            for (int i = 0; i < numCards - REQ_CARDS[RF]; i++)
                royalFlush.InsertCard(Deck.Instance.DealCard());

            royalFlush.Shuffle();
            return royalFlush;
        }

        //Straight Flush//JSS
        static public PokerHand makeStraightFlush(int numCards)
        {
            Random r = new Random();
            Deck deck = Deck.Instance;
            PokerHand hand = new PokerHand();

            deck.MakeShuffledDeck();

            Rank rank = (Rank)r.Next(3, 11);
            Suit suit = (Suit)r.Next(0, 3);

            for (int i = 0; i < REQ_CARDS[SF]; i++)
            {
                Rank cardRank = rank - i;
                if (cardRank < 0) cardRank = Rank.ACE;

                hand.InsertCard(new Card(suit, cardRank));
            }

            deck.RemoveCards(hand.ToArray());

            for (int i = 0; i < numCards - REQ_CARDS[SF]; i++)
                hand.InsertCard(deck.DealCard());

            hand.Shuffle();
            return hand;
        }

        //Four of a Kind//JSS
        static public PokerHand makeFourOfAKind(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand fourKind = new PokerHand();

            //pick the rank of the FK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            for (int i = 0; i < REQ_CARDS[FK]; i++)
                fourKind.InsertCard(new Card((Suit)i, (Rank)rank));

            Deck.Instance.RemoveCards(fourKind.ToArray());

            //random 3 cards
            //can be random because no cards that are dealt will make the hand better than a 4-Kind

            for (int i = 0; i < numCards - REQ_CARDS[FK]; i++)
                fourKind.InsertCard(Deck.Instance.DealCard());

            fourKind.Shuffle();
            return fourKind; //return completed hand
        }

        //Full House//Ruslan
        static public PokerHand makeFullHouse(int numCards)
        {
            Deck deck = Deck.Instance;
            PokerHand hand = new PokerHand();
            Card[] dealBack = new Card[2];
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
            int suitLast = 3;
            Rank[] ranks = { c[0].Rank, c[1].Rank };

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 2; a++)
                {
                    int index = r.Next(0, suitLast);
                    Suit suit = suits[a, index];
                    suits[a, index] = suits[a, suitLast];
                    suits[a, suitLast] = suit;

                    c[a] = new Card((Suit)suit, ranks[a]);
                }

                suitLast--;

                if (i < 2) hand.InsertCards(c);
                else dealBack[i - 2] = c[1];
                if (i == 2) hand.InsertCard(c[0]);
                deck.RemoveCards(c);
            }

            deck.ReturnCard(dealBack[r.Next(0, 1)]);

            for (int i = 0; i < numCards - REQ_CARDS[FH]; i++)
                hand.InsertCard(deck.DealCard());

            hand.Shuffle();
            return hand;
        }

        //Flush//JSS
        static public PokerHand makeFlush(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand flushHand = new PokerHand();

            //pick the suit of the FL
            int suit = 0;
            Random rand = new Random();
            suit = rand.Next(0, 3);
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
                        card = new Card((Suit)suit, (Rank)rand.Next(0, 12));
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
        static public PokerHand makeStraight(int numCards)
        {
            Random r = new Random();
            Deck deck = Deck.Instance;
            PokerHand hand = null;

            deck.MakeShuffledDeck();

            Rank rank = (Rank)r.Next(3, 12);
            Boolean invalid = false;

            do
            {
                if (hand != null) deck.ReturnCards(hand.ToArray());
                hand = new PokerHand();

                for (int i = 0; i < REQ_CARDS[ST]; i++)
                {
                    Rank cardRank = rank - i;
                    if (cardRank < 0) cardRank = Rank.ACE;

                    hand.InsertCard(new Card((Suit)r.Next(0, 3), cardRank));
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
        static public PokerHand makeThreeOfAKind(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand threeKind = new PokerHand();
            Card card;

            //pick the rank of the TK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            //Get all four cards of that rank, and randomly choose one to remove from the hand.
            //This takes care of finding that card later to remove it from the deck so you won't
            //end up with a 4-Kind.
            for (int i = 0; i < REQ_CARDS[TK] + 1; i++)
            {
                card = new Card((Suit)i, (Rank)rank);
                if (i < 3) threeKind.InsertCard(card);
                Deck.Instance.RemoveCard(card);
            }

            //Generate 4 cards, knowing that a Full House, 4-Kind of a different rank, straight, flush,
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

            randHand.Shuffle();
            return randHand;
        }

        //Two Pair//Ruslan
        static public PokerHand makeTwoPair(int numCards)
        {
            Deck deck = Deck.Instance;
            PokerHand hand = new PokerHand();
            Random r = new Random();
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

            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 2; a++)
                {
                    int index = r.Next(0, suitLast);
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

                invalid = randHand.HasStraight() || randHand.HasFlush();

            } while (invalid);

            randHand.Shuffle();
            return randHand;
        }

        //One Pair//JSS
        static public PokerHand makeOnePair(int numCards)
        {
            //pick the rank of the OP
            //pick two of the four cards of that rank
            //Remove the other 2 cards of that rank from deck
            //random 5 cards NOT OF THAT RANK

            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            PokerHand onePair = new PokerHand();

            //pick the rank of the TK
            Random rand = new Random();
            int rank = rand.Next(0, 12);

            //Get all four cards of that rank, and randomly choose twp to remove from the hand.
            //This takes care of finding those cards later to remove them from the deck so you won't
            //end up with a 4-Kind or 3-Kind.
            int suit, suit2 = 0;
            suit = rand.Next(0, 3);
            do
            {
                suit2 = rand.Next(0, 3);
            } while (suit2 == suit);



            for (int i = 0; i < REQ_CARDS[OP] + 2; i++)
                onePair.InsertCard(new Card((Suit)i, (Rank)rank));

            Deck.Instance.RemoveCards(onePair.ToArray());

            onePair.RemoveCard(new Card((Suit)suit, (Rank)rank));
            onePair.RemoveCard(new Card((Suit)suit2, (Rank)rank));

            //Generate 5 cards, knowing that a Full House, 4-Kind of a different rank, straight, flush,
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

            randHand.Shuffle();
            return randHand;
        }

        //High Card//Ruslan
        static public PokerHand makeHighCard(int numCards)
        {
            PokerHand hand;
            Deck deck = Deck.Instance;
            Boolean invalid = false;

            do
            {

                deck.MakeShuffledDeck();

                hand = new PokerHand();

                for (int i = 0; i < numCards; i++) hand.InsertCard(deck.DealCard());

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
            PokerHand hand = new PokerHand();
            return this.HasStraight(minimumNumberOfCards, startingWithRank, ref hand);
        }

        public bool HasStraight(int minimumNumberOfCards, Rank startingWithRank, ref PokerHand matchedHand)
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

        public bool HasThreeOfAKind(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasXOfAKind(ofRank, 3, ref matchedHand);
        }

        public bool HasTwoOfAKind(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasPairOf(ofRank, ref matchedHand);
        }

        public bool HasPairOf(Rank ofRank, ref PokerHand matchedHand)
        {
            return HasXOfAKind(ofRank, 2, ref matchedHand);
        }

        public bool HasXOfAKind(Rank ofRank, int x, ref PokerHand matchedHand)
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

        public bool HasTwoPair(Rank firstRank, Rank secondRank, ref PokerHand matchedHand)
        {
            return (HasPairOf(firstRank, ref matchedHand) && HasPairOf(secondRank, ref matchedHand));
        }

        public bool HasFullHouse(Rank tripleRank, Rank pairRank, ref PokerHand matchedHand)
        {
            return (HasThreeOfAKind(tripleRank, ref matchedHand) && HasPairOf(pairRank, ref matchedHand));
        }
    }
}

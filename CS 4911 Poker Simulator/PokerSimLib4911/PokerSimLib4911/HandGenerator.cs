using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimLib4911
{
    public class HandGenerator
    {
        public HandGenerator() { }

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

        //Royal Flush//JC
        static public Hand genRF(int numCards)
        {
            int suit = new Random().Next(Deck.NUMBER_OF_SUITS);

            // first, create a new + shuffled deck
            Deck.Instance.MakeShuffledDeck();
            Hand royalFlush = new Hand();

            // a royal flush contains the cards ten through ace, all of the same suit
            for (int i = 0; i < REQ_CARDS[RF]; i++)
                royalFlush.InsertCard(new Card(Rank.TEN + i, (Suit)suit));

            Deck.Instance.DealCards(royalFlush.ToArray());

            for (int i = 0; i < numCards - REQ_CARDS[RF]; i++)
                royalFlush.InsertCard(Deck.Instance.DealCard());

            royalFlush.Shuffle();
            return royalFlush;
        }

        //Straight Flush//JSS
        static public Hand genSF(int numCards)
        {
            Random r = new Random();
            Deck deck = Deck.Instance;
            Hand hand = null;

            deck.MakeShuffledDeck();

            Rank rank = (Rank)r.Next(3, 11);
            Suit suit = (Suit)r.Next(0, 3);

            hand = new Hand();

            for (int i = 0; i < REQ_CARDS[SF]; i++)
            {
                Rank cardRank = rank - i;
                if (cardRank < 0) cardRank = Rank.ACE;

                hand.InsertCard(new Card(cardRank, suit));
            }

            deck.DealCards(hand.ToArray());

            for (int i = 0; i < numCards - REQ_CARDS[SF]; i++)
                hand.InsertCard(deck.DealCard());

            hand.Shuffle();
            return hand;
        }

        //Four of a Kind//JSS
        static public Hand genFK(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand fourKind = new Hand();

            //pick the rank of the FK
            int rank = 0;
            Random rand = new Random();
            rank = rand.Next(0, 12);

            for (int i = 0; i < REQ_CARDS[FK]; i++)
                fourKind.InsertCard(new Card((Rank)rank, (Suit)i));

            Deck.Instance.DealCards(fourKind.ToArray());

            //random 3 cards
            //can be random because no cards that are dealt will make the hand better than a 4-Kind

            for (int i = 0; i < numCards - REQ_CARDS[FK]; i++)
                fourKind.InsertCard(Deck.Instance.DealCard());

            fourKind.Shuffle();
            return fourKind; //return completed hand
        }

        //Full House//Ruslan
        static public Hand genFH(int numCards)
        {
            Deck deck = Deck.Instance;
            Hand hand = new Hand();
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

                    c[a] = new Card(ranks[a], (Suit)suit);
                }

                suitLast--;

                if (i < 2) hand.InsertCards(c);
                else dealBack[i - 2] = c[1];
                if (i == 2) hand.InsertCard(c[0]);
                deck.DealCards(c);
            }

            deck.ReturnCard(dealBack[r.Next(0, 1)]);

            for (int i = 0; i < numCards - REQ_CARDS[FH]; i++)
                hand.InsertCard(deck.DealCard());

            hand.Shuffle();
            return hand;
        }

        //Flush//JSS
        static public Hand genFL(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand flushHand = new Hand();

            //pick the suit of the FL
            int suit = 0;
            Random rand = new Random();
            suit = rand.Next(0, 3);
            Boolean invalid = false;

            Card card;

            do
            {
                if (flushHand != null) Deck.Instance.ReturnCards(flushHand.ToArray());
                flushHand = new Hand();

                for (int i = 0; i < REQ_CARDS[FL]; i++)
                {
                    //choose five cards of that suit
                    do
                    {
                        card = new Card((Rank)rand.Next(0, 12), (Suit)suit);
                    } while (flushHand.Contains(card));

                    flushHand.InsertCard(card);
                }

                Deck.Instance.DealCards(flushHand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[FL]; i++)
                    flushHand.InsertCard(Deck.Instance.DealCard());

                invalid = flushHand.HasStraight();
            } while (invalid);

            flushHand.Shuffle();
            return flushHand; //remove later
        }

        //Straight//Ruslan
        static public Hand genST(int numCards)
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

                for (int i = 0; i < REQ_CARDS[ST]; i++)
                {
                    Rank cardRank = rank - i;
                    if (cardRank < 0) cardRank = Rank.ACE;

                    hand.InsertCard(new Card(cardRank, (Suit)r.Next(0, 3)));
                }

                deck.DealCards(hand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[ST]; i++)
                    hand.InsertCard(deck.DealCard());

                invalid = hand.HasFlush();
            } while (invalid);

            hand.Shuffle();
            return hand;
        }

        //Three of a Kind//JSS
        static public Hand genTK(int numCards)
        {
            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand threeKind = new Hand();
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
                card = new Card((Rank)rank, (Suit)i);
                if (i < 3) threeKind.InsertCard(card);
                Deck.Instance.DealCard(card);
            }

            //Generate 4 cards, knowing that a Full House, 4-Kind of a different rank, straight, flush,
            //Straight flush and Royal Flush will beat 3-Kind.

            Hand randHand = null;
            Boolean invalid = false;

            do
            {
                invalid = false;
                if (randHand != null) Deck.Instance.ReturnCards(randHand.ToArray());
                randHand = new Hand(threeKind.ToArray());
                Deck.Instance.DealCards(randHand.ToArray());

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
        static public Hand genTP(int numCards)
        {
            Deck deck = Deck.Instance;
            Hand hand = new Hand();
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

                    c[a] = new Card((Rank)ranks[a], (Suit)suit);
                }

                suitLast--;

                if (i < 2) hand.InsertCards(c);
                deck.DealCards(c);
            }

            Hand randHand = null;
            Boolean invalid = false;

            do
            {
                if (randHand != null) deck.ReturnCards(randHand.ToArray());
                randHand = new Hand(hand.ToArray());
                deck.DealCards(hand.ToArray());

                for (int i = 0; i < numCards - REQ_CARDS[TP]; i++)
                    randHand.InsertCard(deck.DealCard());

                invalid = randHand.HasStraight() || randHand.HasFlush();

            } while (invalid);

            randHand.Shuffle();
            return randHand;
        }

        //One Pair//JSS
        static public Hand genOP(int numCards)
        {
            //pick the rank of the OP
            //pick two of the four cards of that rank
            //Remove the other 2 cards of that rank from deck
            //random 5 cards NOT OF THAT RANK

            //Added by EJ
            Deck.Instance.MakeShuffledDeck();
            Hand onePair = new Hand();

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
                onePair.InsertCard(new Card((Rank)rank, (Suit)i));

            Deck.Instance.DealCards(onePair.ToArray());

            onePair.RemoveCard(new Card((Rank)rank, (Suit)suit));
            onePair.RemoveCard(new Card((Rank)rank, (Suit)suit2));

            //Generate 5 cards, knowing that a Full House, 4-Kind of a different rank, straight, flush,
            //Straight flush and Royal Flush will beat 2-Kind.

            Hand randHand = null;
            Boolean invalid = false;

            do
            {
                invalid = false;
                if (randHand != null) Deck.Instance.ReturnCards(randHand.ToArray());
                randHand = new Hand(onePair.ToArray());
                Deck.Instance.DealCards(randHand.ToArray());

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
        static public Hand genHC(int numCards)
        {
            Hand hand;
            Deck deck = Deck.Instance;
            Boolean invalid = false;

            do
            {

                deck.MakeShuffledDeck();

                hand = new Hand();

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
    }
}

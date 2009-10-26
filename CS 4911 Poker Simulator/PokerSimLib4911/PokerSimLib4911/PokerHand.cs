using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimLib4911
{
    class PokerHand : Hand
    {
        public static Suit RandomSuit
        {
            get
            {
                return (Suit)(new Random().Next(Deck.NUMBER_OF_SUITS));
            }
        }
        public static Rank RandomRank
        {
            get
            {
                return (Rank)(new Random().Next(Deck.NUMBER_OF_RANKS));
            }
        }

        public PokerHand(params Card[] cards) : base(cards) { }

        new public PokerHand GetCardsOfRank(Rank rank)
        {
            PokerHand hand = new PokerHand();

            foreach (Card c in _hand)
            {
                if (c.Rank == rank)
                {
                    hand.InsertCard(c);
                }
            }

            return hand;
        }

        new public PokerHand GetCardsOfSuit(Suit suit)
        {
            PokerHand hand = new PokerHand();

            foreach (Card c in _hand)
            {
                if (c.Suit == suit)
                {
                    hand.InsertCard(c);
                }
            }

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
                matchedHand.InsertCard((GetCardsOfRank(startingWithRank)).PeekHighCard());
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
                matchedHand.InsertCard(new Card(Rank.UNKNOWN, Suit.UNKNOWN));
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
            int count = this.GetCardsOfSuit(suit).Count;

            // have to have at least a single card for a flush
            if (minimumNumberOfCards < 1)
            {
                return false;
            }

            // if the suit isn't unknown, then we can add the wild cards to the suit's total number of cards
            if (suit != Suit.UNKNOWN)
            {
                count = this.GetCardsOfSuit(suit).Count + this.GetCardsOfSuit(Suit.UNKNOWN).Count;
            }
            // make sure the the total number of cards of this suit is adequate
            if ((this.GetCardsOfSuit(suit).Count + this.GetCardsOfSuit(Suit.UNKNOWN).Count) >= minimumNumberOfCards)
            {
                matchedHand = GetCardsOfSuit(suit);
                if (suit != Suit.UNKNOWN)
                {
                    matchedHand.Combine(GetCardsOfSuit(Suit.UNKNOWN));
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

        public bool HasFullHouse(Rank tripleRank, Rank pairRank, ref PokerHand matchedHand)
        {
            return (HasThreeOfAKind(tripleRank, ref matchedHand) && HasPairOf(pairRank, ref matchedHand));
        }

        public Card PeekHighCard()
        {
            PokerHand ordered = new PokerHand(_hand.ToArray());
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

        public static PokerHand GenerateRoyalFlush(Suit suit)
        {
            PokerHand royalFlush = new PokerHand();

            // first, create a new + shuffled deck
            Deck.Instance.MakeShuffledDeck();

            // a royal flush contains the cards ten through ace, all of the same suit
            Card ace = new Card(Rank.ACE, suit);
            Card king = new Card(Rank.KING, suit);
            Card queen = new Card(Rank.QUEEN, suit);
            Card jack = new Card(Rank.JACK, suit);
            Card ten = new Card(Rank.TEN, suit);

            // normally, the return value of DealCard would have to be checked,
            // but we know the deck is brand new and has all cards because it was
            // re-instantiated and shuffled at the beginning of this method
            Deck.Instance.DealCards(ten, jack, queen, king, ace);
            royalFlush.InsertCards(ten, jack, queen, king, ace);

            return royalFlush;
        }

        public static PokerHand GenerateRoyalFlush()
        {
            return GenerateRoyalFlush(RandomSuit);
        }
    }
}

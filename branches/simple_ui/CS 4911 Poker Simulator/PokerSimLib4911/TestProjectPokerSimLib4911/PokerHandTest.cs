using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProjectPokerSimLib4911
{
    
    
    /// <summary>
    ///This is a test class for PokerHandTest and is intended
    ///to contain all PokerHandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PokerHandTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for PeekHighCard
        ///</summary>
        [TestMethod()]
        public void PeekHighCardTest()
        {
            PokerHand target = new PokerHand();
            Card expected = null;
            Card actual;
            actual = target.PeekHighCard();
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Rank.ACE, Suit.SPADES));
            target.InsertCard(new Card(Rank.EIGHT, Suit.DIAMONDS));

            actual = target.PeekHighCard();
            expected = new Card(Rank.ACE, Suit.SPADES);
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Rank.ACE, Suit.UNKNOWN));
            actual = target.PeekHighCard();
            expected = new Card(Rank.ACE, Suit.UNKNOWN);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasXOfAKind
        ///</summary>
        [TestMethod()]
        public void HasXOfAKindTest()
        {
            Card[] cards = { new Card("AS"), new Card("AH"), new Card("AC"), new Card("AD"), new Card("2H"), new Card("UU") };
            PokerHand target = new PokerHand(cards);
            Rank ofRank = Rank.ACE;
            PokerHand matchedHand = new PokerHand();
            PokerHand matchedHandExpected = new PokerHand();
            bool expected = false;
            bool actual;
            actual = target.HasXOfAKind(ofRank, 6, ref matchedHand);
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);

            expected = false;
            ofRank = Rank.SEVEN;
            actual = target.HasXOfAKind(ofRank, 5, ref matchedHand);
            matchedHandExpected = new PokerHand();
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);

            expected = true;
            ofRank = Rank.ACE;
            actual = target.HasXOfAKind(ofRank, 5, ref matchedHand);
            matchedHandExpected = new PokerHand(cards);
            matchedHandExpected.RemoveCard(new Card("2H"));
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);

            expected = true;
            matchedHand = new PokerHand();
            actual = target.HasXOfAKind(ofRank, 4, ref matchedHand);
            matchedHandExpected = new PokerHand(cards);
            matchedHandExpected.RemoveCards(new Card("2H"), new Card("UU"));
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);

            expected = true;
            matchedHand = new PokerHand();
            actual = target.HasXOfAKind(ofRank, 3, ref matchedHand);
            matchedHandExpected = new PokerHand(cards);
            matchedHandExpected.RemoveCards(new Card("AD"), new Card("2H"), new Card("UU"));
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);

            expected = true;
            matchedHand = new PokerHand();
            actual = target.HasXOfAKind(ofRank, 2, ref matchedHand);
            matchedHandExpected = new PokerHand(cards);
            matchedHandExpected.RemoveCards(new Card("AC"), new Card("AD"), new Card("2H"), new Card("UU"));
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasTwoPair
        ///</summary>
        [TestMethod()]
        public void HasTwoPairTest()
        {
            Card[] cards = { new Card("AS"), new Card("JC"), new Card("AC"), new Card("QH") };
            PokerHand target = new PokerHand(cards);
            Rank firstRank = Rank.ACE;
            Rank secondRank = Rank.JACK;
            PokerHand matchedHand = new PokerHand();
            PokerHand matchedHandExpected = new PokerHand();
            bool expected = false;
            bool actual;
            actual = target.HasTwoPair(firstRank, secondRank, ref matchedHand);
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasStraight
        ///</summary>
        [TestMethod()]
        public void HasStraightTest2()
        {
            Card[] cards = null; // TODO: Initialize to an appropriate value
            PokerHand target = new PokerHand(cards); // TODO: Initialize to an appropriate value
            int minimumNumberOfCards = 0; // TODO: Initialize to an appropriate value
            Rank startingWithRank = new Rank(); // TODO: Initialize to an appropriate value
            PokerHand matchedHand = null; // TODO: Initialize to an appropriate value
            PokerHand matchedHandExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasStraight(minimumNumberOfCards, startingWithRank, ref matchedHand);
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasPairOf
        ///</summary>
        [TestMethod()]
        public void HasPairOfTest()
        {
            Card[] cards = null; // TODO: Initialize to an appropriate value
            PokerHand target = new PokerHand(cards); // TODO: Initialize to an appropriate value
            Rank ofRank = new Rank(); // TODO: Initialize to an appropriate value
            PokerHand matchedHand = null; // TODO: Initialize to an appropriate value
            PokerHand matchedHandExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasPairOf(ofRank, ref matchedHand);
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasFullHouse
        ///</summary>
        [TestMethod()]
        public void HasFullHouseTest()
        {
            Card[] cards = null; // TODO: Initialize to an appropriate value
            PokerHand target = new PokerHand(cards); // TODO: Initialize to an appropriate value
            Rank tripleRank = new Rank(); // TODO: Initialize to an appropriate value
            Rank pairRank = new Rank(); // TODO: Initialize to an appropriate value
            PokerHand matchedHand = null; // TODO: Initialize to an appropriate value
            PokerHand matchedHandExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasFullHouse(tripleRank, pairRank, ref matchedHand);
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasFlush
        ///</summary>
        [TestMethod()]
        public void HasFlushTest3()
        {
            Card[] cards = null; // TODO: Initialize to an appropriate value
            PokerHand target = new PokerHand(cards); // TODO: Initialize to an appropriate value
            int minimumNumberOfCards = 0; // TODO: Initialize to an appropriate value
            Suit suit = new Suit(); // TODO: Initialize to an appropriate value
            PokerHand matchedHand = null; // TODO: Initialize to an appropriate value
            PokerHand matchedHandExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasFlush(minimumNumberOfCards, suit, ref matchedHand);
            Assert.AreEqual(matchedHandExpected, matchedHand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for HasFlush
        ///</summary>
        [TestMethod()]
        public void HasFlushTest2()
        {
            Card[] cards = null; // TODO: Initialize to an appropriate value
            PokerHand target = new PokerHand(cards); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.HasFlush();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GenerateRoyalFlush
        ///</summary>
        [TestMethod()]
        public void GenerateRoyalFlushTest()
        {
            Suit suit = Suit.HEARTS;
            PokerHand expected = new PokerHand(new Card("TS"), new Card("JS"), new Card("QS"), new Card("KS"), new Card("AS"));
            PokerHand actual;
            actual = PokerHand.GenerateRoyalFlush(suit);
            Assert.AreNotEqual(expected, actual);
            actual = PokerHand.GenerateRoyalFlush(Suit.SPADES);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetCardsOfSuit
        ///</summary>
        [TestMethod()]
        public void GetSuitCardsTest()
        {
            Hand target = new Hand();
            Suit suit = Suit.SPADES;
            Hand expected = new Hand();
            Hand clubs = new Hand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.CLUBS));
            Hand diamonds = new Hand();
            Hand hearts = new Hand(new Card(Rank.TWO, Suit.HEARTS), new Card(Rank.SEVEN, Suit.HEARTS), new Card(Rank.ACE, Suit.HEARTS));
            Hand spades = new Hand(new Card(Rank.NINE, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES));
            Hand unknown = new Hand(new Card(Rank.QUEEN, Suit.UNKNOWN));
            Hand actual;
            actual = target.GetCardsOfSuit(suit);
            Assert.AreEqual(expected.Count, actual.Count);

            target = new Hand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.TWO, Suit.HEARTS), new Card(Rank.NINE, Suit.SPADES),
                              new Card(Rank.FIVE, Suit.CLUBS), new Card(Rank.SEVEN, Suit.HEARTS), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.UNKNOWN, Suit.CLUBS), new Card(Rank.ACE, Suit.HEARTS), new Card(Rank.QUEEN, Suit.UNKNOWN));

            actual = target.GetCardsOfSuit(Suit.CLUBS);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, clubs.RemoveCard(c));
            }

            actual = target.GetCardsOfSuit(Suit.DIAMONDS);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, diamonds.RemoveCard(c));
            }

            actual = target.GetCardsOfSuit(Suit.HEARTS);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, hearts.RemoveCard(c));
            }

            actual = target.GetCardsOfSuit(Suit.SPADES);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, spades.RemoveCard(c));
            }

            actual = target.GetCardsOfSuit(Suit.UNKNOWN);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, unknown.RemoveCard(c));
            }
        }

        /// <summary>
        ///A test for HasStraight
        ///</summary>
        [TestMethod()]
        public void HasStraightTest1()
        {
            PokerHand target = new PokerHand();
            int minimumNumberOfCards = 0;
            Rank beginRank = Rank.UNKNOWN;
            bool expected = false;
            bool actual;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS));
            expected = false;
            minimumNumberOfCards = 7;
            beginRank = Rank.TWO;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            expected = true;
            minimumNumberOfCards = 6;
            beginRank = Rank.TWO;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            expected = true;
            minimumNumberOfCards = 4;
            beginRank = Rank.THREE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            expected = true;
            minimumNumberOfCards = 3;
            beginRank = Rank.FOUR;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            expected = false;
            minimumNumberOfCards = 3;
            beginRank = Rank.JACK;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            expected = true;
            minimumNumberOfCards = 2;
            beginRank = Rank.JACK;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS));
            expected = true;
            minimumNumberOfCards = 7;
            beginRank = Rank.ACE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.TEN;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS));
            expected = false;
            minimumNumberOfCards = 5;
            beginRank = Rank.NINE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.UNKNOWN));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.TEN;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.FIVE, Suit.HEARTS), new Card(Rank.FOUR, Suit.UNKNOWN));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.ACE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasStraight
        ///</summary>
        [TestMethod()]
        public void HasStraightTest()
        {
            PokerHand target = new PokerHand();
            bool expected = false;
            bool actual;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS));

            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.UNKNOWN, Suit.HEARTS),
                              new Card(Rank.UNKNOWN, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.DIAMONDS));

            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.UNKNOWN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.DIAMONDS));

            expected = false;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.SPADES));
            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.SPADES));
            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.EIGHT, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.SPADES));
            expected = false;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasFlush
        ///</summary>
        [TestMethod()]
        public void HasFlushTest()
        {
            PokerHand target = new PokerHand();
            int minimumNumberOfCards = 0;
            Suit suit = Suit.UNKNOWN;
            bool expected = false;
            bool actual;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.DIAMONDS));
            expected = false;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = false;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasFlush
        ///</summary>
        [TestMethod()]
        public void HasFlushTest1()
        {
            PokerHand target = new PokerHand();
            int minimumNumberOfCards = 0;
            Suit suit = Suit.CLUBS;
            PokerHand hand = new PokerHand();
            PokerHand handExpected = new PokerHand();
            bool expected = false;
            bool actual;
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                                    new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.DIAMONDS));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.DIAMONDS),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.SPADES), new Card(Rank.SEVEN, Suit.DIAMONDS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasRoyalFlush
        ///</summary>
        [TestMethod()]
        public void HasRoyalFlushTest()
        {
            PokerHand target = new PokerHand();
            int minimumNumberOfCards = 0;
            Suit suit = Suit.DIAMONDS;
            PokerHand hand = new PokerHand();
            PokerHand handExpected = new PokerHand();
            bool expected = false;
            bool actual;
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 1;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.ACE, Suit.CLUBS));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.DIAMONDS));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                                    new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 8;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 4;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = true;
            handExpected = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                                    new Card(Rank.JACK, Suit.CLUBS));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HasStraightFlush
        ///</summary>
        [TestMethod()]
        public void HasStraightFlushTest()
        {
            PokerHand target = new PokerHand();
            int minimumNumberOfCards = 0;
            Rank startingWithRank = Rank.SEVEN;
            Suit suit = Suit.HEARTS;
            PokerHand hand = new PokerHand();
            PokerHand handExpected = new PokerHand();
            bool expected = false;
            bool actual;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                                    new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 5;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new PokerHand();
            startingWithRank = Rank.ACE;
            suit = Suit.HEARTS;
            minimumNumberOfCards = 5;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            handExpected = new PokerHand();
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 6;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                                    new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 6;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new PokerHand();
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 7;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.TWO, Suit.SPADES),
                              new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                                    new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            startingWithRank = Rank.ACE;
            suit = Suit.CLUBS;
            minimumNumberOfCards = 4;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.TWO, Suit.SPADES),
                              new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new PokerHand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                                    new Card(Rank.ACE, Suit.CLUBS));
            startingWithRank = Rank.JACK;
            suit = Suit.CLUBS;
            minimumNumberOfCards = 4;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);
        }
    }
}

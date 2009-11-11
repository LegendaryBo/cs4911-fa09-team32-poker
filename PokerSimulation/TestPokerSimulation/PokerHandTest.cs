using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerSimulation;

namespace TestPokerSimulation
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
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            PokerHand target = new PokerHand();
            string expected = string.Empty;
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.SIX), new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.SPADES, Rank.ACE));
            actual = target.ToString();
            expected = "6S, 5S, AS";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for RemoveCard
        ///</summary>
        [TestMethod()]
        public void RemoveCardTest()
        {
            PokerHand target = new PokerHand();
            Card card = null;
            bool expected = false;
            bool actual;
            actual = target.RemoveCard(card);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.SIX), new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.SPADES, Rank.ACE));
            card = new Card(Suit.SPADES, Rank.SIX);
            actual = target.RemoveCard(card);
            expected = true;
            Assert.AreEqual(expected, actual);
        }

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

            target.InsertCard(new Card(Suit.SPADES, Rank.ACE));
            target.InsertCard(new Card(Suit.DIAMONDS, Rank.EIGHT));

            actual = target.PeekHighCard();
            expected = new Card(Suit.SPADES, Rank.ACE);
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Suit.UNKNOWN, Rank.ACE));
            actual = target.PeekHighCard();
            expected = new Card(Suit.UNKNOWN, Rank.ACE);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for OrderDescending
        ///</summary>
        [TestMethod()]
        public void OrderDescendingTest()
        {
            PokerHand target = new PokerHand(new Card(Suit.SPADES, Rank.SIX), new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.SPADES, Rank.ACE));
            PokerHand expected = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.SIX), new Card(Suit.SPADES, Rank.FIVE));

            Card[] targetArray = target.ToArray();
            Card[] expectedArray = expected.ToArray();

            for (int i = 0; i < targetArray.Length && i < expectedArray.Length; ++i)
            {
                Assert.AreNotEqual(expectedArray[i], targetArray[i]);
            }

            target.OrderDescending();

            targetArray = target.ToArray();
            expectedArray = expected.ToArray();

            for (int i = 0; i < targetArray.Length && i < expectedArray.Length; ++i)
            {
                Assert.AreEqual(expectedArray[i], targetArray[i]);
            }
        }

        /// <summary>
        ///A test for OrderAscending
        ///</summary>
        [TestMethod()]
        public void OrderAscendingTest()
        {
            PokerHand target = new PokerHand(new Card(Suit.SPADES, Rank.SIX), new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.FIVE));
            PokerHand expected = new PokerHand(new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.SPADES, Rank.SIX), new Card(Suit.SPADES, Rank.ACE));

            Card[] targetArray = target.ToArray();
            Card[] expectedArray = expected.ToArray();

            for (int i = 0; i < targetArray.Length && i < expectedArray.Length; ++i)
            {
                Assert.AreNotEqual(expectedArray[i], targetArray[i]);
            }

            target.OrderAscending();

            targetArray = target.ToArray();
            expectedArray = expected.ToArray();

            for (int i = 0; i < targetArray.Length && i < expectedArray.Length; ++i)
            {
                Assert.AreEqual(expectedArray[i], targetArray[i]);
            }
        }

        /// <summary>
        ///A test for InsertCard
        ///</summary>
        [TestMethod()]
        public void InsertCardTest()
        {
            PokerHand target = new PokerHand(new Card(Suit.SPADES, Rank.ACE));
            Card card = new Card(Suit.SPADES, Rank.ACE);
            target.InsertCard(card);
            Assert.AreEqual(true, target.Contains(new Card(Suit.SPADES, Rank.ACE)));
            Assert.AreEqual(false, target.Contains(new Card(Suit.CLUBS, Rank.ACE)));
            Assert.AreEqual(2, target.CountOf(new Card(Suit.SPADES, Rank.ACE)));
        }

        /// <summary>
        ///A test for CountOf
        ///</summary>
        [TestMethod()]
        public void CountOfTest1()
        {
            PokerHand target = new PokerHand(new Card(Suit.SPADES, Rank.ACE));
            Rank rank = Rank.EIGHT;
            int expected = 0;
            int actual;

            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);

            rank = Rank.ACE;
            expected = 1;
            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Suit.HEARTS, Rank.ACE));
            expected = 2;
            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);

            target.RemoveCard(new Card(Suit.SPADES, Rank.ACE));
            expected = 1;
            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CountOf
        ///</summary>
        [TestMethod()]
        public void CountOfTest()
        {
            PokerHand target = new PokerHand(new Card(Suit.SPADES, Rank.ACE));
            Suit suit = Suit.HEARTS;
            int expected = 0;
            int actual;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);

            suit = Suit.SPADES;
            expected = 1;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Suit.SPADES, Rank.QUEEN));
            expected = 2;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);

            target.RemoveCard(new Card(Suit.SPADES, Rank.ACE));
            expected = 1;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            PokerHand target = new PokerHand();
            Suit suit = Suit.SPADES;
            Rank rank = Rank.ACE;
            bool expected = false;
            bool actual;
            actual = target.Contains(suit, rank);
            Assert.AreEqual(expected, actual);
            suit = Suit.UNKNOWN;
            rank = Rank.UNKNOWN;
            target = new PokerHand(new Card(suit, rank));
            expected = true;
            actual = target.Contains(suit, rank);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Hand Constructor
        ///</summary>
        [TestMethod()]
        public void HandConstructorTest()
        {
            Card[] cards = { new Card(Suit.CLUBS, Rank.EIGHT), new Card(Suit.DIAMONDS, Rank.ACE), new Card(Suit.SPADES, Rank.ACE) };
            PokerHand target = new PokerHand(cards);
            Assert.AreEqual(true, target.Contains(new Card(Suit.SPADES, Rank.ACE)));
            Assert.AreEqual(true, target.Contains(new Card(Suit.CLUBS, Rank.EIGHT)));
            Assert.AreEqual(true, target.Contains(new Card(Suit.DIAMONDS, Rank.ACE)));
            Assert.AreEqual(false, target.Contains(new Card(Suit.HEARTS, Rank.THREE)));
        }

        /// <summary>
        ///A test for IsEmpty
        ///</summary>
        [TestMethod()]
        public void IsEmptyTest()
        {
            PokerHand target = new PokerHand();
            bool actual;
            actual = target.IsEmpty;
            Assert.AreEqual(true, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.ACE));
            actual = target.IsEmpty;
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        ///A test for GetSuitCards
        ///</summary>
        [TestMethod()]
        public void GetSuitCardsTest()
        {
            Hand target = new Hand();
            Suit suit = Suit.SPADES;
            Hand expected = new Hand();
            Hand clubs = new Hand(new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE), new Card(Suit.CLUBS, Rank.UNKNOWN));
            Hand diamonds = new Hand();
            Hand hearts = new Hand(new Card(Suit.HEARTS, Rank.TWO), new Card(Suit.HEARTS, Rank.SEVEN), new Card(Suit.HEARTS, Rank.ACE));
            Hand spades = new Hand(new Card(Suit.SPADES, Rank.NINE), new Card(Suit.SPADES, Rank.THREE));
            Hand unknown = new Hand(new Card(Suit.UNKNOWN, Rank.QUEEN));
            Hand actual;
            actual = target.GetSuitCards(suit);
            Assert.AreEqual(expected.Count, actual.Count);

            target = new Hand(new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.HEARTS, Rank.TWO), new Card(Suit.SPADES, Rank.NINE),
                              new Card(Suit.CLUBS, Rank.FIVE), new Card(Suit.HEARTS, Rank.SEVEN), new Card(Suit.SPADES, Rank.THREE),
                              new Card(Suit.CLUBS, Rank.UNKNOWN), new Card(Suit.HEARTS, Rank.ACE), new Card(Suit.UNKNOWN, Rank.QUEEN));

            actual = target.GetSuitCards(Suit.CLUBS);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, clubs.RemoveCard(c));
            }

            actual = target.GetSuitCards(Suit.DIAMONDS);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, diamonds.RemoveCard(c));
            }

            actual = target.GetSuitCards(Suit.HEARTS);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, hearts.RemoveCard(c));
            }

            actual = target.GetSuitCards(Suit.SPADES);
            foreach (Card c in actual.ToArray())
            {
                Assert.AreEqual(true, spades.RemoveCard(c));
            }

            actual = target.GetSuitCards(Suit.UNKNOWN);
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

            target = new PokerHand(new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.DIAMONDS, Rank.TWO), new Card(Suit.HEARTS, Rank.FOUR),
                              new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.CLUBS, Rank.SIX), new Card(Suit.CLUBS, Rank.SEVEN),
                              new Card(Suit.HEARTS, Rank.UNKNOWN));
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

            target = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.DIAMONDS, Rank.TWO), new Card(Suit.HEARTS, Rank.FOUR),
                              new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.CLUBS, Rank.SIX), new Card(Suit.CLUBS, Rank.SEVEN),
                              new Card(Suit.HEARTS, Rank.UNKNOWN));
            expected = true;
            minimumNumberOfCards = 7;
            beginRank = Rank.ACE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.DIAMONDS, Rank.TWO), new Card(Suit.HEARTS, Rank.FOUR),
                              new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.CLUBS, Rank.SIX), new Card(Suit.CLUBS, Rank.SEVEN),
                              new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.TEN), new Card(Suit.SPADES, Rank.JACK),
                              new Card(Suit.HEARTS, Rank.KING));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.TEN;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.DIAMONDS, Rank.TWO), new Card(Suit.HEARTS, Rank.FOUR),
                              new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.CLUBS, Rank.SIX), new Card(Suit.CLUBS, Rank.SEVEN),
                              new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.TEN), new Card(Suit.SPADES, Rank.JACK),
                              new Card(Suit.HEARTS, Rank.KING));
            expected = false;
            minimumNumberOfCards = 5;
            beginRank = Rank.NINE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.DIAMONDS, Rank.TEN), new Card(Suit.SPADES, Rank.JACK),
                              new Card(Suit.HEARTS, Rank.KING), new Card(Suit.UNKNOWN, Rank.QUEEN));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.TEN;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.DIAMONDS, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                              new Card(Suit.HEARTS, Rank.FIVE), new Card(Suit.UNKNOWN, Rank.FOUR));
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

            target = new PokerHand(new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.DIAMONDS, Rank.TWO), new Card(Suit.HEARTS, Rank.FOUR),
                              new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.CLUBS, Rank.SIX), new Card(Suit.CLUBS, Rank.SEVEN),
                              new Card(Suit.HEARTS, Rank.UNKNOWN));

            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.UNKNOWN), new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.HEARTS, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.UNKNOWN));

            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.UNKNOWN), new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.CLUBS, Rank.UNKNOWN),
                              new Card(Suit.DIAMONDS, Rank.UNKNOWN));

            expected = false;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.TEN), new Card(Suit.SPADES, Rank.JACK),
                              new Card(Suit.HEARTS, Rank.KING), new Card(Suit.SPADES, Rank.QUEEN));
            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.TEN), new Card(Suit.SPADES, Rank.JACK),
                              new Card(Suit.HEARTS, Rank.KING), new Card(Suit.SPADES, Rank.QUEEN));
            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.HEARTS, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.EIGHT), new Card(Suit.SPADES, Rank.JACK),
                              new Card(Suit.HEARTS, Rank.KING), new Card(Suit.SPADES, Rank.QUEEN));
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
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = true;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.DIAMONDS, Rank.FIVE));
            expected = false;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.UNKNOWN, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = true;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
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
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                                    new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.DIAMONDS, Rank.FIVE));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.UNKNOWN, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.UNKNOWN, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.UNKNOWN, Rank.THREE), new Card(Suit.DIAMONDS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.SPADES, Rank.UNKNOWN), new Card(Suit.DIAMONDS, Rank.SEVEN),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.UNKNOWN, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
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
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.CLUBS, Rank.ACE));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.CLUBS, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.DIAMONDS, Rank.FIVE));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.CLUBS, Rank.TWO), new Card(Suit.UNKNOWN, Rank.THREE), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.CLUBS, Rank.FIVE));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                                    new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.CLUBS, Rank.ACE),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            expected = false;
            handExpected = new PokerHand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 8;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 4;
            suit = Suit.CLUBS;
            target = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                              new Card(Suit.CLUBS, Rank.JACK), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            expected = true;
            handExpected = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                                    new Card(Suit.CLUBS, Rank.JACK));
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

            target = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                            new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.SPADES, Rank.FIVE));
            handExpected = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                                    new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.SPADES, Rank.FIVE));
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 5;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                            new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.SPADES, Rank.FIVE));
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

            target = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                            new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.FIVE));
            handExpected = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                                    new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.SPADES, Rank.FIVE), new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 6;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.SPADES, Rank.TWO), new Card(Suit.SPADES, Rank.THREE),
                            new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.FIVE));
            handExpected = new PokerHand();
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 7;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.SPADES, Rank.ACE), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.TWO),
                              new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.THREE),
                              new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.FIVE));
            handExpected = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                                    new Card(Suit.UNKNOWN, Rank.UNKNOWN));
            startingWithRank = Rank.ACE;
            suit = Suit.CLUBS;
            minimumNumberOfCards = 4;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new PokerHand(new Card(Suit.CLUBS, Rank.ACE), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.TWO),
                              new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.THREE),
                              new Card(Suit.SPADES, Rank.FOUR), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.SPADES, Rank.FIVE));
            handExpected = new PokerHand(new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN), new Card(Suit.UNKNOWN, Rank.UNKNOWN),
                                    new Card(Suit.CLUBS, Rank.ACE));
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

using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProjectPokerSimLib4911
{
    
    
    /// <summary>
    ///This is a test class for HandTest and is intended
    ///to contain all HandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HandTest
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
            Hand target = new Hand();
            string expected = string.Empty;
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.SIX, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.ACE, Suit.SPADES));
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
            Hand target = new Hand();
            Card card = null;
            bool expected = false;
            bool actual;
            actual = target.RemoveCard(card);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.SIX, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.ACE, Suit.SPADES));
            card = new Card(Rank.SIX, Suit.SPADES);
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
            Hand target = new Hand();
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
        ///A test for OrderDescending
        ///</summary>
        [TestMethod()]
        public void OrderDescendingTest()
        {
            Hand target = new Hand(new Card(Rank.SIX, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.ACE, Suit.SPADES));
            Hand expected = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.SIX, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));

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
            Hand target = new Hand(new Card(Rank.SIX, Suit.SPADES), new Card(Rank.ACE, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            Hand expected = new Hand(new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.SPADES), new Card(Rank.ACE, Suit.SPADES));

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
            Hand target = new Hand(new Card(Rank.ACE, Suit.SPADES));
            Card card = new Card(Rank.ACE, Suit.SPADES);
            target.InsertCard(card);
            Assert.AreEqual(true, target.Contains(new Card(Rank.ACE, Suit.SPADES)));
            Assert.AreEqual(false, target.Contains(new Card(Rank.ACE, Suit.CLUBS)));
            Assert.AreEqual(2, target.CountOf(new Card(Rank.ACE, Suit.SPADES)));
        }

        /// <summary>
        ///A test for CountOf
        ///</summary>
        [TestMethod()]
        public void CountOfTest1()
        {
            Hand target = new Hand(new Card(Rank.ACE, Suit.SPADES));
            Rank rank = Rank.EIGHT;
            int expected = 0;
            int actual;

            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);

            rank = Rank.ACE;
            expected = 1;
            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Rank.ACE, Suit.HEARTS));
            expected = 2;
            actual = target.CountOf(rank);
            Assert.AreEqual(expected, actual);

            target.RemoveCard(new Card(Rank.ACE, Suit.SPADES));
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
            Hand target = new Hand(new Card(Rank.ACE, Suit.SPADES));
            Suit suit = Suit.HEARTS;
            int expected = 0;
            int actual;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);

            suit = Suit.SPADES;
            expected = 1;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);

            target.InsertCard(new Card(Rank.QUEEN, Suit.SPADES));
            expected = 2;
            actual = target.CountOf(suit);
            Assert.AreEqual(expected, actual);

            target.RemoveCard(new Card(Rank.ACE, Suit.SPADES));
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
            Hand target = new Hand();
            Suit suit = Suit.SPADES;
            Rank rank = Rank.ACE;
            bool expected = false;
            bool actual;
            actual = target.Contains(suit, rank);
            Assert.AreEqual(expected, actual);
            suit = Suit.UNKNOWN;
            rank = Rank.UNKNOWN;
            target = new Hand(new Card(rank, suit));
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
            Card[] cards = { new Card(Rank.EIGHT, Suit.CLUBS), new Card(Rank.ACE, Suit.DIAMONDS), new Card(Rank.ACE, Suit.SPADES) };
            Hand target = new Hand(cards);
            Assert.AreEqual(true, target.Contains(new Card(Rank.ACE, Suit.SPADES)));
            Assert.AreEqual(true, target.Contains(new Card(Rank.EIGHT, Suit.CLUBS)));
            Assert.AreEqual(true, target.Contains(new Card(Rank.ACE, Suit.DIAMONDS)));
            Assert.AreEqual(false, target.Contains(new Card(Rank.THREE, Suit.HEARTS)));
        }

        /// <summary>
        ///A test for IsEmpty
        ///</summary>
        [TestMethod()]
        public void IsEmptyTest()
        {
            Hand target = new Hand();
            bool actual;
            actual = target.IsEmpty;
            Assert.AreEqual(true, actual);

            target = new Hand(new Card(Rank.ACE, Suit.SPADES));
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
            Hand clubs = new Hand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.CLUBS));
            Hand diamonds = new Hand();
            Hand hearts = new Hand(new Card(Rank.TWO, Suit.HEARTS), new Card(Rank.SEVEN, Suit.HEARTS), new Card(Rank.ACE, Suit.HEARTS));
            Hand spades = new Hand(new Card(Rank.NINE, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES));
            Hand unknown = new Hand(new Card(Rank.QUEEN, Suit.UNKNOWN));
            Hand actual;
            actual = target.GetSuitCards(suit);
            Assert.AreEqual(expected.Count, actual.Count);

            target = new Hand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.TWO, Suit.HEARTS), new Card(Rank.NINE, Suit.SPADES),
                              new Card(Rank.FIVE, Suit.CLUBS), new Card(Rank.SEVEN, Suit.HEARTS), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.UNKNOWN, Suit.CLUBS), new Card(Rank.ACE, Suit.HEARTS), new Card(Rank.QUEEN, Suit.UNKNOWN));

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
            Hand target = new Hand();
            int minimumNumberOfCards = 0;
            Rank beginRank = Rank.UNKNOWN;
            bool expected = false;
            bool actual;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
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

            target = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS));
            expected = true;
            minimumNumberOfCards = 7;
            beginRank = Rank.ACE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.TEN;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS));
            expected = false;
            minimumNumberOfCards = 5;
            beginRank = Rank.NINE;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.UNKNOWN));
            expected = true;
            minimumNumberOfCards = 5;
            beginRank = Rank.TEN;
            actual = target.HasStraight(minimumNumberOfCards, beginRank);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.THREE, Suit.SPADES),
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
            Hand target = new Hand();
            bool expected = false;
            bool actual;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.TWO, Suit.DIAMONDS), new Card(Rank.FOUR, Suit.HEARTS),
                              new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.SIX, Suit.CLUBS), new Card(Rank.SEVEN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.HEARTS));

            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.UNKNOWN, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.UNKNOWN, Suit.HEARTS),
                              new Card(Rank.UNKNOWN, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.DIAMONDS));

            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.UNKNOWN, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.UNKNOWN, Suit.CLUBS),
                              new Card(Rank.UNKNOWN, Suit.DIAMONDS));

            expected = false;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.SPADES));
            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.TEN, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
                              new Card(Rank.KING, Suit.HEARTS), new Card(Rank.QUEEN, Suit.SPADES));
            expected = true;
            actual = target.HasStraight();
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.UNKNOWN, Suit.HEARTS), new Card(Rank.EIGHT, Suit.DIAMONDS), new Card(Rank.JACK, Suit.SPADES),
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
            Hand target = new Hand();
            int minimumNumberOfCards = 0;
            Suit suit = Suit.UNKNOWN;
            bool expected = false;
            bool actual;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.DIAMONDS));
            expected = false;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            actual = target.HasFlush(minimumNumberOfCards, suit);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
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
            Hand target = new Hand();
            int minimumNumberOfCards = 0;
            Suit suit = Suit.CLUBS;
            Hand hand = new Hand();
            Hand handExpected = new Hand();
            bool expected = false;
            bool actual;
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                                    new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.DIAMONDS));
            expected = false;
            handExpected = new Hand();
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = false;
            handExpected = new Hand();
            actual = target.HasFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.DIAMONDS),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.SPADES), new Card(Rank.SEVEN, Suit.DIAMONDS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
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
            Hand target = new Hand();
            int minimumNumberOfCards = 0;
            Suit suit = Suit.DIAMONDS;
            Hand hand = new Hand();
            Hand handExpected = new Hand();
            bool expected = false;
            bool actual;
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 1;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = true;
            handExpected = new Hand(new Card(Rank.ACE, Suit.CLUBS));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.CLUBS), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.DIAMONDS));
            expected = false;
            handExpected = new Hand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.TWO, Suit.CLUBS), new Card(Rank.THREE, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.FIVE, Suit.CLUBS));
            expected = false;
            handExpected = new Hand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 5;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = true;
            handExpected = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                                    new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 6;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.ACE, Suit.CLUBS),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = false;
            handExpected = new Hand();
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 8;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = true;
            handExpected = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            actual = target.HasRoyalFlush(minimumNumberOfCards, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            minimumNumberOfCards = 4;
            suit = Suit.CLUBS;
            target = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                              new Card(Rank.JACK, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            expected = true;
            handExpected = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
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
            Hand target = new Hand();
            int minimumNumberOfCards = 0;
            Rank startingWithRank = Rank.SEVEN;
            Suit suit = Suit.HEARTS;
            Hand hand = new Hand();
            Hand handExpected = new Hand();
            bool expected = false;
            bool actual;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                                    new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 5;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new Hand();
            startingWithRank = Rank.ACE;
            suit = Suit.HEARTS;
            minimumNumberOfCards = 5;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            handExpected = new Hand();
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 6;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                                    new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.FIVE, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 6;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.TWO, Suit.SPADES), new Card(Rank.THREE, Suit.SPADES),
                            new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new Hand();
            startingWithRank = Rank.ACE;
            suit = Suit.SPADES;
            minimumNumberOfCards = 7;
            expected = false;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.TWO, Suit.SPADES),
                              new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
                                    new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            startingWithRank = Rank.ACE;
            suit = Suit.CLUBS;
            minimumNumberOfCards = 4;
            expected = true;
            actual = target.HasStraightFlush(minimumNumberOfCards, startingWithRank, suit, ref hand);
            Assert.AreEqual(handExpected, hand);
            Assert.AreEqual(expected, actual);

            target = new Hand(new Card(Rank.ACE, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.TWO, Suit.SPADES),
                              new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.THREE, Suit.SPADES),
                              new Card(Rank.FOUR, Suit.SPADES), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.FIVE, Suit.SPADES));
            handExpected = new Hand(new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN), new Card(Rank.UNKNOWN, Suit.UNKNOWN),
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

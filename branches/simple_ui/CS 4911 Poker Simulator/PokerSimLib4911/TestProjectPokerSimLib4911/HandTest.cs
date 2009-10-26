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
        ///A test for DealCard
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
    }
}

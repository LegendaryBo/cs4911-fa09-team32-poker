using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProjectPokerSimLib4911
{
    
    
    /// <summary>
    ///This is a test class for CardTest and is intended
    ///to contain all CardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CardTest
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
        ///A test for IsWild
        ///</summary>
        [TestMethod()]
        public void IsWildTest()
        {
            Card target = new Card(Rank.TWO, Suit.CLUBS);
            Assert.AreEqual(false, target.IsWild);
            target = new Card(Rank.TWO, Suit.UNKNOWN);
            Assert.AreEqual(true, target.IsWild);
            target = new Card(Rank.UNKNOWN, Suit.CLUBS);
            Assert.AreEqual(true, target.IsWild);
            target = new Card(Rank.UNKNOWN, Suit.UNKNOWN);
            Assert.AreEqual(true, target.IsWild);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Card target = new Card(Rank.ACE, Suit.SPADES);
            string expected = "AS";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Rank.EIGHT, Suit.CLUBS);
            expected = "8C";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Rank.TEN, Suit.CLUBS);
            expected = "TC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Rank.JACK, Suit.CLUBS);
            expected = "JC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Rank.QUEEN, Suit.CLUBS);
            expected = "QC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Rank.KING, Suit.CLUBS);
            expected = "KC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for op_Inequality
        ///</summary>
        [TestMethod()]
        public void op_InequalityTest()
        {
            Assert.AreEqual(true, (new Card(Rank.ACE, Suit.SPADES) != new Card(Rank.UNKNOWN, Suit.SPADES)));
            Assert.AreEqual(false, (new Card(Rank.ACE, Suit.SPADES) != new Card(Rank.ACE, Suit.SPADES)));
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            Assert.AreEqual(false, (new Card(Rank.ACE, Suit.SPADES) == new Card(Rank.UNKNOWN, Suit.SPADES)));
            Assert.AreEqual(true, (new Card(Rank.ACE, Suit.SPADES) == new Card(Rank.ACE, Suit.SPADES)));
        }

        /// <summary>
        ///A test for IsValidSuit
        ///</summary>
        [TestMethod()]
        public void IsValidSuitTest()
        {
            string suit = "bar";
            bool expected = false;
            bool actual;
            actual = Card.IsValidSuit(suit);
            Assert.AreEqual(expected, actual);

            suit = "hearts";
            expected = true;
            actual = Card.IsValidSuit(suit);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsValidRank
        ///</summary>
        [TestMethod()]
        public void IsValidRankTest()
        {
            string rank = "foo";
            bool expected = false;
            bool actual;
            actual = Card.IsValidRank(rank);
            Assert.AreEqual(expected, actual);

            rank = "ace";
            expected = true;
            actual = Card.IsValidRank(rank);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Card Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException),
         "The rank string {M} specified for the Card constructor is invalid.")]
        public void CardConstructorTest1()
        {
            char rank = 'M';
            char suit = 'D';
            Card target = new Card(rank, suit);
            Card expected = new Card(Rank.EIGHT, Suit.SPADES);
            Card actual = new Card('8', 's');

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Card Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException),
         "The suit string {P} specified for the Card constructor is invalid.")]
        public void CardConstructorTest2()
        {
            char rank = 'A';
            char suit = 'P';
            Card target = new Card(rank, suit);
            Card expected = new Card(Rank.EIGHT, Suit.SPADES);
            Card actual = new Card('8', 's');

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Card Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException),
         "The rank string {foo} specified for the Card constructor is invalid.")]
        public void CardConstructorTest()
        {
            string rank = "foo";
            string suit = "bar";
            Card target = new Card(rank, suit);

            rank = "three";
            suit = "c";
            Card expected = new Card(Rank.THREE, Suit.CLUBS);
            Card actual = new Card(rank, suit);
            Assert.AreEqual(expected, actual);

            rank = "king";
            suit = "diamonds";
            expected = new Card(Rank.KING, Suit.DIAMONDS);
            actual = new Card(rank, suit);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ValidSuitStrings
        ///</summary>
        [TestMethod()]
        public void ValidSuitStringsTest()
        {
            List<string> expected = new List<string>();
            List<string> actual;

            actual = Card.ValidSuitStrings();
            expected.AddRange(new string[] { "C", "D", "H", "S", "U", "CLUBS", "DIAMONDS", "HEARTS", "SPADES", "UNKNOWN" });

            Assert.IsFalse(actual.Contains("Y"));

            foreach (string s in expected)
            {
                Assert.IsTrue(actual.Contains(s));
            }

            foreach (string s in actual)
            {
                Assert.IsTrue(expected.Contains(s));
            }
        }

        /// <summary>
        ///A test for ValidRankStrings
        ///</summary>
        [TestMethod()]
        public void ValidRankStringsTest()
        {
            List<string> expected = new List<string>();
            List<string> actual;

            expected.AddRange(new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "U"});
            foreach (string s in System.Enum.GetNames(typeof(Rank)))
            {
                expected.Add(s);
            }

            actual = Card.ValidRankStrings();

            // negative test case
            Assert.IsFalse(actual.Contains("B"));

            // positive test case
            foreach (string s in actual)
            {
                Assert.IsTrue(expected.Contains(s));
            }

            foreach (string s in expected)
            {
                Assert.IsTrue(actual.Contains(s));
            }
        }
    }
}

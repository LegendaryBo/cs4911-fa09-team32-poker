using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Card target = new Card(Suit.CLUBS, Rank.TWO);
            Assert.AreEqual(false, target.IsWild);
            target = new Card(Suit.UNKNOWN, Rank.TWO);
            Assert.AreEqual(true, target.IsWild);
            target = new Card(Suit.CLUBS, Rank.UNKNOWN);
            Assert.AreEqual(true, target.IsWild);
            target = new Card(Suit.UNKNOWN, Rank.UNKNOWN);
            Assert.AreEqual(true, target.IsWild);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Card target = new Card(Suit.SPADES, Rank.ACE);
            string expected = "AS";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Suit.CLUBS, Rank.EIGHT);
            expected = "8C";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Suit.CLUBS, Rank.TEN);
            expected = "TC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Suit.CLUBS, Rank.JACK);
            expected = "JC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Suit.CLUBS, Rank.QUEEN);
            expected = "QC";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            target = new Card(Suit.CLUBS, Rank.KING);
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
            Assert.AreEqual(true, (new Card(Suit.SPADES, Rank.ACE) != new Card(Suit.SPADES, Rank.UNKNOWN)));
            Assert.AreEqual(false, (new Card(Suit.SPADES, Rank.ACE) != new Card(Suit.SPADES, Rank.ACE)));
        }

        /// <summary>
        ///A test for op_Equality
        ///</summary>
        [TestMethod()]
        public void op_EqualityTest()
        {
            Assert.AreEqual(false, (new Card(Suit.SPADES, Rank.ACE) == new Card(Suit.SPADES, Rank.UNKNOWN)));
            Assert.AreEqual(true, (new Card(Suit.SPADES, Rank.ACE) == new Card(Suit.SPADES, Rank.ACE)));
        }
    }
}

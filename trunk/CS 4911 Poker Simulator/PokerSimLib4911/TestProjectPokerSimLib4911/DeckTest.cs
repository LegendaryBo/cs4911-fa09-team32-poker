using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProjectPokerSimLib4911
{
    
    
    /// <summary>
    ///This is a test class for DeckTest and is intended
    ///to contain all DeckTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DeckTest
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

        ///// <summary>
        /////A test for OrderHand
        /////</summary>
        //[TestMethod()]
        //public void OrderHandTest()
        //{
        //    List<Card> hand = new List<Card>();
        //    List<Card> expected = new List<Card>();

        //    // create an un-ordered hand
        //    hand.Add(new Card(Suit.CLUB, Rank.ACE));
        //    hand.Add(new Card(Suit.CLUB, Rank.TEN));
        //    hand.Add(new Card(Suit.CLUB, Rank.TWO));
        //    hand.Add(new Card(Suit.CLUB, Rank.THREE));
        //    hand.Add(new Card(Suit.CLUB, Rank.KING));
        //    hand.Add(new Card(Suit.CLUB, Rank.SEVEN));
        //    hand.Add(new Card(Suit.CLUB, Rank.FIVE));

        //    // create the ordered hand
        //    expected.Add(new Card(Suit.CLUB, Rank.TWO));
        //    expected.Add(new Card(Suit.CLUB, Rank.THREE));
        //    expected.Add(new Card(Suit.CLUB, Rank.FIVE));
        //    expected.Add(new Card(Suit.CLUB, Rank.SEVEN));
        //    expected.Add(new Card(Suit.CLUB, Rank.TEN));
        //    expected.Add(new Card(Suit.CLUB, Rank.KING));
        //    expected.Add(new Card(Suit.CLUB, Rank.ACE));        // notice that the ACE is the highest ranking card

        //    // order the un-ordered hand
        //    Deck.OrderHandAscending(ref hand);

        //    for (int i = 0; i < hand.Count; i++)
        //    {
        //        Assert.AreEqual(hand[i].Suit, expected[i].Suit);
        //        Assert.AreEqual(hand[i].Rank, expected[i].Rank);
        //    }
        //}
    }
}

using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System;

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

        /// <summary>
        ///A test for MakeFreshDeck
        ///</summary>
        [TestMethod()]
        public void MakeFreshDeckTest()
        {
            Card[] deckArray;
            Card[] defaultDeck = this.GetDefaultDeck();

            Deck.Instance.Shuffle();
            Deck.Instance.MakeFreshDeck();
            deckArray = Deck.Instance.ToArray();

            for (int i = 0; i < 52; ++i)
            {
                Assert.AreEqual(defaultDeck[i], deckArray[i]);
            }
        }

        private Card[] GetDefaultDeck()
        {
            Card[] cards = new Card[52];
            
            // outer loop for suits
            for (int i = 0; i < 4; ++i)
            {
                //inner loop for ranks
                for (int j = 0; j < 13; ++j)
                {
                    cards[i * 13 + j] = new Card((Rank)j, (Suit)i);
                    Console.WriteLine((Rank)j + " of " + (Suit)i);
                }
            }

            return cards;
        }

        /// <summary>
        ///A test for MakeShuffledDeck
        ///</summary>
        [TestMethod()]
        public void MakeShuffledDeckTest()
        {
            Card[] shuffledDeckArray;
            Card[] defaultDeck = this.GetDefaultDeck();
            int matches = 0;

            Deck.Instance.MakeShuffledDeck();
            shuffledDeckArray = Deck.Instance.ToArray();

            Assert.AreEqual(52, shuffledDeckArray.Length);
            for (int i = 0; i < 52; ++i)
            {
                if (defaultDeck[i] == shuffledDeckArray[i])
                {
                    matches++;
                }
            }

            if (matches > 3)
            {
                Assert.Inconclusive("The shuffled deck contained at least three cards in their natural positions.");
            }
        }

        /// <summary>
        ///A test for InsertCards
        ///</summary>
        [TestMethod()]
        public void InsertCardsTest()
        {
            Card[] cards = { new Card(Rank.UNKNOWN, Suit.CLUBS), new Card(Rank.UNKNOWN, Suit.DIAMONDS) };
            Deck.Instance.InsertCards(cards);
            Assert.AreEqual(true, Deck.Instance.Contains(new Card(Rank.UNKNOWN, Suit.CLUBS)));
            Assert.AreEqual(true, Deck.Instance.Contains(new Card(Rank.UNKNOWN, Suit.DIAMONDS)));
            Deck.Instance.InsertCards(new Card(Rank.UNKNOWN, Suit.HEARTS));
            Assert.AreEqual(true, Deck.Instance.Contains(new Card(Rank.UNKNOWN, Suit.HEARTS)));
            Assert.AreEqual(false, Deck.Instance.Contains(new Card(Rank.UNKNOWN, Suit.SPADES)));
        }

        /// <summary>
        ///A test for RemoveCard
        ///</summary>
        [TestMethod()]
        public void RemoveCardTest()
        {
            Card card = new Card(Rank.ACE, Suit.SPADES);
            bool actual;
            actual = Deck.Instance.RemoveCard(card);
            Assert.AreEqual(true, actual);
            actual = Deck.Instance.RemoveCard(new Card(Rank.UNKNOWN, Suit.UNKNOWN));
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        ///A test for DealCard
        ///</summary>
        [TestMethod()]
        public void DealCardTest()
        {
            Deck.Instance.MakeFreshDeck();
            Card expected = new Card(Rank.TWO, Suit.CLUBS);
            Card actual;
            actual = Deck.Instance.DealCard();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(false, Deck.Instance.Contains(expected));
        }

        /// <summary>
        ///A test for Contains
        ///</summary>
        [TestMethod()]
        public void ContainsTest()
        {
            Card invalid = new Card(Rank.ACE, Suit.UNKNOWN);
            Card valid = new Card(Rank.ACE, Suit.CLUBS);
            bool actual;
            actual = Deck.Instance.Contains(valid);
            Assert.AreEqual(true, actual);
            actual = Deck.Instance.Contains(invalid);
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        ///A test for HasBeenDealt
        ///</summary>
        [TestMethod()]
        public void HasBeenDealtTest()
        {
            Deck.Instance.MakeFreshDeck();
            Card card = new Card(Rank.TWO, Suit.CLUBS);
            bool actual;
            actual = Deck.Instance.HasBeenDealt(card);
            Assert.AreEqual(false, actual);
            Deck.Instance.DealCard();
            actual = Deck.Instance.HasBeenDealt(card);
            Assert.AreEqual(true, actual);
        }
    }
}

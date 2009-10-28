using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerSimulation;

namespace TestPokerSimulation
{
    /// <summary>
    /// Summary description for HandGeneratorTest
    /// </summary>
    [TestClass]
    public class HandGeneratorTest
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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void genRFTest()
        {
            Hand hand = new Hand();

            Hand testHand = HandGenerator.genRF(5);
            //Hand testHand5 = HandGenerator.genFL();
            //Hand testHand6 = HandGenerator.genST();
            //Hand testHand7 = HandGenerator.genTK();
            //Hand testHand8 = HandGenerator.genTP();
            //Hand testHand9 = HandGenerator.genOP();
            //Hand testHand0 = HandGenerator.genHC();

            Assert.IsTrue(testHand.HasRoyalFlush(5, Suit.CLUBS, ref hand) || testHand.HasRoyalFlush(5, Suit.SPADES, ref hand) || testHand.HasRoyalFlush(5, Suit.HEARTS, ref hand) || testHand.HasRoyalFlush(5, Suit.DIAMONDS, ref hand));
            Assert.IsFalse(testHand.HasFourOfAKind(Rank.ACE, ref hand));
            Assert.IsFalse(testHand.HasFullHouse(Rank.ACE, Rank.KING, ref hand));

        }

        [TestMethod]
        public void genSFTest()
        {
            Hand hand = new Hand();

            Hand testHand = HandGenerator.genSF(5);

            Assert.IsTrue(
                testHand.HasStraightFlush(5, Rank.TEN, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.NINE, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.EIGHT, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SEVEN, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SIX, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FIVE, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FOUR, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.THREE, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.TWO, Suit.CLUBS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.ACE, Suit.CLUBS, ref hand) ||

                testHand.HasStraightFlush(5, Rank.TEN, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.NINE, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.EIGHT, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SEVEN, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SIX, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FIVE, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FOUR, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.THREE, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.TWO, Suit.SPADES, ref hand) ||
                testHand.HasStraightFlush(5, Rank.ACE, Suit.SPADES, ref hand) ||

                testHand.HasStraightFlush(5, Rank.TEN, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.NINE, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.EIGHT, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SEVEN, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SIX, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FIVE, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FOUR, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.THREE, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.TWO, Suit.HEARTS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.ACE, Suit.HEARTS, ref hand) ||

                testHand.HasStraightFlush(5, Rank.TEN, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.NINE, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.EIGHT, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SEVEN, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.SIX, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FIVE, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.FOUR, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.THREE, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.TWO, Suit.DIAMONDS, ref hand) ||
                testHand.HasStraightFlush(5, Rank.ACE, Suit.DIAMONDS, ref hand)
                );
            Assert.IsFalse(testHand.HasFourOfAKind(Rank.ACE, ref hand));
            Assert.IsFalse(testHand.HasFullHouse(Rank.ACE, Rank.KING, ref hand));
        }

        [TestMethod]
        public void genFKTest()
        {
            Hand hand = new Hand();

            Hand testHand3 = HandGenerator.genFK(5);

            Assert.IsTrue(
                testHand3.HasFourOfAKind(Rank.ACE, ref hand) ||
                testHand3.HasFourOfAKind(Rank.KING, ref hand) ||
                testHand3.HasFourOfAKind(Rank.QUEEN, ref hand) ||
                testHand3.HasFourOfAKind(Rank.JACK, ref hand) ||
                testHand3.HasFourOfAKind(Rank.TEN, ref hand) ||
                testHand3.HasFourOfAKind(Rank.NINE, ref hand) ||
                testHand3.HasFourOfAKind(Rank.EIGHT, ref hand) ||
                testHand3.HasFourOfAKind(Rank.SEVEN, ref hand) ||
                testHand3.HasFourOfAKind(Rank.SIX, ref hand) ||
                testHand3.HasFourOfAKind(Rank.FIVE, ref hand) ||
                testHand3.HasFourOfAKind(Rank.FOUR, ref hand) ||
                testHand3.HasFourOfAKind(Rank.THREE, ref hand) ||
                testHand3.HasFourOfAKind(Rank.TWO, ref hand)
                );
        }

        [TestMethod]
        public void genFHTest()
        {
            Hand hand = new Hand();

            Hand testHand4 = HandGenerator.genFH(5);

            Assert.IsTrue(
                testHand4.HasFullHouse(Rank.ACE, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.ACE, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.KING, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.KING, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.QUEEN, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.QUEEN, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.JACK, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.JACK, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.TEN, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.TEN, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.NINE, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.NINE, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.EIGHT, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.EIGHT, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.SEVEN, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.SEVEN, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.SIX, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.SIX, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.FIVE, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.FIVE, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.FOUR, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.FOUR, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.THREE, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.ACE, ref hand) ||
                testHand4.HasFullHouse(Rank.THREE, Rank.TWO, ref hand) ||

                testHand4.HasFullHouse(Rank.TWO, Rank.KING, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.QUEEN, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.JACK, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.TEN, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.NINE, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.EIGHT, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.SEVEN, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.SIX, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.FIVE, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.FOUR, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.THREE, ref hand) ||
                testHand4.HasFullHouse(Rank.TWO, Rank.ACE, ref hand)
                );
        }


    }
}
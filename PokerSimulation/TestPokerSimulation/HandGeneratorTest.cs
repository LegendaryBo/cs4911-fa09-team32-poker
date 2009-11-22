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
        public void makeRoyalFlushTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand = PokerHand.makeRoyalFlush(5);
            //PokerHand testHand5 = HandGenerator.genFL();
            //PokerHand testHand6 = HandGenerator.genST();
            //PokerHand testHand7 = HandGenerator.genTK();
            //PokerHand testHand8 = HandGenerator.genTP();
            //PokerHand testHand9 = HandGenerator.genOP();
            //PokerHand testHand0 = HandGenerator.genHC();

            Assert.IsTrue(testHand.HasRoyalFlush(5, Suit.CLUBS, ref hand) || testHand.HasRoyalFlush(5, Suit.SPADES, ref hand) || testHand.HasRoyalFlush(5, Suit.HEARTS, ref hand) || testHand.HasRoyalFlush(5, Suit.DIAMONDS, ref hand));
            Assert.IsFalse(testHand.HasFourOfAKind(Rank.ACE, ref hand));
            Assert.IsFalse(testHand.HasFullHouse(Rank.ACE, Rank.KING, ref hand));

        }

        [TestMethod]
        public void makeStraightFlushTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand = PokerSimulation.PokerHand.makeStraightFlush(5);

            Assert.IsTrue(testHand.HasStraightFlush());
            Assert.IsFalse(testHand.HasFourOfAKind(Rank.ACE, ref hand));
            Assert.IsFalse(testHand.HasRoyalFlush());
        }

        [TestMethod]
        public void makeFourOfAKindTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand3 = PokerSimulation.PokerHand.makeFourOfAKind(5);

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
        public void makeFullHouseTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand4 = PokerSimulation.PokerHand.makeFullHouse(5);

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

        [TestMethod]
        public void makeFlushTest()
        {
            //PokerHand straightFlush = new PokerHand();

            PokerHand testHand5 = PokerSimulation.PokerHand.makeFlush(5);

            Assert.IsTrue(testHand5.HasFlush());
        }

        [TestMethod]
        public void makeStraightTest()
        {
            //PokerHand straightFlush = new PokerHand();

            PokerHand testHand6 = PokerSimulation.PokerHand.makeStraight(5);

            Assert.IsTrue(testHand6.HasStraight());
        }

        [TestMethod]
        public void makeOnePairTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand7 = PokerSimulation.PokerHand.makeOnePair(5);

            Assert.IsTrue(
                testHand7.HasTwoOfAKind( Rank.ACE, ref hand)||
                testHand7.HasTwoOfAKind( Rank.TWO, ref hand)||
                testHand7.HasTwoOfAKind( Rank.THREE, ref hand)||
                testHand7.HasTwoOfAKind( Rank.FOUR, ref hand)||
                testHand7.HasTwoOfAKind( Rank.FIVE, ref hand)||
                testHand7.HasTwoOfAKind( Rank.SIX, ref hand)||
                testHand7.HasTwoOfAKind( Rank.SEVEN, ref hand)||
                testHand7.HasTwoOfAKind( Rank.EIGHT, ref hand)||
                testHand7.HasTwoOfAKind( Rank.NINE, ref hand)||
                testHand7.HasTwoOfAKind( Rank.TEN, ref hand)||
                testHand7.HasTwoOfAKind( Rank.JACK, ref hand)||
                testHand7.HasTwoOfAKind( Rank.QUEEN, ref hand)||
                testHand7.HasTwoOfAKind( Rank.KING, ref hand)
                );
        }
        [TestMethod]
        public void makeTwoPairTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand8 = PokerSimulation.PokerHand.makeTwoPair(5);

            Assert.IsTrue(
                testHand8.HasTwoPair(Rank.ACE, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.ACE, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.KING, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.KING, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.QUEEN, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.QUEEN, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.JACK, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.JACK, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.TEN, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.TEN, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.NINE, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.NINE, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.EIGHT, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.EIGHT, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.SEVEN, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.SEVEN, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.SIX, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.SIX, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.FIVE, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.FIVE, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.FOUR, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.FOUR, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.THREE, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.ACE, ref hand) ||
                testHand8.HasTwoPair(Rank.THREE, Rank.TWO, ref hand) ||

                testHand8.HasTwoPair(Rank.TWO, Rank.KING, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.QUEEN, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.JACK, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.TEN, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.NINE, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.EIGHT, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.SEVEN, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.SIX, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.FIVE, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.FOUR, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.THREE, ref hand) ||
                testHand8.HasTwoPair(Rank.TWO, Rank.ACE, ref hand));
        }
        [TestMethod]
        public void makeThreeOfAKindTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand9 = PokerSimulation.PokerHand.makeThreeOfAKind(5);

            Assert.IsTrue(
                testHand9.HasThreeOfAKind( Rank.ACE, ref hand)||
                testHand9.HasThreeOfAKind(Rank.TWO, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.THREE, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.FOUR, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.FIVE, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.SIX, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.SEVEN, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.EIGHT, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.NINE, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.TEN, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.JACK, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.QUEEN, ref hand) ||
                testHand9.HasThreeOfAKind(Rank.KING, ref hand)
                );
        }
        [TestMethod]
        public void makeHighCardTest()
        {
            PokerHand hand = new PokerHand();

            PokerHand testHand0 = PokerSimulation.PokerHand.makeHighCard(5);
            //it's a high-card if it doesn't have at least a pair, straight, or flush.
            Assert.IsFalse(
                testHand0.HasTwoOfAKind( Rank.ACE, ref hand)||
                testHand0.HasTwoOfAKind( Rank.TWO, ref hand)||
                testHand0.HasTwoOfAKind( Rank.THREE, ref hand)||
                testHand0.HasTwoOfAKind( Rank.FOUR, ref hand)||
                testHand0.HasTwoOfAKind( Rank.FIVE, ref hand)||
                testHand0.HasTwoOfAKind( Rank.SIX, ref hand)||
                testHand0.HasTwoOfAKind( Rank.SEVEN, ref hand)||
                testHand0.HasTwoOfAKind( Rank.EIGHT, ref hand)||
                testHand0.HasTwoOfAKind( Rank.NINE, ref hand)||
                testHand0.HasTwoOfAKind( Rank.TEN, ref hand)||
                testHand0.HasTwoOfAKind( Rank.JACK, ref hand)||
                testHand0.HasTwoOfAKind( Rank.QUEEN, ref hand)||
                testHand0.HasTwoOfAKind( Rank.KING, ref hand)
                );

            Assert.IsFalse(testHand0.HasStraight());

            Assert.IsFalse(testHand0.HasFlush());
        }

    }
}
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
        private const int TEST_ITERATIONS = 100000;

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

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand = PokerHand.MakeRoyalFlush(7);
                Assert.IsTrue(testHand.HasRoyalFlush());
            }
        }

        [TestMethod]
        public void makeStraightFlushTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand = PokerSimulation.PokerHand.MakeStraightFlush(7);

                Assert.IsTrue(testHand.HasStraightFlush());
                Assert.IsFalse(testHand.HasRoyalFlush());
            }
        }

        [TestMethod]
        public void makeFourOfAKindTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand3 = PokerSimulation.PokerHand.MakeFourOfAKind(7);

                Assert.IsTrue(testHand3.HasFourOfAKind());
                Assert.IsFalse(testHand3.HasStraightFlush());
            }
        }

        [TestMethod]
        public void makeFullHouseTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand4 = PokerSimulation.PokerHand.MakeFullHouse(7);

                Assert.IsTrue(testHand4.HasFullHouse());
                Assert.IsFalse(testHand4.HasStraightFlush());
                Assert.IsFalse(testHand4.HasFourOfAKind());
            }
        }

        [TestMethod]
        public void makeFlushTest()
        {
            //PokerHand straightFlush = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand5 = PokerSimulation.PokerHand.MakeFlush(7);

                Assert.IsTrue(testHand5.HasFlush());
                Assert.IsFalse(testHand5.HasFullHouse());
                Assert.IsFalse(testHand5.HasStraightFlush());
                Assert.IsFalse(testHand5.HasFourOfAKind());
            }
        }

        [TestMethod]
        public void makeStraightTest()
        {
            //PokerHand straightFlush = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand6 = PokerSimulation.PokerHand.MakeStraight(7);
                Assert.IsTrue(testHand6.HasStraight());
                Assert.IsFalse(testHand6.HasFourOfAKind());
                Assert.IsFalse(testHand6.HasFullHouse());
                Assert.IsFalse(testHand6.HasFlush());
            }
        }

        [TestMethod]
        public void makeOnePairTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand7 = PokerSimulation.PokerHand.MakeOnePair(7);

                Assert.IsTrue(testHand7.HasPair());
                Assert.IsFalse(testHand7.HasStraight());
                Assert.IsFalse(testHand7.HasFlush());
                Assert.IsFalse(testHand7.HasThreeOfAKind());
                Assert.IsFalse(testHand7.HasTwoPair());
            }
        }

        [TestMethod]
        public void makeTwoPairTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand8 = PokerSimulation.PokerHand.MakeTwoPair(7);

                Assert.IsTrue(testHand8.HasTwoPair());
                Assert.IsFalse(testHand8.HasStraight());
                Assert.IsFalse(testHand8.HasFlush());
                Assert.IsFalse(testHand8.HasThreeOfAKind());
            }
        }
        
        [TestMethod]
        public void makeThreeOfAKindTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand9 = PokerSimulation.PokerHand.MakeThreeOfAKind(7);

                Assert.IsTrue(testHand9.HasThreeOfAKind());
                Assert.IsFalse(testHand9.HasStraight());
                Assert.IsFalse(testHand9.HasFlush());
                Assert.IsFalse(testHand9.HasFullHouse());
                Assert.IsFalse(testHand9.HasFourOfAKind());
            }
        }

        [TestMethod]
        public void makeHighCardTest()
        {
            PokerHand hand = new PokerHand();

            for (int i = 0; i < TEST_ITERATIONS; i++)
            {
                PokerHand testHand0 = PokerSimulation.PokerHand.MakeHighCard(7);
                //it's a high-card if it doesn't have at least a pair, straight, or flush.
                Assert.IsFalse(testHand0.HasPair());
                Assert.IsFalse(testHand0.HasStraight());
                Assert.IsFalse(testHand0.HasFlush());
            }
        }

    }
}
using PokerSimLib4911;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProjectPokerSimLib4911
{
    
    
    /// <summary>
    ///This is a test class for LoggerTest and is intended
    ///to contain all LoggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LoggerTest
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
        ///A test for Write
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            Logger target = Logger.Instance;
            string someString = "This is a test string.";
            string expected = "This is a test string.";
            string actual;

            target.MakeNewLog();
            actual = target.Write(someString);

            // the logger adds a date/time to the beginning of the line, followed by a tab
            // strip the date/time+tab off and return the rest of the string
            actual = actual.Split('\t')[1];

            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Print
        ///</summary>
        [TestMethod()]
        public void PrintTest()
        {
            string expected = "This is a test string.\r\n";
            string actual;
            Logger.Instance.MakeNewLog();
            Logger.Instance.Write("This is a test string.");
            actual = Logger.Instance.Print();
            if (actual != null)
            {
                // the logger adds a date/time to the beginning of the line, followed by a tab
                // strip the date/time+tab off and return the rest of the string
                actual = actual.Split('\t')[1];
            }
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for WriteInfo
        ///</summary>
        [TestMethod()]
        public void WriteInfoTest()
        {
            string someString = "This is a test string.";
            string expected = "INFO:";
            string actual;
            Logger.Instance.MakeNewLog();
            actual = Logger.Instance.WriteInfo(someString);
            if (actual != null)
            {
                // the logger adds a date/time to the beginning of the line, followed by a tab
                // strip the date/time+tab off and return the rest of the string
                actual = actual.Split('\t')[1];
            }
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for WriteError
        ///</summary>
        [TestMethod()]
        public void WriteErrorTest()
        {
            string someString = "This is a test string.";
            string expected = "ERROR:";
            string actual;
            Logger.Instance.MakeNewLog();
            actual = Logger.Instance.WriteError(someString);
            if (actual != null)
            {
                // the logger adds a date/time to the beginning of the line, followed by a tab
                // strip the date/time+tab off and return the rest of the string
                actual = actual.Split('\t')[1];
            }
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for WriteCritical
        ///</summary>
        [TestMethod()]
        public void WriteCriticalTest()
        {
            string someString = "This is a test string.";
            string expected = "CRITICAL:";
            string actual;
            Logger.Instance.MakeNewLog();
            actual = Logger.Instance.WriteCritical(someString);
            if (actual != null)
            {
                // the logger adds a date/time to the beginning of the line, followed by a tab
                // strip the date/time+tab off and return the rest of the string
                actual = actual.Split('\t')[1];
            }
            Assert.AreEqual(expected, actual);
        }
    }
}

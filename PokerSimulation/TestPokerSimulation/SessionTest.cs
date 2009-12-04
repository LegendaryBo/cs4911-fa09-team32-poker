using PokerSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
namespace TestPokerSimulation
{
    
    
    /// <summary>
    ///This is a test class for SessionTest and is intended
    ///to contain all SessionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SessionTest
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
        /////A test for UserSaysOverwrite
        /////Commented out because the test requires user input.
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("PokerSimulation.dll")]
        //public void UserSaysOverwriteTest()
        //{
        //    Session_Accessor target = new Session_Accessor();
        //    string filename = "choose_no.sim";
        //    bool expected = false;
        //    bool actual;
        //    actual = target.UserSaysOverwrite(filename);
        //    Assert.AreEqual(expected, actual);

        //    filename = "choose_yes.sim";
        //    expected = true;
        //    actual = target.UserSaysOverwrite(filename);
        //    Assert.AreEqual(expected, actual);
        //}

        ///// <summary>
        /////A test for TryOpenFile
        /////Commented out because the test requires user input.
        /////</summary>
        //[TestMethod()]
        //public void TryOpenFileTest()
        //{
        //    Session target = new Session();
        //    string path = "fake_path";
        //    string testPath = Directory.GetCurrentDirectory() + "\\tests";
        //    bool expected = false;
        //    bool actual;
        //    actual = target.TryOpenFile(path);
        //    Assert.AreEqual(expected, actual);

        //    Directory.CreateDirectory(testPath);
        //    MakeTestFiles(testPath);

        //    path = "";
        //    expected = false;
        //    actual = target.TryOpenFile(path);
        //    Assert.AreEqual(expected, actual);

        //    path = null;
        //    expected = false;
        //    actual = target.TryOpenFile(path);
        //    Assert.AreEqual(expected, actual);

        //    path = testPath + "\\subj001_session001.txt";
        //    actual = target.TryOpenFile(path);
        //    expected = true;
        //    Assert.AreEqual(expected, actual);

        //    path = testPath + "\\subj001_session001.in";
        //    actual = target.TryOpenFile(path);
        //    expected = true;
        //    Assert.AreEqual(expected, actual);

        //    path = testPath + "\\subj002_session001.txt";
        //    actual = target.TryOpenFile(path);
        //    expected = false;
        //    Assert.AreEqual(expected, actual);

        //    path = testPath + "\\test.nop";
        //    actual = target.TryOpenFile(path);
        //    expected = false;
        //    Assert.AreEqual(expected, actual);

        //    File.Delete(testPath + "\\subj001_session001.txt");
        //    File.Delete(testPath + "\\subj001_session001.in");
        //    File.Delete(testPath + "\\subj002_session001.txt");
        //    File.Delete(testPath + "\\test.nop");
        //}

        private void MakeTestFiles(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(path + "\\subj001_session001.txt", FileMode.CreateNew)))
                {
                    sw.WriteLine("5\trf\tno");
                    sw.WriteLine("7\tst\tyes\tblock 1");
                    sw.WriteLine("7\tfh\tyes\tblock 2");
                    sw.WriteLine("7\tfk\tno\tshould not show this");
                }
                using (StreamWriter sw = new StreamWriter(new FileStream(path + "\\subj001_session001.in", FileMode.CreateNew)))
                {
                    sw.WriteLine("5\trf\tno");
                    sw.WriteLine("7\tst\tyes\tblock 1");
                    sw.WriteLine("7\tfh\tyes\tblock 2");
                    sw.WriteLine("7\tfk\tno\tshould not show this");
                }
                using (StreamWriter sw = new StreamWriter(new FileStream(path + "\\subj002_session001.txt", FileMode.CreateNew)))
                {
                    sw.WriteLine("nonsense");
                }
                using (StreamWriter sw = new StreamWriter(new FileStream(path + "\\test.nop", FileMode.CreateNew)))
                {
                    sw.WriteLine("");
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        ///A test for TryGetSubjectAndSessionIDFromPath
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PokerSimulation.dll")]
        public void TryGetSubjectAndSessionIDFromPathTest()
        {
            Session_Accessor target = new Session_Accessor();
            string path = "incorrectpath.inc";
            string subjectID = string.Empty;
            string subjectIDExpected = string.Empty;
            string sessionID = string.Empty;
            string sessionIDExpected = string.Empty;
            bool expected = false;
            bool actual;
            actual = target.TryGetSubjectAndSessionIDFromPath(path, out subjectID, out sessionID);
            Assert.AreEqual(subjectIDExpected, subjectID);
            Assert.AreEqual(sessionIDExpected, sessionID);
            Assert.AreEqual(expected, actual);

            path = "correct_path.sim";
            subjectIDExpected = "correct";
            sessionIDExpected = "path";
            expected = true;
            actual = target.TryGetSubjectAndSessionIDFromPath(path, out subjectID, out sessionID);
            Assert.AreEqual(subjectIDExpected, subjectID);
            Assert.AreEqual(sessionIDExpected, sessionID);
            Assert.AreEqual(expected, actual);

            path = "correct_path.alt";
            subjectIDExpected = "correct";
            sessionIDExpected = "path";
            expected = true;
            actual = target.TryGetSubjectAndSessionIDFromPath(path, out subjectID, out sessionID);
            Assert.AreEqual(subjectIDExpected, subjectID);
            Assert.AreEqual(sessionIDExpected, sessionID);
            Assert.AreEqual(expected, actual);
        }
    }
}

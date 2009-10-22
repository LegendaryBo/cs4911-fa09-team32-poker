using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PokerSimulation
{
    public partial class TestingForm : Form
    {
        Hand testHand = new Hand();
        HandGenerator testGenerator = new HandGenerator();
        string generatedText = "";
        int handCount = 0;
        string id = "";
        string session = "";
        string filename = "";
        string lastFilename = "";
        bool newFile = false;
        TextWriter tw = new StreamWriter("hand.txt");

        public TestingForm()
        {
            InitializeComponent();
            Deck.Instance.MakeShuffledDeck();
        }

        #region Methods

        private Hand generateHand()
        {
            generatedText = generateTextBox.Text;
            int numOfCards = (int)numCards.Value;

            testHand = new Hand();
            if((generatedText.Length == 0) || generatedText.Equals("Enter Hand"))
            {
                MessageBox.Show("You must enter a valid two-letter hand");
            }
            else if (generatedText.ToUpper().Equals("HC"))
                testHand = PokerSimulation.HandGenerator.genHC(numOfCards);
            else if (generatedText.ToUpper().Equals("OP"))
                testHand = PokerSimulation.HandGenerator.genOP(numOfCards);
            else if (generatedText.ToUpper().Equals("TP"))
                testHand = PokerSimulation.HandGenerator.genTP(numOfCards);
            else if (generatedText.ToUpper().Equals("TK"))
                testHand = PokerSimulation.HandGenerator.genTK(numOfCards);
            else if (generatedText.ToUpper().Equals("ST"))
                testHand = PokerSimulation.HandGenerator.genST(numOfCards);
            else if (generatedText.ToUpper().Equals("FL"))
                testHand = PokerSimulation.HandGenerator.genFL(numOfCards);
            else if (generatedText.ToUpper().Equals("FH"))
                testHand = PokerSimulation.HandGenerator.genFH(numOfCards);
            else if (generatedText.ToUpper().Equals("SF"))
                testHand = PokerSimulation.HandGenerator.genSF(numOfCards);
            else if (generatedText.ToUpper().Equals("FK"))
                testHand = PokerSimulation.HandGenerator.genFK(numOfCards);
            else if (generatedText.ToUpper().Equals("RF"))
                testHand = PokerSimulation.HandGenerator.genRF(numOfCards);
            else
                MessageBox.Show("You must enter a valid two-letter hand");

            handCount++;
            writeHandToFile();

            return testHand;
        }

        //Having trouble in here differentiating between making a new file,
        //then typing in a file that exists.
        //If the file doesn't exist, then make it
        //else, see if it's a newly created file.
        //If so, don't fire the error dialog
        //If it's not newly created, fire the error dialog
        //But for future files, when do I change newFile to false?
        private bool setupFile()
        {
            //Set the id and session text.
            id = idTextBox.Text;
            session = sessionTextBox.Text;
            filename = id + session + ".txt";

            //check to see if the current filename is different from the last filename
            //If it is, you either will make a new file, or have an existing file
            if (lastFilename == filename)
                newFile = false;

            //If the file doesn't already exist
            if (!File.Exists(filename))
            {
                tw = new StreamWriter(filename);
                newFile = true;
                return true;
            }
            else
            {
                //set lastFilename to filename for the next generation
                lastFilename = filename;

                if (newFile)
                    return true;
                else
                {
                    MessageBox.Show("File with that User ID and Session # already exists");
                    return false;
                }
            }
        }

        private void writeHandToFile()
        {
            // write a line of text to the file
            if (tw == null)
            {
                TextWriter newTw = new StreamWriter("hand.txt");
                tw = newTw;
            }
            else
            {
                //Text at the top of the file containing:
                // Name/ID
                // Session #
                // Maybe Block Number, have to figure out where to put that.
                if (handCount == 1)
                {
                    tw.WriteLine(idTextBox.Text);
                    tw.WriteLine("Session " + sessionTextBox.Text);
                    tw.WriteLine();
                }
                tw.WriteLine("Trial " + handCount);
                tw.WriteLine("Hand: " + testHand.ToString());
                tw.WriteLine("Guess: ");
                tw.WriteLine("Time: ");
                tw.WriteLine();
            }
        }

        private void writeFileClosing()
        {
            tw.WriteLine("End Session " + session);
            tw.WriteLine("End " + id);
        }

        #endregion

        #region Events

        private void generateButton_Click(object sender, EventArgs e)
        {
            //Sets up the file to write to
            if (setupFile())
            {
                testCardsList.Items.Clear();
                testHand = generateHand();

                if (testHand.Count != 0)
                {
                    testCardsList.Items.AddRange(testHand.ToArray());
                }
            }
        }

        private void generateTextBox_Enter(object sender, EventArgs e)
        {
            generateTextBox.Clear();
        }

        private void generateTextBox_Leave(object sender, EventArgs e)
        {
            if (generateTextBox.Text.Equals("")) 
                generateTextBox.Text = "Enter Hand";
        }

        private void TestingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the stream
            writeFileClosing();
            tw.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void idTextBox_Click(object sender, EventArgs e)
        {
            if(idTextBox.Text.Equals("ID#"))
                idTextBox.Clear();
        }

        private void sessionTextBox_Click(object sender, EventArgs e)
        {
            if (sessionTextBox.Text.Equals("Session#"))
                sessionTextBox.Clear();
        }

        private void idTextBox_Leave(object sender, EventArgs e)
        {
            if (idTextBox.Text.Equals(""))
                idTextBox.Text = "ID#";
        }

        private void sessionTextBox_Leave(object sender, EventArgs e)
        {
            if (sessionTextBox.Text.Equals(""))
                sessionTextBox.Text = "Session#";
        }

        #endregion
    }
}

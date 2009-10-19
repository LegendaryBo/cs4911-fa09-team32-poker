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
    public partial class GuessForm : Form
    {
        Hand testHand = new Hand();
        Random rand = new Random(10);
        Random rand2 = new Random(2);
        int randNum;
        int numOfCards;
        int time = 0;

        string generatedText = "";
        int handCount = 0;
        string id = "";
        string session = "";
        string filename = "";
        string lastFilename = "";
        int lastFileCount = 0;
        bool newFile = false;
        TextWriter tw;

        public GuessForm()
        {
            InitializeComponent();
            Deck.Instance.MakeShuffledDeck();
            if(tw == null)
                tw = new StreamWriter("hand.txt");
        }

        #region Methods

        private void generateTrial()
        {
            //Make sure that ID and session text boxes are valid
            if (setupFile())
            {
                //Make sure that the guess TextBox is not empty
                if (guessTextBox.Text != "")
                {
                    enableTextBoxes();
                    cardsListBox.Items.Clear();
                    testHand = generateHand();
                    startTimer();

                    if (testHand.Count != 0)
                    {
                        cardsListBox.Items.AddRange(testHand.ToArray());
                    }

                    writeHandToFile();
                }
            }
        }

        private Hand generateHand()
        {
            randNum = rand.Next(0,10);
            numOfCards = rand2.Next(0,3) + 5;
            switch(randNum)
            {
                case 0:
                    testHand = PokerSimulation.HandGenerator.genHC(numOfCards);
                    break;
                case 1:
                    testHand = PokerSimulation.HandGenerator.genOP(numOfCards);
                    break;
                case 2:
                    testHand = PokerSimulation.HandGenerator.genTP(numOfCards);
                    break;
                case 3:
                    testHand = PokerSimulation.HandGenerator.genTK(numOfCards);
                    break;
                case 4:
                    testHand = PokerSimulation.HandGenerator.genST(numOfCards);
                    break;
                case 5:
                    testHand = PokerSimulation.HandGenerator.genFL(numOfCards);
                    break;
                case 6:
                    testHand = PokerSimulation.HandGenerator.genFH(numOfCards);
                    break;
                case 7:
                    testHand = PokerSimulation.HandGenerator.genSF(numOfCards);
                    break;
                case 8:
                    testHand = PokerSimulation.HandGenerator.genFK(numOfCards);
                    break;
                case 9:
                    testHand = PokerSimulation.HandGenerator.genRF(numOfCards);
                    break;
            }
            handCount++;

            return testHand;
        }

        private bool setupFile()
        {
            //Set the id and session text.
            id = idTextBox.Text;
            session = sessionTextBox.Text;

            //validate id and session
            if (id == "" || id == "ID#" || session == "" || session == "Session#")
            {
                MessageBox.Show("Please enter a valid ID and Session");
                return false;
            }

            //construct the filename
            filename = id + session + ".txt";

            //check to see if the current filename is different from the last filename
            //If it is, you either will make a new file, or have an existing file
            if (lastFilename == filename)
            {
                newFile = false;
                lastFileCount++;
            }
            else
                lastFileCount = 0;

            //If the file doesn't already exist
            if (!File.Exists(filename))
            {
                tw = new StreamWriter(filename);
                newFile = true;
                lastFileCount = 0;
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
                    if (lastFileCount != 0)
                        return true;
                    else
                    {
                        MessageBox.Show("File with that User ID and Session # already exists");
                        return false;
                    }
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
                    tw.WriteLine("Trial " + handCount);
                    tw.WriteLine("Hand: " + testHand.ToString());
                }
                else
                {
                    tw.WriteLine("Guess: " + guessTextBox.Text);
                    tw.WriteLine("Time: " + timerTextBox.Text);
                    tw.WriteLine();
                    tw.WriteLine("Trial " + handCount);
                    tw.WriteLine("Hand: " + testHand.ToString());
                }
            }
        }

        private void writeFileClosing()
        {
            tw.WriteLine();
            tw.WriteLine("End Session " + session);
            tw.WriteLine("End " + id);
        }

        private void startTimer()
        {
            time = 0;
            guessTimer.Start();
        }

        private void enableTextBoxes()
        {
            guessTextBox.ReadOnly = false;
        }

        #endregion

        private void generateButton_Click(object sender, EventArgs e)
        {
            generateTrial();
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            writeFileClosing();
            tw.Close();
            this.Close();
        }

        private void guessTimer_Tick(object sender, EventArgs e)
        {
            time++;
            timerTextBox.Text = "" + time;
        }

        private void GuessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the stream
            tw.Close();
        }

        private void guessTextBox_Click(object sender, EventArgs e)
        {
            guessTextBox.Clear();
        }

        private void guessTextBox_Leave(object sender, EventArgs e)
        {
            if (guessTextBox.Text.Equals(""))
                guessTextBox.Text = "Enter Hand";
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

        private void idTextBox_Click(object sender, EventArgs e)
        {
            idTextBox.Clear();
        }

        private void sessionTextBox_Click(object sender, EventArgs e)
        {
            sessionTextBox.Clear();
        }

        private void guessTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generateTrial();
                guessTextBox.Clear();
            }
        }
    }

}

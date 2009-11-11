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
        List<Hand> handList = new List<Hand>();
        List<string> handStringList = new List<string>();
        Random rand = new Random();
        Random rand2 = new Random();
        int randNum;
        int numOfCards;
        double time = 0;
        TimeSpan reactionTime;
        DateTime startTime;
        DateTime stopTime;
        bool reactionPressed = false;

        string generatedHand = "";
        string feedbackText = "";
        int handCount = 0;
        string id = "";
        string session = "";
        string filename = "";
        string lastFilename = "";
        int lastFileCount = 0;
        bool newFile = false;
        bool inputFile = false;
        TextWriter tw;
        TextReader tr;

        public GuessForm()
        {
            InitializeComponent();
            Deck.Instance.MakeShuffledDeck();
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
                    //Feedback generated here because we are asking about the last hand that was generated.
                    feedbackText = writeFeedback();
                    enableTextBoxes();
                    cardsListBox.Items.Clear();
                    //If we're reading from an input file
                    if (inputFile)
                    {
                        testHand = returnHandFromHandList(handList);
                    }
                    else
                    {
                        testHand = generateHand();
                    }
                    startTimer();
                    reactionPressed = false;

                    if (testHand.Count != 0)
                    {
                        cardsListBox.Items.AddRange(testHand.ToArray());
                       
                    }
                    else
                    {
                        MessageBox.Show("Finished");
                        generateButton.Enabled = false;
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
                    testHand = PokerSimulation.PokerHand.makeHighCard(numOfCards);
                    generatedHand = "HC";
                    break;
                case 1:
                    testHand = PokerSimulation.PokerHand.makeOnePair(numOfCards);
                    generatedHand = "OP";
                    break;
                case 2:
                    testHand = PokerSimulation.PokerHand.makeTwoPair(numOfCards);
                    generatedHand = "TP";
                    break;
                case 3:
                    testHand = PokerSimulation.PokerHand.makeThreeOfAKind(numOfCards);
                    generatedHand = "TK";
                    break;
                case 4:
                    testHand = PokerSimulation.PokerHand.makeStraight(numOfCards);
                    generatedHand = "ST";
                    break;
                case 5:
                    testHand = PokerSimulation.PokerHand.makeFlush(numOfCards);
                    generatedHand = "FL";
                    break;
                case 6:
                    testHand = PokerSimulation.PokerHand.makeFullHouse(numOfCards);
                    generatedHand = "FH";
                    break;
                case 7:
                    testHand = PokerSimulation.PokerHand.makeStraightFlush(numOfCards);
                    generatedHand = "SF";
                    break;
                case 8:
                    testHand = PokerSimulation.PokerHand.makeFourOfAKind(numOfCards);
                    generatedHand = "FK";
                    break;
                case 9:
                    testHand = PokerSimulation.PokerHand.makeRoyalFlush(numOfCards);
                    generatedHand = "RF";
                    break;
            }
            handCount++;

            return testHand;
        }

        private string chooseInputFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            dialog.Title = "Select a text Input File";

            return (dialog.ShowDialog() == DialogResult.OK) ? dialog.FileName : null;

        }

        private List<Hand> compileHandList(string inputFile)
        {
            //Initialize StreamReader
            tr = new StreamReader(inputFile);

            //Intialize handList
            List<Hand> handList = new List<Hand>();
            string hand = "";
            string line = tr.ReadLine().Trim();

            while(line != "end")
            {
                hand = line;
                handStringList.Add(hand.Substring(0, 2));
                handList.Add(generateHandFromInputFile(hand));
                line = tr.ReadLine().Trim();
            }

            handList.Add(new Hand());
            handStringList.Add("");
            tr.Close();
            return handList;
        }

        private Hand generateHandFromInputFile(string hand)
        {
            Hand returnHand = new Hand();

            //This assumes that the hand from the file will look like: 
            //"[2-letter Hand][Number of cards to generate (5-7)]"
            //Ex. FL6 for a flush hand of 6 cards.
            switch (hand.Substring(0,2).ToUpper())
            {
                case "HC":
                    returnHand = PokerSimulation.PokerHand.makeHighCard(int.Parse(hand.Substring(2, 1)));
                    break;
                case "OP":
                    returnHand = PokerSimulation.PokerHand.makeOnePair(int.Parse(hand.Substring(2, 1)));
                    break;
                case "TP":
                    returnHand = PokerSimulation.PokerHand.makeTwoPair(int.Parse(hand.Substring(2, 1)));
                    break;
                case "TK":
                    returnHand = PokerSimulation.PokerHand.makeThreeOfAKind(int.Parse(hand.Substring(2, 1)));
                    break;
                case "ST":
                    returnHand = PokerSimulation.PokerHand.makeStraight(int.Parse(hand.Substring(2, 1)));
                    break;
                case "FL":
                    returnHand = PokerSimulation.PokerHand.makeFlush(int.Parse(hand.Substring(2, 1)));
                    break;
                case "FH":
                    returnHand = PokerSimulation.PokerHand.makeFullHouse(int.Parse(hand.Substring(2, 1)));
                    break;
                case "SF":
                    returnHand = PokerSimulation.PokerHand.makeStraightFlush(int.Parse(hand.Substring(2, 1)));
                    break;
                case "FK":
                    returnHand = PokerSimulation.PokerHand.makeFourOfAKind(int.Parse(hand.Substring(2, 1)));
                    break;
                case "RF":
                    returnHand = PokerSimulation.PokerHand.makeRoyalFlush(int.Parse(hand.Substring(2, 1)));
                    break;
            }
            return returnHand;
        }

        private Hand returnHandFromHandList(List<Hand> handList)
        {
            //handList.Add(new Hand());
            testHand = handList.ElementAt(handCount);
            generatedHand = handStringList.ElementAt(handCount);    
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
                    tw.WriteLine("Guess: " + guessTextBox.Text.ToUpper());
                    tw.WriteLine("Feedback: " + feedbackText);
                    tw.WriteLine("Reaction Time: " + reactionTime.TotalSeconds + ", Response Time: " + timerTextBox.Text);
                    tw.WriteLine();
                    if (testHand.Count != 0)
                    {
                        tw.WriteLine("Trial " + handCount);
                        tw.WriteLine("Hand: " + testHand.ToString());
                    }
                }
            }
        }

        private void writeFileClosing()
        {
            if (tw != null)
            {
                tw.WriteLine();
                tw.WriteLine("End Session " + session);
                tw.WriteLine("End " + id);
            }
        }

        private string writeFeedback()
        {
            string guess = guessTextBox.Text;
            string feedback = "Incorrect. The correct answer was ";

            if(generatedHand.Equals(""))
            {
                feedback = "Feedback posted here.";
            }
            else if (guess.ToUpper().Equals(generatedHand))
            {
                feedback = "Correct";
            }
            else if (generatedHand.Equals("finished"))
            {
                feedback = "Finished";
            }
            else
            {
                feedback += generatedHand;
            }

            feedbackTextBox.Text = feedback;
            return feedback;
        }

        private void startTimer()
        {
            time = 0;
            guessTimer.Start();
            startTime = DateTime.Now;
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
            time += 1;
            timerTextBox.Text = time.ToString("00.00"); ;
        }

        private void GuessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close the stream
            if(tw != null)
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
            if (!reactionPressed)
            {
                stopTime = DateTime.Now;
                reactionTime = stopTime - startTime;
                reactionPressed = true;
                reactionTextBox.Text = "" + reactionTime.TotalSeconds;
            }
            if (e.KeyCode == Keys.Enter)
            {
                generateTrial();
                guessTextBox.Clear();
            }
        }

        private void inputButton_Click(object sender, EventArgs e)
        {
            inputFile = true;
            handList = compileHandList(chooseInputFile());
            inputButton.Enabled = false;
        }
    }

}

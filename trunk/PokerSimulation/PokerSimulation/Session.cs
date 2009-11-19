using System;
using System.Collections.Generic;
using System.IO;

namespace PokerSimulation
{
    public class Session
    {
        #region Fields

        private const string _inDirectory = @"\in";
        private const string _rawDirectory = @"\raw";
        private const string _outDirectory = @"\out";
        private const string _defaultDirectory = @"\default";
        private const string _inPath = _inDirectory + @"\in_";
        private const string _rawPath = _rawDirectory + @"\raw_";
        private const string _outPath = _outDirectory + @"\out_";
        private const string _defaultPath = _defaultDirectory + @"\raw_default.txt";
        private string _defaultRaw = "START BLOCK 1" + Environment.NewLine + "ST5" 
            + Environment.NewLine + "ST6" + Environment.NewLine + "ST7" + Environment.NewLine 
            + "ST5" + Environment.NewLine + "END BLOCK" + Environment.NewLine + "START BLOCK 2" 
            + Environment.NewLine + "FL7" + Environment.NewLine + "FL6" + Environment.NewLine 
            + "FL5" + Environment.NewLine + "END BLOCK";
        private string _settingPath;
        private StreamReader _fileReader;
        private StreamWriter _fileWriter;

        public const string BLOCK_START = "START BLOCK";
        public const string BLOCK_END = "END BLOCK";

        #endregion

        #region Properties

        public string Subject_ID { get; internal set; }
        public string Session_ID { get; internal set; }
        public List<Block> Blocks { get; internal set; }
        public bool IsDefault { get; internal set; }

        #endregion

        #region Constructors

        public Session()
        {
            IsDefault = false;
            Blocks = new List<Block>();
            if (Properties.Settings.Default.defaultRawFile.Equals(""))
            {
                _settingPath = Directory.GetCurrentDirectory() + _defaultPath;
                Properties.Settings.Default.defaultRawFile = _settingPath;
            }
            else
                _settingPath = Properties.Settings.Default.defaultRawFile;

            Properties.Settings.Default.Save();
        }

        public Session(string file)
            : this()
        {
        }

        public Session(string subject_id, string session_id)
            : this()
        {
            Subject_ID = subject_id;
            Session_ID = session_id;
            string pathEnd = subject_id + "_" + session_id + ".txt";

            if (!Directory.Exists(Directory.GetCurrentDirectory() + _outDirectory))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + _outDirectory);
            else if (File.Exists(Directory.GetCurrentDirectory() + _outPath + pathEnd))
                throw (new Exception("Session has been completed. Use the dialog on the right to override existing results."));

            LoadInputFile(pathEnd);
        }

        #endregion

        #region Methods
        private void LoadInputFile(string pathEnd)
        {
            try
            {
                _fileReader = new StreamReader(Directory.GetCurrentDirectory() + _inPath + pathEnd);

                string line = null;
                int id = 0;
                Block currBlock = null;

                while ((line = _fileReader.ReadLine()) != null)
                {
                    if (line.Equals("")) continue;
                    if (line.StartsWith(BLOCK_START))
                    {
                        string[] s = line.Split(" ".ToCharArray());
                        currBlock = new Block(long.Parse(s[s.Length - 1]));
                    }
                    else if (line.StartsWith(BLOCK_END))
                    {
                        Blocks.Add(currBlock);
                        currBlock = null;
                    }
                    else
                    {
                        StringReader sr = new StringReader(line);

                        Hand h = new Hand();
                        id++;

                        int num = int.Parse("" + (char)sr.Read());

                        for (int i = 0; i < num; i++)
                        {
                            sr.Read();
                            Rank rank = this.ParseRank((char)sr.Read());
                            Suit suit = this.ParseSuit((char)sr.Read());

                            Card c = new Card(suit, rank);
                            h.InsertCard(c);
                        }
                        sr.Read();
                        currBlock.AddTrial(new Trial(id, h, num, (char)sr.Read() + "" + (char)sr.Read()));
                        sr.Close();
                    }
                }

                _fileReader.Close();
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + _inDirectory);

                this.LoadRawFile(pathEnd);
            }
            catch (FileNotFoundException e)
            {
                this.LoadRawFile(pathEnd);
            }
        }

        private void LoadRawFile(string pathEnd)
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + _rawPath + pathEnd;
                if (IsDefault)
                    path = _settingPath;

                _fileReader = new StreamReader(path);

                Block currBlock = null;

                string line;

                int id = 0;

                while ((line = _fileReader.ReadLine()) != null)
                {
                    if (line.Equals("")) continue;
                    if (line.StartsWith(BLOCK_START))
                    {
                        string[] s = line.Split(" ".ToCharArray());
                        currBlock = new Block(long.Parse(s[s.Length - 1]));
                    }
                    else if (line.StartsWith(BLOCK_END))
                    {
                        Blocks.Add(currBlock);
                        currBlock = null;
                    }
                    else
                    {
                        id++;

                        string nuts = line.Substring(0, 2).ToUpper();
                        int num = int.Parse(line.Substring(2, 1));

                        currBlock.AddTrial(new Trial(id, this.ParseNuts(nuts, num), num, nuts));
                    }
                }
                _fileReader.Close();

                this.WriteInputFile(pathEnd);
            }
            catch (DirectoryNotFoundException e)
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + _defaultDirectory);
                LoadDefaultRawFile(pathEnd);
            }
            catch (FileNotFoundException e)
            {
                if (IsDefault)
                    this.WriteDefaultFile();
                this.LoadDefaultRawFile(pathEnd);
            }
        }

        private void LoadDefaultRawFile(string pathEnd)
        {
            IsDefault = true;
            LoadRawFile(pathEnd);
        }

        private void WriteDefaultFile()
        {
            _fileWriter = new StreamWriter(Directory.GetCurrentDirectory() + _defaultPath);

            _fileWriter.Write(_defaultRaw);

            _fileWriter.Close();
        }

        private void WriteInputFile(string pathEnd)
        {
            _fileWriter = new StreamWriter(Directory.GetCurrentDirectory() + _inPath + pathEnd);

            foreach (Block b in Blocks)
            {
                _fileWriter.WriteLine(BLOCK_START + " " + b.Block_ID);
                foreach (Trial t in b.Trials)
                {
                    string result = "" + t.Number_of_cards;
                    foreach (Card c in t.Hand.Cards)
                    {
                        result += " " + c.ToString();
                    }
                    result += " " + t.Nuts;
                    _fileWriter.WriteLine(result);
                }
                _fileWriter.WriteLine(BLOCK_END);
            }

            _fileWriter.Close();
        }

        private PokerHand ParseNuts(string nuts, int num)
        {
            PokerHand returnHand = new PokerHand();
            switch (nuts)
            {
                case "HC":
                    returnHand = PokerSimulation.PokerHand.makeHighCard(num);
                    break;
                case "OP":
                    returnHand = PokerSimulation.PokerHand.makeOnePair(num);
                    break;
                case "TP":
                    returnHand = PokerSimulation.PokerHand.makeTwoPair(num);
                    break;
                case "TK":
                    returnHand = PokerSimulation.PokerHand.makeThreeOfAKind(num);
                    break;
                case "ST":
                    returnHand = PokerSimulation.PokerHand.makeStraight(num);
                    break;
                case "FL":
                    returnHand = PokerSimulation.PokerHand.makeFlush(num);
                    break;
                case "FH":
                    returnHand = PokerSimulation.PokerHand.makeFullHouse(num);
                    break;
                case "SF":
                    returnHand = PokerSimulation.PokerHand.makeStraightFlush(num);
                    break;
                case "FK":
                    returnHand = PokerSimulation.PokerHand.makeFourOfAKind(num);
                    break;
                case "RF":
                    returnHand = PokerSimulation.PokerHand.makeRoyalFlush(num);
                    break;
            }

            return returnHand;
        }

        private Suit ParseSuit(char s)
        {
            Suit suit = Suit.UNKNOWN;
            switch (s)
            {
                case 'S': suit = Suit.SPADES; break;
                case 'C': suit = Suit.CLUBS; break;
                case 'D': suit = Suit.DIAMONDS; break;
                case 'H': suit = Suit.HEARTS; break;
            }
            return suit;
        }

        private Rank ParseRank(char r)
        {
            Rank rank = Rank.UNKNOWN;
            switch (r)
            {
                case '2': rank = Rank.TWO; break;
                case '3': rank = Rank.THREE; break;
                case '4': rank = Rank.FOUR; break;
                case '5': rank = Rank.FIVE; break;
                case '6': rank = Rank.SIX; break;
                case '7': rank = Rank.SEVEN; break;
                case '8': rank = Rank.EIGHT; break;
                case '9': rank = Rank.NINE; break;
                case 'T': rank = Rank.TEN; break;
                case 'J': rank = Rank.JACK; break;
                case 'Q': rank = Rank.QUEEN; break;
                case 'K': rank = Rank.KING; break;
                case 'A': rank = Rank.ACE; break;
            }
            return rank;
        }

        private void AddBlock(Block b)
        {
            Blocks.Add(b);
        }

        private bool RemoveBlock(Block b)
        {
            return Blocks.Remove(b);
        }

        #endregion
    }
}

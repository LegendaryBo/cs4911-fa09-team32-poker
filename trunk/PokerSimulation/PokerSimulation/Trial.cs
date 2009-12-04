using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PokerSimulation
{
    public class Trial
    {
        private string _subjectID;
        private string _sessionID;
        private int _blockID;
        private int _trialID;
        private HandRank _handRank;
        private string _responseString;
        private string _blockTag;
        private HandRank _responseRank;
        private static Dictionary<string, HandRank> _stringToHandRankDictionary = new Dictionary<string, HandRank>();

        public PokerHand Hand { get; private set; }
        public string PokerHand
        {
            get
            {
                return Hand.ToString();
            }
        }
        public HandRank HandRank
        {
            get
            {
                return _handRank;
            }
            private set
            {
                _handRank = value;
            }
        }
        public int NumberOfCards { get; private set; }
        public string ResponseString
        {
            get
            {
                return _responseString;
            }

            set
            {
                string lookupString = value.Trim().ToUpper();

                if(_stringToHandRankDictionary.ContainsKey(lookupString))
                {
                    _responseRank = _stringToHandRankDictionary[lookupString];
                }

                _responseString = value;
            }
        }
        public TimeSpan FixationTime { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public TimeSpan ReactionTime { get; set; }

        static Trial()
        {
            BuildHandRankDictionary();
        }

        public Trial(string simLine)
        {
            string[] tokens = simLine.Split("\t".ToCharArray(), 8, StringSplitOptions.None);
            _subjectID = tokens[0].Trim();
            _sessionID = tokens[1].Trim();
            _blockID = int.Parse(tokens[2]);
            _trialID = int.Parse(tokens[3]);
            NumberOfCards = int.Parse(tokens[4]);

            Hand = new PokerHand();
            string[] cards = tokens[5].Trim().Split(",".ToCharArray());
            foreach (string c in cards)
            {
                Hand.InsertCard(new Card(c.Trim()));
            }

            _handRank = (HandRank)Enum.Parse(typeof(HandRank), tokens[6], true);
            _blockTag = tokens[7];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(_subjectID + "\t");
            sb.Append(_sessionID + "\t");
            sb.Append(_blockID + "\t");
            sb.Append(_trialID + "\t");
            sb.Append(NumberOfCards + "\t");
            sb.Append(Hand + "\t");
            sb.Append(_handRank + "\t");
            sb.Append(ResponseString + "\t");
            sb.Append(_responseRank + "\t");
            sb.Append((_responseRank != HandRank.None) + "\t");
            sb.Append((_handRank == _responseRank) + "\t");
            sb.Append(FixationTime.Milliseconds + "\t");
            sb.Append(ReactionTime.Milliseconds + "\t");
            sb.Append(ResponseTime.Milliseconds + "\t");

            return sb.ToString();
        }

        private static void BuildHandRankDictionary()
        {

            AddToHandRankDictionay(Properties.Settings.Default.RoyalStraightFlushIdentifiers.ToUpper(), HandRank.RoyalFlush);
            AddToHandRankDictionay(Properties.Settings.Default.StraightFlushIdentifiers.ToUpper(), HandRank.StraightFlush);
            AddToHandRankDictionay(Properties.Settings.Default.FourOfAKindIdentifiers.ToUpper(), HandRank.FourOfAKind);
            AddToHandRankDictionay(Properties.Settings.Default.FullHouseIdentifiers.ToUpper(), HandRank.FullHouse);
            AddToHandRankDictionay(Properties.Settings.Default.FlushIdentifiers.ToUpper(), HandRank.Flush);
            AddToHandRankDictionay(Properties.Settings.Default.StraightIdentifiers.ToUpper(), HandRank.Straight);
            AddToHandRankDictionay(Properties.Settings.Default.ThreeOfAKindIdentifiers.ToUpper(), HandRank.ThreeOfAKind);
            AddToHandRankDictionay(Properties.Settings.Default.TwoPairIdentifiers.ToUpper(), HandRank.TwoPair);
            AddToHandRankDictionay(Properties.Settings.Default.OnePairIdentifiers.ToUpper(), HandRank.OnePair);
            AddToHandRankDictionay(Properties.Settings.Default.HighCardIdentifiers.ToUpper(), HandRank.HighCard);
        }

        private static void AddToHandRankDictionay(string stringRepresentations, HandRank rank)
        {
            string[] representations = stringRepresentations.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string r in representations)
            {
                try
                {                   
                    _stringToHandRankDictionary.Add(r.Trim(), rank);
                }
                catch (ArgumentException)
                {
                    HandRank hr = _stringToHandRankDictionary[r.Trim()];
                    string error = "Cannot add the string representation: " + r.Trim() + " for " + rank + ". It is already mapped to a poker hand identifier: " + hr;
                    Logger.Instance.WriteError(error);
                    MessageBox.Show("There was a problem with a poker hand identifier token: " + r.Trim() + ".  Please refer to the error log: " + Logger.Instance.LogPath);
                }
            }
        }

        public bool Persist()
        {
            string filepath = Directory.GetCurrentDirectory() + "\\" + _subjectID + "_" + _sessionID + ".out";

            //if (File.Exists(filepath) && !UserSaysOverwrite(filepath))
            //{
            //    return false;
            //}

            try
            {
                using (StreamWriter sw = new StreamWriter(filepath, true))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(this);
                }
            }
            catch (Exception)
            {
                string error = "Could not write to the file: \"" + filepath + "\" .";
                Logger.Instance.WriteCritical(error);
                MessageBox.Show("Critical Error: Could not write to file.  Check log for details.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            return true;
        }

        private bool UserSaysOverwrite(string filename)
        {
            if (MessageBox.Show("Would you like to overwrite the existing file \"" + filename + "\"?", "File Already Exists",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

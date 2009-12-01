using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace PokerSimulation
{
    public class Session
    {
        private List<Trial> _trials = new List<Trial>();
        public delegate PokerHand PokerHandGeneratorDelegate(int numCards);
        private static Dictionary<string, PokerHandGeneratorDelegate> _generatorDictionary = new Dictionary<string,PokerHandGeneratorDelegate>();
        private int _trialIndex = 0;

        static Session()
        {
            BuildStringToPokerHandDictionary();
        }

        public Session() { }

        private static void BuildStringToPokerHandDictionary()
        {
            AddToPokerHandDictionary(Properties.Settings.Default.RoyalStraightFlushFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeRoyalFlush));
            AddToPokerHandDictionary(Properties.Settings.Default.StraightFlushFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeStraightFlush));
            AddToPokerHandDictionary(Properties.Settings.Default.FourOfAKindFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeFourOfAKind));
            AddToPokerHandDictionary(Properties.Settings.Default.FullHouseFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeFullHouse));
            AddToPokerHandDictionary(Properties.Settings.Default.FlushFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeFlush));
            AddToPokerHandDictionary(Properties.Settings.Default.StraightFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeStraight));
            AddToPokerHandDictionary(Properties.Settings.Default.ThreeOfAKindFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeThreeOfAKind));
            AddToPokerHandDictionary(Properties.Settings.Default.TwoPairFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeTwoPair));
            AddToPokerHandDictionary(Properties.Settings.Default.OnePairFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeOnePair));
            AddToPokerHandDictionary(Properties.Settings.Default.HighCardFileTokens.ToUpper(),
                                     new PokerHandGeneratorDelegate(PokerHand.MakeHighCard));
        }

        private static void AddToPokerHandDictionary(string stringRepresentations, PokerHandGeneratorDelegate generator)
        {
            string[] representations = stringRepresentations.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string r in representations)
            {
                try
                {
                    _generatorDictionary.Add(r.Trim(), generator);
                }
                catch (ArgumentException)
                {
                    PokerHandGeneratorDelegate g = _generatorDictionary[r.Trim()];
                    string error = "Cannot add the string representation: " + r.Trim() + " for the generator: " + generator + ". It is already mapped to a poker hand generator: " + g;
                    Logger.Instance.WriteError(error);
                    MessageBox.Show("There was a problem with a poker hand file token: " + r.Trim() + ".  Please refer to the error log: " + Logger.Instance.LogPath);
                }
            }
        }

        public bool TryOpenFile(string path)
        {
            if (File.Exists(path))
            {
                string fileExt = Path.GetExtension(path);

                if (fileExt == null || fileExt == string.Empty)
                {
                    string error = "The specified file: " + path + " does not have an extension.\n" +
                                   "Supported extensions are: .txt, .in, and .sim.";
                    Logger.Instance.WriteError(error);
                    MessageBox.Show(error);
                    return false;
                }
                else if (fileExt == ".txt" || fileExt == ".in")
                {
                    if (TryGenerateSimFile(path))
                    {
                        string filename = Path.GetFileNameWithoutExtension(path);
                        filename += ".sim";
                        return TryLoadSimFile(filename);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (fileExt == ".sim")
                {
                    return TryLoadSimFile(path);
                }
                else
                {
                    string error = "The specified file: " + path + " does not have a supported extension.\n" +
                                   "Supported extensions are: .txt, .in, and .sim.";
                    Logger.Instance.WriteError(error);
                    MessageBox.Show(error);
                    return false;
                }
            }
            else
            {
                string error = "The specified file: " + path + " does not exist.";
                Logger.Instance.WriteError(error);
                MessageBox.Show(error);
                return false;
            }
        }

        private bool TryGenerateSimFile(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path) + ".sim";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    if (File.Exists(filename))
                    {
                        if (!UserSaysOverwrite(filename))
                        {
                            Logger.Instance.WriteInfo("Did not create the .sim file " + filename + ", the file already exists.");
                            return false;
                        }
                        else
                        {
                            Logger.Instance.WriteInfo("Over-wrote the .sim file " + filename + ".");
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(new FileStream(filename, FileMode.Create)))
                    {
                        string subjectID;   // subjectID and sessionID are parsed from the file name
                        string sessionID;   // these will remain constant within this scope

                        int blockID = 0;    // blockID and trialID are auto-incremented for each respective new block
                        int trialID = 0;    // or new trial
                        string blockTag;

                        sw.AutoFlush = true;

                        // try to parse the subjectID and sessionID out of the file name
                        if (!TryGetSubjectAndSessionIDFromPath(path, out subjectID, out sessionID))
                        {
                            return false;
                        }

                        while (!sr.EndOfStream)
                        {
                            string[] inTokens = sr.ReadLine().ToUpper().Split("\t".ToCharArray(), 4, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < inTokens.Length; i++) inTokens[i] = inTokens[i].Trim();

                            blockTag = "";
                            int numCards;
                            string bestHand = "";
                            string hand = "";

                            if (DoBeginNewBlock(inTokens))
                            {
                                blockID++;
                                blockTag = GetBlockTag(inTokens);
                            }

                            if (!TryGetNumCards(inTokens, out numCards))
                            {
                                return false;
                            }

                            if (!TryGetBestHand(inTokens, numCards, out bestHand, out hand))
                            {
                                return false;
                            }

                            string simLine = subjectID + "\t" + sessionID + "\t" + blockID + "\t" + trialID + "\t" +
                                             numCards + "\t" + hand + "\t" + bestHand + "\t" + blockTag;
                            sw.WriteLine(simLine);

                            trialID++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                string error = "Could not generate the simulation file: An invalid path or file name was specified.";
                MessageBox.Show(error);
                Logger.Instance.WriteError(error);
                return false;
            }

            return true;
        }

        private bool TryGetBestHand(string[] inTokens, int numCards, out string bestHand, out string hand)
        {
            bestHand = "";
            hand = "";

            if (inTokens.Length >= 2)
            {
                if (!_generatorDictionary.ContainsKey(inTokens[1]))
                {
                    return false;
                }

                PokerHandGeneratorDelegate d = _generatorDictionary[inTokens[1]];
                PokerHand pokerHand = d.Invoke(numCards);
                hand = pokerHand.ToString();
                bestHand = pokerHand.MaxRank.ToString();
                return true;
            }

            return false;
        }

        private bool TryGetNumCards(string[] inTokens, out int numCards)
        {
            numCards = 0;

            if (inTokens.Length >= 1)
            {
                return int.TryParse(inTokens[0], out numCards);
            }

            return false;
        }

        private string GetBlockTag(string[] inTokens)
        {
            string blockTag = "";

            if (inTokens.Length == 4)
            {
                blockTag = inTokens[3];
            }

            return blockTag;
        }

        private bool DoBeginNewBlock(string[] inTokens)
        {
            if (inTokens.Length >= 3)
            {               
                if (inTokens[2] == "YES")
                {
                    return true;
                }
            }

            return false;
        }

        private bool TryGetSubjectAndSessionIDFromPath(string path, out string subjectID, out string sessionID)
        {
            string subjAndSessionId = Path.GetFileNameWithoutExtension(path);
            string[] subjAndSessionIdArr = subjAndSessionId.Split("_".ToCharArray(), 2, StringSplitOptions.RemoveEmptyEntries);

            subjectID = "";
            sessionID = "";

            if (subjAndSessionIdArr.Length != 2)
            {
                string error = "The specified filename format: " + subjAndSessionId + " is invalid.  The correct format is: <subject ID>_<session ID>.";
                Logger.Instance.WriteCritical(error);
                return false;
            }

            subjectID = subjAndSessionIdArr[0].ToUpper();
            sessionID = subjAndSessionIdArr[1].ToUpper();
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

        private bool TryLoadSimFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            _trials.Add(new Trial(sr.ReadLine()));
                        }
                    }
                }
                catch (Exception)
                {
                    string error = "Could not open the simulation file: An invalid path or file name was specified.";
                    MessageBox.Show(error);
                    Logger.Instance.WriteError(error);
                }

                return true;
            }
            return false;
        }

        public Trial GetNextTrial()
        {
            if (_trialIndex < _trials.Count)
            {
                return _trials[_trialIndex++];
            }
            else
            {
                return null;
            }
        }
    }
    
    //[Flags]
    //public enum HandRank
    //{
    //    None = 0,
    //    HighCard = 1,
    //    OnePair = 2,
    //    TwoPair = 4,
    //    ThreeOfAKind = 8,
    //    Straight = 16,
    //    Flush = 32,
    //    FullHouse = 64,
    //    FourOfAKind = 128,
    //    StraightFlush = 256,
    //    RoyalStraightFlush = 512
    //}

    //public struct MyEnum<T> : IEnumerable<T>
    //{
    //    private T _value;

    //    public MyEnum(T value)
    //    {
    //        _value = value;
    //    }

    //    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    //    {
    //        if (!typeof(T).IsSubclassOf(typeof(Enum)))
    //            throw new InvalidCastException("MyEnum must be a type of Enum");

    //        int[] allValues = (int[])Enum.GetValues(typeof(T));

    //        int intValues = Convert.ToInt32(_value);

    //        foreach (int i in allValues)
    //        {
    //            if ((i & intValues) != 0)
    //                yield return (T)Enum.ToObject(typeof(T), i);
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        return _value.ToString();
    //    }
    //}
}

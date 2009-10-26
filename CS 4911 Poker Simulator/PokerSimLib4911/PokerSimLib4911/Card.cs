using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerSimLib4911
{
    /// <summary>
    /// A card has a certain suit and rank, or is a wild card.
    /// </summary>
    public class Card
    {
        #region private fields

        private static Dictionary<String, Rank> _rankMappings = new Dictionary<string, Rank>();
        private static Dictionary<String, Suit> _suitMappings = new Dictionary<string, Suit>();

        #endregion

        #region public properties

        public Suit Suit { get; internal set; }
        public Rank Rank { get; internal set; }
        public bool IsWild
        {
            get
            {
                return (Suit == Suit.UNKNOWN || Rank == Rank.UNKNOWN);
            }
        }

        #endregion

        #region constructors

        static Card()
        {
            #region create dictionary for mapping rank strings to rank values

            // Add the short representations of each rank to the dictionary
            _rankMappings.Add("A", Rank.ACE);
            _rankMappings.Add("2", Rank.TWO);
            _rankMappings.Add("3", Rank.THREE);
            _rankMappings.Add("4", Rank.FOUR);
            _rankMappings.Add("5", Rank.FIVE);
            _rankMappings.Add("6", Rank.SIX);
            _rankMappings.Add("7", Rank.SEVEN);
            _rankMappings.Add("8", Rank.EIGHT);
            _rankMappings.Add("9", Rank.NINE);
            _rankMappings.Add("T", Rank.TEN);
            _rankMappings.Add("J", Rank.JACK);
            _rankMappings.Add("Q", Rank.QUEEN);
            _rankMappings.Add("K", Rank.KING);
            _rankMappings.Add("U", Rank.UNKNOWN);

            // Add each rank's full name to the dictionary
            String[] rankStrings = Enum.GetNames(typeof(Rank));
            foreach (string r in rankStrings)
            {
                _rankMappings.Add(r, (Rank)Enum.Parse(typeof(Rank), r));
            }

            #endregion

            #region create dictionary for mapping suit strings to suit values

            // Add the short representations of each suit to the dictionary
            _suitMappings.Add("C", Suit.CLUBS);
            _suitMappings.Add("D", Suit.DIAMONDS);
            _suitMappings.Add("H", Suit.HEARTS);
            _suitMappings.Add("S", Suit.SPADES);
            _suitMappings.Add("U", Suit.UNKNOWN);

            // Add each rank's full name to the dictionary
            String[] suitStrings = Enum.GetNames(typeof(Suit));
            foreach (string s in suitStrings)
            {
                _suitMappings.Add(s, (Suit)Enum.Parse(typeof(Suit), s));
            }

            #endregion
        }

        /// <summary>
        /// Constructor for a Card.
        /// </summary>
        /// <param name="rank">The Rank of the card.</param>
        /// <param name="suit">The Suit of the card.</param>
        public Card(Rank rank, Suit suit)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Constructor for a Card.
        /// </summary>
        /// <param name="rank">A single character representing the card's rank.</param>
        /// <param name="suit">A single character representing the card's suit.</param>
        public Card(char rank, char suit) : this(rank.ToString(), suit.ToString()) { }

        public Card(string rankAndSuit)
        {
            if (rankAndSuit.Length != 2)
            {
                throw new ArgumentException("A string of length " + rankAndSuit.Length + " is an invalid argument to the Card constructor.");
            }
            else
            {
                try
                {
                    SetRankAndSuit(rankAndSuit.Substring(0, 1), rankAndSuit.Substring(1, 1));
                }
                catch (ArgumentException)
                {
                    Logger.Instance.WriteCritical("Card constructor failed with argument:(" + rankAndSuit + ").");
                    throw;
                }
            }
        }

        /// <summary>
        /// Constructor for a Card.
        /// </summary>
        /// <param name="rank">The card's rank as a string.</param>
        /// <param name="suit">The card's suit as a string.</param>
        public Card(string rank, string suit)
        {
            try
            {
                SetRankAndSuit(rank, suit);
            }
            catch (ArgumentException)
            {
                Logger.Instance.WriteCritical("Card constructor failed with arguments:(" + rank + ", " + suit + ").");
                throw;
            }
        }

        #endregion

        private void SetRankAndSuit(string rank, string suit)
        {
            rank = rank.ToUpper();
            suit = suit.ToUpper();

            if (!_rankMappings.ContainsKey(rank))
            {
                throw new ArgumentException("The rank string {" + rank + "} is an invalid argument.");
            }
            else
            {
                Rank = _rankMappings[rank];
            }

            if (!_suitMappings.ContainsKey(suit))
            {
                throw new ArgumentException("The suit string {" + suit + "} is an invalid argument.");
            }
            else
            {
                Suit = _suitMappings[suit];
            }
        }

        /// <summary>
        /// Retrieves the valid string representations for a Card's rank.
        /// </summary>
        /// <returns>A List of valid strings for a Card's Rank.</returns>
        public static List<string> ValidRankStrings()
        {
            return _rankMappings.Keys.ToList<string>();
        }

        /// <summary>
        /// Retrieves the valid string representations for a Card's suit.
        /// </summary>
        /// <returns>A List of valid strings for a Card's Suit.</returns>
        public static List<string> ValidSuitStrings()
        {
            return _suitMappings.Keys.ToList<string>();
        }

        /// <summary>
        /// Checks if a string is a valid Rank.
        /// </summary>
        /// <param name="rank">The string to check.</param>
        /// <returns>True if the string is a valid Rank, otherwise false.</returns>
        public static bool IsValidRank(string rank)
        {
            rank = rank.ToUpper();

            if (_rankMappings.ContainsKey(rank))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if a string is a valid Suit.
        /// </summary>
        /// <param name="suit">The string to check.</param>
        /// <returns>True is the string is a valid Suit, otherwise false.</returns>
        public static bool IsValidSuit(string suit)
        {
            suit = suit.ToUpper();

            if (_suitMappings.ContainsKey(suit))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts the Card into a string.
        /// </summary>
        /// <returns>A string representation of the Card.</returns>
        public override string ToString()
        {
            string s = Suit.ToString().Substring(0, 1);
            string r;

            switch ((int)Rank)
            {
                case 8:
                    r = "T";
                    break;
                case 9:
                    r = "J";
                    break;
                case 10:
                    r = "Q";
                    break;
                case 11:
                    r = "K";
                    break;
                case 12:
                    r = "A";
                    break;
                default:
                    r = ((int)Rank + 2).ToString().Substring(0, 1);
                    break;
            }

            return r + s;
        }

        /// <summary>
        /// Compares the Card against a given Card to determine if their Rank and Suit are equal.
        /// </summary>
        /// <param name="obj">The Card object to compare.</param>
        /// <returns>True if the given Card's Suit and Rank are the same as the caller's, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType() && (this == (Card)obj);
        }

        /// <summary>
        /// Retrieves a hash code for the Card.
        /// </summary>
        /// <returns>An integer hash value.</returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode() |
                    Suit.GetHashCode() |
                    Rank.GetHashCode());
        }

        /// <summary>
        /// Compares two Cards for equality.  Two cards are equal if they are both null, or
        /// if they both have the same Rank and Suit values.
        /// </summary>
        /// <param name="x">A Card.</param>
        /// <param name="y">A Card.</param>
        /// <returns>True if the Cards are both null, or both have the same Rank and Suit, otherwise false.</returns>
        public static bool operator ==(Card x, Card y)
        {
            if ((Object)x == null && (Object)y == null)
            {
                return true;
            }
            else if ((Object)x == null || (Object)y == null)
            {
                return false;
            }

            return (x.Rank == y.Rank &&
                    x.Suit == y.Suit);
        }

        /// <summary>
        /// Determines if two Cards are not equal.
        /// </summary>
        /// <param name="x">A Card.</param>
        /// <param name="y">A Card.</param>
        /// <returns>True if the Cards, when compared with the == operator, return false.
        /// Otherwise, returns false.</returns>
        public static bool operator !=(Card x, Card y)
        {
            return !(x == y);
        }
    }

    /// <summary>
    /// The Suit enumeration contains all of the valid suit values for a Deck.
    /// </summary>
    public enum Suit
    {
        CLUBS,
        DIAMONDS,
        HEARTS,
        SPADES,
        UNKNOWN
    }

    /// <summary>
    /// The Rank enumeration contains all of the valid card values for a Deck, in ascending order.
    /// </summary>
    /// <remarks>
    /// Note that the lowest rank in this deck is 2 and the highest is an ace.
    /// </remarks>
    public enum Rank
    {
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        ACE,
        UNKNOWN
    }
}

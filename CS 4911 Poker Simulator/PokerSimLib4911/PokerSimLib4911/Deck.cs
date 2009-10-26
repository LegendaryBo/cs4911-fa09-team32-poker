using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PokerSimLib4911
{
    public class Deck
    {
        private static Deck _instance;
        private List<Card> _cards = new List<Card>();
        private List<Card> _dealtCards = new List<Card>();

        public static readonly int NUMBER_OF_RANKS = 13;
        public static readonly int NUMBER_OF_SUITS = 4;

        public static Deck Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Deck();
                }
                return _instance;
            }

            private set
            {
                _instance = value;
            }
        }

        private Deck() : this(Deck.NUMBER_OF_SUITS, Deck.NUMBER_OF_RANKS) { }

        private Deck(int numberOfSuits, int numberOfRanks)
        {
            // construct the deck
            // outer loop is for suit
            for (int i = 0; i < numberOfSuits; i++)
            {
                // inner loop is for rank
                for (int j = 0; j < numberOfRanks; j++)
                {
                    Card c = new Card((Rank)j, (Suit)i);
                    _cards.Add(c);
                }
            }
        }

        public void MakeFreshDeck()
        {
            // If the Deck _instance is null, the Deck.Instance property will re-create an
            // unshuffled standard deck the next time Deck.Instance is accessed
            _instance = null;
        }

        public void MakeShuffledDeck()
        {
            MakeFreshDeck();
            Deck.Instance.Shuffle();
        }

        public void Shuffle()
        {
            List<Card> tempCards = new List<Card>();
            Random rand = new Random();

            while (_cards.Count > 0)
            {
                // select a card from the cards left in the deck
                int randomIndex = rand.Next(_cards.Count);
                // add the selected card to the temp deck
                tempCards.Add(_cards[randomIndex]);
                // remove the selected card from the current deck
                _cards.RemoveAt(randomIndex);
            }

            // set the current deck to the shuffled deck
            _cards = tempCards;
        }

        public bool DealCard(Card card)
        {
            if (_cards.Remove(card))
            {
                _dealtCards.Add(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCard(Card card)
        {
            if (_cards.Remove(card))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReturnCard(Card card)
        {
            if (_dealtCards.Remove(card))
            {
                _cards.Add(card);
                this.Shuffle();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertCards(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                if (!_cards.Contains(c))
                {
                    _cards.Add(c);
                }
            }
        }

        public void DealCards(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                if (_cards.Contains(c))
                {
                    this.DealCard(c);
                }
            }
        }

        public void ReturnCards(params Card[] cards)
        {
            foreach (Card c in cards)
            {
                if (_dealtCards.Contains(c))
                {
                    this.ReturnCard(c);
                }
            }
        }

        public Card DealCard()
        {
            Card dealtCard = null;

            // we can only deal from a non-empty deck
            if (_cards.Count > 0)
            {
                // save the card to return
                dealtCard = _cards[0];
                // remove the card from the top of the deck
                _cards.RemoveAt(0);
                // add the removed card to the list of dealt cards
                _dealtCards.Add(dealtCard);
            }
            else
            {
                throw new InvalidOperationException("You cannot deal a card from an empty deck.");
            }

            return dealtCard;
        }

        public Card[] ToArray()
        {
            return _cards.ToArray();
        }

        public override string ToString()
        {
            StringBuilder deckString = new StringBuilder();

            deckString.Append("Deck Cards: ");
            for (int i = 0; i < _cards.Count; ++i)
            {
                if (i != 0)
                {
                    deckString.Append(", ");
                }
                deckString.Append(_cards.ElementAt(i));
            }

            deckString.Append("Dealt Cards: ");
            for (int i = 0; i < _dealtCards.Count; ++i)
            {
                if (i != 0)
                {
                    deckString.Append(", ");
                }
                deckString.Append(_dealtCards.ElementAt(i));
            }

            return deckString.ToString();
        }

        public bool Contains(Card card)
        {
            return _cards.Contains(card);
        }

        public bool HasBeenDealt(Card card)
        {
            return _dealtCards.Contains(card);
        }
    }
}


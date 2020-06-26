
using Humanizer; //NuGet Package Humanizer.Core
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CardGames
{
    public struct PlayingCard : IComparable, IComparable<PlayingCard>
    {
        public readonly CardSuit Suit;
        public readonly CardValue Value;

        public enum CardSuit { HEARTS, DIAMONDS, SPADES, CLUBS }
        public enum CardValue { ACE, TWO, THREE, FOUR, FIVE,
                               SIX, SEVEN, EIGHT, NINE, TEN,
                               JACK, QUEEN, KING }

        public PlayingCard(CardValue value, CardSuit suit)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString() => 
            $"{Value.Humanize(LetterCasing.LowerCase).Humanize(LetterCasing.Title)} " +
            $"of {Suit.Humanize(LetterCasing.LowerCase).Humanize(LetterCasing.Title)}";

        //{
        //    return $"{Value} of {Suit}";
        //}

        public int CompareTo(object obj)
        {
            if (!(obj is PlayingCard))
            {
                throw new ArgumentException($"{nameof(obj)} is not a {nameof(PlayingCard)}");
            }
            return CompareTo((PlayingCard)obj);
        }
       

        public int CompareTo([AllowNull] PlayingCard other)
        {
            int result = 0; //equivalent of saying result is "equal to" 
            //Ordering the cards by Suit, then by Value
            result = this.Suit.CompareTo(other.Suit) * 10
                    + this.Value.CompareTo(other.Value);
            return result;
        }
    }

    public class DeckOfCards
    {
        public int Count => 52;

        private IList<PlayingCard> _Cards;
        //public IEnumerable<PlayingCard> Cards => new List<PlayingCard>();
        public IEnumerable<PlayingCard> Cards => _Cards;
        private Random Rnd = new Random();
        public bool IsEmpty { get; private set; }

        public static DeckOfCards OpenNewDeck()
                => new DeckOfCards();

        public DeckOfCards()
        {
            List<PlayingCard> theDeck = new List<PlayingCard>();
            var suits = Enum.GetValues(typeof(PlayingCard.CardSuit));
            var cards = Enum.GetValues(typeof(PlayingCard.CardValue));
            foreach(var suit in suits)
            {
                foreach(var card in cards)
                {
                    theDeck.Add(new PlayingCard((PlayingCard.CardValue)card,
                                                (PlayingCard.CardSuit)suit));
                }
            }
            //alternative of type casting, specify type instead of var on the foreach
            //foreach (PlayingCard.CardSuit suit in suits)
            //{
            //    foreach (PlayingCard.CardValue card in cards)
            //    {
            //        theDeck.Add(new PlayingCard(card,suit));
            //    }
            //}
            _Cards = theDeck;
            IsEmpty = false;
        }

        public void Shuffle()
        {
            int index;
            for (int i = 0; i < 1000; i++)
            {
                // Grab the top card
                PlayingCard card = _Cards[0];
                //remove that card from the deck
                _Cards.RemoveAt(0);
                //randomly generate a value of where to replace the card in the deck
                // values will be 0 to 51
                index = Rnd.Next(_Cards.Count);
                //insert the card in the collection at position index
                //cards in the collection that are beyond the index position will be 
                //   pushed down ie  postion index 33 moves current cards 33-51 to be
                //   34 -52
                _Cards.Insert(index, card);
            }
        }

        public PlayingCard DrawCard()
        {
            
            if (IsEmpty)
            {
                throw new NoDrawException();
            }

            PlayingCard card = _Cards[0];
            _Cards.RemoveAt(0);
            if (_Cards.Count == 0)
            {
                IsEmpty = true;
            }
            return card;
        }
    }

    
}

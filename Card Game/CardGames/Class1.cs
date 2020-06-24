using Humanizer; //NuGet Package Humanizer.Core
using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public struct PlayingCard
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
    }

    public class DeckOfCards
    {
        public int Count => 52;

        public IEnumerable<PlayingCard> Cards => new List<PlayingCard>();

        public bool IsEmpty;

        public static DeckOfCards OpenNewDeck()
                => new DeckOfCards();


    }
}

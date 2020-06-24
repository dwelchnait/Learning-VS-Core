using CardGames;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

// will allow me to access enum without overly long names.
using static CardGames.PlayingCard.CardSuit;
using static CardGames.PlayingCard.CardValue;

namespace CardGame.Specs
{
    public class A_Playing_Card_Must
    {
        // Field for the Subject Under Test (sut)
        PlayingCard playingCard = new PlayingCard(FIVE, HEARTS);
        [Fact]
        public void Track_Supplied_Suit()
        {
            playingCard.Suit.Should().Be(HEARTS);
        }
        [Fact]
        public void Track_Supplied_Value()
        {
            playingCard.Value.Should().Be(FIVE);
        }

        [Fact]
        public void Express_As_Meaningful_String()
        {
            playingCard.ToString().Should().Be("Five of Hearts");
        }

        [Fact]
        public void Contain_Full_Range_Of_Card_Suits()
        {
            var range = new string[] { "HEARTS", "DIAMONDS", "SPADES", "CLUBS" };
            var CardSuitNames = Enum.GetNames(typeof(PlayingCard.CardSuit));
            //CardSuitNames.Should().Contain(range); //Passes though order did not match : order not important
            CardSuitNames.Should().ContainInOrder(range); //Fails beacuse order did not match: order is important

        }

        [Fact]
        public void Contain_Full_Range_Of_Card_Values()
        {
            var range = new string[] { "ACE", "TWO", "THREE", "FOUR", "FIVE",
                               "SIX", "SEVEN", "EIGHT", "NINE", "TEN",
                               "JACK", "QUEEN", "KING" };
            var CardValueNames = Enum.GetNames(typeof(PlayingCard.CardValue));
            CardValueNames.Should().ContainInOrder(range);
        }

       
   
    }     
    public class A_Deck_Of_Cards_Must
    {
        DeckOfCards deck =
            DeckOfCards.OpenNewDeck();

        [Fact]
        public void Open_With_52_Cards()
        {
            deck.Count.Should().Be(52);
            deck.Cards.Count().Should().Be(deck.Count);
        }

        [Fact]
        public void Not_Be_Empty_When_Opened()
        {
            deck.IsEmpty.Should().BeFalse();
        }

        [Fact]
        public void Not_Have_Duplicate_Cards()
        {
            var cards = deck.Cards;
            cards.Should().OnlyHaveUniqueItems();
        }
    }
}

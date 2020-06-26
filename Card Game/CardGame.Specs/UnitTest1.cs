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

        [Fact]
        public void Open_With_Cards_In_Order()
        {
            var cards = deck.Cards;
            cards.Should().BeInAscendingOrder();
        }

        [Fact]
        public void Shuffle_Cards_Into_A_Random_Order()
        {
            deck.Shuffle();
            var cards = deck.Cards;
            //does not check "true" randomness just that it is not
            //   in the original order.
            cards.Should().NotBeInAscendingOrder();
        }

        [Fact]
        public void Draw_The_Top_Card_From_The_Deck()
        {
            var expectedCard =
                new PlayingCard(ACE, HEARTS);
            PlayingCard card = deck.DrawCard();
            card.Should().NotBeNull().And.Be(expectedCard);
        }

        [Fact]
        public void Remove_The_Card_From_The_Deck_When_Drawn()
        {
            var expectedCard =
                new PlayingCard(ACE, HEARTS);
            deck.DrawCard();
            deck.Cards.Should().NotContain(expectedCard);
        }
    
        // TODO: What happens when the last card is drawn?
        [Fact]
        public void Draw_The_Last_Card()
        {
            int decksize = deck.Count;
            for (int i = 0; i < decksize; i++)
            {
                deck.DrawCard();
            }
            Assert.True(deck.IsEmpty);
        }
        // TODO: What happens if I draw from an empty deck?
        [Fact]
        public void Will_Throw_NoDraw_When_Empty_Deck_Is_Drawn()
        {
            int decksize = deck.Count;
            for (int i = 0; i < decksize; i++)
            {
                deck.DrawCard();
            }
            deck.DrawCard();
//            Assert.Throws<NoDrawException>(()=> deck.DrawCard());
        }
    }

    public class The_GoFish_Game_Must
    {

    }
    public class The_Player_Must
    {

    }
}

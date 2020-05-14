using System;
using System.Collections.Generic;
using System.Linq;
using LostCities.Enums;
using LostCities.GameData;

namespace LostCities.Managers
{
    public class CardManager
    {
        private const int CardsTotalCount = 60;

        internal static Stack<Card> GenerateAndShuffleDeck()
        {
            var deck = new Stack<Card>();

            var cardsInOrder = new List<Card>(CardsTotalCount);

            var numericCardValueNames = Enum.GetNames(typeof(CardValue)).Where(n => n != nameof(CardValue.Investment));
            foreach (var cardColorName in Enum.GetNames(typeof(CardColor)))
            {
                var color = (CardColor)Enum.Parse(typeof(CardColor), cardColorName);

                foreach (var numericCardValueName in numericCardValueNames)
                {
                    var card = new Card();
                    card.Color = color;
                    card.Value = (CardValue)Enum.Parse(typeof(CardValue), numericCardValueName);
                    cardsInOrder.Add(card);
                }

                AddThreeInvestmentCards(cardsInOrder, color);
            }

            if (cardsInOrder.Count != CardsTotalCount)
            {
                throw new Exception("Incorrect number of cards in ordered list");
            }

            // add cards to stack/deck in random order

            Random random = new Random();

            while (cardsInOrder.Count > 0)
            {
                var randomIndex = random.Next(0, cardsInOrder.Count - 1);
                var randomCard = cardsInOrder[randomIndex];
                cardsInOrder.RemoveAt(randomIndex);
                deck.Push(randomCard);
            }

            if (deck.Count != CardsTotalCount)
            {
                throw new Exception("Incorrect number of cards in basic deck");
            }

            return deck;
        }

        private static void AddThreeInvestmentCards(List<Card> cardList, CardColor color)
        {
            for (int i = 0; i < 3; i++)
            {
                var investmentCard = new Card();
                investmentCard.Color = color;
                investmentCard.Value = CardValue.Investment;
                cardList.Add(investmentCard);
            }
        }
    }
}
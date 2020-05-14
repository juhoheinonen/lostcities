using System.Collections.Generic;

namespace LostCities.GameData
{
    public class Hand
    {
        List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }
    }
}
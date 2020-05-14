using System;
using System.Collections.Generic;
using LostCities.Managers;

namespace LostCities.GameData
{
    public class GameSituationContainer
    {
        public Guid GameId { get; set; }

        public HumanPlayer Human { get; set; }

        public ComputerPlayer Computer { get; set; }

        // todo: maybe make a class for BasicDeck
        public Stack<Card> BasicDeck { get; set; }

        private GameSituationContainer()
        {

        }

        public static GameSituationContainer InitializeNewGame()
        {
            var gameSituationContainer = new GameSituationContainer();

            var basicDeck = CardManager.GenerateAndShuffleDeck();

            gameSituationContainer.GameId = Guid.NewGuid();

            gameSituationContainer.Human = new HumanPlayer();

            gameSituationContainer.Computer = new ComputerPlayer();

            gameSituationContainer.DealCardsToPlayers();

            return gameSituationContainer;
        }

        private void DealCardsToPlayers()
        {
            for (int i = 0; i < Constants.Constants.CardsToDeal; i++)
            {                
                Human.Hand.Add(BasicDeck.Pop());
                Computer.Hand.Add(BasicDeck.Pop());
            }
        }
    }

    // 60 cards

    // 5 colors: white, red, green, blue, yellow

    // card value 2-10 or an investment card

    // removal stack

    // basic stack

    // whose turn?            

}
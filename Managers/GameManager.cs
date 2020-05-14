using System;
using LostCities.GameData;

namespace LostCities.Managers
{
    public class GameManager : IGameManager
    {    
        public GameSituationContainer StartNewGame()
        {
            var newGameContainer = GameSituationContainer.InitializeNewGame();

            return newGameContainer;
        }        
    }
}
using LostCities.GameData;

namespace LostCities.Managers
{
    public interface IGameManager
    {
        Task<GameSituationContainer> StartNewGame();
    }
}

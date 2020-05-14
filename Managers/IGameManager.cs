using LostCities.GameData;
using System.Threading.Tasks;

namespace LostCities.Managers
{
    public interface IGameManager
    {
        Task<GameSituationContainer> StartNewGame();
    }
}
    
namespace LostCities.GameData
{
    public abstract class Player
    {
        public Player()
        {
            Hand = new Hand();
        }

        public Hand Hand {get; set;}
    }
}
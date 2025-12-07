using DuelingSimulation.Duels;

namespace DuelingSimulation.Factories
{
    public class DuelFactory
    {
        public BaseDuel CreateStandardDuel()
        {
            return new StandardDuel();
        
        }
        public BaseDuel CreateHouseCupDuel()
        {
            return new HouseCupDuel();
        }
    }
}

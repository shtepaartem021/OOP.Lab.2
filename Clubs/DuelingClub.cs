using DuelingSimulation.Duels;
using DuelingSimulation.Models;
using DuelingSimulation.Wizards;
using System;
using System.Collections.Generic;

namespace DuelingSimulation.Clubs
{
    public class DuelingClub
    {
        private static int duelCounter = 1;
        public DuelResult HostDuel(BaseWizard wizard1, BaseWizard wizard2, BaseDuel duelType)
        {
            if (wizard1.KnownSpells.Count == 0 || wizard2.KnownSpells.Count == 0)
            {
                Console.WriteLine($"Неможливо провести дуель між {wizard1.Name} і {wizard2.Name} – один або обидва не знають заклинань.");
                return null;
            }

            string duelId = duelCounter.ToString();

            DuelResult duelResult = duelType.ConductDuel(wizard1, wizard2, duelId);

            if (duelResult != null)
            {
                wizard1.AddDuelToHistory(duelResult);
                wizard2.AddDuelToHistory(duelResult);
            }

            duelCounter++;
            return duelResult;
        }
    }
}
using System.Collections.Generic;
using System;
using DuelingSimulation.Models;
using DuelingSimulation.Wizards;

namespace DuelingSimulation.Duels
{
    public class HouseCupDuel : BaseDuel
    {
        public override int GetRatingStake()
        {
            return 50;
        }

        public override DuelResult ConductDuel(BaseWizard wizard1, BaseWizard wizard2, string duelId)
        {
            var (winner, loser, turnLog) = SimulateFight(wizard1, wizard2);
            int stake = GetRatingStake();

            if (winner.House == loser.House)
            {
                stake *= 2;
                turnLog.Add($"[{winner.House}]: Оскільки обидва чарівники з одного дому, ставка подвоюється! ({stake})");
            }

            Console.WriteLine($"\n*** Результат Дуелі Змагання Дому #{duelId}: {winner.Name} ПЕРЕМІГ {loser.Name} (Ставка: {stake}) ***\n");

            return new DuelResult(
                duelId: duelId,
                contestants: new List<BaseWizard> { wizard1, wizard2 },
                winner: winner,
                loser: loser,
                turnLog: turnLog,
                ratingStake: stake
            );
        }
    }
}
using System.Collections.Generic;
using System;
using DuelingSimulation.Models;
using DuelingSimulation.Wizards;

namespace DuelingSimulation.Duels
{
    public class StandardDuel : BaseDuel
    {
        public override int GetRatingStake()
        {
            return 25;
        }

        public override DuelResult ConductDuel(BaseWizard wizard1, BaseWizard wizard2, string duelId)
        {
            var (winner, loser, turnLog) = SimulateFight(wizard1, wizard2);
            int stake = GetRatingStake();

            Console.WriteLine($"\n*** Результат Стандартної Дуелі #{duelId}: {winner.Name} ПЕРЕМІГ {loser.Name} (Ставка: {stake}) ***\n");

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
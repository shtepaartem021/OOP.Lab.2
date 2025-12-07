using DuelingSimulation.Models;
using DuelingSimulation.Wizards;
using System.Collections.Generic;
using System.Linq;

namespace DuelingSimulation.Duels
{
    public abstract class BaseDuel
    {
        public abstract int GetRatingStake();
        public abstract DuelResult ConductDuel(BaseWizard wizard1, BaseWizard wizard2, string duelId);
        protected (BaseWizard winner, BaseWizard loser, List<string> log) SimulateFight(BaseWizard wizard1, BaseWizard wizard2)
        {
            wizard1.RestoreHealth();
            wizard2.RestoreHealth();

            List<string> turnLog = new List<string>();
            BaseWizard currentAttacker = wizard1;
            BaseWizard currentDefender = wizard2;

            int maxTurns = 100;
            int turnCount = 0;

            while (wizard1.Health > 0 && wizard2.Health > 0 && turnCount < maxTurns)
            {
                var spell = currentAttacker.CastSpell();

                if (spell == null)
                {
                    turnLog.Add($"{currentAttacker.Name} не зміг кастанути заклинання.");
                    break;
                }

                currentDefender.TakeDamage(spell.Damage);
                turnLog.Add($"{currentAttacker.Name} кастує {spell.Name} ({spell.Damage} шкоди) — {currentDefender.Name} має {currentDefender.Health} HP");

                (currentAttacker, currentDefender) = (currentDefender, currentAttacker);
                turnCount++;
            }

            BaseWizard winner = wizard1.Health > 0 ? wizard1 : wizard2;
            BaseWizard loser = wizard1.Health <= 0 ? wizard1 : wizard2;

            return (winner, loser, turnLog);
        }
    }
}

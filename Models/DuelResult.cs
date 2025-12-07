using DuelingSimulation.Wizards;
using System.Collections.Generic;

namespace DuelingSimulation.Models
{
    public class DuelResult
    {
        public string DuelId { get; set; }
        public List<BaseWizard> Contestants { get; set; }
        public BaseWizard Winner { get; set; }
        public BaseWizard Loser { get; set; }
        public List<string> TurnLog { get; set; }
        public int RatingStake { get; set; }

        public DuelResult(string duelId, List<BaseWizard> contestants, BaseWizard winner, BaseWizard loser, List<string> turnLog, int ratingStake)
        {
            DuelId = duelId;
            Contestants = contestants;
            Winner = winner;
            Loser = loser;
            TurnLog = turnLog;
            RatingStake = ratingStake;
        }

        public override string ToString()
        {
            string result = $"Дуель #{DuelId} (Ставка: {RatingStake}): {Winner.Name} переміг {Loser.Name}\n";
            result += "Ходи:\n";
            foreach (var log in TurnLog)
                result += "  " + log + "\n";
            return result;
        }
    }
}
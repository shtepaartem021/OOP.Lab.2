using DuelingSimulation.Models;
using System.Linq;

namespace DuelingSimulation.Wizards
{
    public class GryffindorWizard : BaseWizard
    {
        public GryffindorWizard(string name) : base(name, "Грифіндор") { }
        public override Spell CastSpell()
        {
            if (KnownSpells.Count == 0)
                return null;

            return KnownSpells.OrderByDescending(s => s.Damage).FirstOrDefault();
        }
    }
}
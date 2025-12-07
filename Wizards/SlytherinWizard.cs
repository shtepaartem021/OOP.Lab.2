using System.Linq;
using System.Collections.Generic;
using DuelingSimulation.Models;

namespace DuelingSimulation.Wizards
{
    public class SlytherinWizard : BaseWizard
    {
        public SlytherinWizard(string name) : base(name, "Слизерин") { }
        public override Spell CastSpell()
        {
            if (KnownSpells.Count == 0)
                return null;

            var effectSpells = KnownSpells.Where(s => s.Effect != SpellEffect.Damage).ToList();

            if (effectSpells.Any())
            {
                return effectSpells[Rnd.Next(effectSpells.Count)];
            }
            return KnownSpells[Rnd.Next(KnownSpells.Count)];
        }
    }
}

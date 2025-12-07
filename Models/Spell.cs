using System;

namespace DuelingSimulation.Models
{
    public class Spell
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public SpellEffect Effect { get; set; }

        public Spell(string name, int damage, SpellEffect effect)
        {
            Name = name;
            Damage = damage;
            Effect = effect;
        }

        public override string ToString()
        {
            return $"{Name} ({Effect}, {Damage} шкоди)";
        }
    }
}
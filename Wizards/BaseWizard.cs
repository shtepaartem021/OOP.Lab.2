using DuelingSimulation.Models;
using System;
using System.Collections.Generic;

namespace DuelingSimulation.Wizards
{
    public abstract class BaseWizard
    {
        protected const int InitialHealth = 100;
        protected static readonly Random Rnd = new Random();

        public string Name { get; set; }
        public string House { get; set; }
        public int Health { get; protected set; }
        public int Rating { get; protected set; } = 1000;
        public List<Spell> KnownSpells { get; private set; }
        private readonly List<DuelResult> duelHistory;

        public BaseWizard(string name, string house)
        {
            Name = name;
            House = house;
            Health = InitialHealth;
            KnownSpells = new List<Spell>();
            duelHistory = new List<DuelResult>();
        }

        public void LearnSpell(Spell spell)
        {
            KnownSpells.Add(spell);
        }
        public abstract Spell CastSpell();

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public void RestoreHealth()
        {
            Health = InitialHealth;
        }

        public void AddDuelToHistory(DuelResult duelRecord)
        {
            duelHistory.Add(duelRecord);
            if (duelRecord.Winner == this)
            {
                Rating += duelRecord.RatingStake;
            }
            else if (duelRecord.Loser == this)
            {
                Rating -= duelRecord.RatingStake;
            }
        }

        public void GetDuelHistory()
        {
            Console.WriteLine($"\nІсторія дуелей чарівника {Name} (Рейтинг: {Rating}):");
            if (duelHistory.Count == 0)
            {
                Console.WriteLine("Немає записів про дуелі.");
                return;
            }

            foreach (var duel in duelHistory)
                Console.WriteLine(duel.ToString());
        }
    }
}
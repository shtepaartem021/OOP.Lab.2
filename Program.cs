using DuelingSimulation.Clubs;
using DuelingSimulation.Duels;
using DuelingSimulation.Factories;
using DuelingSimulation.Models;
using DuelingSimulation.Wizards;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuelingSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("Симуляція Дуелей Поттеріани");
            Console.WriteLine("====================================\n");

            Spell expelliarmus = new Spell("Експеліармус", 15, SpellEffect.Disarming);
            Spell stupefy = new Spell("Ступефай", 20, SpellEffect.Stunning);
            Spell petrificus = new Spell("Петрифікус Тоталус", 25, SpellEffect.Damage);

            GryffindorWizard harry = new GryffindorWizard("Гаррі Поттер");
            SlytherinWizard draco = new SlytherinWizard("Драко Малфой");
            GryffindorWizard hermione = new GryffindorWizard("Герміона Ґрейнджер");

            harry.LearnSpell(expelliarmus);
            harry.LearnSpell(stupefy);

            draco.LearnSpell(petrificus);
            draco.LearnSpell(stupefy);
            draco.LearnSpell(expelliarmus);

            hermione.LearnSpell(expelliarmus);
            hermione.LearnSpell(petrificus);
            hermione.LearnSpell(stupefy);

            DuelingClub club = new DuelingClub();
            DuelFactory factory = new DuelFactory();

            BaseDuel standardDuel = factory.CreateStandardDuel();
            BaseDuel houseCupDuel = factory.CreateHouseCupDuel();

            Console.WriteLine("--- Дуель 1: Стандартна (Гаррі vs Драко) ---");
            club.HostDuel(harry, draco, standardDuel);

            Console.WriteLine("--- Дуель 2: Кубок Дому (Гаррі vs Герміона - обидва Грифіндор) ---");
            club.HostDuel(harry, hermione, houseCupDuel);

            Console.WriteLine("--- Дуель 3: Стандартна (Драко vs Герміона) ---");
            club.HostDuel(draco, hermione, standardDuel);

            Console.WriteLine("\n====================================");
            Console.WriteLine("Звіти про історію дуелей та Рейтинг");
            Console.WriteLine("====================================\n");

            harry.GetDuelHistory();
            draco.GetDuelHistory();
            hermione.GetDuelHistory();
        }
    }
}
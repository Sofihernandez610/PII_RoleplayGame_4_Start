using RoleplayGame.Characters;
using RoleplayGame.Items;
using RoleplayGame.Encounters;
using RoleplayGame.Scenarios;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
           // IScenario scenario = new ConsoleScenario();
           // scenario.Setup();
           // scenario.Run();
            Elf p1 = new Elf("Santi");
            Trolls p2 = new Trolls("Coco");
            Wizard p3 = new Wizard("Sofi");
            Trolls p4 = new Trolls("Santi");

            List<Character> personajes = new List<Character>();

            List<IItem> itemsP1 = new List<IItem>() {new Espada(), new Coraza()};
            p1.AddItems(itemsP1);
            List<IItem> itemsP2 = new List<IItem>() {new HachaMedieval(), new Palo()};
            p2.AddItems(itemsP2);
            List<IItem> itemsP3 = new List<IItem>() {new Espada(), new Palo()};
            p3.AddItems(itemsP3);
            List<IItem> itemsP4 = new List<IItem>() {new HachaMedieval(), new Coraza()};
            p4.AddItems(itemsP4);

            personajes.Add(p1);
            personajes.Add(p2);
            personajes.Add(p3);
            personajes.Add(p4);
            Console.WriteLine("****** Primer Encuentro ******");
            /*Primer encuentro*/
            AttackEncounter encuentro1 = new AttackEncounter(p1, p2);
            encuentro1.Reporter = new ConsoleReporter();
            encuentro1.DoEncounter();

            bool p1IsDead = false;
            bool p2IsDead = false;
            Character winnerEncounter1;
            p1IsDead = p1.IsDead;
            p2IsDead = p2.IsDead;

            if (p1IsDead)
            {
                winnerEncounter1 = p2;
            }
            else
            {
                winnerEncounter1 = p1;
            }

            Console.WriteLine("****** Segundo Encuentro ******");
            /*Segundo encuentro*/
            AttackEncounter encuentro2 = new AttackEncounter(p3, p4);
            encuentro2.Reporter = new ConsoleReporter();
            encuentro2.DoEncounter();

            bool p3IsDead = false;
            bool p4IsDead = false;
            Character winnerEncounter2;
            p3IsDead = p3.IsDead;
            p4IsDead = p4.IsDead;

            if (p3IsDead)
            {
                winnerEncounter2 = p4;
            }
            else
            {
                winnerEncounter2 = p3;
            }

            Console.WriteLine("****** Encuentro Final ******");
            AttackEncounter encuentro3 = new AttackEncounter(winnerEncounter1, winnerEncounter2);
            encuentro3.Reporter = new ConsoleReporter();
            encuentro3.DoEncounter();

            bool winnerEncounter1IsDead = false;
            bool winnerEncounter2IsDead = false;
            Character Winner;
            winnerEncounter1IsDead = winnerEncounter1.IsDead;
            winnerEncounter2IsDead = winnerEncounter2.IsDead;

            if (winnerEncounter1IsDead)
            {
                Winner = winnerEncounter2;
            }
            else
            {
                Winner = winnerEncounter1;
            }

            Console.WriteLine($"El ganador de la Tierra Media es {Winner.Name}");
        }
    }
}

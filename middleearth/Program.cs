using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем 2 армии
            List<MiddleEarthCitizen> Army1 = new List<MiddleEarthCitizen>(),
                                     Army2 = new List<MiddleEarthCitizen>();

            int i, j = 1, length = 10;
            String type = "";
            Random rnd = new Random();

            //заполняем армии
            if (rnd.Next(2) > 0)
                Army1.Add(new Wizard("Wizard", new Horse("WizardHorse", rnd.Next(4,5))));
            else
                j = 0;

            for (i = j; i < length; i++)
            {
                switch (rnd.Next(4))
                {
                    case 0:
                        type = "Human";
                        Army1.Add(new Human(type + i, rnd.Next(7,8)));
                        break;
                    case 1:
                        type = "Rohhirim";
                        Army1.Add(new Rohhirim(type + i, rnd.Next(11,13), new Horse("Horse"+ i, rnd.Next(4,5))));
                        break;
                    case 2:
                        type = "Elf";
                        Army1.Add(new Elf(type + i, rnd.Next(4,7)));
                        break;
                    case 3:
                        type = "WoodenElf";
                        Army1.Add(new WoodenElf(type + i, rnd.Next(6)));
                        break;
                }
            }

            for (i = 0; i < length; i++)
            {
                switch (rnd.Next(4))
                {
                    case 0:
                        type = "Orc";
                        Army2.Add(new Orc(type + i, rnd.Next(8,10), new Orc.Wolf("Wolf" + i, rnd.Next(4,7))));
                        break;
                    case 1:
                        type = "UrukHai";
                        Army2.Add(new UrukHai(type + i, rnd.Next(10,12)));
                        break;
                    case 2:
                        type = "Troll";
                        Army2.Add(new Troll(type + i, rnd.Next(11,15)));
                        break;
                    case 3:
                        type = "Goblin";
                        Army2.Add(new Goblin(type + i, rnd.Next(2,5)));
                        break;
                }
            }

            ArmyInfo(Army1, Army2, "Before");
            FirstRound(Army1, Army2);
            ArmyInfo(Army1, Army2, "After 1st Round");
            SecondRound(Army1, Army2);
            ArmyInfo(Army1, Army2, "After 2nd Round");
            ThirdRound(Army1, Army2);
            ArmyInfo(Army1, Army2, "After 3rd Round");
            String winner = Army1.Count > 0 ? "Army1" : "Army2";
            Console.WriteLine($"{winner} Won!");

            Console.ReadKey();
        }

        //вывод армии на консоль
        public static void PrintArmy(List<MiddleEarthCitizen> army)
        {
            int i = 1;
            foreach (var item in army)
            {
                Console.WriteLine($"{item.ToString()}");
                i++;
            }
        }

        //информация об армиях
        public static void ArmyInfo(List<MiddleEarthCitizen> Army1, List<MiddleEarthCitizen> Army2, String message)
        {
            Console.WriteLine(message);
            Console.WriteLine("   Army1");
            PrintArmy(Army1);
            Console.WriteLine("\n   Army2");
            PrintArmy(Army2);
            Console.WriteLine("\n");
        }

        //удаление умерших воинов
        public static void Clear(List<MiddleEarthCitizen> army)
        {
            for (int i = 0; i < army.Count; i++)
            {
                if (army[i].Power <= 0)
                {
                    army.Remove(army[i]);
                    break;
                }
            }
        }

        //первый раунд
        public static void FirstRound(List<MiddleEarthCitizen> Army1, List<MiddleEarthCitizen> Army2)
        {
            Random rnd = new Random();
            MiddleEarthCitizen kind, evil;

            List<MiddleEarthCitizen> kindCavalry = new List<MiddleEarthCitizen>(),
                evilCavalry = new List<MiddleEarthCitizen>();

            kindCavalry = (from t in Army1
                           where (t is Wizard || t is Rohhirim)
                           select t).ToList();
            evilCavalry = (from t in Army2
                           where (t is Orc && ((Orc)t).OwnWolf != null)
                           select t).ToList();

            while (kindCavalry.Count > 0 && evilCavalry.Count > 0)
            {
                kind = kindCavalry[rnd.Next(kindCavalry.Count)];
                evil = evilCavalry[rnd.Next(evilCavalry.Count)];

                if (rnd.Next(2) < 1) // бьют светлые
                {
                    FirstRoundKind(ref kind, ref evil);
                    if (evil.Power > 0)
                        FirstRoundEvil(ref kind, ref evil);
                }
                else // eбьют темные
                {
                    FirstRoundEvil(ref kind, ref evil);
                    if (kind.Power > 0)
                        FirstRoundKind(ref kind, ref evil);
                }

                Clear(Army1);
                Clear(Army2);

                kindCavalry = (from t in Army1
                               where (t is Wizard || t is Rohhirim)
                               select t).ToList();
                evilCavalry = (from t in Army2
                               where (t is Orc && ((Orc)t).OwnWolf != null)
                               select t).ToList();
            }
        }

        public static void FirstRoundKind(ref MiddleEarthCitizen kind, ref MiddleEarthCitizen evil)
        {
            ((Orc)evil).OwnWolf.Power -= kind.Power;
            if (((Orc)evil).OwnWolf.Power < 0)
            {
                ((Orc)evil).Power += ((Orc)evil).OwnWolf.Power;
                ((Orc)evil).OwnWolf.Power = 0;
            }
        }

        public static void FirstRoundEvil(ref MiddleEarthCitizen kind, ref MiddleEarthCitizen evil)
        {
            if (kind is Rohhirim)
            {
                ((Rohhirim)kind).OwnHorse.Power -= evil.Power;
                if (((Rohhirim)kind).OwnHorse.Power < 0)
                {
                    ((Rohhirim)kind).Power += ((Rohhirim)kind).OwnHorse.Power;
                    ((Rohhirim)kind).OwnHorse.Power = 0;
                }
            }
            else if (kind is Wizard)
            {
                ((Wizard)kind).OwnHorse.Power -= kind.Power;
                if (((Wizard)kind).OwnHorse.Power < 0)
                {
                    ((Wizard)kind).Power += ((Wizard)kind).OwnHorse.Power;
                    ((Wizard)kind).OwnHorse.Power = 0;
                }
            }
        }

        //второй раунд
        public static void SecondRound(List<MiddleEarthCitizen> Army1, List<MiddleEarthCitizen> Army2)
        {
            Random rnd = new Random();
            MiddleEarthCitizen kind, evil;

            List<MiddleEarthCitizen> kindInfantry = new List<MiddleEarthCitizen>(),
                evilInfantry = new List<MiddleEarthCitizen>();

            kindInfantry = (from t in Army1
                            where !(t is FirstStrike)
                            select t).ToList();
            evilInfantry = (from t in Army2
                            where (!(t is FirstStrike) || t is UrukHai)
                            select t).ToList();

            while (kindInfantry.Count > 0 && evilInfantry.Count > 0)
            {
                kind = kindInfantry[rnd.Next(kindInfantry.Count)];
                evil = evilInfantry[rnd.Next(evilInfantry.Count)];

                if (rnd.Next(2) < 1) // бьют светлые
                {
                    SecondRoundKind(ref kind, ref evil);
                    if (evil.Power > 0)
                        SecondRoundEvil(ref kind, ref evil);
                }
                else // бьют темные
                {
                    SecondRoundEvil(ref kind, ref evil);
                    if (kind.Power > 0)
                        SecondRoundKind(ref kind, ref evil);
                }

                Clear(Army1);
                Clear(Army2);

                kindInfantry = (from t in Army1
                                where !(t is FirstStrike)
                                select t).ToList();
                evilInfantry = (from t in Army2
                                where (!(t is FirstStrike) || t is UrukHai)
                                select t).ToList();
            }
        }

        public static void SecondRoundKind(ref MiddleEarthCitizen kind, ref MiddleEarthCitizen evil)
        {
            evil.Power -= kind.Power;
        }

        public static void SecondRoundEvil(ref MiddleEarthCitizen kind, ref MiddleEarthCitizen evil)
        {
            kind.Power -= evil.Power;
        }

        //третий раунд
        public static void ThirdRound(List<MiddleEarthCitizen> Army1, List<MiddleEarthCitizen> Army2)
        {
            Random rnd = new Random();
            MiddleEarthCitizen kind, evil;

            while (Army1.Count > 0 && Army2.Count > 0)
            {
                kind = Army1[rnd.Next(Army1.Count)];
                evil = Army2[rnd.Next(Army2.Count)];

                if (((kind is FirstStrike && !(evil is Orc))) || rnd.Next(2) < 1) // бьют светлые
                {
                    ThirdRoundKind(ref kind, ref evil);
                    if (kind.Power > 0)
                        ThirdRoundEvil(ref kind, ref evil);
                }
                else // бьют темные
                {
                    ThirdRoundEvil(ref kind, ref evil);
                    if (kind.Power > 0)
                        ThirdRoundKind(ref kind, ref evil);
                }

                Clear(Army1);
                Clear(Army2);
            }
        }

        public static void ThirdRoundKind(ref MiddleEarthCitizen kind, ref MiddleEarthCitizen evil)
        {
            if (evil is Orc && ((Orc)evil).OwnWolf != null)
                FirstRoundKind(ref kind, ref evil);
            else
                evil.Power -= kind.Power;
        }

        public static void ThirdRoundEvil(ref MiddleEarthCitizen kind, ref MiddleEarthCitizen evil)
        {
            if (kind is Wizard || kind is Rohhirim)
                FirstRoundEvil(ref kind, ref evil);
            else
                kind.Power -= evil.Power;
        }
    }
}

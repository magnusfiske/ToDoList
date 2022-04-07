using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listan2
{
    class Tdl
    {


        public Tdl()
        {

        }

        //Metoder
        public void ListMeny(List<string> ts)
        {
            bool stay = true;
            do
            {
                Console.WriteLine("1. Lägg till         2. Ta bort\n3. Spara             4.Avsluta");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddItem(ts);
                        Print(ts);
                        break;
                    case "2":
                        RemoveItem(ts);
                        break;
                    case "3":
                        SaveList(ts);
                        break;
                    case "4":
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Ange '1', '2', '3' eller '4', dumskalle!");
                        break;
                }
            } while (stay == true);


        }

        public static void AddItem(List<string> ts)
        {
            Console.Write("Lägg till något till listan: ");
            string input = Console.ReadLine();
            ts.Add(input);
        }

        public static void RemoveItem(List<string> ts)
        {
            Console.WriteLine("Ange numret för den punkt som ska bort: ");
            string input = Console.ReadLine();
            int number;
            bool rightNumber = Int32.TryParse(input, out number);
            do
            {
                if (rightNumber)
                {
                    ts.RemoveAt(number - 1);
                    Console.WriteLine();
                    Print(ts);
                }
                else
                {
                    Console.WriteLine("Ange ett giltigt nummer för den punkt på listan som ska bort.");
                    RemoveItem(ts);
                }
            } while (rightNumber == false);
        }

        public static void Print(List<string> ts)
        {
            Console.WriteLine();
            Console.WriteLine("Att göra-listan \n___________");
            for (int i = 0; i < ts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ts[i]}");
            }
            Console.WriteLine();
        }
        public static void SaveList(List<string> ts)
        {
            using StreamWriter spara = new StreamWriter("sparadLista.txt");
            { // Skriv in alla punkter i listan:
                foreach (string i in ts)
                {
                    spara.WriteLine(i);
                }
                spara.Close();
            }
            Console.WriteLine("Listan sparad.");
        }

        public void Ladda()
        {     
            List<string> ts = File.ReadAllLines("sparadLista.txt")
            .Select(line => line.Trim())
            .ToList();
            Console.WriteLine();
            Print(ts);
        }
    }
}

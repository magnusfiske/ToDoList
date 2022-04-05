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
                Console.WriteLine("1. Lägg till         2. Spara\n3. Avsluta");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddItem(ts);
                        Print(ts);
                        break;
                    case "2":
                        SaveList(ts);
                        break;
                    case "3":
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Ange '1', '2' eller '3', dumskalle!");
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

// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Listan2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> lista = new List<string>();
            Tdl ts = new Tdl();

            Console.WriteLine("Att göra-listan\n--------\n1. Skapa ny lista       2. Ladda sparad lista\n");
            bool stay = true;
            do
            {
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        stay = false;
                        ts.ListMeny(lista);
                        break;
                    case "2":
                        stay = false;
                        ts.Ladda();
                        ts.ListMeny(lista);
                        break;
                    default:
                        stay = true;
                        Console.WriteLine("Välj '1' eller '2', pappskalle!");
                        break;
                } 
            } while (stay == true);
        }
    }
}



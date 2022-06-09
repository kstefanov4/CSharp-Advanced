using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    class Program
    {
        private static int forgedSwords = 0;
        private static Dictionary<string, int> forgedSwordsList;
        private static Queue<int> steel;
        private static Stack<int> carbon;
        private static Dictionary<int,string> swordResources;

        static void Main(string[] args)
        {
            swordResources = new Dictionary<int, string>{
                {70, "Gladius"  },
                {80, "Shamshir" },
                {90, "Katana" },
                {110, "Sabre" },
                {150, "Broadsword" },
            };

            forgedSwordsList = new Dictionary<string, int> { { "Broadsword", 0 }, { "Sabre", 0 }, { "Katana", 0 }, { "Shamshir", 0 }, { "Gladius", 0 }, };

            steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (true)
            {
                if (SteelOrCarbonEmpty())
                {
                    break;
                }

                ForgeASwort();

            }

            PrintIfSwordWasForged();
            PrintLeftSteel();
            PrintLeftCarbon();
            PrintForgedSworts();

        }

        private static void PrintForgedSworts()
        {
            foreach (var item in forgedSwordsList.OrderBy(x => x.Key).Where(x=>x.Value > 0))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static void PrintLeftCarbon()
        {
            if (carbon.Count <= 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
        }

        private static void PrintLeftSteel()
        {
            if (steel.Count <= 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }
        }

        private static void PrintIfSwordWasForged()
        {
            if (forgedSwords > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
        }

        private static void ForgeASwort()
        {
            int currentSteel = steel.Peek();
            int currentCarbon = carbon.Peek();

            if (swordResources.ContainsKey(currentSteel + currentCarbon))
            {
                forgedSwordsList[swordResources[currentSteel + currentCarbon]]++;
                forgedSwords++;
                steel.Dequeue();
                carbon.Pop();
            }
            else
            {
                steel.Dequeue();
                carbon.Pop();
                carbon.Push(currentCarbon + 5);
            }
        }

        private static bool SteelOrCarbonEmpty()
        {
            return steel.Count == 0 || carbon.Count == 0;
        }
    }
}

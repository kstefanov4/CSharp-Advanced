using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int num =int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentMap = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string continent = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string countries = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                string cities = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];

                if (!continentMap.ContainsKey(continent))
                {
                    continentMap.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentMap[continent].ContainsKey(countries))
                {
                    continentMap[continent].Add(countries,new List<string>());
                }

                continentMap[continent][countries].Add(cities);
            }

            foreach (var continent in continentMap)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var countries in continent.Value)
                {
                    Console.WriteLine($"  {countries.Key} -> {string.Join(", ", countries.Value)}");
                }
            }
        }
    }
}

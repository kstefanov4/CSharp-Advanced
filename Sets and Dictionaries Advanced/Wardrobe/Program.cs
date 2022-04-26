using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrope = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," },StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (!wardrope.ContainsKey(color))
                {
                    wardrope.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    if (!wardrope[color].ContainsKey(input[j]))
                    {
                        wardrope[color].Add(input[j], 0);
                    }
                    wardrope[color][input[j]]++;
                }
                
            }

            string[] serched = Console.ReadLine().Split();

            foreach (var color in wardrope)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key == serched[0] && cloth.Key == serched[1] )
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}

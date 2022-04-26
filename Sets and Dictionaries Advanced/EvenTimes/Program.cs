using System;
using System.Collections.Generic;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!map.ContainsKey(input))
                {
                    map.Add(input, 0);
                }
                map[input]++;
            }

            foreach (var item in map)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}

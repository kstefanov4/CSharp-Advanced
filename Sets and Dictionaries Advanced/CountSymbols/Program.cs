using System;
using System.Collections.Generic;

namespace CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();

            SortedDictionary<char,int> map = new SortedDictionary<char,int>();

            foreach (char c in chars)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                }
                map[c]++;
            }

            foreach (var item in map)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}

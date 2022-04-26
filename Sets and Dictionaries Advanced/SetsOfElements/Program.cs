using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < numbers[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < numbers[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> repeatedSet = new HashSet<int>();

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    repeatedSet.Add(item);        
                }
            }

            Console.WriteLine(String.Join(" ",repeatedSet));
        }
    }
}

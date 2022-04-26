using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < num; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int j = 0; j < elements.Length; j++)
                {
                    set.Add(elements[j]);
                }
            }
            Console.WriteLine(string.Join(" ",set));
        }
    }
}

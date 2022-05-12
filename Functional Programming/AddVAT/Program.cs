using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2)
                .ToArray();


            foreach (var item in nums)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] inputArray = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Dictionary<double, int> numberArray = new Dictionary<double, int>();

            foreach (var number in inputArray)
            {
                if (!numberArray.ContainsKey(number))
                {
                    numberArray.Add(number, 0);
                }
                numberArray[number]++;
            }

            foreach (var number in numberArray)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}

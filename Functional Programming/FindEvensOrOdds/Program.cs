using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> oddChecker = n => n % 2 != 0;
            Predicate<int> evenChecker = n => n % 2 == 0;

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string condition = Console.ReadLine();
                

            switch (condition)
            {
                case "odd":
                    Print(oddChecker, input);
                    break;
                case "even":
                    Print(evenChecker, input);
                    break;
            }
        }

        private static void Print(Predicate<int> checker, int[] input)
        {
            for (int i = input[0]; i <= input[1]; i++)
            {
                if (checker(i))
                {
                    Console.Write(i + " ");
                }
                
            }
        }
    }
}

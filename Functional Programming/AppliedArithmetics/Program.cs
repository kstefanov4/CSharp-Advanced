using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Func<int, int> add = n => n + 1;
            Func<int, int> multiply = n => n * 1;
            Func<int, int> subtract = n => n - 1;
            

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        foreach (var item in numList)
                        {

                            numList.Add(add(item));
                            numList.Remove(item);
                        }
                        break;
                    case "multiply":
                        foreach (var item in numList)
                        {
                            multiply(item);
                        }
                        break;
                    case "subtract":
                        foreach (var item in numList)
                        {
                            subtract(item);
                        }
                        break;
                    case "print":
                        foreach (var item in numList)
                        {
                            Console.WriteLine(item + " ");
                        }
                        break;
                }
            }
        }
    }
}

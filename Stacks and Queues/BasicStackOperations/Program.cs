using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int numOfElements = int.Parse(input.Split()[0]);
            int numToPop = int.Parse(input.Split()[1]);
            int numToCheck = int.Parse(input.Split()[2]);

            int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> intStack = new Stack<int>();

            for (int i = 0; i < numOfElements; i++)
            {
                intStack.Push(intArray[i]);
            }

            if (intStack.Count > 0)
            {
                for (int i = 0; i < numToPop; i++)
                {
                    intStack.Pop();
                }
            }

            if (intStack.Count == 0 )
            {
                Console.WriteLine(0);
            }
            else if (intStack.Contains(numToCheck))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine(intStack.Min());
            }

        }
    }
}

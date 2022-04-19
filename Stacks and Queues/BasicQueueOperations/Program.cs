using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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
            Queue<int> intStack = new Queue<int>();

            for (int i = 0; i < numOfElements; i++)
            {
                intStack.Enqueue(intArray[i]);
            }

            if (intStack.Count > 0)
            {
                for (int i = 0; i < numToPop; i++)
                {
                    intStack.Dequeue();
                }
            }

            if (intStack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (intStack.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(intStack.Min());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num =int.Parse(Console.ReadLine());
            Queue<int[]> pumpQueue = new Queue<int[]>();

            for (int i = 0; i < num; i++)
            {
                int[] intArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumpQueue.Enqueue(intArray);
            }

            int index = 0;
            int pumpIndex = 0;
            int distance = 0;

            for (int i = 0; i < pumpQueue.Count; i++)
            {
                int[] currentArray = pumpQueue.Peek();
                if (currentArray[0] + distance < currentArray[1])
                {
                    pumpQueue.Dequeue();
                    pumpQueue.Enqueue(currentArray);
                    pumpIndex += index + 1;
                    i = -1;
                    distance = 0;
                    index = 0;
                }
                else
                {
                    distance += currentArray[0] - currentArray[1];
                    pumpQueue.Dequeue();
                    pumpQueue.Enqueue(currentArray);
                    index++;
                }
            }
            Console.WriteLine(pumpIndex);
        }
    }
}

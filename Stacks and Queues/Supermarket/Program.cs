using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> peopleQueue = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    int queueLenght = peopleQueue.Count;

                    for (int i = 0; i < queueLenght; i++)
                    {
                        Console.WriteLine(peopleQueue.Dequeue());
                    }

                }
                else
                {
                    peopleQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{peopleQueue.Count} people remaining.");
        }
    }
}

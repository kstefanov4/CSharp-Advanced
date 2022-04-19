using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> peopleQueue = new Queue<string>(Console.ReadLine().Split());
            int turns = int.Parse(Console.ReadLine());

            while (peopleQueue.Count != 1)
            {
                for (int i = 0; i < turns-1; i++)
                {
                    string name = peopleQueue.Peek();
                    peopleQueue.Dequeue();
                    peopleQueue.Enqueue(name);
                }
                Console.WriteLine($"Removed {peopleQueue.Dequeue()}");
            }
            Console.WriteLine($"Last is {peopleQueue.Peek()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> intQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> evenQueue = new Queue<int>();

            foreach (int item in intQueue)
            {
                if (item % 2 == 0)
                {
                    evenQueue.Enqueue(item);
                }
            }

            Console.WriteLine(string.Join(", ",evenQueue));

        }
    }
}

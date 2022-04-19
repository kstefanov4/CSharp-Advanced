using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> ordersQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Console.WriteLine(ordersQueue.Max());

            while (true)
            {
                if (ordersQueue.Count == 0 || ordersQueue.Peek() > foodQuantity)
                {
                    break;
                }
                else
                {
                    int currentOrder = ordersQueue.Dequeue();
                    foodQuantity -= currentOrder;
                }
            }

            if (ordersQueue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}

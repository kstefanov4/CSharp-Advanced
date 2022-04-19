using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int realRackCapacity = rackCapacity;
            int rack = 1;
            while (clothesStack.Any())
            {
                if (clothesStack.Peek() > rackCapacity)
                {
                    rack++;
                    rackCapacity = realRackCapacity;
                }
                else
                {
                    rackCapacity -= clothesStack.Pop();
                }
            }
            Console.WriteLine(rack);
            
        }
    }
}

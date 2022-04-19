using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Stack<int> intStack = new Stack<int>();

            for (int i = 0; i < num; i++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (array[0])
                {
                    case 1:
                        intStack.Push(array[1]);
                        break;

                    case 2:
                        intStack.Pop();
                        break;
                    case 3:
                        if (intStack.Count > 0)
                        {
                            Console.WriteLine(intStack.Max());
                        }
                        break;
                    case 4:
                        if (intStack.Count > 0)
                        {
                            Console.WriteLine(intStack.Min());
                        }
                        break;
                }
                
            }
            Console.WriteLine(string.Join(", ", intStack));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num =int.Parse(Console.ReadLine());
            List<int> textList = new List<int>();

            for (int i = 0; i < num; i++)
            {
                textList.Add(int.Parse(Console.ReadLine()));
            }
            
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SwapAndPrintTheList(indexes[0], indexes[1], textList);
        }

        private static void SwapAndPrintTheList<T> (int v1, int v2, List<T> list)
        {
            T elementToSwap = list[v1];
            list[v1] = list[v2];
            list[v2] = elementToSwap;

            foreach (var item in list)
            {
                Console.WriteLine($"{typeof(T).FullName}: {item}");
            }
        }
    }
}

using System;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[num][];

            for (int i = 0; i < num; i++)
            {
                jaggedArray[i] = new int[i+1];
            }

            for (int i = 0; i < num; i++)
            {
                jaggedArray[i][0] = 1;
                jaggedArray[i][jaggedArray[i].Length - 1] = 1;

                for (int j = 1; j < jaggedArray[i].Length-1; j++)
                {
                    jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                    
                }
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(string.Join(" ",jaggedArray[i]));
            }
        }
    }
}

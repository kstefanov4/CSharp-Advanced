using System;
using System.Linq;

namespace PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[,] matrix = new int[num, num];

            for (int rows = 0; rows < num; rows++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int cols = 0; cols < num; cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            int sum = 0;

            for (int row = 0; row < num; row++)
            {
                for (int col = 0; col < num; col++)
                {
                    if (col==row)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}

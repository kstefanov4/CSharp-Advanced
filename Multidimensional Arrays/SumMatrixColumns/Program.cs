using System;
using System.Linq;

namespace SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            for (int cols = 0; cols < rowsAndCols[1]; cols++)
            {
                int sum = 0;
                for (int rows = 0; rows < rowsAndCols[0]; rows++)
                {
                    sum += matrix[rows, cols];
                }
                Console.WriteLine(sum);
            }
        }
    }
}

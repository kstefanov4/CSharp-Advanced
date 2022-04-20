using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputNums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputNums[col];
                }
            }
            int biggestSum = 0;
            int biggestRow = 0;
            int biggestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col] + matrix[row, col + 1]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestRow = row;
                        biggestCol = col;
                    }
                }

            }
            Console.WriteLine(matrix[biggestRow, biggestCol] + " " + matrix[biggestRow, biggestCol + 1]);
            Console.WriteLine(matrix[biggestRow + 1, biggestCol] + " " + matrix[biggestRow + 1, biggestCol + 1]);
            Console.WriteLine(biggestSum);
        }
    }
}

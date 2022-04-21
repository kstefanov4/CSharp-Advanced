using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[,] matrix = new int[num, num];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputArray[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        primaryDiagonalSum += matrix[i, j];
                    }
                }
            }

            int SecondaryDiagonalSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(1) - 1 -i; j >= 0; j--)
                {
                    SecondaryDiagonalSum += matrix[i, j];
                    break;
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum- SecondaryDiagonalSum));

        }
    }
}

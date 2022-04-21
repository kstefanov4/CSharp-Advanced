using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] matrix = new char[rowAndCol[0], rowAndCol[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputChars = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputChars[col];
                }
            }
            int countEqualsSquares = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        countEqualsSquares++;
                    }
                }
            }

            Console.WriteLine(countEqualsSquares);
        }
    }
}

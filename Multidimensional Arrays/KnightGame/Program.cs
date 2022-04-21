using System;
using System.Linq;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowAndCol = int.Parse(Console.ReadLine());

            char[,] matrix = new char[rowAndCol, rowAndCol];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int removedKnight = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currenTAttacks = 0;

                        if (matrix[row, col] != 'K')
                        {
                            continue;
                        }

                        if (isInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (isInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                        {
                            currenTAttacks++;
                        }

                        if (currenTAttacks > maxAttacks)
                        {
                            maxAttacks = currenTAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks == 0)
                {
                    Console.WriteLine(removedKnight);
                    break;
                }
                else
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnight++;
                }
            }

        }

        private static bool isInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}

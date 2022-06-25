using System;

namespace ReVolt
{
    class Program
    {
        private static int playerRow;
        private static int playerCol;
        private static char[,] matrix;
        private static string direction;
        private static bool finishLineReached = false;
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandsNum = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];

            FillTheMatrix();

            for (int i = 0; i < commandsNum; i++)
            {
                direction = Console.ReadLine();
                GetDifection(direction);
                if (finishLineReached)
                {
                    break;
                }
            }

            PrintWinningMessage();
            PrintMatrix();

        }
        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void PrintWinningMessage()
        {
            if (finishLineReached)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
        }

        private static void GetDifection(string direction)
        {
            switch (direction)
            {
                case "up":
                    Move(-1, 0);
                    // PrintMatrix();
                    break;
                case "down":
                    Move(1, 0);
                    //  PrintMatrix();
                    break;
                case "left":
                    Move(0, -1);
                    //  PrintMatrix();
                    break;
                case "right":
                    Move(0, 1);
                    //  PrintMatrix();
                    break;
            }
        }

        private static void Move(int row, int col)
        {
            if (IsInside(playerRow + row, playerCol + col))
            {
                if (matrix[playerRow + row, playerCol + col] == 'B')
                {
                    matrix[playerRow, playerCol] = '-';
                    playerRow = playerRow + row;
                    playerCol = playerCol + col;
                    GetDifection(direction);
                    return;
                }

                if (matrix[playerRow + row, playerCol + col] == 'T')
                {
                    return;
                }

                if (matrix[playerRow + row, playerCol + col] == 'F')
                {
                    finishLineReached = true;
                    matrix[playerRow + row, playerCol + col] = 'f';
                    matrix[playerRow, playerCol] = '-';
                    playerRow = playerRow + row;
                    playerCol = playerCol + col;
                    return;
                }

                matrix[playerRow + row, playerCol + col] = 'f';
                if (matrix[playerRow, playerCol] != 'B')
                {
                    matrix[playerRow, playerCol] = '-';
                }
                
                playerRow = playerRow + row;
                playerCol = playerCol + col;

            }
            else
            {
                if (playerRow + row < 0)
                {
                    if (matrix[matrix.GetLength(0) - 1, playerCol + col] == 'F')
                    {
                        finishLineReached = true;
                    }
                    matrix[matrix.GetLength(0) - 1 , playerCol + col] = 'f';
                    if (matrix[playerRow, playerCol] != 'B')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    playerRow = matrix.GetLength(0) - 1;
                    playerCol = playerCol + col;
                }
                else if (playerRow + row >= matrix.GetLength(0))
                {
                    if (matrix[0, playerCol + col] == 'F')
                    {
                        finishLineReached = true;
                    }
                    matrix[0, playerCol + col] = 'f';
                    if (matrix[playerRow, playerCol] != 'B')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    playerRow = 0;
                    playerCol = playerCol + col;
                }
                else if (playerCol + col < 0 )
                {
                    if (matrix[playerRow + row, matrix.GetLength(1) - 1] == 'F')
                    {
                        finishLineReached = true;
                    }
                    matrix[playerRow + row, matrix.GetLength(1) - 1] = 'f';
                    if (matrix[playerRow, playerCol] != 'B')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    playerRow = playerRow + row;
                    playerCol = matrix.GetLength(1) - 1;
                }
                else if (playerCol + col >= matrix.GetLength(1))
                {
                    if (matrix[playerRow + row, 0] == 'F')
                    {
                        finishLineReached = true;
                    }
                    matrix[playerRow + row, 0] = 'f';
                    if (matrix[playerRow, playerCol] != 'B')
                    {
                        matrix[playerRow, playerCol] = '-';
                    }
                    playerRow = playerRow + row;
                    playerCol = 0;
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
        private static void FillTheMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
        }

    }
}

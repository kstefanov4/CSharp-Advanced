using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[fieldSize, fieldSize];
            
            FillTheMatrix(fieldSize, fieldSize, matrix);

            //int initialCoalSum = GetCoalSum();
            int[] playerPosition = GetThePlayerPosition(matrix);
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];

            foreach (var command in commands)
            {
                switch (command)
                {
                    case "left":
                        if (CheckInside(playerRow, playerCol - 1, matrix))
                        {
                            if (matrix[playerRow, playerCol - 1] == '*' || matrix[playerRow, playerCol - 1] == 'c')
                            {
                                matrix[playerRow, playerCol - 1] = 's';
                                matrix[playerRow, playerCol] = '*';
                                playerCol = playerCol - 1;
                            }
                            else if (matrix[playerRow, playerCol - 1] == 'e')
                            {
                                matrix[playerRow, playerCol - 1] = 's';
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol - 1})");
                                return;
                            }
                        }
                     break;
                    case "right":
                        if (CheckInside(playerRow, playerCol + 1, matrix))
                        {
                            if (matrix[playerRow, playerCol + 1] == '*' || matrix[playerRow, playerCol + 1] == 'c')
                            {
                                matrix[playerRow, playerCol + 1] = 's';
                                matrix[playerRow, playerCol] = '*';
                                playerCol = playerCol + 1;
                            }
                            else if (matrix[playerRow, playerCol + 1] == 'e')
                            {
                                matrix[playerRow, playerCol + 1] = 's';
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol + 1})");
                                return;
                            }
                        }
                        break;
                    case "up":
                        if (CheckInside(playerRow - 1, playerCol, matrix))
                        {
                            if (matrix[playerRow - 1, playerCol] == '*' || matrix[playerRow - 1, playerCol] == 'c')
                            {
                                matrix[playerRow - 1, playerCol] = 's';
                                matrix[playerRow, playerCol] = '*';
                                playerRow = playerRow - 1;
                            }
                            else if (matrix[playerRow - 1, playerCol] == 'e')
                            {
                                matrix[playerRow - 1, playerCol] = 's';
                                Console.WriteLine($"Game over! ({playerRow - 1}, {playerCol})");
                                return;
                            }
                        }
                        break;
                    case "down":
                        if (CheckInside(playerRow + 1, playerCol, matrix))
                        {
                            if (matrix[playerRow + 1, playerCol] == '*' || matrix[playerRow + 1, playerCol] == 'c')
                            {
                                matrix[playerRow + 1, playerCol] = 's';
                                matrix[playerRow, playerCol] = '*';
                                playerRow = playerRow + 1;
                            }
                            else if (matrix[playerRow + 1, playerCol] == 'e')
                            {
                                matrix[playerRow + 1, playerCol] = 's';
                                Console.WriteLine($"Game over! ({playerRow + 1}, {playerCol})");
                                return;
                            }
                        }
                        break;
                }

                if (GetCoalSum(matrix) == 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    return;
                }
            }

            Console.WriteLine($"{GetCoalSum(matrix)} coals left. ({playerRow}, {playerCol})");
        }

        private static int[] GetThePlayerPosition(char[,] matrix)
        {
            int[] currentPosition = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 's')
                    {
                        currentPosition[0] = i;
                        currentPosition[1] = j;
                    }
                }
            }
            return currentPosition;
        }

        private static void GetAction(int row, int col, char[,] matrix)
        {
            if (matrix[row,col] == '*' || matrix[row, col] == 'c')
            {
                matrix[row, col] = '*';
            }
        }
        private static bool CheckInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }


        private static int GetCoalSum(char[,] matrix)
        {
            int coalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 'c')
                    {
                        coalSum++;
                    }
                }
            }
            return coalSum;
        }
        private static void FillTheMatrix(int row, int col, char[,] matrix)
        {
            
            for (int i = 0; i < row; i++)
            {
                string[] input = Console.ReadLine().Split().Select(x => x.Replace(" ", "")).ToArray();
                for (int j = 0; j < col; j++)
                {
                    string inputChar = input[j];
                    matrix[i, j] = inputChar[0];
                }
            }
        }
    }
}

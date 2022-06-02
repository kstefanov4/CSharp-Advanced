using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixParamethers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = matrixParamethers[0];
            int col = matrixParamethers[1];

            char[,] matrix = new char[row, col];
            FillTheMatrix(row, col, matrix);

            char[] movingCommands = Console.ReadLine().ToCharArray();

            string winState = "";
            int[] playerPosition = new int[2];

            for (
                int i = 0; i < movingCommands.Length; i++)
            {
                playerPosition = GetPlayerPosition(matrix);


                if (movingCommands[i] == 'U')
                {
                    if (CheckInside(playerPosition[0] - 1, playerPosition[1], matrix))
                    {
                        if (matrix[playerPosition[0] - 1, playerPosition[1]] == 'B')
                        {
                            winState = "dead";
                            playerPosition[0] = playerPosition[0] - 1;
                            
                        }
                        else
                        {
                            matrix[playerPosition[0] - 1, playerPosition[1]] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                        }

                    }
                    else
                    {
                        winState = "won";
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        break;
                    }
                }
                else if (movingCommands[i] == 'D')
                {
                    if (CheckInside(playerPosition[0] + 1, playerPosition[1], matrix))
                    {
                        if (matrix[playerPosition[0] + 1, playerPosition[1]] == 'B')
                        {
                            winState = "dead";
                            playerPosition[0] = playerPosition[0] + 1;
                            
                        }
                        else
                        {
                            matrix[playerPosition[0] + 1, playerPosition[1]] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                        }
                    }
                    else
                    {
                        winState = "won";
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        
                    }
                }
                else if (movingCommands[i] == 'L')
                {
                    if (CheckInside(playerPosition[0], playerPosition[1] - 1, matrix))
                    {
                        if (matrix[playerPosition[0], playerPosition[1] - 1] == 'B')
                        {
                            winState = "dead";
                            playerPosition[1] = playerPosition[1] - 1;
                            
                        }
                        else
                        {
                            matrix[playerPosition[0], playerPosition[1] - 1] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                        }

                    }
                    else
                    {
                        winState = "won";
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        
                    }
                }
                else if (movingCommands[i] == 'R')
                {
                    if (CheckInside(playerPosition[0], playerPosition[1] + 1, matrix))
                    {
                        if (matrix[playerPosition[0], playerPosition[1] + 1] == 'B')
                        {
                            winState = "dead";
                            playerPosition[1] = playerPosition[1] + 1;
                            
                        }
                        else
                        {
                            matrix[playerPosition[0], playerPosition[1] + 1] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                        }

                    }
                    else
                    {
                        winState = "won";
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        
                    }
                }
                /*Console.WriteLine();
                PrintMatrix(matrix);*/

                BunniesSpread(matrix);

                if (winState != "")
                {
                    break;
                }

                /*Console.WriteLine();
                PrintMatrix(matrix);*/
            }

            PrintMatrix(matrix);
            Console.WriteLine($"{winState}: {playerPosition[0]} {playerPosition[1]}");
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static int[] GetPlayerPosition(char[,] matrix)
        {
            int[] currentPlayerPosition = new int[2];

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[j, k] == 'P')
                    {
                        currentPlayerPosition = new int[] { j, k };

                    }
                }
            }
            return currentPlayerPosition;

        }

        private static void BunniesSpread(char[,] matrix)
        {
            char[,] currentMatrinx = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < currentMatrinx.GetLength(0); i++)
            {
                for (int j = 0; j < currentMatrinx.GetLength(1); j++)
                {
                    currentMatrinx[i, j] = matrix[i, j];
                }

            }
            /*Console.WriteLine();
            PrintMatrix(matrix);*/

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (currentMatrinx[i, j] == 'B')
                    {
                        if (CheckInside(i - 1, j, matrix))
                        {
                            matrix[i - 1, j] = 'B';
                        }

                        if (CheckInside(i + 1, j, matrix))
                        {
                            matrix[i + 1, j] = 'B';
                        }

                        if (CheckInside(i, j + 1, matrix))
                        {
                            matrix[i, j + 1] = 'B';
                        }

                        if (CheckInside(i, j - 1, matrix))
                        {
                            matrix[i, j - 1] = 'B';
                        }
                    }
                    /*Console.WriteLine();
                    PrintMatrix(matrix);*/
                }

            }
        }

        private static bool CheckInside(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillTheMatrix(int row, int col, char[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }
        }
    }
}

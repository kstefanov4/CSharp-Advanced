using System;
using System.Collections.Generic;
using System.Linq;

namespace TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[matrixSize, matrixSize];
            FillTheMatrix(matrix);

            Dictionary<string, int> petersTruffles = new Dictionary<string, int>();
            petersTruffles.Add("B", 0);
            petersTruffles.Add("S", 0);
            petersTruffles.Add("W", 0);

            int wildBoarTrufflesCount = 0;

            string input = Console.ReadLine();

            while (input != "Stop the hunt")
            {
                string command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];
                int row = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                int col = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[2]);

                string truffles;

                if (command == "Collect")
                {
                    truffles = matrix[row, col];
                    if (truffles != "-")
                    {
                        petersTruffles[truffles]++;
                        matrix[row, col] = "-";
                    }
                   // PrintMatrix(matrix);

                }
                else if (command == "Wild_Boar")
                {
                    string direction = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[3];

                    switch (direction)
                    {
                        case "up" :
                            for (int i = row; i >= 0; i = i - 2)
                            {
                                truffles = matrix[i, col];
                                if (truffles != "-")
                                {
                                    wildBoarTrufflesCount++;
                                    matrix[i, col] = "-";
                                }
                            }
                            break;
                        case "down":
                            for (int i = row; i < matrix.GetLength(0); i = i + 2)
                            {
                                truffles = matrix[i, col];
                                if (truffles != "-")
                                {
                                    wildBoarTrufflesCount++;
                                    matrix[i, col] = "-";
                                }
                            }
                            break;
                        case "left":
                            for (int i = col; i >= 0; i = i - 2)
                            {
                                truffles = matrix[row, i];
                                if (truffles != "-")
                                {
                                    wildBoarTrufflesCount++;
                                    matrix[i, col] = "-";
                                }
                            }
                            break;
                        case "right":

                            for (int i = col; i < matrix.GetLength(1); i = i + 2)
                            {
                                truffles = matrix[row, i];
                                if (truffles != "-")
                                {
                                    wildBoarTrufflesCount++;
                                    matrix[row, i] = "-";
                                }
                            }
                            break;
                    }
                    //PrintMatrix(matrix);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {petersTruffles["B"]} black, {petersTruffles["S"]} summer, and {petersTruffles["W"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarTrufflesCount} truffles.");

            PrintMatrix(matrix);

        }

        private static void FillTheMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine().Split().Select(x => x.Replace(" ", "")).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}

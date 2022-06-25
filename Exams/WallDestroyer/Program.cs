using System;

namespace WallDestroyer
{
    class Program
    {
        private static int vankoRow;
        private static int vankoCol;
        private static char[,] matrix;
        private static int holeCounter = 1;
        private static int rodsCounter = 0;
        private static bool gotElectrocuted = false;
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];

            FillTheMatrix();

            string direction = Console.ReadLine();

            while (true)
            {
                if (direction == "End" || gotElectrocuted)
                {
                    break;
                }

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

                direction = Console.ReadLine();
            }

            if (gotElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCounter} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holeCounter} hole(s) and he hit only {rodsCounter} rod(s).");
            }
            PrintMatrix();
        }

        private static void Move(int row, int col)
        {
            if (IsInside(vankoRow + row, vankoCol + col))
            {
                if (matrix[vankoRow + row, vankoCol + col] == 'R')
                {
                    rodsCounter++;
                    Console.WriteLine("Vanko hit a rod!");
                    return;
                }

                if (matrix[vankoRow + row, vankoCol + col] == 'C')
                {
                    holeCounter++;
                    matrix[vankoRow + row, vankoCol + col] = 'E';
                    matrix[vankoRow, vankoCol] = '*';
                    gotElectrocuted = true;
                    return;
                }

                if (matrix[vankoRow + row, vankoCol + col] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow + row}, {vankoCol + col}]!");
                    matrix[vankoRow, vankoCol] = '*';
                    matrix[vankoRow + row, vankoCol + col] = 'V';
                    vankoRow = vankoRow + row;
                    vankoCol = vankoCol + col;
                    return;
                }

                if (matrix[vankoRow + row, vankoCol + col] == '-')
                {
                    holeCounter++;
                    matrix[vankoRow, vankoCol] = '*';
                    matrix[vankoRow + row, vankoCol + col] = 'V';
                    vankoRow = vankoRow + row;
                    vankoCol = vankoCol + col;
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
                    if (matrix[i, j] == 'V')
                    {
                        vankoRow = i;
                        vankoCol = j;
                    }
                }
            }
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
    }
}

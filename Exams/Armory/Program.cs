using System;

namespace Armory
{
    class Program
    {
        private static int officerRow;
        private static int officerCol;
        private static char[,] matrix;
        private static int bladesWorth = 0;
        private static bool output = false;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];

            FillTheMatrix();

            string direction = Console.ReadLine();

            while (true)
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
                if (output)
                {
                    break;
                }
                direction = Console.ReadLine();
            }
            Console.WriteLine($"The king paid {bladesWorth} gold coins.");
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
        private static void Move(int rowMove, int colMove)
        {
            if (IsInside(officerRow + rowMove, officerCol + colMove))
            {
                if (char.IsDigit(matrix[officerRow + rowMove, officerCol + colMove]))
                {
                    bladesWorth += matrix[officerRow + rowMove, officerCol + colMove] - '0';

                    matrix[officerRow + rowMove, officerCol + colMove] = 'A';
                    matrix[officerRow, officerCol] = '-';

                    SetOfficerNewPosition(officerRow + rowMove, officerCol + colMove);
                    CheckBladesWorth();
                    return;
                }

                if (char.IsLetter(matrix[officerRow + rowMove, officerCol + colMove]))
                {
                    int[] mirrorCoordinates = GetMirrorCoordinates(officerRow + rowMove, officerCol + colMove);

                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow + rowMove, officerCol + colMove] = '-';
                    matrix[mirrorCoordinates[0], mirrorCoordinates[1]] = 'A';

                    SetOfficerNewPosition(mirrorCoordinates[0], mirrorCoordinates[1]);
                    return;

                }
                if (matrix[officerRow + rowMove, officerCol + colMove] == '-')
                {
                    matrix[officerRow + rowMove, officerCol + colMove] = 'A';
                    matrix[officerRow, officerCol] = '-';
                    SetOfficerNewPosition(officerRow + rowMove, officerCol + colMove);
                }
            }
            else
            {
                matrix[officerRow, officerCol] = '-';
                output = true;
                Console.WriteLine("I do not need more swords!");
            }

            
        }

        private static int[] GetMirrorCoordinates(int mirrorRow, int mirrorCol)
        {
            int[] coordinates = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != mirrorRow && j != mirrorCol)
                    {
                        if (matrix[i, j] == 'M')
                        {
                            coordinates[0] = i;
                            coordinates[1] = j;
                        }
                    }
                }
            }
            return coordinates;
        }

        private static void CheckBladesWorth()
        {
            if (bladesWorth >= 65)
            {
                output = true;
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void SetOfficerNewPosition(int rowMove, int colMove)
        {
            officerRow = rowMove;
            officerCol = colMove;
        }

        private static void RewriteTheMatrixAfterMove(int rowMove, int colMove)
        {
            matrix[officerRow + rowMove, officerCol + colMove] = 'A';
            matrix[officerRow, officerCol] = '-';
        }

        private static void FillTheMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'A')
                    {
                        officerRow = i;
                        officerCol = j;
                    }
                }
            }
        }
    }
}

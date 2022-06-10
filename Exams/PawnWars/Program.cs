using System;

namespace PawnWars
{
    class Program
    {
        private static int pawnWhiteRow;
        private static int pawnWhiteCol;

        private static int pawnBlackRow;
        private static int pawnBlackCol;

        private static char[,] matrix;
        private static int matrixSize = 8;
        private static bool isGameEnd = false;
        static void Main()
        {
            matrix = new char[matrixSize, matrixSize];

            FillTheMatrixAndGetPositions();

            while (true)
            {
                if (isGameEnd)
                {
                    break;
                }
                //White pawn moving
                WhiteMove(-1,0);

                if (isGameEnd)
                {
                    break;
                }
                // Black pawn moving
                BlackMove(1,0);
            }
        }

        private static void BlackMove(int row, int col)
        {
            if (pawnBlackRow + row == 7)
            {
                PrintPromotedMessage(pawnBlackRow + row, pawnBlackCol + col);
                isGameEnd = true;
                return;
            }

            if (IsInside(pawnBlackRow + row, pawnBlackCol + col + 1))
            {
                if (matrix[pawnBlackRow + row, pawnBlackCol + col + 1] == 'w')
                {
                    PrintCaptureMessage(pawnBlackRow + row, pawnBlackCol + col + 1);
                    isGameEnd = true;
                    return;
                }
            }

            if (IsInside(pawnBlackRow + row, pawnBlackCol + col - 1))
            {
                if (matrix[pawnBlackRow + row, pawnBlackCol + col - 1] == 'w')
                {
                    PrintCaptureMessage(pawnBlackRow + row, pawnBlackCol + col - 1);
                    isGameEnd = true;
                    return;
                }
            }

            matrix[pawnBlackRow + row, pawnBlackCol + col] = 'b';
            matrix[pawnBlackRow, pawnBlackCol] = '-';
            pawnBlackRow += row;
            pawnBlackCol += col;
        }

        private static void WhiteMove(int row, int col)
        {
            if (pawnWhiteRow + row == 0)
            {
                PrintPromotedMessage(pawnWhiteRow + row, pawnWhiteCol + col);
                isGameEnd = true;
                return;
            }

            if (IsInside(pawnWhiteRow + row, pawnWhiteCol + col + 1))
            {
                if (matrix[pawnWhiteRow + row, pawnWhiteCol + col + 1] == 'b')
                {
                    PrintCaptureMessage(pawnWhiteRow + row, pawnWhiteCol + col + 1);
                    isGameEnd = true;
                    return;
                }
            }

            if (IsInside(pawnWhiteRow + row, pawnWhiteCol + col - 1))
            {
                if (matrix[pawnWhiteRow + row, pawnWhiteCol + col - 1] == 'b')
                {
                    PrintCaptureMessage(pawnWhiteRow + row, pawnWhiteCol + col - 1);
                    isGameEnd = true;
                    return;
                }
            }

            matrix[pawnWhiteRow + row, pawnWhiteCol + col] = 'w';
            matrix[pawnWhiteRow, pawnWhiteCol] = '-';
            pawnWhiteRow += row;
            pawnWhiteCol += col;

        }

        private static void PrintCaptureMessage(int row, int col)
        {
            char letter = (char)((char)97 + col);
            Console.WriteLine($"Game over! white capture on {letter}{8 - row}.");
        }

        private static void PrintPromotedMessage(int row, int col)
        {
            char letter = (char)((char)97 + col);
            Console.WriteLine($"Game over! White pawn is promoted to a queen at {letter}{8 - row}.");
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void FillTheMatrixAndGetPositions()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (input[j] == 'w')
                    {
                        pawnWhiteRow = i;
                        pawnWhiteCol = j;
                    }
                    else if (input[j] == 'b')
                    {
                        pawnBlackRow = i;
                        pawnBlackCol = j;
                    }
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}

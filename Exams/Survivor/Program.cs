using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        private static char[][] beach;
        private static int beachRows;
        private static int collectedTokens = 0;
        private static int opponentTokens = 0;

        private static int opponentRowPosition;
        private static int opponentColPosition;
        private static int steps;


        static void Main(string[] args)
        {
            beachRows = int.Parse(Console.ReadLine());

            FillTheMatrix();

            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "Gong")
            {
                string command = input[0];
                int rowIndex = int.Parse(input[1]);
                int colIndex = int.Parse(input[2]);

                if (IsInside(rowIndex, colIndex))
                {

                    switch (command)
                    {
                        case "Find":

                            if (beach[rowIndex][colIndex] == 'T')
                            {
                                collectedTokens++;
                                beach[rowIndex][colIndex] = '-';
                            }

                            break;
                        case "Opponent":
                            opponentRowPosition = rowIndex;
                            opponentColPosition = colIndex;

                            if (beach[rowIndex][colIndex] == 'T')
                            {
                                opponentTokens++;
                                beach[rowIndex][colIndex] = '-';
                            }
                            steps = 0;
                            OpponentMoving(input[3]);
                            break;
                    }
                }


                input = Console.ReadLine().Split(" ").ToArray();
            }
            PrintMatrix();

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < beach.Length; i++)
            {
                Console.WriteLine(String.Join(" ", beach[i]));
            }
        }

        private static void OpponentMoving(string direction)
        {

            if (steps < 3)
            {

                switch (direction)
                {
                    case "up":
                        Move(-1, 0, direction);
                        // PrintMatrix();
                        break;
                    case "down":
                        Move(1, 0, direction);
                        //  PrintMatrix();
                        break;
                    case "left":
                        Move(0, -1, direction);
                        //  PrintMatrix();
                        break;
                    case "right":
                        Move(0, 1, direction);
                        //  PrintMatrix();
                        break;
                }
            }
        }

        private static void Move(int row, int col, string direction)
        {
            steps++;
            if (IsInside(opponentRowPosition + row, opponentColPosition + col))
            {
                if (beach[opponentRowPosition + row][opponentColPosition + col] == 'T')
                {
                    opponentTokens++;
                    beach[opponentRowPosition + row][opponentColPosition + col] = '-';

                }

                opponentRowPosition = opponentRowPosition + row;
                opponentColPosition = opponentColPosition + col;

                OpponentMoving(direction);

            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < beach.Length &&
                   col >= 0 && col < beach[row].Length;
        }

        private static void FillTheMatrix()
        {
            beach = new char[beachRows][];
            for (int i = 0; i < beachRows; i++)
            {
                string stringInput = Console.ReadLine().Replace(" ", "");
                char[] input = stringInput.ToCharArray();
                beach[i] = input;
            }
        }
    }
}

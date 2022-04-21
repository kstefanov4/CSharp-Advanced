using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[rowAndCol[0], rowAndCol[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputChars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputChars[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input.Split()[0] == "swap")
                {
                    if (input.Split().Length == 5)
                    {
                        int row1 = int.Parse(input.Split()[1]);
                        int col1 = int.Parse(input.Split()[2]);

                        int row2 = int.Parse(input.Split()[3]);
                        int col2 = int.Parse(input.Split()[4]);

                        if (row1 < 0 || row1 > rowAndCol[0] - 1 || row2 < 0 || row2 > rowAndCol[0] - 1 || col1 < 0 || col1 > rowAndCol[1] - 1 || col2 < 0 || col1 > rowAndCol[1] - 1)
                        {
                            printInvalidMessage();
                        }
                        else
                        {
                            string num = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = num;

                            printMatrix(matrix);
                        }
                    }
                    else
                    {
                        printInvalidMessage();
                    }
                }
                else
                {
                    printInvalidMessage();
                }


                input = Console.ReadLine();
            }
        }

        private static void printMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write( matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void printInvalidMessage()
        {
            Console.WriteLine("Invalid input!");
        }
    }
}

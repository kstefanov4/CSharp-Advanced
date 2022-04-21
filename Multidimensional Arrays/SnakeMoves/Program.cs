using System;
using System.Linq;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] martix = new char[rowAndCol[0], rowAndCol[1]];

            char[] inputArray = Console.ReadLine().ToCharArray();

            int inputArrayIndex = 0;

            for (int row = 0; row < martix.GetLength(0); row++)
            {

                if (row % 2 == 0)
                {
                    for (int col = 0; col < martix.GetLength(1); col++)
                    {
                        martix[row, col] = inputArray[inputArrayIndex];
                        inputArrayIndex++;
                        if (inputArrayIndex > inputArray.Length -1 )
                        {
                            inputArrayIndex = 0;
                        }
                        
                        
                    }
                }
                else
                {
                    for (int col = martix.GetLength(1) - 1; col >= 0; col--)
                    {
                        martix[row, col] = inputArray[inputArrayIndex];
                        inputArrayIndex++;
                        if (inputArrayIndex > inputArray.Length - 1)
                        {
                            inputArrayIndex = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < martix.GetLength(0); row++)
            {
                for (int col = 0; col < martix.GetLength(1); col++)
                {
                    Console.Write(martix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

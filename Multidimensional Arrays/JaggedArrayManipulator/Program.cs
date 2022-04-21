using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            double[][] jaggedMatrix = new double[num][];

            for (int i = 0; i < num; i++)
            {
                jaggedMatrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            for (int i = 0; i < jaggedMatrix.Length - 1; i++)
            {
                if (jaggedMatrix[i].Length == jaggedMatrix[i+1].Length)
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] *= 2;
                    }
                    for (int j = 0; j < jaggedMatrix[i + 1].Length; j++)
                    {
                        jaggedMatrix[i+1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedMatrix[i + 1].Length; j++)
                    {
                        jaggedMatrix[i+1][j] /= 2;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArray = input.Split();
                string cmd = inputArray[0];
                int row = int.Parse(inputArray[1]);
                int col = int.Parse(inputArray[2]);
                int value = int.Parse(inputArray[3]);

                if (row >= 0 && row < jaggedMatrix.Length && col >= 0 && col < jaggedMatrix[row].Length)
                {
                    if (cmd == "Add")
                    {
                        jaggedMatrix[row][col] += value;
                    }
                    else if (cmd == "Subtract")
                    {
                        jaggedMatrix[row][col] -= value;
                    }
                    
                    
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < jaggedMatrix.Length; i++)
            {

                Console.WriteLine(string.Join(" ",jaggedMatrix[i]));
            }
        }
    }
}

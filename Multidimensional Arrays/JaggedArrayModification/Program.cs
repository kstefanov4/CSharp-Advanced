using System;
using System.Linq;

namespace JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[][] jaggetArray = new int[num][];

            for (int i = 0; i < num; i++)
            {
                int[] inputNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jaggetArray[i] = inputNums;
            }

            string commands = Console.ReadLine();
            while (commands != "END")
            {
                string[] cmdArray = commands.Split(' ');
                int row = int.Parse(cmdArray[1]);
                int col = int.Parse(cmdArray[2]);
                int newValue = int.Parse(cmdArray[3]);

                if (row < 0 || row > jaggetArray.Length -1 || col < 0 || col > jaggetArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");

                }
                else
                {

                    if (cmdArray[0] == "Add")
                    {
                        jaggetArray[row][col] += newValue;
                    }
                    else if (cmdArray[0] == "Subtract")
                    {
                        jaggetArray[row][col] -= newValue;
                    }
                }
                commands = Console.ReadLine();
            }

            for (int i = 0; i < jaggetArray.Length; i++)
            {
                for (int j = 0; j < jaggetArray[i].Length; j++)
                {
                    Console.Write(jaggetArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

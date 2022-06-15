using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        private static int armyRow;
        private static int armyCol;
        private static char[][] jaggedArray;
        private static bool armyAlive = true;
        private static int armor;

        static void Main(string[] args)
        {
            armor = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());

            jaggedArray = new char[matrixSize][];

            FillTheMatrix();
            GetArmyPosition();

            while (armyAlive)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = input[0];
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                AddOrcToTheField(spawnRow, spawnCol);

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
            }

            PrintMatrix();
        }

        private static void GetArmyPosition()
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }
        }

        private static void Move(int row, int col)
        {
            ArmorDecrease(1);
            
            if (IsInside(armyRow + row, armyCol + col))
            {
                if (jaggedArray[armyRow + row][armyCol + col] == 'O')
                {
                    ArmorDecrease(2);
                    if (armor > 0)
                    {
                        RewriteTheMatrixAfterMove(row, col,'A');
                    }
                    else
                    {
                        RewriteTheMatrixAfterMove(row, col, 'X');
                        armyAlive = false;
                        PrintDefeatedMessage();
                        return;
                    }
                }
                else if (jaggedArray[armyRow + row][ armyCol + col] == 'M')
                {
                    armyAlive = false;
                    RewriteTheMatrixAfterMove(row, col, '-');
                    PrintWinMessage();
                    return;
                }
                else
                {
                    RewriteTheMatrixAfterMove(row, col, 'A');
                    return;
                }
            }

            if (armor <= 0)
            {
                RewriteTheMatrixAfterMove(row, col, 'X');
                armyAlive = false;
                PrintDefeatedMessage();
            }
        }

        private static void PrintWinMessage()
        {
            Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
        }

        private static void RewriteTheMatrixAfterMove(int row, int col, char v)
        {
            jaggedArray[armyRow + row][ armyCol + col] = v;
            jaggedArray[armyRow][armyCol] = '-';
            armyRow += row;
            armyCol += col;
        }

        private static void PrintDefeatedMessage()
        {
            Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
        }

        private static void ArmorDecrease(int v)
        {
            armor -= v;
        }

        private static void FillTheMatrix()
        {
            for (int i = 0; i < jaggedArray.GetLength(0); i++)
            {
                char[] charArray = Console.ReadLine().ToCharArray();
                jaggedArray[i] = charArray;
            }
        }

        private static void AddOrcToTheField(int spawnRow, int spawnCol)
        {
            if (IsInside(spawnRow, spawnCol))
            {
                jaggedArray[spawnRow][spawnCol] = 'O';
            }
        }
        private static void PrintMatrix()
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(String.Join("", jaggedArray[i]));
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length &&
                   col >= 0 && col < jaggedArray[row].Length;
        }
    }
}

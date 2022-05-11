using System;
using System.IO;

namespace ExtractOddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("Input.txt"))
            {
                int counter = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}

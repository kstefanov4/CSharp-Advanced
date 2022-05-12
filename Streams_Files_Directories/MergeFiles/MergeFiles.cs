namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            List<string> input1 = new List<string>();
            List<string> input2 = new List<string>();

            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                string num = reader.ReadLine();

                while (num != null)
                {
                    input1.Add(num);
                    num = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(secondInputFilePath))
            {
                string num = reader.ReadLine();

                while (num != null)
                {
                    input2.Add(num);
                    num = reader.ReadLine();
                }
            }

            int minLenght = Math.Min(input1.Count, input2.Count);
            int maxLenght = Math.Max(input1.Count, input2.Count);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < minLenght; i++)
                {
                    writer.WriteLine(input1[i]);
                    writer.WriteLine(input2[i]);
                }

                if (input1.Count == maxLenght)
                {

                    for (int i = minLenght; i < maxLenght; i++)
                    {
                        writer.WriteLine(input1[i]);
                    }
                }
                else
                {
                    for (int i = minLenght; i < maxLenght; i++)
                    {
                        writer.WriteLine(input2[i]);
                    }
                }
            }

        }
    }
}

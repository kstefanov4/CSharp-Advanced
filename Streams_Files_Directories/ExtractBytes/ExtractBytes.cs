namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (StreamReader streamReader = new StreamReader(bytesFilePath))
            {
                byte[] fileByte = File.ReadAllBytes(binaryFilePath);
                List<string> byteList = new List<string>();
                

                while (!streamReader.EndOfStream)
                {
                    byteList.Add(streamReader.ReadLine());
                }

                foreach (var item in fileByte)
                {
                    if (byteList.Contains(item.ToString()))
                    {
                        stringBuilder.AppendLine(item.ToString());
                    }

                }
            }

            using (StreamWriter streamWriter = new StreamWriter(outputPath))
            {
                streamWriter.WriteLine(stringBuilder.ToString().Trim());
            }

        }
    }
}

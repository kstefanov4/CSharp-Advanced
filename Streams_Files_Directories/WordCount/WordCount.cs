namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> countedWords = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    countedWords.Add(word, 0);
                }
            }

            using (StreamReader textReader = new StreamReader(textFilePath))
            {
                string line = textReader.ReadLine();
                while (line != null)
                {
                    List<string> wordsToCheck = line.Split(new string[] { "-", ", ", " ", "...", ".", "?", "?!" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    foreach (string word in wordsToCheck)
                    {
                        string wordToCheck = word.ToLower();
                        if (countedWords.ContainsKey(wordToCheck))
                        {
                            countedWords[wordToCheck]++;
                        }
                    }
                    line = textReader.ReadLine();
                }
            }


            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in countedWords.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{

    class Food
    {
        
        private List<char> letters;
        public Food(string word)
        {
            Name = word;
            Letters = new List<char>(word.ToList());
        }
        public string Name { get; }
        public List<char> Letters { get => letters; set => letters = value; }

        public void RemoveFromList(char letterToCheck)
        {
            if (Letters.Contains(letterToCheck))
            {
                Letters.Remove(letterToCheck);
                
            }
            
        }
    }
    class Program
    {
        private static List<Food> foodList;
        static void Main(string[] args)
        {
            foodList = new List<Food>();
            Food pear = new Food("pear");
            Food flour = new Food("flour");
            Food pork = new Food("pork");
            Food olive = new Food("olive");
            foodList.Add(pear);
            foodList.Add(flour);
            foodList.Add(pork);
            foodList.Add(olive);


            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            while (consonants.Count > 0)
            {
                char vowelsLetter = vowels.Dequeue();
                CheckLetter(vowelsLetter);
                vowels.Enqueue(vowelsLetter);

                char consonantsLetters = consonants.Pop();
                CheckLetter(consonantsLetters);
            }

            foodList = foodList.Where(x => x.Letters.Count == 0).ToList();

            Console.WriteLine($"Words found: {foodList.Count}");
            foreach (var food in foodList)
            {
                Console.WriteLine(food.Name);
            }
        }

        private static void CheckLetter(char vowelsLetter)
        {
            foreach (var food in foodList)
            {
                food.RemoveFromList(vowelsLetter);
            }
        }
    }
}

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
            Dictionary<string, List<char>> foods = new Dictionary<string, List<char>>
            {
                {"pear", new List<char>("pear".ToList()) },
                {"flour", new List<char>("flour".ToList()) },
                {"pork", new List<char>("pork".ToList()) },
                {"olive", new List<char>("olive".ToList()) }

            };

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
                foreach (var item in foods)
                {
                    if (item.Value.Contains(vowelsLetter))
                    {
                        item.Value.Remove(vowelsLetter);
                    }
                }
               // CheckLetter(vowelsLetter);
                vowels.Enqueue(vowelsLetter);

                char consonantsLetters = consonants.Pop();
                foreach (var item in foods)
                {
                    if (item.Value.Contains(consonantsLetters))
                    {
                        item.Value.Remove(consonantsLetters);
                    }
                }
                // CheckLetter(consonantsLetters);
            }

            Dictionary<string, List<char>> filteredFood = new Dictionary<string, List<char>>();

            foreach (var food in foods)
            {
                if (food.Value.Count == 0)
                {
                    filteredFood.Add(food.Key,food.Value);
                }
            }
            //foodList = foodList.Where(x => x.Letters.Count == 0).ToList();

            Console.WriteLine($"Words found: {filteredFood.Count}");
            foreach (var food in filteredFood)
            {
                Console.WriteLine(food.Key);
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

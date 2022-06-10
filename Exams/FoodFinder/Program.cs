using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<char>> foods = new Dictionary<string, List<char>>
            {
                {"pear", new List<char>("pear".ToList()) },
                {"flour", new List<char>("flour".ToList()) },
                {"pork", new List<char>("pork".ToList()) },
                {"olive", new List<char>("olive".ToList()) }

            };

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
               
                vowels.Enqueue(vowelsLetter);

                char consonantsLetters = consonants.Pop();
                foreach (var item in foods)
                {
                    if (item.Value.Contains(consonantsLetters))
                    {
                        item.Value.Remove(consonantsLetters);
                    }
                }
                
            }

            Dictionary<string, List<char>> filteredFood = new Dictionary<string, List<char>>();

            foreach (var food in foods)
            {
                if (food.Value.Count == 0)
                {
                    filteredFood.Add(food.Key,food.Value);
                }
            }
            
            Console.WriteLine($"Words found: {filteredFood.Count}");
            foreach (var food in filteredFood)
            {
                Console.WriteLine(food.Key);
            }
        }

    }
}

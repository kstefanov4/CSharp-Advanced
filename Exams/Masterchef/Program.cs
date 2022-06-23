using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<int, string> dishes = new Dictionary<int, string>
            {
                {150, "Dipping sauce"},
                {250, "Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"}
            };

            SortedDictionary<string, int> cookedDishes = new SortedDictionary<string, int>();

            while (true)
            {
                if (ingredients.Count == 0 || freshness.Count == 0)
                {
                    break;
                }

                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();

                    if (ingredients.Count == 0)
                    {
                        break;
                    }
                }

                int totalFreshnessLevel = ingredients.Peek() * freshness.Peek();

                if (dishes.ContainsKey(totalFreshnessLevel))
                {
                    string dish = dishes[totalFreshnessLevel];

                    if (!cookedDishes.ContainsKey(dish))
                    {
                        cookedDishes.Add(dish, 1);
                    }
                    else
                    {
                        cookedDishes[dish]++;
                    }
                    ingredients.Dequeue();
                    freshness.Pop();

                }
                else
                {
                    freshness.Pop();
                    int currentIngredients = ingredients.Dequeue();
                    ingredients.Enqueue(currentIngredients + 5);
                }
            }

            if (cookedDishes.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                int ingridientsSum = 0;
                foreach (var item in ingredients)
                {
                    ingridientsSum += item;
                }
                Console.WriteLine($"Ingredients left: {ingridientsSum}");
            }

            foreach (var item in cookedDishes.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}

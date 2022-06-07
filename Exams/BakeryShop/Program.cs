using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterQueue = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flourStack = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<double, string> recipe = new Dictionary<double, string>();
            recipe.Add(50, "Croissant");
            recipe.Add(40, "Muffin");
            recipe.Add(30, "Baguette");
            recipe.Add(20, "Bagel");

            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();

            int waterCount = waterQueue.Count;

            for (int i = 0; i < waterCount; i++)
            {
                double water = waterQueue.Peek();
                double flour = flourStack.Peek();

                double percentage = water * 100 / (water + flour);

                string product = "";

                if (recipe.ContainsKey(percentage))
                {
                    product = recipe[percentage];

                    waterQueue.Dequeue();
                    flourStack.Pop();
                }
                else
                {
                    flour -= water;
                    product = "Croissant";
                    waterQueue.Dequeue();
                    flourStack.Pop();
                    flourStack.Push(flour);

                }

                if (!bakedProducts.ContainsKey(product))
                {
                    bakedProducts.Add(product, 0);
                }

                bakedProducts[product]++;

                if (waterQueue.Count == 0 || flourStack.Count == 0)
                {
                    break;
                }
            }

            foreach (var product in bakedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            var flourLeft = flourStack.Count == 0 ? "None" : string.Join(", ", flourStack);
            var waterLeft = waterQueue.Count == 0 ? "None" : string.Join(", ", waterQueue);

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");

        }
    }
}

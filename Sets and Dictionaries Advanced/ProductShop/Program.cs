using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, double>> shopMap = new SortedDictionary<string, Dictionary<string, double>>();

            while (input != "Revision")
            {
                string shop = input.Split(", ")[0];
                string product = input.Split(", ")[1];
                double price = double.Parse(input.Split(", ")[2]);

                if (!shopMap.ContainsKey(shop))
                {
                    shopMap.Add(shop, new Dictionary<string, double>());
                }

                if (!shopMap[shop].ContainsKey(product))
                {
                    shopMap[shop].Add(product, price);
                }
                
                    shopMap[shop][product] = price;
                

                input = Console.ReadLine();
            }

            foreach (var shop in shopMap)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}

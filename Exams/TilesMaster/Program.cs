using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<int, string> location = new Dictionary<int, string>
            {
                {40,"Sink" },
                {50,"Oven" },
                {60,"Countertop" },
                {70,"Wall" },
            };

            SortedDictionary<string, int> collectedTiles = new SortedDictionary<string, int>();

            while (true)
            {
                if (whiteTiles.Count == 0 || greyTiles.Count == 0)
                {
                    break;
                }

                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int tileSum = whiteTiles.Peek() + greyTiles.Peek();

                    if (location.ContainsKey(tileSum))
                    {
                        string tileLocation = location[tileSum];
                        if (!collectedTiles.ContainsKey(tileLocation))
                        {
                            collectedTiles.Add(tileLocation, 1);
                        }
                        else
                        {
                            collectedTiles[tileLocation]++;
                        }

                    }
                    else
                    {
                        if (!collectedTiles.ContainsKey("Floor"))
                        {
                            collectedTiles.Add("Floor", 1);
                        }
                        else
                        {
                            collectedTiles["Floor"]++;
                        }
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }
                else
                {
                    int white = whiteTiles.Pop() / 2;
                    whiteTiles.Push(white);

                    int grey = greyTiles.Dequeue();
                    greyTiles.Enqueue(grey);
                }

            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ",greyTiles)}");
            }

            foreach (var item in collectedTiles.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

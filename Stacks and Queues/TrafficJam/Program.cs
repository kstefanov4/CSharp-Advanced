using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsThatCanPass = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();

            string input = Console.ReadLine();
            int totalCarPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    if (carsQueue.Count >= carsThatCanPass)
                    {
                        for (int i = 0; i < carsThatCanPass; i++)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            totalCarPassed++;
                        }
                    }
                    else
                    {
                        int queueLenght = carsQueue.Count;

                        for (int i = 0; i < queueLenght; i++)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            totalCarPassed++;
                        }
                    }
                    
                }
                else
                {
                    carsQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{totalCarPassed} cars passed the crossroads.");
        }
    }
}

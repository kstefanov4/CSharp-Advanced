using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedGrams = 0;

            while (true)
            {
                if (guests.Count == 0 || plates.Count == 0)
                {
                    break;
                }

                int guest = guests.Peek();
                int plate = plates.Peek();

                if (plate >= guest)
                {
                    wastedGrams += plate - guest;
                    guests.Dequeue();
                    plates.Pop();
                }
                else
                {
                    while (guest > 0)
                    {
                        guest -= plates.Pop();
                        if (guest < 0)
                        {
                            wastedGrams -= guest;
                        }
                    }
                    guests.Dequeue();

                }
            }

            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ",guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedGrams}");
        }
    }
}

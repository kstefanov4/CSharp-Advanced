using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> set = new HashSet<string>(0);

            while (input != "END")
            {
                string direction = input.Split(", ")[0];
                string number = input.Split(", ")[1];

                if (direction == "IN")
                {
                    set.Add(number);
                }
                else
                {
                    set.Remove(number);
                }

                input = Console.ReadLine();
            }

            if (set.Any())
            {
                foreach (var car in set)
                {
                    Console.WriteLine(car);
                }

            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reservation = Console.ReadLine();
            HashSet<string> set = new HashSet<string>();

            while (reservation != "PARTY")
            {
                set.Add(reservation);
                reservation = Console.ReadLine();
            }

            string camePeople = Console.ReadLine();

            while (camePeople != "END")
            {
                if (set.Contains(camePeople))
                {
                    set.Remove(camePeople);
                }
                camePeople = Console.ReadLine();
            }

            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            foreach (var number in set)
            {
                if (Char.IsDigit(number[0]))
                {
                    vip.Add(number);
                }
                else
                {
                    regular.Add(number);
                }

            }
            int count = vip.Count + regular.Count;
            Console.WriteLine(count);

            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}

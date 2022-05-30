using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToList());

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}

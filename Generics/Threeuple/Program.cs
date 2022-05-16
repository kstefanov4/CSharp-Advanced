using System;

namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameInput = Console.ReadLine().Split(' ');
            Threeuple<string, string, string> nameTuple = new Threeuple<string, string, string>
                ($"{nameInput[0]} {nameInput[1]}", nameInput[2], nameInput[3]);

            string[] beerInput = Console.ReadLine().Split(' ');
            Threeuple<string, int, bool> beerTuple = new Threeuple<string, int, bool>
                (beerInput[0], int.Parse(beerInput[1]), beerInput[2] == "drunk");

            string[] bankInput = Console.ReadLine().Split(' ');
            Threeuple<string, double, string> numTuple = new Threeuple<string, double, string>
                (bankInput[0], double.Parse(bankInput[1]), bankInput[2]);

            Console.WriteLine(nameTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(numTuple);
        }
    }
}

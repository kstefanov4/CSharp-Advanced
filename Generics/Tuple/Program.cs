using System;
using System.Collections.Generic;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            string[] nameInput = Console.ReadLine().Split(' ');
            MyTuple<string, string> nameTuple = new MyTuple<string, string>
                ($"{nameInput[0]} {nameInput[1]}", nameInput[2]);

            string[] beerInput = Console.ReadLine().Split(' ');
            MyTuple<string, int> beerTuple = new MyTuple<string, int>
                (beerInput[0], int.Parse(beerInput[1]));

            string[] numInput = Console.ReadLine().Split(' ');
            MyTuple<int, double> numTuple = new MyTuple<int, double>
                (int.Parse(numInput[0]), double.Parse(numInput[1]));

            Console.WriteLine(nameTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(numTuple);
        }
    }
}

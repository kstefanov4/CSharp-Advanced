﻿using System;

namespace GenericArrayCreator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);

            Console.Write(string.Join(" ",strings));
            Console.Write(string.Join(" ",integers));
        }
    }
}

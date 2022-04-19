using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputArray = Console.ReadLine().ToCharArray();
            Stack<char> charStack = new Stack<char>();
            foreach (var item in inputArray)
            {
                charStack.Push(item);
            }

            foreach (var item in charStack)
            {
                Console.Write(item);
            }
        }
    }
}

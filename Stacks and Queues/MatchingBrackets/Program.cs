using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> intStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (currentChar == '(')
                {
                    intStack.Push(i);
                }
                else if (currentChar == ')')
                {
                    int index = intStack.Pop();
                    string content = input.Substring(index, i - index + 1);

                    Console.WriteLine(content);
                }
            }
        }
    }
}

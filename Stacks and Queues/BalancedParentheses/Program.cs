using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray();

            Stack<char> parentheseStack = new Stack<char>();

            for (int i = 0; i < charArray.Length; i++)
            {
                char currentChar = charArray[i];

                if (currentChar == '(' || currentChar == '{' || currentChar == '[')
                {
                    parentheseStack.Push(currentChar);
                }
                else
                {
                    if (parentheseStack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    if ((parentheseStack.Peek() == '(' && currentChar == ')') || (parentheseStack.Peek() == '{' && currentChar == '}') || (parentheseStack.Peek() == '[' && currentChar == ']'))
                    {
                        parentheseStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }


            }

            Console.WriteLine("YES");


        }
    }
}

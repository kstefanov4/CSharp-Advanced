using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> inputStack = new Stack<string>(Console.ReadLine().Split().Reverse());
           // inputStack.Reverse();
            
            while (inputStack.Count > 1)
            {
                int firstNum = int.Parse(inputStack.Pop());
                string sighn = inputStack.Pop();
                int secondNum = int.Parse(inputStack.Pop());

                switch (sighn)
                {
                    case "+":
                        inputStack.Push((firstNum + secondNum).ToString());
                        break;
                    case "-":
                        inputStack.Push((firstNum - secondNum).ToString());
                        break;
                }
            }
            Console.WriteLine(inputStack.Pop());
        }
    }
}

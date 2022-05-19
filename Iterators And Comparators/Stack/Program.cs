using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();
            Stack<string> myStack = new Stack<string>();

            while (input != "END")
            {
                string[] inputArray = input.Split(new string[] { " ", ", " }, StringSplitOptions.None);
                string command = inputArray[0];

                if (command == "Push")
                {
                    for (int i = 1; i < inputArray.Length; i++)
                    {
                        myStack.Push(inputArray[i]);
                    }
                }
                else if (command == "Pop")
                {
                    myStack.Pop();
                }

                input = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> customStack = new CustomStack<string>();
            customStack.Push("Ivan");
            customStack.Push("Petar");
            customStack.Push("Georgi");
            customStack.Push("Plamen");
            customStack.Push("Bobi");
            //10,20,30,40,50 - array lenght = 8
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Pop());
            //10,20,30
            Console.WriteLine(customStack.Peek());
            // return 30
           customStack.Clear();
            // clear all elements
            customStack.Push("Ivan");
            customStack.Push("Petar");
            customStack.Push("Georgi");
            customStack.Push("Plamen");
            customStack.Push("Bobi");
            //
            Console.WriteLine(customStack.Count());
            // return 5
            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numStack = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            string commands = Console.ReadLine();
            

            while (true)
            {
                string[] commandArray = commands.ToLower().Split();

                if (commandArray[0] == "end")
                {
                    break;
                }

                switch (commandArray[0])
                {
                    case "add":
                        numStack.Push(int.Parse(commandArray[1]));
                        numStack.Push(int.Parse(commandArray[2]));

                        break;

                    case "remove":
                        int count = int.Parse(commandArray[1]);
                        if (numStack.Count >= count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numStack.Pop();
                            }
                        }
                        
                        break;
                }
                commands = Console.ReadLine();
            }
            int sum = 0;
            foreach (var item in numStack)
            {
                sum += item;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

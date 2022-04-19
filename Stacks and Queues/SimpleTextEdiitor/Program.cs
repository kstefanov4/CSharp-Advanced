using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SimpleTextEdiitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> textHistory = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {

                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "1":
                        textHistory.Push(text.ToString());
                        text.Append(command[1]);
                        break;
                    case "2":
                        textHistory.Push(text.ToString());
                        text.Remove(text.Length - int.Parse(command[1]), int.Parse(command[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(command[1]) - 1]);
                        break;
                    case "4":
                        text = new StringBuilder(textHistory.Pop());
                        break;
                }
            }
        }
    }
}

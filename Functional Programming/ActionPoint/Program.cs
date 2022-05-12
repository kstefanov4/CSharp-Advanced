using System;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = x => Console.WriteLine(x);

            foreach (var item in names)
            {
                print(item);
            }
        }
    }
}

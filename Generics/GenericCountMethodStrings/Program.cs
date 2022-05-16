using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < num; i++)
            {
                box.AddItem(double.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box.CountCompateTo(double.Parse(Console.ReadLine())));
        }
    }
}

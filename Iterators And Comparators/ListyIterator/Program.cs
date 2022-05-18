using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>(Console.ReadLine().Split().Skip(1).ToList());

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        
                            Console.WriteLine(string.Join(" ", listyIterator));
                        
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}

using System;

namespace CustomQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue customQueue = new CustomQueue();
            customQueue.Enqueue(10);
            customQueue.Enqueue(20);
            customQueue.Enqueue(30);
            customQueue.Enqueue(40);
            customQueue.Enqueue(50);
            //10,20,30,40,50 - array lenght = 8
            Console.WriteLine(customQueue.Dequeue());
            Console.WriteLine(customQueue.Dequeue());
            //10,20,30
            Console.WriteLine(customQueue.Peek());
            // return 30
            customQueue.Clear();
            // clear all elements
            customQueue.Enqueue(10);
            customQueue.Enqueue(20);
            customQueue.Enqueue(30);
            customQueue.Enqueue(40);
            customQueue.Enqueue(50);
            //
            Console.WriteLine(customQueue.Count());
            // return 5
            foreach (var item in customQueue)
            {
                Console.WriteLine(item);
            }
            customQueue.ForEach(x => Console.WriteLine(x));
        }
    }
}

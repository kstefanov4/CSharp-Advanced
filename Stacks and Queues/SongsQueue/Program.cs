using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsQueue = new Queue<string>(Console.ReadLine().Split(", "));

            
            while (songsQueue.Count > 0)
            {
                string[] commandArray = Console.ReadLine().Split();

                switch (commandArray[0])
                {
                    case "Play":
                        
                            songsQueue.Dequeue();
                        
                        break;
                    case "Add":
                        StringBuilder sbSong = new StringBuilder();
                        for (int i = 1; i < commandArray.Length; i++)
                        {
                            sbSong.Append(commandArray[i]);
                            sbSong.Append(" ");
                        }
                        string song = sbSong.ToString().TrimEnd();

                        if (songsQueue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songsQueue.Enqueue(song);
                        }

                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }
        Console.WriteLine("No more songs!");
        }
    }
}

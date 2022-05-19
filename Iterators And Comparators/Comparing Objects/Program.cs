using System;
using System.Collections.Generic;

namespace Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArray[0];
                int age = int.Parse(inputArray[1]);
                string town = inputArray[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int personIndexToCount = int.Parse(Console.ReadLine());
            Person personToCompare = people[personIndexToCount -1];
            people.RemoveAt(personIndexToCount-1);

            int matches = 1;
            int diff = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    matches++;
                }
                else
                {
                    diff++;
                }
            }

            if (matches == 1 )
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {diff} {matches + diff}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List <Person> personList = new List<Person> ();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(age,name);
                
                personList.Add(person);
            }
            List<Person> filteredList = personList.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            
            foreach (Person person in filteredList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}

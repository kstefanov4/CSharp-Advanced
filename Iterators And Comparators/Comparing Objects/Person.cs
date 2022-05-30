using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Person
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo( Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (Age.CompareTo(other.Age) != 0)
            {
                return Age.CompareTo(other.Age);
            }

            if (Town.CompareTo(this.Town) != 0)
            {
                return Town.CompareTo(this.Town);
            }
            return 0;
        }
    }
}

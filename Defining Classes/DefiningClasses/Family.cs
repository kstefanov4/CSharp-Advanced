using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            PersonList = new List<Person>();
        }
        public List<Person> PersonList { get; set; }

        public void AddMember(Person member)
        {
            PersonList.Add(member);
        }

        public Person GetOldestMember()
        {
            return PersonList.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Person GetPersonOldestThan30()
        {
            List<Person> personOldestThan30 = PersonList.Where(x => x.Age > 30).ToList();
            return personOldestThan30.Count > 0 ? personOldestThan30[0] : null;
        }

    }
}

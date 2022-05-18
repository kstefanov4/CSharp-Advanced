using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public List<T> Colection { get; set; }
        private int index;
        public ListyIterator(List<T> list)
        {
            Colection = list;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (Colection.Count > 0)
            {
                Console.WriteLine(Colection[index]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
            
        }

        public bool HasNext()
        {
            if (index + 1 < Colection.Count)
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Colection.Count; i++)
            {
                yield return Colection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}

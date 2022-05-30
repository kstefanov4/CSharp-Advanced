using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        public Stack()
        {
            Collection = new List<T>();
            Index = -1;
        }
        public List<T> Collection { get; set; }
        public int Index { get; set; }

        public void Push(T element)
        {
            Collection.Add(element);
            Index++;
        }

        public void Pop()
        {
            if (Collection.Count > 0)
            {
                Collection.RemoveAt(Index);
                Index--;
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = Collection.Count - 1; j >= 0; j--)
                {
                    yield return Collection[j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}

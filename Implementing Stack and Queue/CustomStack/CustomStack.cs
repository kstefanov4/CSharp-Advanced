using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int defaultSize = 4;
        private T[] items;
        private int index;
        private T zero;

        public CustomStack()
        {
            this.items = new T[defaultSize];
            index = 0;
            zero = items[index];
        }

        public void Push(T input)
        {
            if (items.Length <= index)
            {
                T[] newArray = Resize();
                items = newArray;
            }

            items[index] = input;
            index++;
        }

        public T Pop()
        {
            if (items.Length > 0)
            {
                T numToReturn = items[index - 1];
                items[index - 1] = zero;
                index--;
                CheckForShrink();
                return numToReturn;

            }
            else
            {
                throw new NullReferenceException();
            }

        }
        public T Peek()
        {
            if (items.Length > 0)
            {
                return items[index - 1];
            }
            else
            {
                throw new NullReferenceException();
            }

        }

        public void Clear()
        {
            for (int i = index - 1; i >= 0; i--)
            {
                items[i] = zero;
                index--;
            }

            CheckForShrink();
        }

        public int Count()
        {
            return index;
        }


        private T[] Resize()
        {
            T[] newArray = new T[items.Length * 2];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = items[i];
            }

            return newArray;
        }

        private T[] Shrink()
        {
            T[] newArray = new T[items.Length / 2];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = items[i];
            }

            return newArray;
        }

        private void CheckForShrink()
        {
            if (items.Length / 4 > index)
            {
                T[] newArray = Shrink();
                items = newArray;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return items[i];
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomQueue
{
    class CustomQueue : IEnumerable
    {
        private const int defaultSize = 4;
        private int[] items;
        private int index;
        private int zero;

        public CustomQueue()
        {
            this.items = new int[defaultSize];
            index = 0;
            zero = items[index];
        }

        public void Enqueue(int input)
        {
            if (items.Length <= index)
            {
                int[] newArray = Resize();
                items = newArray;
            }

            items[index] = input;
            index++;
        }

        public int Dequeue()
        {
            if (items.Length > 0)
            {
                int numToReturn = items[0];
                for (int i = 0; i < index-1; i++)
                {
                    items[i] = items[i + 1];
                }
                items[index - 1] = zero;
                index--;
                CheckForShrink();
                return numToReturn;

            }
            else
            {
                throw new InvalidOperationException("Custom Stack is empty");
            }

        }
        public int Peek()
        {
            if (items.Length > 0)
            {
                return items[index - 1];
            }
            else
            {
                throw new InvalidOperationException("Custom Stack is empty");
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


        private int[] Resize()
        {
            int[] newArray = new int[items.Length * 2];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = items[i];
            }

            return newArray;
        }

        private int[] Shrink()
        {
            int[] newArray = new int[items.Length / 2];
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
                int[] newArray = Shrink();
                items = newArray;
            }
        }
        
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < index; i++)
            {
                action(items[i]);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < index; i++)
            {
                yield return items[i];
            }
        }

       
    }
}

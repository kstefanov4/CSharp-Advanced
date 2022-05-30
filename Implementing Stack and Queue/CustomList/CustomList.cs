using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    internal class CustomList<T>
    {
        private static int defaultSize = 2;
        private T[] items;
        private int index;
        private T zero;
        public CustomList()
        {
            items = new T[defaultSize];
            index = 0;
            zero = items[0];
        }

        public void Add(T input)
        {
            if (items.Length <= index)
            {
                T[] newArray = Resize();
                items = newArray;
                items[index] = input;
            }
            else
            {
                items[index] = input;
            }

            index++;
        }

        public void RemoveAt(int num)
        {
            if (InRangeChecker(num))
            {
                Shift(num);
                
                items[index - 1] = zero;
                index--;
            }

            if (items.Length / 4 > index)
            {
                T[] newArray = Shrink();
                items = newArray;
            }
        }

        public bool Contains(T input)
        {
            for (int i = 0; i < index; i++)
            {
                if (items[i].Equals(input))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int indexPosition1, int indexPosition2)
        {
            if (InRangeChecker(indexPosition1) && InRangeChecker(indexPosition2))
            {
                T temp = items[indexPosition1];
                items[indexPosition1] = items[indexPosition2];
                items[indexPosition2] = temp;
            }
            
        }

        public int Count()
        {
            return index;
        }

        public bool InRangeChecker(int num)
        {
            if (num >= 0 && num <= index)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(num));
            }
            
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

        private void Shift(int num)
        {
            for (int i = num; i < index - 1; i++)
            {
                items[i] = items[i + 1];
            }
            
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

    }
}

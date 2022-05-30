using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    internal class CustomList
    {
        private static int defaultSize = 2;
        private int[] items;
        private int index;
        public CustomList()
        {
            items = new int[defaultSize];
            index = 0;
        }

        public void Add(int num)
        {
            if (items.Length <= index)
            {
                int[] newArray = Resize();
                items = newArray;
                items[index] = num;
            }
            else
            {
                items[index] = num;
            }

            index++;
        }

        public void RemoveAt(int num)
        {
            if (InRangeChecker(num))
            {
                Shift(num);
                index--;
            }

            if (items.Length / 4 > index)
            {
                int[] newArray = Shrink();
                items = newArray;
            }
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

        public bool Contains(int num)
        {
            for (int i = 0; i < index; i++)
            {
                if (items[i] == num)
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
                int temp = items[indexPosition1];
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

        private int[] Resize()
        {
            int[] newArray = new int[items.Length * 2];
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
            items[index - 1] = 0;
        }

    }
}

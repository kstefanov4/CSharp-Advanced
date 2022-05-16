using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> itemList = new List<T>();
        public void AddItem(T item)
        {
            itemList.Add(item);
        }

        public int CountCompateTo(T itemToCompare)
        {
            int count = 0;
            foreach (T item in itemList)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
        
    }
}

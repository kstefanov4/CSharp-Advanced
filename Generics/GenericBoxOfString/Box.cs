using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T item;
        public Box(T item)
        {
            this.item = item;
        }
        public override string ToString()
        {
            string classFullName = typeof(T).FullName;
            return $"{classFullName}: {item}";
        }
    }
}

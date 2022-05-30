using System;
using System.Collections.Generic;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            customList.Add(10);
            customList.Add(20);
            customList.Add(30);
            // 10, 20, 30
            customList.RemoveAt(1);
            // 10, 30
            customList.Add(40);
            // 10, 30, 40
            customList.RemoveAt(0);
            //30,40
        //    customList.RemoveAt(5);
            //IndexOutOfRangeException
            customList.Contains(30);
            //true
            customList.Contains(500);
            //false
            customList.Add(100);
            //30,40,100
            customList.Swap(0, 2);
            //100,40,30
         //   customList.Swap(0, 5);
            //IndexOutOfRangeException
            int count = customList.Count();
            customList.Add(40);
            customList.Add(50);
            customList.Add(60);
            //100,40,30,40,50,60
            customList.RemoveAt(0);
            customList.RemoveAt(0);
            customList.RemoveAt(0);
            customList.RemoveAt(0);
            customList.RemoveAt(0);
            //60
            //Shrink to 4 lenght
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string name = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                decimal grade = decimal.Parse(input.Split()[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }
            

            foreach (var student in students)
            {
                double averageSum = (double)student.Value.Average();
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(x => $"{x:f2}"))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}

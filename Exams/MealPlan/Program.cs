using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> mealCalories = new Dictionary<string, int>();
            mealCalories.Add("salad", 350);
            mealCalories.Add("soup", 490);
            mealCalories.Add("pasta", 680);
            mealCalories.Add("steak", 790);

            int initialMeals = meals.Count;

            for (
                int i = 0; i < initialMeals; i++)
            {
                string meal = meals.Dequeue();
                int caloriesPerMeal = mealCalories[meal];
                int allowedCaloriesPerDay = caloriesPerDay.Pop() - caloriesPerMeal;
                if (allowedCaloriesPerDay > 0)
                {
                    caloriesPerDay.Push(allowedCaloriesPerDay);
                }
                else
                {
                    if (caloriesPerDay.Count>0)
                    {
                        int newAllowedCaloriesPerDay = caloriesPerDay.Pop() + allowedCaloriesPerDay;
                        //allowedCaloriesPerDay -= caloriesPerDay.Pop();
                        caloriesPerDay.Push(newAllowedCaloriesPerDay);
                    }
                    else
                    {
                        break;
                    }
                    
                }

                if (meals.Count == 0 || caloriesPerDay.Count == 0)
                {
                    break;
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {initialMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {initialMeals - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }

            

        }
    }
}

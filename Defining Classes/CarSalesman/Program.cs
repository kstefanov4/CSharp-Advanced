using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int engineNum = int.Parse(Console.ReadLine());
            List<Engine> engineList = new List<Engine>();

            for (int i = 0; i < engineNum; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                int displecement;
                string efficiency;
                Engine engine = null;

                if (engineData.Length == 2)
                {                    
                    engine = new Engine(model,power);
                }
                else if (engineData.Length == 4)
                {
                    displecement = int.Parse(engineData[2]);
                    efficiency = engineData[3];
                    engine = new Engine(model,power,displecement,efficiency);
                }
                else if (engineData.Length == 3)
                {
                    try
                    {
                        int.Parse(engineData[2]);
                        displecement = int.Parse(engineData[2]);
                        engine = new Engine(model, power, displecement);
                    }
                    catch (Exception exception)
                    {

                        efficiency = engineData[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                engineList.Add(engine);
            }

            int carNum = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();

            for (int i = 0; i < carNum; i++)
            {
                string[] carData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                string engine = carData[1];
                int weight;
                string color;
                Car car = null;

                Engine engineFromList = engineList.Where(x => x.Model.Equals(engine)).FirstOrDefault();

                if (carData.Length == 2)
                {
                    car = new Car(model, engineFromList);
                }
                else if (carData.Length == 4 )
                {
                    weight = int.Parse(carData[2]);
                    color = carData[3];
                    car = new Car(model,engineFromList, weight,color);
                }
                else if (carData.Length == 3)
                {
                    try
                    {
                        int.Parse(carData[2]);
                        weight = int.Parse(carData[2]);
                        car = new Car(model,engineFromList,weight);
                    }
                    catch (Exception)
                    {

                        color = carData[2];
                        car = new Car(model, engineFromList, color);
                    }
                }
                carList.Add(car);   
            }
            foreach (var item in carList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            //List<Car> cars = new List<Car>();
            Dictionary<string, Car> carMap = new Dictionary<string, Car>();

            for (int i = 0; i < num; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                //cars.Add(car);
                carMap.Add(model, car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArray = command.Split();
                int distance = int.Parse(commandArray[2]);

                Car currentCar = carMap[commandArray[1]];
                // cars.Remove(currentCar);
                currentCar.DriveKM(distance);
                //cars.Add(currentCar);
                carMap[commandArray[1]] = currentCar;
                

                command = Console.ReadLine();
            }

            foreach (var car in carMap)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.TravelledDistance}");
            }
        }
    }
}

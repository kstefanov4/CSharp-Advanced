using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num =int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();
            
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split();
                
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed,enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire tire1 = new Tire(tire1age, tire1Pressure);
                Tire tire2 = new Tire(tire2age, tire2Pressure);
                Tire tire3 = new Tire(tire3age, tire3Pressure);
                Tire tire4 = new Tire(tire4age, tire4Pressure);

                Car car = new Car(model, engine, cargo, new Tire[] { tire1, tire2, tire3, tire4 });
                carList.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in carList.Where(x => x.Cargo.Type == "fragile").Where(x =>
                {
                    foreach (var tire in x.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            return true;
                        }
                    }
                    return false;
                }))
                {
                    Console.WriteLine($"{car.Model}");
                }
                
            }
            else if (command == "flammable")
            {
                foreach (var car in carList.Where(x => x.Cargo.Type == "flammable").Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tireInput = Console.ReadLine();
            List<Tire[]> tireList = new List<Tire[]>();

            while (tireInput != "No more tires")
            {
                string[] tiresData = tireInput.Split();
                Tire[] tires = new Tire[4];

                int counter = 0;
                double totalTirePressure = 0;
                for (int i = 0; i < tiresData.Length; i += 2)
                {
                    int year = int.Parse(tiresData[i]);
                    double pressure = double.Parse(tiresData[i + 1]);
                    totalTirePressure += pressure;
                    Tire tire = new Tire(year, pressure);

                    tires[counter] = tire;
                    counter++;
                }
                tireList.Add(tires);
                tireInput = Console.ReadLine();
            }

            string engineInput = Console.ReadLine();
            List<Engine> engineList = new List<Engine>();

            while (engineInput != "Engines done")
            {
                string[] engineData = engineInput.Split();

                for (int i = 0; i < engineData.Length; i += 2)
                {
                    int horsePower = int.Parse(engineData[i]);
                    double cubicCapacity = double.Parse(engineData[i + 1]);
                    Engine engine = new Engine(horsePower, cubicCapacity);
                    engineList.Add(engine);
                }
                engineInput = Console.ReadLine();
            }

            string carInput = Console.ReadLine();
            List<Car> carList = new List<Car>();

            while (carInput != "Show special")
            {
                string[] carData = carInput.Split();

                string make = carData[0];
                string model = carData[1];
                int year =int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tiresIndex = int.Parse(carData[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineList[engineIndex], tireList[tiresIndex]);
                carList.Add(car);

                carInput = Console.ReadLine();
            }

            

            foreach (var car in carList.Where(x => x.Year >= 2017).Where(x => x.Engine.HorsePower > 330))
            {
                double totalPressureSum = 0;
                foreach (var tire in car.Tires)
                {
                    totalPressureSum += tire.Pressure;
                }

                if (totalPressureSum >= 9 && totalPressureSum <= 10)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}

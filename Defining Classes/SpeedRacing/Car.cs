using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance = 0;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
        }
        public string Model { get => model; set => model = value; }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double FuelConsumptionPerKilometer { get { return fuelConsumptionPerKilometer; } set { fuelConsumptionPerKilometer = value; } }
        public double TravelledDistance { get { return travelledDistance; } set { travelledDistance = value; } }
        public void DriveKM (int km)
        {
            if (km * fuelConsumptionPerKilometer <= fuelAmount)
            {
                fuelAmount -= km * fuelConsumptionPerKilometer;
                travelledDistance += km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public string Print()
        {
            return $"{model} {fuelAmount} {travelledDistance}";
        }
    }
}

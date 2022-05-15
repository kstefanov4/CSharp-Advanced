using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement = 0;
        private string efficiency = "n/a";
        public string Model { get => model; set => model = value; }
        public int Power { get => power; set => power = value; }
        public int Displacement { get => displacement; set => displacement = value; }
        public string Efficiency { get => efficiency; set => efficiency = value; }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficieny) : this(model, power)
        {
            Efficiency = efficieny;
        }

        public Engine(string model, int power, int displacement, string efficieny) : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficieny;
        }
    }
}

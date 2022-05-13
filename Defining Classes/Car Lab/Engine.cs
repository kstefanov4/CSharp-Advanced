using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get => horsePower; set => horsePower = value; }
        public double CubicCapacity { get => cubicCapacity; set => cubicCapacity = value; }

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
    }
}

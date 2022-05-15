using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight = 0;
        private string color = "n/a";
        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public int Weight { get => weight; set => weight = value; }
        public string Color { get => color; set=> color = value; }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Model}:\n  {Engine.Model}:\n    Power: {(Engine.Power != 0 ? Engine.Power.ToString() : "n/a")}" +
                $"\n    Displacement: {(Engine.Displacement != 0 ? Engine.Displacement.ToString() : "n/a")}\n    Efficiency: {Engine.Efficiency}" +
                $"\n  Weight: {(Weight != 0 ? Weight.ToString() : "n/a")}\n  Color: {Color}";
        }
    }
}

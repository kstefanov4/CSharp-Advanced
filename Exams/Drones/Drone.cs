using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available = true;

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
        }

        public string Name { get => name; set => name = value; }
        public string Brand { get => brand; set => brand = value; }
        public int Range { get => range; set => range = value; }
        public bool Available { get => available; set => available = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");
            return sb.ToString().Trim();
        }

    }
}

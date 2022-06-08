using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly ICollection<Fish> fish;
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            this.fish = new List<Fish>();

        }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Fish> Fish => (IReadOnlyCollection<Fish>)this.fish;

        public int Count => this.fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length == 0 || fish.Weight == 0)
            {
                return $"Invalid fish.";
            }
            if (Fish.Count >= Capacity)
            {
                return $"Fishing net is full.";
            }

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (fish != null)
            {
                return this.fish.Remove(fish);
            }
            return false;
        }

        public Fish GetFish(string fishType) 
        {
            return this.fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            double longestFish = this.fish.Max(e => e.Length);
            return this.fish.FirstOrDefault(e => e.Length == longestFish);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var item in Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();

        }

    }
}

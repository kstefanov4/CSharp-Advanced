using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private string name;
        private int capacity;
        private double landingStrip;
        private ICollection<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public double LandingStrip { get => landingStrip; set => landingStrip = value; }
        public ICollection<Drone> Drones { get => drones; set => drones = value; }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Brand) || string.IsNullOrEmpty(drone.Name) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }


            if (Count > Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            // int count = Drones.RemoveAll(x => x.Name == name);
            // return count > 0;
            
            foreach (var drone in Drones)
            {
                Drone droneToRemove = this.Drones.FirstOrDefault(x => x.Name == name);

                if (droneToRemove != null)
                {
                    return Drones.Remove(droneToRemove);
                }
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            // return Drones.RemoveAll(x => x.brand == brand); 
            
            int removedDrones = 0;

            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones.ElementAt(i).Brand == brand)
                {
                    removedDrones++;
                }
            }
            Drones = Drones.Where(x => x.Brand != brand).ToArray();
            return removedDrones;
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToFly = Drones.FirstOrDefault(x => x.Name == name);
            if (droneToFly != null)
            {
                droneToFly.Available = false;
            }
            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDronesByRange = Drones.Where(x => x.Range >= range).ToList();
            foreach (var drone in flyDronesByRange)
            {
                Drones.Remove(drone);
                drone.Available = false;
            }
            return flyDronesByRange;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            
            foreach (var item in Drones)
            {
                sb.AppendLine($"Drone: {item.Name}");
                sb.AppendLine($"Manufactured by: {item.Brand}");
                sb.AppendLine($"Range: {item.Range} kilometers");
            }

            return sb.ToString().Trim();
        }
    }
}

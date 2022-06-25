using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new Dictionary<string, Car>();

        }
        public Dictionary<string, Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count() => Participants.Count;

        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate) || Capacity > Participants.Count || car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
            {
                Participants.Remove(licensePlate);
                return true;
            }
            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var item in Participants)
            {
                if (item.Key == licensePlate)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }
            else
            {
                return Participants.OrderByDescending(x => x.Value.HorsePower).First().Value;

            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var item in Participants)
            {
                sb.Append(item.Value);
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }
    }
}

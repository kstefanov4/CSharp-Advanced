using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Ski ski)
        {

            if (data.Count + 1 <= Capacity )
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            //data.RemoveAll(x => x.Manufacturer == manufacturer && x.Model == model);
            
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski != null)
            {
                data.Remove(ski);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int Count => data.Count;

        public string GetStatistics()
        {
            return $"The skis stored in {Name}:" + Environment.NewLine +
            string.Join(Environment.NewLine, data);
        }
    }
}

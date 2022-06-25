using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (renovators.Count + 1 > NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
            
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(x => x.Name == name);
            if (renovator != null)
            {
                renovators.Remove(renovator);
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            foreach (var renovator in renovators)
            {
                if (renovator.Type == type)
                {
                    count++;
                }
            }

            renovators.RemoveAll(x => x.Type == type);

            return count;
        }

        public Renovator HireRenovator(string name)
        {
            foreach (var renovator in renovators)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    return renovator;
                }
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payRenovators = new List<Renovator>(renovators.Where(x => x.Days >= days));
            return payRenovators;
        }

        public string Report()
        {
            List<Renovator> notHiredRenovators = new List<Renovator>(renovators.Where(x => x.Hired == false));

            return $"Renovators available for Project {Project}" + Environment.NewLine +
                string.Join(Environment.NewLine, notHiredRenovators);
        }
    }
}

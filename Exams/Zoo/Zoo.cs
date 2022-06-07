using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }
        public List<Animal> Animals { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal (Animal animal)
        {
            if (String.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count > Capacity)
            {
                return "The zoo is full.";
            }
            Animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int removedAnimals = 0;

            foreach (var animal in Animals)
            {
                if (animal.Species == species)
                {
                    removedAnimals++;
                }
            }
            Animals = Animals.Where(x => x.Species != species).ToList();
            
            return removedAnimals;
        }

        private void Remove(Animal animal)
        {
            Animals.Remove(animal);
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(x => x.Diet == diet).ToList();
            
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int animalCount = 0;

            foreach (var animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    animalCount++;
                }
            }
            return $"There are {animalCount} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}

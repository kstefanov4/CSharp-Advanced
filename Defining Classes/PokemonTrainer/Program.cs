using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Trainer> trainerMap = new Dictionary<string, Trainer>();

            while (input != "Tournament")
            {
                string trainerName = input.Split(' ')[0];
                string pokemonName = input.Split(' ')[1];
                string pokemonElement = input.Split(' ')[2];
                int pokemonHealth = int.Parse(input.Split(' ')[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);
                trainer.AddPokemonToTheList(pokemon);

                if (!trainerMap.ContainsKey(trainerName))
                {
                    trainerMap.Add(trainerName, trainer);
                }
                else
                {
                    trainerMap[trainerName].AddPokemon(pokemon);
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainerMap.Values)
                {
                    bool hasAPokemon = false;
                    foreach (var pokemon in trainer.PokemonList)
                    {
                        if (pokemon.Element.Equals(command))
                        {
                            hasAPokemon = true;
                        }
                    }

                    if (hasAPokemon)
                    {
                        trainer.NumberOfBarges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.PokemonList)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                    trainer.PokemonList.RemoveAll(x => x.Health <= 0);
                }
                command = Console.ReadLine();
            }

            foreach (var trainer in trainerMap.Values.OrderByDescending(x => x.NumberOfBarges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBarges} {trainer.PokemonList.Count}");
            }
        }
    }
}

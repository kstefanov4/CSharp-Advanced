using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        //private string name;
        private int numberOfBadges = 0;
        //private List<Pokemon> pokemonList = new List<Pokemon>();
        public string Name { get; set; }
        public int NumberOfBarges { get => numberOfBadges; set => numberOfBadges = value; }
        public List<Pokemon> PokemonList { get; set; }

        public Trainer(string name)
        {
            Name = name;
            PokemonList = new List<Pokemon>();
        }
        public void AddPokemonToTheList(Pokemon pokemon)
        {
            PokemonList.Add(pokemon);
        }
        public void AddPokemon(Pokemon pokemon)
        {
            PokemonList.Add(pokemon);
        }
    }
}

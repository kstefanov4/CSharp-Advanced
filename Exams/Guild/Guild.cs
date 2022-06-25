using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();

        }
        public string Name{ get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (roster.Count + 1 <= Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name && player.Rank != "Member")
                {
                    player.Rank = "Member";
                    return;
                }
            }
        }

        public void DemotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name && player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                    return;
                }
            }
        }

        public Player[] KickPlayersByClass(string playerClass)
        {
           List<Player> kickedPlayers = new List<Player>(roster);
            roster.RemoveAll(x => x.Class == playerClass);
            kickedPlayers.RemoveAll(x => x.Class != playerClass);

            Player[] playerArray = new Player[kickedPlayers.Count];

            return playerArray = kickedPlayers.ToArray();
        }

        public int Count => roster.Count;

        public string Report()
        {
            return $"Players in the guild: {Name}" + Environment.NewLine +
                string.Join(Environment.NewLine, roster);
        }
    }
}

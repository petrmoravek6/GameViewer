using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Model
{
    public class Player : DomainEntity<long?>
    {
        private long? id;
        public string name;
        public DateTime dateOfBirth;
        public PlayerPosition position;
        /**
         * The team which the player plays in.
         */
        public Team team;
        /**
         * The matches that the player participates in.
         */
        public readonly ISet<Match> matchesPlayed
        {
            get 
            {
                return matchesPlayed;
            }
        }
        private readonly MatchService matchService;

        public Player(long? id, string name, DateTime dateOfBirth, PlayerPosition position, Team team, MatchService matchService)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.position = position;
            this.team = team;
            this.matchService = matchService;
        }

        public long? getId()
        {
            return id;
        }

        public void setId(long? id)
        {
            this.id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   id == player.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }
}

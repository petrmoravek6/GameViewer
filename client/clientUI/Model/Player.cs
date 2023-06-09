﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Model
{
    public class Player : GameModel<long?>
    {
        private long? id;
        public string name;
        public DateTime dateOfBirth;
        public PlayerPosition position;
        /**
         * The team which the player plays in.
         */
        public Team team;

        public Player(long? id, string name, DateTime dateOfBirth, PlayerPosition position, Team team)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.position = position;
            this.team = team;
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

        public T apply<T>(Visitor<T> visitor)
        {
            return visitor.VisitPlayer(this);
        }
    }
}

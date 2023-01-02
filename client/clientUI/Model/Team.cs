using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Model
{
    public class Team : DomainEntity<long?>
    {
        private long? id;
        public string name;
        public string shortname;

        public Team(long? id, string name, string shortname)
        {
            this.id = id;
            this.name = name;
            this.shortname = shortname;
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
            return obj is Team team &&
                   id == team.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }
}

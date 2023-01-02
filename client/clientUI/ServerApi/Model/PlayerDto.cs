using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model
{
    public class PlayerDto : DomainEntity<long?> {
        private long? id;
        public string name;
        public int dayOfBirth;
        public int monthOfBirth;
        public int yearOfBirth;
        public string position;
        public long team;
        public List<long> matchesPlayed;

        public long? getId()
        {
            return id;
        }

        public void setId(long? id)
        {
            this.id = id;
        }

    }
}

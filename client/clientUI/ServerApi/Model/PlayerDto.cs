using clientUI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model
{
    public class PlayerDto : DomainEntity<long?> {
        [JsonProperty]
        private long? id;
        public string name;
        public int dayOfBirth;
        public int monthOfBirth;
        public int yearOfBirth;
        public string position;
        public long team;

        public PlayerDto(long? id, string name, int dayOfBirth, int monthOfBirth, int yearOfBirth, string position, long team)
        {
            this.id = id;
            this.name = name;
            this.dayOfBirth = dayOfBirth;
            this.monthOfBirth = monthOfBirth;
            this.yearOfBirth = yearOfBirth;
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

    }
}

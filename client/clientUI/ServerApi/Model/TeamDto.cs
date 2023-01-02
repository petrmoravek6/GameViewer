using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model
{
    public class TeamDto : DomainEntity<long?> {
        private long? id;
        public string name;
        public string shortname;

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

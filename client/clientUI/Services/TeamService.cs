using clientUI.Model;
using clientUI.ServerApi;
using clientUI.ServerApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Services
{
    public class TeamService : CrudService<long?, Team, TeamDto>
    {
        public TeamService(TeamRequester requester) : base(requester)
        {
        }
    }
}

using clientUI.Forms;
using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.UIContext
{
    public class TeamContext : GameModelContext<long?, Team, TeamDto>
    {
        public TeamContext(TeamService service) : base(service)
        {
        }

        public override void CreateEntity()
        {
            var form = new AddTeamForm((TeamService)service);
            form.ShowDialog();
        }

        public override void DeleteEntity(int idx)
        {
           ((TeamService)service).Delete(entities[idx]);
        }

        public override void DisplayEntity(int idx)
        {
            var form = new ViewTeamForm((TeamService)service, entities[idx]);
            form.ShowDialog();
        }
    }
}

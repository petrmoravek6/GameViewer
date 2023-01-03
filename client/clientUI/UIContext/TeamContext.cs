using clientUI.Forms;
using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.Services;

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

        public override void DisplayEntity(int idx)
        {
            var form = new ViewTeamForm((TeamService)service, entities[idx]);
            form.ShowDialog();
        }
    }
}

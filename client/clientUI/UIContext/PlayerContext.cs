using clientUI.Forms;
using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.Services;

namespace clientUI.UIContext
{
    public class PlayerContext : GameModelContext<long?, Player, PlayerDto>
    {
        private readonly TeamService teamService;

        public PlayerContext(PlayerService service, TeamService teamService) : base(service)
        {
            this.teamService = teamService;
        }

        public override void CreateEntity()
        {
            var form = new AddPlayerForm((PlayerService)service, teamService);
            form.ShowDialog();
        }

        public override void DisplayEntity(int idx)
        {
            var form = new ViewPlayerForm((PlayerService)service, entities[idx], teamService);
            form.ShowDialog();
        }
    }
}

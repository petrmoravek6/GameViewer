using clientUI.Forms;
using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.Services;

namespace clientUI.UIContext
{
    public class MatchContext : GameModelContext<long?, Match, MatchDto>
    {
        private readonly PlayerService playerService;
        private readonly TeamService teamService;

        public MatchContext(MatchService service, PlayerService playerService, TeamService teamService) : base(service)
        {
            this.playerService = playerService;
            this.teamService = teamService;
        }

        public override void CreateEntity()
        {
            var form = new AddMatchForm((MatchService)service, playerService, teamService);
            form.ShowDialog();
        }

        public override void DisplayEntity(int idx)
        {
            var form = new ViewMatchForm((MatchService)service, playerService, teamService, entities[idx]);
            form.ShowDialog();
        }
    }
}

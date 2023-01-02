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
    public class PlayerService : CrudService<long?, Player, PlayerDto>
    {
        public PlayerService(PlayerRequester requester) : base(requester)
        {
        }

        public List<Team> ReadAllTeamsPlayerWonAgainst(Player player)
        {
            try
            {
                return ((PlayerRequester)requester).GetAllTeamsPlayerWonAgainst(player);
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException || ex is HttpRequestException)
                {
                    throw new Exception("Connection to server failed. Please check internet connection.");
                }
                throw;
            }
        }
    }
}

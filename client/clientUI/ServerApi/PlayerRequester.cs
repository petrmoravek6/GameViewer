using clientUI.Model;
using clientUI.ServerApi.Model;
using clientUI.ServerApi.Model.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Resources.ResXFileRef;

namespace clientUI.ServerApi
{
    internal class PlayerRequester : CrudRequester<long?, Player, PlayerDto>
    {
        private readonly IConverter<Team, TeamDto> teamConverter;

        public PlayerRequester(string basePath, IConverter<Player, PlayerDto> playerConverter, IConverter<Team, TeamDto> teamConverter) 
            : base(basePath, "player", playerConverter)
        {
            this.teamConverter = teamConverter;
        }

        public List<Team> GetAllTeamsPlayerWonAgainst(Player player)
        {
            if (player.getId() is null)
            {
                throw new ArgumentNullException("id");
            }
            var id = player.getId().Value;
            var response = client.GetAsync($"{basePath}/{parameter}/{id}/won_teams").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error during posting. STATUS CODE: " + response.StatusCode);
            }
            var responseString = response.Content.ReadAsStringAsync().Result;
            var dtoTeams = JsonConvert.DeserializeObject<List<TeamDto>>(responseString);
            return dtoTeams.Select(dto => teamConverter.ToEntity(dto)).ToList();
        }
    }
}

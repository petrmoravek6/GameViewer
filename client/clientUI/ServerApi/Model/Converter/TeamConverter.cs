using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model.Converter
{
    public class TeamConverter : IConverter<Team, TeamDto>
    {
        public TeamDto ToDto(Team entity)
        {
            return new TeamDto(entity.getId(), entity.name, entity.shortname);
        }

        public Team ToEntity(TeamDto dto)
        {
            return new Team(dto.getId(), dto.name, dto.shortname);
        }
    }
}

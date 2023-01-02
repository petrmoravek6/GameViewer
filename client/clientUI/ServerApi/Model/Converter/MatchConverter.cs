using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model.Converter
{
    public class MatchConverter : IConverter<Match, MatchDto>
    {
        private PlayerService playerService;
        private TeamService teamService;
        public MatchDto toDto(Match entity)
        {
            return new MatchDto(entity.getId(), entity.homeTeamScore, entity.awayTeamScore, entity.ageLimit.ToString(),
                entity.dateOfTheMatch.Day, entity.dateOfTheMatch.Month, entity.dateOfTheMatch.Year, 
                entity.homeTeam.getId().Value, entity.awayTeam.getId().Value, entity.participants.Select(p => p.getId().Value).ToList());
        }

        public Match toEntity(MatchDto dto)
        {
            List<Player> participants = 
            Team homeTeam
            Team awayTeam
            return new Match(dto.getId(), dto.homeTeamScore, dto.awayTeamScore, Enum.Parse(typeof(AgeLimit), dto.ageLimit), 
                new DateTime(dto.year, dto.month, dto.day), );
        }

        public Match ToEntity(MatchDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

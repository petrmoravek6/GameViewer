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
        private PlayerRequester playerRequester;
        private TeamRequester teamRequester;

        public MatchConverter(PlayerRequester playerRequester, TeamRequester teamRequester)
        {
            this.playerRequester = playerRequester;
            this.teamRequester = teamRequester;
        }

        public MatchDto ToDto(Match entity)
        {
            return new MatchDto(entity.getId(), entity.homeTeamScore, entity.awayTeamScore, entity.ageLimit.ToString(),
                entity.dateOfTheMatch.Day, entity.dateOfTheMatch.Month, entity.dateOfTheMatch.Year, 
                entity.homeTeam.getId().Value, entity.awayTeam.getId().Value, entity.participants.Select(p => p.getId().Value).ToList());
        }

        public Match ToEntity(MatchDto dto)
        {
            List<Player> participants = new();
            dto.participants.ForEach(id => playerRequester.Get(id));
            Team homeTeam = teamRequester.Get(dto.homeTeam);
            Team awayTeam = teamRequester.Get(dto.awayTeam);
            return new Match(dto.getId(), dto.homeTeamScore, dto.awayTeamScore, (AgeLimit)Enum.Parse(typeof(AgeLimit), dto.ageLimit), 
                new DateTime(dto.year, dto.month, dto.day), homeTeam, awayTeam, participants);
        }
    }
}

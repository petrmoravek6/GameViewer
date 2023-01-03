using clientUI.Model;
using clientUI.ServerApi;
using clientUI.ServerApi.Model;
using clientUI.Services.Exceptions;

namespace clientUI.Services
{
    public class MatchService : CrudService<long?, Match, MatchDto>
    {
        public MatchService(MatchRequester requester) : base(requester)
        {
        }

        // During creating new match, we have to check some requirements
        public override Match Create(Match match)
        {
            _checkRequirements(match);
            return base.Create(match);
        }

        // During updating a match, we have to check some requirements
        public override void Update(Match match)
        {
            _checkRequirements(match);
            base.Update(match);
        }

        // if any requirement is not met, throw exception
        private void _checkRequirements(Match match)
        {
            // same teams cannot play against each other
            if (match.homeTeam == match.awayTeam)
                throw new SameTeamsException();

            foreach (Player p in match.participants)
            {
                if (!p.team.Equals(match.homeTeam) && !p.team.Equals(match.awayTeam))
                {
                    throw new WrongParticipantsException("Some of the match participants are not part of home team nor away team.");
                }
                // player's date of birth is higher than date of the match
                if (p.dateOfBirth > match.dateOfTheMatch)
                {
                    throw new WrongParticipantsException("Some of the match participants are born later than the date of the match.");

                }
                // age of the player during the match is higher than the limit
                if ((match.dateOfTheMatch - p.dateOfBirth).TotalDays / 365.0 > AgeLimitYears.ToYears(match.ageLimit))
                {
                    throw new WrongParticipantsException("Some of the match participants are older than the age limit.");
                }

            }
        }
    }
}

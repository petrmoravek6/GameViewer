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
    public class MatchService : CrudService<long?, Match, MatchDto>
    {
        public MatchService(MatchRequester requester) : base(requester)
        {
        }

        // During creating new match, we have to check some requirements
        public override Match Create(Match match)
        {
            DateTime now = DateTime.Now;
            foreach (Player p in entity.participants)
            {
                if (p.team != match.homeTeam && p.team != match.awayTeam)
                {
                    throw new WrongParticipantsException("Some of the match participants are not part of home team nor away team.");
                }

            }
            return base.Create(entity);
        }

        public override void Update(Match match)
        {
            base.Update(entity);
        }
    }
}

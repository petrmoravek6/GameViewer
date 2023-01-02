using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.ServerApi.Model
{
    public class MatchDto : DomainEntity<long?> {
        private long? id;
        public int homeTeamScore;
        public int awayTeamScore;
        public string ageLimit;
        public int day;
        public int month;
        public int year;
        public long homeTeam;
        public long awayTeam;
        public List<long> participants;

        public MatchDto(long? id, int homeTeamScore, int awayTeamScore, string ageLimit, int day, int month, int year, long homeTeam, long awayTeam, List<long> participants)
        {
            this.id = id;
            this.homeTeamScore = homeTeamScore;
            this.awayTeamScore = awayTeamScore;
            this.ageLimit = ageLimit;
            this.day = day;
            this.month = month;
            this.year = year;
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.participants = participants;
        }

        public long? getId()
        {
            return id;
        }

        public void setId(long? id)
        {
            this.id = id;
        }
    }
}

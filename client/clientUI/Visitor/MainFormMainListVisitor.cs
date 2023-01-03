using clientUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Visitor
{
    public class MainFormMainListVisitor : Visitor<string>
    {
        public string VisitMatch(Match match)
        {
            return $"{match.dateOfTheMatch.ToShortDateString()}  {match.homeTeam.name} - {match.awayTeam.name}   {match.homeTeamScore} : {match.awayTeamScore}";
        }

        public string VisitPlayer(Player player)
        {
            return $"{player.name}  ({player.team.name})    {player.dateOfBirth.Day}/{player.dateOfBirth.Month}/{player.dateOfBirth.Year}";
        }

        public string VisitTeam(Team team)
        {
            return $"{team.name} ({team.shortname})";
        }
    }
}

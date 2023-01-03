using clientUI.Model;
using clientUI.Services;
using clientUI.Services.Exceptions;
using clientUI.Visitor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientUI.Forms
{
    public partial class ViewMatchForm : Form
    {
        private MatchService matchService;
        private readonly Match match;
        private List<Team> allTeams;
        private List<Player> allPlayers;

        public ViewMatchForm(MatchService matchService, PlayerService playerService, TeamService teamService, Match match)
        {
            this.matchService = matchService;
            this.match = match;
            InitializeComponent();

            allTeams = teamService.ReadAll();
            allPlayers = playerService.ReadAll();


            var textVisitor = new MainFormMainListVisitor();
            participants.DataSource = allPlayers.Select(t => t.apply(textVisitor)).ToList();
            homeTeam.DataSource = allTeams.Select(t => t.apply(textVisitor)).ToList();
            awayTeam.DataSource = allTeams.Select(t => t.apply(textVisitor)).ToList();

            save_button.Enabled = false;
            button1.Enabled = true;
            ageLevel.Enabled = false;
            day.Enabled = false;
            month.Enabled = false;
            year.Enabled = false;
            participants.Enabled = false;
            homeTeam.Enabled = false;
            awayTeam.Enabled = false;
            homeTeamScore.Enabled = false;
            awayTeamScore.Enabled = false;

            day.SelectedIndex = match.dateOfTheMatch.Day - 1;
            month.SelectedIndex = match.dateOfTheMatch.Month - 1;
            year.Text = match.dateOfTheMatch.Year.ToString();
            var x = match.ageLimit.ToString();
            ageLevel.SelectedItem = match.ageLimit.ToString();
            homeTeam.SelectedIndex = allTeams.IndexOf(match.homeTeam);
            awayTeam.SelectedIndex = allTeams.IndexOf(match.awayTeam);
            homeTeamScore.Text = match.homeTeamScore.ToString();
            awayTeamScore.Text = match.awayTeamScore.ToString();
            foreach(var participant in match.participants)
            {
                participants.SetItemChecked(allPlayers.IndexOf(participant), true);
            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (year.Text.Length < 1)
            {
                logger.Text = "Year cannot be empty";
                return;
            }
            if (homeTeam.Text.Length < 1 || awayTeam.Text.Length < 1)
            {
                logger.Text = "Fill in the score";
                return;
            }
            if (day.SelectedIndex == -1 || month.SelectedIndex == -1 || homeTeam.SelectedIndex == -1 || awayTeam.SelectedIndex == -1 || ageLevel.SelectedIndex == -1) 
            {
                logger.Text = "All properties needs to be selected";
                return;
            }
            var checkedPlayersIdxs = participants.CheckedIndices.Cast<int>().ToList();
            if (checkedPlayersIdxs.Count < 1)
            {
                logger.Text = "Please select some players the participate in the match";
                return;
            }
            ushort hScore;
            ushort aScore;
            if (!UInt16.TryParse(homeTeamScore.Text, out hScore) || !UInt16.TryParse(awayTeamScore.Text, out aScore))
            {
                logger.Text = "Please fill in the score correctly";
                return;
            }
            List<Player> players = new List<Player>();
            checkedPlayersIdxs.ForEach(idx => players.Add(allPlayers[idx]));
            try
            {
                var newMatch = new Match(match.getId(), hScore, aScore, (AgeLimit)Enum.Parse(typeof(AgeLimit), ageLevel.Text), new DateTime(Int32.Parse(year.Text), Int32.Parse(month.Text), Int32.Parse(day.Text)),
                   allTeams[homeTeam.SelectedIndex], allTeams[awayTeam.SelectedIndex], players);
                matchService.Update(newMatch);
                logger.Text = "Updated successfully";
                save_button.Enabled = false;
                button1.Enabled = true;
                ageLevel.Enabled = false;
                day.Enabled = false;
                month.Enabled = false;
                year.Enabled = false;
                participants.Enabled = false;
                homeTeam.Enabled = false;
                awayTeam.Enabled = false;
                homeTeamScore.Enabled = false;
                awayTeamScore.Enabled = false;

            }
            catch(Exception ex)
            {
                if (ex is ArgumentOutOfRangeException)
                {
                    logger.Text = "Incorrect data format";
                    return;
                }
                if (ex is WrongParticipantsException)
                {
                    logger.Text = ex.Message;
                    return;
                }
                if (ex is SameTeamsException)
                {
                    logger.Text = "One team cannot play against itself";
                    return;
                }
                logger.Text = ex.Message;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_button.Enabled = true;
            button1.Enabled = false;
            ageLevel.Enabled = true;
            day.Enabled = true;
            month.Enabled = true;
            year.Enabled = true;
            participants.Enabled = true;
            homeTeam.Enabled = true;
            awayTeam.Enabled = true;
            homeTeamScore.Enabled = true;
            awayTeamScore.Enabled = true;
        }
    }
}

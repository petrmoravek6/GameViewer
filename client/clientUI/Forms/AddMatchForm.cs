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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientUI.Forms
{
    public partial class AddMatchForm : Form
    {
        private MatchService matchService;
        private List<Team> allTeams;
        private List<Player> allPlayers;

        public AddMatchForm(MatchService matchService, PlayerService playerService, TeamService teamService)
        {
            this.matchService = matchService;
            InitializeComponent();

            allTeams = teamService.ReadAll();
            allPlayers = playerService.ReadAll();


            var textVisitor = new MainFormMainListVisitor();
            participants.DataSource = allPlayers.Select(t => t.apply(textVisitor)).ToList();
            homeTeam.DataSource = allTeams.Select(t => t.apply(textVisitor)).ToList();
            awayTeam.DataSource = allTeams.Select(t => t.apply(textVisitor)).ToList();
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
                var newMatch = new Match(null, hScore, aScore, (AgeLimit)Enum.Parse(typeof(AgeLimit), ageLevel.Text), new DateTime(Int32.Parse(year.Text), Int32.Parse(month.Text), Int32.Parse(day.Text)),
                   allTeams[homeTeam.SelectedIndex], allTeams[awayTeam.SelectedIndex], players);
                matchService.Create(newMatch);
                logger.Text = "New match added!";
                Close();
                logger.Text = "";
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

        private void AddMatchForm_Load(object sender, EventArgs e)
        {

        }
    }
}

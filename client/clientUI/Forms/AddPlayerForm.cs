using clientUI.Model;
using clientUI.Services;
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
    public partial class AddPlayerForm : Form
    {
        private PlayerService playerService;
        private List<Team> allTeams;

        public AddPlayerForm(PlayerService playerService, TeamService teamService)
        {
            this.playerService = playerService;
            InitializeComponent();

            allTeams = teamService.ReadAll();

            var textVisitor = new MainFormMainListVisitor();
            team.DataSource = allTeams.Select(t => t.apply(textVisitor)).ToList();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text.Length < 1) 
            {
                logger.Text = "Name cannot be empty";
                return;
            }
            if (year.Text.Length < 1)
            {
                logger.Text = "Year cannot be empty";
                return;
            }
            if (day.SelectedIndex == -1 || month.SelectedIndex == -1 || team.SelectedIndex == -1 || position.SelectedIndex == -1) 
            {
                logger.Text = "All properties needs to be selected";
                return;
            }
            try
            {
                var player = new Player(null, name_textBox.Text, new DateTime(Int32.Parse(year.Text), Int32.Parse(month.Text), Int32.Parse(day.Text)),
                    (PlayerPosition)Enum.Parse(typeof(PlayerPosition), position.Text), allTeams[team.SelectedIndex]);
                playerService.Create(player);
                logger.Text = "New player added!";
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
                logger.Text = ex.Message;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

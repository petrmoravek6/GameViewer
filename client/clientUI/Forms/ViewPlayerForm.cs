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
    public partial class ViewPlayerForm : Form
    {
        private PlayerService playerService;
        private readonly Player player;
        private List<Team> allTeams;

        public ViewPlayerForm(PlayerService playerService, Player player, TeamService teamService)
        {
            this.playerService = playerService;
            this.player = player;
            InitializeComponent();

            allTeams = teamService.ReadAll();

            var textVisitor = new MainFormMainListVisitor();
            team.DataSource = allTeams.Select(t => t.apply(textVisitor)).ToList();

            save_button.Enabled = false;
            button1.Enabled = true;
            name_textBox.Enabled = false;
            day.Enabled = false;
            month.Enabled = false;
            year.Enabled = false;
            position.Enabled = false;
            team.Enabled = false;

            name_textBox.Text = player.name;
            day.SelectedIndex = player.dateOfBirth.Day - 1;
            month.SelectedIndex = player.dateOfBirth.Month - 1;
            year.Text = player.dateOfBirth.Year.ToString();
            position.SelectedValue = player.position.ToString();
            team.SelectedIndex = allTeams.IndexOf(player.team);
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
                var newPlayer = new Player(player.getId(), name_textBox.Text, new DateTime(Int32.Parse(year.Text), Int32.Parse(month.Text), Int32.Parse(day.Text)),
                    (PlayerPosition)Enum.Parse(typeof(PlayerPosition), position.Text), allTeams[team.SelectedIndex]);
                playerService.Update(newPlayer);
                logger.Text = "New player added!";
                save_button.Enabled = false;
                button1.Enabled = true;
                name_textBox.Enabled = false;
                day.Enabled = false;
                month.Enabled = false;
                year.Enabled = false;
                position.Enabled = false;
                team.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            save_button.Enabled = true;
            button1.Enabled = false;
            name_textBox.Enabled = true;
            day.Enabled = true;
            month.Enabled = true;
            year.Enabled = true;
            position.Enabled = true;
            team.Enabled = true;
        }
    }
}

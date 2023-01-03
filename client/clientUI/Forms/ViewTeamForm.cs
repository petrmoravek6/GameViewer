using clientUI.Model;
using clientUI.Services;
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
    public partial class ViewTeamForm : Form
    {
        private TeamService teamService;
        private readonly Team team;

        public ViewTeamForm(TeamService teamService, Team team)
        {
            this.teamService = teamService;
            this.team = team;
            InitializeComponent();
            save_button.Enabled = false;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text.Length < 1) 
            {
                logger.Text = "Name cannot be empty";
                return;
            }
            if (name_textBox.Text.Length < 1)
            {
                logger.Text = "Shortname cannot be empty";
                return;
            }
            try
            {
                var team = new Team(team.getId(), name_textBox.Text, shortname_textBox.Text);
                teamService.Update(team);
                logger.Text = "Updated succesfully";
                save_button.Enabled = false;
                button1.Enabled = true;
            }
            catch(Exception ex)
            {
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
        }
    }
}

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
    public partial class AddTeamForm : Form
    {
        private TeamService teamService;

        public AddTeamForm(TeamService teamService)
        {
            this.teamService = teamService;
            InitializeComponent();
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
                var team = new Team(null, name_textBox.Text, shortname_textBox.Text);
                teamService.Create(team);
                logger.Text = "New team added!";
                Close();
                logger.Text = "";
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
    }
}

namespace clientUI;

using clientUI.ServerApi;
using clientUI.Services;
using clientUI.UIContext;
using clientUI.Visitor;
using System.Net.Sockets;

public partial class MainForm : Form
{
    private Context currentContext;
    private readonly MatchContext matchContext;
    private readonly PlayerContext playerContext;
    private readonly TeamContext teamContext;
    public MainForm(TeamContext teamContext, PlayerContext playerContext, MatchContext matchContext)
    {
        this.teamContext = teamContext;
        this.playerContext = playerContext;
        this.matchContext = matchContext;

        currentContext = teamContext;
        
        InitializeComponent();
        try
        {
            mainList.DataSource = currentContext.ReloadAndGetMainList();
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

    private void team_button_Click(object sender, EventArgs e)
    {
        try
        {
            currentContext = teamContext;
            mainList.DataSource = currentContext.ReloadAndGetMainList();
            logger.Text = "";
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private void player_button_Click(object sender, EventArgs e)
    {
        try
        {
            currentContext = playerContext;
            mainList.DataSource = currentContext.ReloadAndGetMainList();
            logger.Text = "";
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private void match_button_Click(object sender, EventArgs e)
    {
        try
        {
            currentContext = matchContext;
            mainList.DataSource = currentContext.ReloadAndGetMainList();
            logger.Text = "";
        }
        catch(Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private void display_button_Click(object sender, EventArgs e)
    {
        if (mainList.SelectedIndex == -1)
        {
            logger.Text = "No item selected";
            return;
        }
        
        try
        {
            currentContext.DisplayEntity(mainList.SelectedIndex);
            mainList.DataSource = currentContext.ReloadAndGetMainList();
            logger.Text = "";
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private void remove_button_Click(object sender, EventArgs e)
    {
        if (mainList.SelectedIndex == -1)
        {
            logger.Text = "No item selected";
            return;
        }
        try
        {
            currentContext.DeleteEntity(mainList.SelectedIndex);
            Thread.Sleep(500);
            mainList.DataSource = currentContext.ReloadAndGetMainList();
            logger.Text = "Item was deleted successfully";
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private void add_button_Click(object sender, EventArgs e)
    {
        try
        {
            currentContext.CreateEntity();
            mainList.DataSource = currentContext.ReloadAndGetMainList();
            logger.Text = "Item was created successfully";
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }
}
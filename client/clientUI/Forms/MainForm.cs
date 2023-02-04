namespace clientUI;

using clientUI.ServerApi;
using clientUI.Services;
using clientUI.UIContext;
using clientUI.Visitor;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

public class MainFormArgs : EventArgs
{
    public readonly uint TeamClickedCnt;

    public MainFormArgs(uint teamClickedCnt)
    {
        TeamClickedCnt = teamClickedCnt;
    }
}

public partial class MainForm : Form
{
    private Context currentContext;
    private readonly MatchContext matchContext;
    private readonly PlayerContext playerContext;
    private readonly TeamContext teamContext;
    private uint teamClickedCnt = 0;
    public event EventHandler<MainFormArgs> TeamClicked;
    public MainForm(TeamContext teamContext, PlayerContext playerContext, MatchContext matchContext)
    {
        this.teamContext = teamContext;
        this.playerContext = playerContext;
        this.matchContext = matchContext;

        currentContext = teamContext;
        
        InitializeComponent();
        try
        {
            Trace.WriteLine("Trying to reload context");
            mainList.DataSource = currentContext.ReloadAndGetMainList();
        }
        catch(Exception ex)
        {
            Trace.WriteLine($"Exception during reloading context. Ex.Msg: {ex.Message}");
            logger.Text = ex.Message;
        }
    }

    private void exit_button_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async Task setContext(Context newContext)
    {
        logger.Text = "Loading...";
        mainList.DataSource = await newContext.ReloadAndGetMainListAsync();
        currentContext = newContext;
        logger.Text = "";
    }

    private async void team_button_Click(object sender, EventArgs e)
    {
        try
        {
            await setContext(teamContext);
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
        if (++teamClickedCnt > 3)
        {
            TeamClicked(this, new MainFormArgs(teamClickedCnt));
        }
    }

    private async void player_button_ClickAsync(object sender, EventArgs e)
    {
        try
        {
            await setContext(playerContext);
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private async void match_button_Click(object sender, EventArgs e)
    {
        try
        {
            await setContext(matchContext);
        }
        catch(Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private async void display_button_Click(object sender, EventArgs e)
    {
        if (mainList.SelectedIndex == -1)
        {
            logger.Text = "No item selected";
            return;
        }
        
        try
        {
            currentContext.DisplayEntity(mainList.SelectedIndex);
            logger.Text = "";
            mainList.DataSource = await currentContext.ReloadAndGetMainListAsync();
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private async void remove_button_Click(object sender, EventArgs e)
    {
        if (mainList.SelectedIndex == -1)
        {
            logger.Text = "No item selected";
            return;
        }
        try
        {
            currentContext.DeleteEntity(mainList.SelectedIndex);
            logger.Text = "Item was deleted successfully";
            // asychronous delaying for waiting for server update after removing
            await Task.Delay(500);
            mainList.DataSource = await currentContext.ReloadAndGetMainListAsync();
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }

    private async void add_button_Click(object sender, EventArgs e)
    {
        try
        {
            currentContext.CreateEntity();
            logger.Text = "Item was created successfully";
            mainList.DataSource = await currentContext.ReloadAndGetMainListAsync();
        }
        catch (Exception ex)
        {
            logger.Text = ex.Message;
        }
    }
}
namespace clientUI;

using clientUI.ServerApi;
using clientUI.Services;
using clientUI.UIContext;
using clientUI.Visitor;

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
        ReloadMainList();
    }

    void ReloadMainList()
    {
    }

    private void exit_button_Click(object sender, EventArgs e)
    {
        Close();
    }
}
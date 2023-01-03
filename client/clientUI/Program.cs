using clientUI.Model;
using clientUI.ServerApi;
using clientUI.ServerApi.Model.Converter;
using clientUI.Services;
using clientUI.UIContext;

namespace clientUI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        string baseApiAddress = @"http://localhost:8080";

        TeamConverter teamConverter = new TeamConverter();

        TeamRequester teamRequester = new(baseApiAddress, teamConverter);
        PlayerRequester playerRequester = new(baseApiAddress, null, teamConverter);
        MatchRequester matchRequester = new(baseApiAddress, null);

        MatchConverter matchConverter = new MatchConverter(playerRequester, teamRequester);
        PlayerConverter playerConverter = new PlayerConverter(teamRequester);

        // setting cycle references
        playerRequester.converter = playerConverter;
        matchRequester.converter = matchConverter;

        TeamService teamService = new(teamRequester);
        PlayerService playerService = new(playerRequester);
        MatchService matchService = new(matchRequester);

        TeamContext teamContext = new(teamService);
        PlayerContext playerContext = new(playerService, teamService);
        MatchContext matchContext = new(matchService, playerService, teamService);

        Application.Run(new MainForm(teamContext, playerContext, matchContext));
    }
}
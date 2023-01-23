using clientUI.Model;
using clientUI.ServerApi;
using clientUI.ServerApi.Model.Converter;
using clientUI.Services;
using clientUI.UIContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;
using System.IO;

namespace clientUI;

static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }
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

       var host = Host.CreateDefaultBuilder()
           .ConfigureServices((provider, services) =>
           {
               services.AddSingleton<TeamConverter>();
               services.AddSingleton<TeamRequester>(provider => new TeamRequester(baseApiAddress, provider.GetService<TeamConverter>()!));
               services.AddSingleton<PlayerRequester>(provider => new PlayerRequester(baseApiAddress, provider.GetService<PlayerConverter>()!, provider.GetService<TeamConverter>()!));
               services.AddSingleton<MatchRequester>(provider => new MatchRequester(baseApiAddress, provider.GetService<MatchConverter>()!));
               services.AddSingleton<MatchConverter>();
               services.AddSingleton<PlayerConverter>();
       
               services.AddSingleton<TeamService>();
               services.AddSingleton<PlayerService>();
               services.AddSingleton<MatchService>();
       
               services.AddSingleton<TeamContext>();
               services.AddSingleton<PlayerContext>();
               services.AddSingleton<MatchContext>();
       
               services.AddSingleton<MainForm>();
           })
           .Build();

        ServiceProvider = host.Services;

        Application.Run(ServiceProvider.GetRequiredService<MainForm>());

       



        

       //TeamConverter teamConverter = new TeamConverter();
       //
       //TeamRequester teamRequester = new(baseApiAddress, teamConverter);
       //PlayerRequester playerRequester = new(baseApiAddress, null, teamConverter);
       //MatchRequester matchRequester = new(baseApiAddress, null);
       //
       //MatchConverter matchConverter = new MatchConverter(playerRequester, teamRequester);
       //PlayerConverter playerConverter = new PlayerConverter(teamRequester);
       //
       //// setting cycle references
       //playerRequester.converter = playerConverter;
       //matchRequester.converter = matchConverter;
       //
       //TeamService teamService = new(teamRequester);
       //PlayerService playerService = new(playerRequester);
       //MatchService matchService = new(matchRequester);
       //
       //TeamContext teamContext = new(teamService);
       //PlayerContext playerContext = new(playerService, teamService);
       //MatchContext matchContext = new(matchService, playerService, teamService);
       
       //Application.Run(new MainForm(teamContext, playerContext, matchContext));
    }
}
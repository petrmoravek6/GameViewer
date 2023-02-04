using clientUI.Model;
using clientUI.ServerApi;
using clientUI.ServerApi.Model.Converter;
using clientUI.Services;
using clientUI.UIContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;
using System.IO;
using System.Diagnostics;

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

        // trace configuration
        string fileLogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Coding", "tjv", "client", "logger.txt");
        try
        {
            TextWriterTraceListener logFile = new(File.CreateText(fileLogPath));
            Trace.Listeners.Add(logFile);
        }
        catch(Exception) { }
        Trace.AutoFlush = true;

        string baseApiAddress = @"http://localhost:8080";

        Trace.WriteLine("Configuring DI");
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

        Trace.WriteLine("DI was configured successfully");
        ServiceProvider = host.Services;

        ServiceProvider.GetService<MainForm>()!.TeamClicked += (_, args) => { Trace.WriteLine($"{args.TeamClickedCnt}x clicked on TEAM button"); };

        Trace.WriteLine("Starting application");

        Application.Run(ServiceProvider.GetRequiredService<MainForm>());
    }
}
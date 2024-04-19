// JK, PB, MB, JP start
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.InteropServices;
using Serilog;

namespace SyncView;

static class Program
{
    public static readonly LoginForm LoginForm = new();
    public static MainForm? MainForm;
    public static readonly SvClient SvClient = new();
    public static readonly MediaManager MediaManager = new();
    
    [STAThread]
    static void Main()
    {
        // AllocConsole();
        
        // Create logger
        Log.Logger = new LoggerConfiguration().WriteTo.Console(outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}").MinimumLevel.Debug().CreateLogger();
        
        ApplicationConfiguration.Initialize();
        
        // Start the login form
        Application.Run(LoginForm);
        //LoginForm will run first, then once a user enters their name and a connection is established MainForm will run
    }

    public static void StartFully()
    {
        // Create and start the main form
        MainForm = new MainForm();
        Application.Run(MainForm);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
}
// JK, PB, MB, JP end
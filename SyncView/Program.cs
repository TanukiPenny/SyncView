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
        
        Log.Logger = new LoggerConfiguration().WriteTo.Console(outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}").MinimumLevel.Debug().CreateLogger();
        
        ApplicationConfiguration.Initialize();
        
        Application.Run(LoginForm);
    }

    public static void StartFully()
    {
        MainForm = new MainForm();
        Application.Run(MainForm);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
}
using System.Runtime.InteropServices;
using Serilog;

namespace SyncView;

static class Program
{
    public static readonly MainForm MainForm = new();
    
    [STAThread]
    static void Main()
    {
        AllocConsole();
        
        Log.Logger = new LoggerConfiguration().WriteTo.Console(outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}").MinimumLevel.Debug().CreateLogger();
        
        ApplicationConfiguration.Initialize();
        
        LoginForm frmLogin = new LoginForm();
        if (frmLogin.ShowDialog() == DialogResult.OK )
        {
            Application.Run(MainForm);
        }
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
}
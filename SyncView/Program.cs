using System.Runtime.InteropServices;

namespace SyncView;

static class Program
{
    public static readonly MainForm MainForm = new();
    
    [STAThread]
    static void Main()
    {
        AllocConsole();
        
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
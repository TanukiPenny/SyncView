namespace SyncView;

static class Program
{
    public static MainForm MainForm = new();
    
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(MainForm);
    }
}
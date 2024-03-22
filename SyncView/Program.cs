namespace SyncView;

static class Program
{
    public static MainForm MainForm;
    
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        MainForm = new MainForm();
        Application.Run(MainForm);
    }
}
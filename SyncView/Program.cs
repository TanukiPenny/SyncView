namespace SyncView;

static class Program
{
    public static readonly MainForm MainForm = new();
    
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        LoginForm frmLogin = new LoginForm();
        if (frmLogin.ShowDialog() == DialogResult.OK )
        {
            Application.Run(MainForm);
        }
    }
}
namespace SyncView;

public static class Utils
{
    public static void WaitForMainForm()
    {
        while (Program.MainForm == null)
        {
            
        }
    }

    public static void WaitForMainFormHandle()
    {
        while (!Program.MainForm.IsHandleCreated)
        {
                
        }
    }
}
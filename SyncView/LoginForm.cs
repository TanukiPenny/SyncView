using System.Net.Mime;
using SVCommon.Packet;

namespace SyncView
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Program.SvClient.Connect();
            Program.SvClient.Login(nicknameBox.Text);
        }

        public void HandleLoginResult(LoginResponse loginResponse)
        {
            if (loginResponse.Success)
            {
                Program.LoginForm.Invoke((MethodInvoker)Hide);
                Program.StartFully();
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
            
        }
    }
}
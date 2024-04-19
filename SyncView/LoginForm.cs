// JK, PB start
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
        //MB
        private List<string> randomNicknames = new List<string> //list of random users

        {
           "shaquille.oatmeal","hanging_with_my_gnomies","fast_and_the_curious","google_was_my_idea","fedora_the_explorer","notch","oprahwindfury","chickenriceandbeans","buh-buh-bacon",
           "applebottomjeans","toastedbagelwithcreamcheese","baeconandeggz","bigfootisreal","PeterGriffin"
        };

        private void randomnameButton_Click(object sender, EventArgs e)
        {
            nicknameBox.Text = GetRandomNicknames();
        }
        private string GetRandomNicknames() //inputing the random user into the textbox
        {
            Random rand = new Random();
            int index = rand.Next(randomNicknames.Count);
            return randomNicknames[index];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
// JK, PB end
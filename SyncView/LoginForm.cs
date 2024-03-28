namespace SyncView
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public string UsernameText // Prompt for username
        {
            get
            {
                return UsernameField.Text;
            }
            set
            {
                UsernameField.Text = value;
            }
        }

        public string PasswordText // Prompt for password
        {
            get
            {
                return PasswordField.Text;
            }
            set
            {
                PasswordField.Text = value;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //TODO: Make it check to make sure it connects properly with nick before closing
            if (true)
            {
                DialogResult = DialogResult.OK; // Sends user to main program if ok
                Hide();
            }
        }
    }
}
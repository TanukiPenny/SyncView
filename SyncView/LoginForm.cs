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
            if (UsernameField.Text == PasswordField.Text)
            {
                this.DialogResult = DialogResult.OK; // Sends user to main program
                var frm = new MainForm();
                frm.Location = this.Location;
                frm.StartPosition = FormStartPosition.Manual;
                frm.FormClosing += delegate { this.Show(); };
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!"); // If username or password is incorrect
            }
        }
    }
}
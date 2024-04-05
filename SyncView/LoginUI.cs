using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncView
{
    public partial class LoginUI : UserControl
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Program.SyncViewForm.SvClient.Connect();
            Program.SyncViewForm.SvClient.Login(nickTextBox.Text);
        }
    }
}

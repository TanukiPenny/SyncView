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
    public partial class SyncViewForm : Form
    {
        public readonly SvClient SvClient = new();
        public readonly MediaManager MediaManager = new();
        public MainUI MainUi => mainui1;
        public LoginUI LoginUI => loginui1;
        
        public SyncViewForm()
        {
            InitializeComponent();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backgroundSync
{
    public partial class svBG : Form
    {
        private List<string> dataList = new List<string>();
        public svBG()
        {
            InitializeComponent();
            chatBox.KeyDown += chatBox_KeyDown;     //subscribe keydown
            enterButton.MouseDown += enterButton_MouseDown;
        }

        private void svBG_Load(object sender, EventArgs e)    //change background to art
        {
            PictureBox background = new PictureBox();           //pictureboxBACKGROUND
            background.SizeMode = PictureBoxSizeMode.StretchImage;
            background.Dock = DockStyle.Fill;
            background.BorderStyle = BorderStyle.None;

            background.Image = Image.FromFile(@"C:\Users\julpa\OneDrive\Desktop\syncviewlogos\SVBackground2.png");
            this.Controls.Add(background);
            MaximizeBox = false;

            string chatColorCode = "#AC85C4";                                       //hexadecimal string of desired color
            Color transparentColor = ColorTranslator.FromHtml(chatColorCode);       //create new color & translate from string
            chatDisplay.BackColor = transparentColor;                               //change chatDisplay back color to that Color
            chatDisplay.BorderStyle = BorderStyle.None;
            chatDisplay.ScrollAlwaysVisible = false;
            chatBox.BackColor = transparentColor;       //transparencyCHATBOX
            chatBox.BorderStyle = BorderStyle.None;
            exitButton.BackColor = transparentColor;
            exitButton.FlatStyle = FlatStyle.Popup;
            enterButton.BackColor = transparentColor;
            enterButton.BackColor = transparentColor;
            enterButton.FlatStyle = FlatStyle.Popup;

        }
        private void enterButton_MouseDown(object sender, MouseEventArgs e)     //enterButtonCLICK
        {
            if (MouseButtons == MouseButtons.Left)
            {
                string inputText = chatBox.Text.Trim();
                dataList.Add(inputText);
                chatDisplay.Items.Add(inputText);
                chatDisplay.Font = new Font("ND LOGOS Regular", 10, FontStyle.Bold);
                chatBox.Clear();
            }
        }
        private void chatBox_KeyDown(object sender, KeyEventArgs e)    //enterButtonKEY
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string inputText = chatBox.Text.Trim();
                dataList.Add(inputText);
                chatDisplay.Font = new Font("ND LOGOS Regular", 10, FontStyle.Bold);
                AddWrappedTextToDisplay(inputText);
                chatBox.Clear();
            }
        }
        private void UpdateChatDisplay()        //chatDisplayUPDATE
        {
            chatDisplay.Items.Clear();
            foreach (string data in dataList)
            {
                chatDisplay.Items.Add(data);
            }
        }


        private void AddWrappedTextToDisplay(string text)
        {
            int maxCharactersPerLine = 35; // Change this to your desired character limit per line
            List<string> wrappedLines = WrapText(text, maxCharactersPerLine);
            foreach (string line in wrappedLines)
            {
                dataList.Add(line);
                chatDisplay.Items.Add(line);
            }
        }

        private List<string> WrapText(string text, int maxCharactersPerLine)
        {
            List<string> lines = new List<string>();
            string[] words = text.Split(' ');

            string currentLine = "";
            foreach (string word in words)
            {
                if ((currentLine + word).Length > maxCharactersPerLine)
                {
                    lines.Add(currentLine.Trim());
                    currentLine = "";
                }
                currentLine += word + " ";
            }
            if (!string.IsNullOrWhiteSpace(currentLine))
            {
                lines.Add(currentLine.Trim());
            }
            chatDisplay.Items.Add(""); //linespace inbetween each input
            chatDisplay.TopIndex = chatDisplay.Items.Count - 1; //automated chat scroll
            return lines;
        }

        private void chatBox_TextChanged(object sender, EventArgs e)
        {
            chatBox.Font = new Font("LEMONMILK", 10, FontStyle.Bold);
        }
        private void chatDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void enterButton_Click(object sender, EventArgs e)
        {

        }
    }
}
namespace SyncView
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            SyncViewLogo = new PictureBox();
            nicknameBox = new TextBox();
            UsernameLabel = new Label();
            LoginButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SyncViewLogo
            // 
            SyncViewLogo.Image = (Image)resources.GetObject("SyncViewLogo.Image");
            SyncViewLogo.Location = new Point(223, 4);
            SyncViewLogo.Margin = new Padding(2);
            SyncViewLogo.Name = "SyncViewLogo";
            SyncViewLogo.Size = new Size(379, 79);
            SyncViewLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            SyncViewLogo.TabIndex = 0;
            SyncViewLogo.TabStop = false;
            // 
            // nicknameBox
            // 
            nicknameBox.BackColor = Color.GhostWhite;
            nicknameBox.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nicknameBox.ForeColor = Color.Black;
            nicknameBox.Location = new Point(199, 278);
            nicknameBox.Margin = new Padding(2);
            nicknameBox.Name = "nicknameBox";
            nicknameBox.Size = new Size(428, 21);
            nicknameBox.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.GhostWhite;
            UsernameLabel.Location = new Point(199, 255);
            UsernameLabel.Margin = new Padding(2, 0, 2, 0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(75, 15);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Nickname:";
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.SlateBlue;
            LoginButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(330, 350);
            LoginButton.Margin = new Padding(2);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(164, 33);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(297, 79);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(825, 410);
            Controls.Add(pictureBox1);
            Controls.Add(LoginButton);
            Controls.Add(UsernameLabel);
            Controls.Add(nicknameBox);
            Controls.Add(SyncViewLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox SyncViewLogo;
        private TextBox nicknameBox;
        private Label UsernameLabel;
        private Button LoginButton;
        private PictureBox pictureBox1;
    }
}
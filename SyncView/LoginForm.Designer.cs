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
            UsernameField = new TextBox();
            PasswordField = new TextBox();
            UsernameLabel = new Label();
            PasswordLabel = new Label();
            LoginButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // SyncViewLogo
            // 
            SyncViewLogo.Image = (Image)resources.GetObject("SyncViewLogo.Image");
            SyncViewLogo.Location = new Point(319, 7);
            SyncViewLogo.Name = "SyncViewLogo";
            SyncViewLogo.Size = new Size(541, 132);
            SyncViewLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            SyncViewLogo.TabIndex = 0;
            SyncViewLogo.TabStop = false;
            // 
            // UsernameField
            // 
            UsernameField.BackColor = Color.GhostWhite;
            UsernameField.Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameField.ForeColor = Color.Black;
            UsernameField.Location = new Point(284, 402);
            UsernameField.Name = "UsernameField";
            UsernameField.Size = new Size(610, 30);
            UsernameField.TabIndex = 1;
            // 
            // PasswordField
            // 
            PasswordField.BackColor = Color.GhostWhite;
            PasswordField.Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordField.ForeColor = Color.Black;
            PasswordField.Location = new Point(284, 509);
            PasswordField.Name = "PasswordField";
            PasswordField.Size = new Size(610, 30);
            PasswordField.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.GhostWhite;
            UsernameLabel.Location = new Point(284, 364);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(116, 22);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordLabel.ForeColor = Color.GhostWhite;
            PasswordLabel.Location = new Point(284, 470);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(115, 22);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password:";
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.SlateBlue;
            LoginButton.Font = new Font("Orbitron", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(472, 583);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(234, 55);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(424, 126);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 228);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1178, 684);
            Controls.Add(pictureBox1);
            Controls.Add(LoginButton);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordField);
            Controls.Add(UsernameField);
            Controls.Add(SyncViewLogo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox SyncViewLogo;
        private TextBox UsernameField;
        private TextBox PasswordField;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private Button LoginButton;
        private PictureBox pictureBox1;
    }
}
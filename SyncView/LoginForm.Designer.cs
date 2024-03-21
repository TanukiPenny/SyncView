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
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).BeginInit();
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
            UsernameField.BackColor = Color.DarkSlateBlue;
            UsernameField.ForeColor = Color.White;
            UsernameField.Location = new Point(284, 445);
            UsernameField.Name = "UsernameField";
            UsernameField.Size = new Size(610, 31);
            UsernameField.TabIndex = 1;
            // 
            // PasswordField
            // 
            PasswordField.BackColor = Color.DarkSlateBlue;
            PasswordField.ForeColor = Color.White;
            PasswordField.Location = new Point(284, 552);
            PasswordField.Name = "PasswordField";
            PasswordField.Size = new Size(610, 31);
            PasswordField.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(284, 407);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(116, 22);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Orbitron", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordLabel.ForeColor = Color.White;
            PasswordLabel.Location = new Point(284, 513);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(115, 22);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "Password:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1178, 684);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(PasswordField);
            Controls.Add(UsernameField);
            Controls.Add(SyncViewLogo);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox SyncViewLogo;
        private TextBox UsernameField;
        private TextBox PasswordField;
        private Label UsernameLabel;
        private Label PasswordLabel;
    }
}
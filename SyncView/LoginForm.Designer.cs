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
            nicknameBox = new TextBox();
            UsernameLabel = new Label();
            LoginButton = new Button();
            randomnameButton = new Button();
            SuspendLayout();
            // 
            // nicknameBox
            // 
            nicknameBox.BackColor = Color.FromArgb(57, 67, 64);
            nicknameBox.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nicknameBox.ForeColor = Color.White;
            nicknameBox.Location = new Point(199, 208);
            nicknameBox.Margin = new Padding(2);
            nicknameBox.Name = "nicknameBox";
            nicknameBox.Size = new Size(428, 21);
            nicknameBox.TabIndex = 1;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.BackColor = Color.FromArgb(57, 67, 64);
            UsernameLabel.Font = new Font("Microsoft Sans Serif", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.White;
            UsernameLabel.Location = new Point(199, 185);
            UsernameLabel.Margin = new Padding(2, 0, 2, 0);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(75, 15);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Nickname:";
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.FromArgb(57, 67, 64);
            LoginButton.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginButton.ForeColor = Color.White;
            LoginButton.Location = new Point(330, 317);
            LoginButton.Margin = new Padding(2);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(164, 33);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // randomnameButton
            // 
            randomnameButton.BackColor = Color.White;
            randomnameButton.Location = new Point(364, 242);
            randomnameButton.Name = "randomnameButton";
            randomnameButton.Size = new Size(102, 23);
            randomnameButton.TabIndex = 5;
            randomnameButton.Text = "Random";
            randomnameButton.UseVisualStyleBackColor = false;
            randomnameButton.Click += randomnameButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.SVLFINAL;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(825, 410);
            Controls.Add(randomnameButton);
            Controls.Add(LoginButton);
            Controls.Add(UsernameLabel);
            Controls.Add(nicknameBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox nicknameBox;
        private Label UsernameLabel;
        private Button LoginButton;
        private Button randomnameButton;
    }
}
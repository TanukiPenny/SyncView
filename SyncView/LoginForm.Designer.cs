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
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(1178, 684);
            Controls.Add(SyncViewLogo);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)SyncViewLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox SyncViewLogo;
    }
}
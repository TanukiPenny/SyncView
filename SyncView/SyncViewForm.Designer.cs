namespace SyncView
{
    partial class SyncViewForm
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
            loginui1 = new LoginUI();
            mainui1 = new MainUI();
            SuspendLayout();
            // 
            // loginui1
            // 
            loginui1.Location = new Point(0, 0);
            loginui1.Margin = new Padding(0);
            loginui1.Name = "loginui1";
            loginui1.Size = new Size(1584, 861);
            loginui1.TabIndex = 0;
            // 
            // mainui1
            // 
            mainui1.Location = new Point(0, 0);
            mainui1.Margin = new Padding(0);
            mainui1.Name = "mainui1";
            mainui1.Size = new Size(1584, 861);
            mainui1.TabIndex = 0;
            // 
            // SyncViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(loginui1);
            Controls.Add(mainui1);
            MaximizeBox = false;
            MaximumSize = new Size(1600, 900);
            MinimumSize = new Size(1600, 900);
            Name = "SyncViewForm";
            Text = "SyncViewForm";
            ResumeLayout(false);
        }

        #endregion

        private LoginUI loginui1;
        private MainUI mainui1;
    }
}
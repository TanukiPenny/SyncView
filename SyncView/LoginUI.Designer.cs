namespace SyncView
{
    partial class LoginUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nickTextBox = new TextBox();
            loginButton = new Button();
            SuspendLayout();
            // 
            // nickTextBox
            // 
            nickTextBox.Location = new Point(473, 266);
            nickTextBox.Name = "nickTextBox";
            nickTextBox.Size = new Size(170, 23);
            nickTextBox.TabIndex = 0;
            nickTextBox.Text = "Tester 1";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(515, 311);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 1;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(loginButton);
            Controls.Add(nickTextBox);
            Margin = new Padding(0);
            Name = "LoginUI";
            Size = new Size(1584, 861);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nickTextBox;
        private Button loginButton;
    }
}

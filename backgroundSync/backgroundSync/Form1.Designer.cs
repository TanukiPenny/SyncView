namespace backgroundSync
{
    partial class svBG
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chatBox = new TextBox();
            chatDisplay = new ListBox();
            exitButton = new Button();
            enterButton = new Button();
            SuspendLayout();
            // 
            // chatBox
            // 
            chatBox.Location = new Point(1433, 1011);
            chatBox.Margin = new Padding(3, 4, 3, 4);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(335, 27);
            chatBox.TabIndex = 0;
            chatBox.TextChanged += chatBox_TextChanged;
            // 
            // chatDisplay
            // 
            chatDisplay.FormattingEnabled = true;
            chatDisplay.Location = new Point(1241, 79);
            chatDisplay.Margin = new Padding(3, 4, 3, 4);
            chatDisplay.Name = "chatDisplay";
            chatDisplay.Size = new Size(302, 624);
            chatDisplay.TabIndex = 1;
            chatDisplay.SelectedIndexChanged += chatDisplay_SelectedIndexChanged;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Transparent;
            exitButton.Location = new Point(1747, 1101);
            exitButton.Margin = new Padding(3, 4, 3, 4);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(49, 31);
            exitButton.TabIndex = 2;
            exitButton.Text = "EXIT";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // enterButton
            // 
            enterButton.Location = new Point(1713, 1011);
            enterButton.Margin = new Padding(3, 4, 3, 4);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(56, 31);
            enterButton.TabIndex = 3;
            enterButton.Text = "ENTER";
            enterButton.UseVisualStyleBackColor = true;
            enterButton.Click += enterButton_Click;
            // 
            // svBG
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 853);
            Controls.Add(enterButton);
            Controls.Add(exitButton);
            Controls.Add(chatBox);
            Controls.Add(chatDisplay);
            Margin = new Padding(3, 4, 3, 4);
            Name = "svBG";
            Text = "SyncView";
            Load += svBG_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox chatBox;
        private ListBox chatDisplay;
        private Button exitButton;
        private Button enterButton;
    }
}

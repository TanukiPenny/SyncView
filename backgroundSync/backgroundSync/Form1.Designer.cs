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
            chatBox.Location = new Point(1254, 758);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(294, 23);
            chatBox.TabIndex = 0;
            chatBox.TextChanged += chatBox_TextChanged;
            // 
            // chatDisplay
            // 
            chatDisplay.FormattingEnabled = true;
            chatDisplay.ItemHeight = 15;
            chatDisplay.Location = new Point(1244, 62);
            chatDisplay.Name = "chatDisplay";
            chatDisplay.Size = new Size(304, 634);
            chatDisplay.TabIndex = 1;
            chatDisplay.SelectedIndexChanged += chatDisplay_SelectedIndexChanged;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Transparent;
            exitButton.Location = new Point(1529, 826);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(43, 23);
            exitButton.TabIndex = 2;
            exitButton.Text = "EXIT";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // enterButton
            // 
            enterButton.Location = new Point(1499, 758);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(49, 23);
            enterButton.TabIndex = 3;
            enterButton.Text = "ENTER";
            enterButton.UseVisualStyleBackColor = true;
            enterButton.Click += enterButton_Click;
            // dd
            // svBG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(enterButton);
            Controls.Add(exitButton);
            Controls.Add(chatDisplay);
            Controls.Add(chatBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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

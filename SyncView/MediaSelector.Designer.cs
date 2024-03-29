namespace SyncView
{
    partial class MediaSelector
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
            mediaList = new ListBox();
            label = new Label();
            SuspendLayout();
            // 
            // mediaList
            // 
            mediaList.FormattingEnabled = true;
            mediaList.ItemHeight = 25;
            mediaList.Location = new Point(12, 53);
            mediaList.Name = "mediaList";
            mediaList.Size = new Size(454, 379);
            mediaList.TabIndex = 0;
            mediaList.DoubleClick += mediaList_DoubleClick;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(60, 12);
            label.Name = "label";
            label.Size = new Size(357, 25);
            label.TabIndex = 1;
            label.Text = "Double click to select media, close to cancel";
            // 
            // MediaSelector
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(478, 444);
            Controls.Add(label);
            Controls.Add(mediaList);
            MaximumSize = new Size(500, 500);
            MinimumSize = new Size(500, 500);
            Name = "MediaSelector";
            Text = "MediaSelector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox mediaList;
        private Label label;
    }
}
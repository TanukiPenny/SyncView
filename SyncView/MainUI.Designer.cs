namespace SyncView
{
    partial class MainUI
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
            progressBar = new TrackBar();
            timePassed = new Label();
            timeLeft = new Label();
            mediaSelectorButton = new Button();
            playButton = new Button();
            pauseButton = new Button();
            skipBackButton = new Button();
            skipForward30Button = new Button();
            stopButton = new Button();
            // videoView = new LibVLCSharp.WinForms.VideoView();
            ((System.ComponentModel.ISupportInitialize)progressBar).BeginInit();
            // ((System.ComponentModel.ISupportInitialize)videoView).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.LargeChange = 10000;
            progressBar.Location = new Point(222, 682);
            progressBar.Margin = new Padding(0);
            progressBar.Maximum = 10000000;
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(763, 45);
            progressBar.TabIndex = 1;
            // 
            // timePassed
            // 
            timePassed.AutoSize = true;
            timePassed.Location = new Point(239, 718);
            timePassed.Name = "timePassed";
            timePassed.Size = new Size(49, 15);
            timePassed.TabIndex = 2;
            timePassed.Text = "00:00:00";
            // 
            // timeLeft
            // 
            timeLeft.AutoSize = true;
            timeLeft.Location = new Point(919, 718);
            timeLeft.Name = "timeLeft";
            timeLeft.Size = new Size(49, 15);
            timeLeft.TabIndex = 3;
            timeLeft.Text = "00:00:00";
            // 
            // mediaSelectorButton
            // 
            mediaSelectorButton.Location = new Point(1017, 689);
            mediaSelectorButton.Name = "mediaSelectorButton";
            mediaSelectorButton.Size = new Size(154, 38);
            mediaSelectorButton.TabIndex = 4;
            mediaSelectorButton.Text = "Select New Media";
            mediaSelectorButton.UseVisualStyleBackColor = true;
            mediaSelectorButton.Click += mediaSelectorButton_Click;
            // 
            // playButton
            // 
            playButton.Font = new Font("Segoe MDL2 Assets", 24F);
            playButton.Location = new Point(548, 727);
            playButton.Margin = new Padding(0);
            playButton.Name = "playButton";
            playButton.Size = new Size(50, 50);
            playButton.TabIndex = 5;
            playButton.Text = "";
            playButton.UseVisualStyleBackColor = true;
            playButton.Click += playButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Font = new Font("Segoe MDL2 Assets", 24F);
            pauseButton.Location = new Point(598, 727);
            pauseButton.Margin = new Padding(0);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(50, 50);
            pauseButton.TabIndex = 6;
            pauseButton.Text = "";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // skipBackButton
            // 
            skipBackButton.Font = new Font("Segoe MDL2 Assets", 24F);
            skipBackButton.Location = new Point(498, 727);
            skipBackButton.Margin = new Padding(0);
            skipBackButton.Name = "skipBackButton";
            skipBackButton.Size = new Size(50, 50);
            skipBackButton.TabIndex = 7;
            skipBackButton.Text = "";
            skipBackButton.UseVisualStyleBackColor = true;
            skipBackButton.Click += skipBackButton_Click;
            // 
            // skipForward30Button
            // 
            skipForward30Button.Font = new Font("Segoe MDL2 Assets", 24F);
            skipForward30Button.Location = new Point(648, 727);
            skipForward30Button.Margin = new Padding(0);
            skipForward30Button.Name = "skipForward30Button";
            skipForward30Button.Size = new Size(50, 50);
            skipForward30Button.TabIndex = 8;
            skipForward30Button.Text = "";
            skipForward30Button.UseVisualStyleBackColor = true;
            skipForward30Button.Click += skipForward30Button_Click;
            // 
            // stopButton
            // 
            stopButton.Font = new Font("Segoe MDL2 Assets", 24F);
            stopButton.Location = new Point(576, 777);
            stopButton.Margin = new Padding(0);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(50, 50);
            stopButton.TabIndex = 9;
            stopButton.Text = "";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            /*// 
            // videoView1
            // 
            videoView.BackColor = Color.Black;
            videoView.Location = new Point(2, 2);
            videoView.Margin = new Padding(0);
            videoView.MediaPlayer = null;
            videoView.Name = "videoView";
            videoView.Size = new Size(1200, 675);
            videoView.TabIndex = 10;
            videoView.Text = "videoView1";*/
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            // Controls.Add(videoView);
            Controls.Add(stopButton);
            Controls.Add(skipForward30Button);
            Controls.Add(skipBackButton);
            Controls.Add(pauseButton);
            Controls.Add(playButton);
            Controls.Add(mediaSelectorButton);
            Controls.Add(timeLeft);
            Controls.Add(timePassed);
            Controls.Add(progressBar);
            Margin = new Padding(0);
            Name = "MainUI";
            Size = new Size(1584, 861);
            ((System.ComponentModel.ISupportInitialize)progressBar).EndInit();
            // ((System.ComponentModel.ISupportInitialize)videoView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TrackBar progressBar;
        private Label timePassed;
        private Label timeLeft;
        private Button mediaSelectorButton;
        private Button playButton;
        private Button pauseButton;
        private Button skipBackButton;
        private Button skipForward30Button;
        private Button stopButton;
        // private LibVLCSharp.WinForms.VideoView videoView;
    }
}

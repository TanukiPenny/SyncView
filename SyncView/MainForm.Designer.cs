namespace SyncView;

partial class MainForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        videoView = new LibVLCSharp.WinForms.VideoView();
        stopButton = new Button();
        skipForward30Button = new Button();
        skipBack10Button = new Button();
        pauseButton = new Button();
        playButton = new Button();
        mediaSelectorButton = new Button();
        timeLeft = new Label();
        timePassed = new Label();
        progressBar = new TrackBar();
        volumeBar = new TrackBar();
        volMinLabel = new Label();
        volMaxLabel = new Label();
        currentMediaLabel = new Label();
        currentHostLabel = new Label();
        volumeLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)videoView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)progressBar).BeginInit();
        ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
        SuspendLayout();
        // 
        // videoView
        // 
        videoView.BackColor = Color.Black;
        videoView.Location = new Point(23, 20);
        videoView.Margin = new Padding(0);
        videoView.MediaPlayer = null;
        videoView.Name = "videoView";
        videoView.Size = new Size(1189, 669);
        videoView.TabIndex = 0;
        videoView.Text = "videoView";
        // 
        // stopButton
        // 
        stopButton.BackColor = Color.FromArgb(76, 88, 68);
        stopButton.FlatStyle = FlatStyle.Flat;
        stopButton.Font = new Font("Segoe MDL2 Assets", 24F);
        stopButton.ForeColor = Color.White;
        stopButton.Location = new Point(480, 802);
        stopButton.Margin = new Padding(0);
        stopButton.Name = "stopButton";
        stopButton.Size = new Size(50, 50);
        stopButton.TabIndex = 18;
        stopButton.Text = "";
        stopButton.UseVisualStyleBackColor = false;
        stopButton.Click += stopButton_Click;
        // 
        // skipForward30Button
        // 
        skipForward30Button.BackColor = Color.FromArgb(76, 88, 68);
        skipForward30Button.FlatStyle = FlatStyle.Flat;
        skipForward30Button.Font = new Font("Segoe MDL2 Assets", 24F);
        skipForward30Button.ForeColor = Color.White;
        skipForward30Button.Location = new Point(552, 751);
        skipForward30Button.Margin = new Padding(0);
        skipForward30Button.Name = "skipForward30Button";
        skipForward30Button.Size = new Size(50, 50);
        skipForward30Button.TabIndex = 17;
        skipForward30Button.Text = "";
        skipForward30Button.UseVisualStyleBackColor = false;
        skipForward30Button.Click += skipForward30Button_Click;
        // 
        // skipBack10Button
        // 
        skipBack10Button.BackColor = Color.FromArgb(76, 88, 68);
        skipBack10Button.FlatStyle = FlatStyle.Flat;
        skipBack10Button.Font = new Font("Segoe MDL2 Assets", 24F);
        skipBack10Button.ForeColor = Color.White;
        skipBack10Button.Location = new Point(402, 751);
        skipBack10Button.Margin = new Padding(0);
        skipBack10Button.Name = "skipBack10Button";
        skipBack10Button.Size = new Size(50, 50);
        skipBack10Button.TabIndex = 16;
        skipBack10Button.Text = "";
        skipBack10Button.UseVisualStyleBackColor = false;
        skipBack10Button.Click += SkipBack10ButtonClick;
        // 
        // pauseButton
        // 
        pauseButton.BackColor = Color.FromArgb(76, 88, 68);
        pauseButton.FlatStyle = FlatStyle.Flat;
        pauseButton.Font = new Font("Segoe MDL2 Assets", 24F);
        pauseButton.ForeColor = Color.White;
        pauseButton.Location = new Point(502, 751);
        pauseButton.Margin = new Padding(0);
        pauseButton.Name = "pauseButton";
        pauseButton.Size = new Size(50, 50);
        pauseButton.TabIndex = 15;
        pauseButton.Text = "";
        pauseButton.UseVisualStyleBackColor = false;
        pauseButton.Click += pauseButton_Click;
        // 
        // playButton
        // 
        playButton.BackColor = Color.FromArgb(76, 88, 68);
        playButton.FlatStyle = FlatStyle.Flat;
        playButton.Font = new Font("Segoe MDL2 Assets", 24F);
        playButton.ForeColor = Color.White;
        playButton.Location = new Point(452, 751);
        playButton.Margin = new Padding(0);
        playButton.Name = "playButton";
        playButton.Size = new Size(50, 50);
        playButton.TabIndex = 14;
        playButton.Text = "";
        playButton.UseVisualStyleBackColor = false;
        playButton.Click += playButton_Click;
        // 
        // mediaSelectorButton
        // 
        mediaSelectorButton.BackColor = Color.FromArgb(76, 88, 68);
        mediaSelectorButton.FlatStyle = FlatStyle.Flat;
        mediaSelectorButton.Location = new Point(915, 741);
        mediaSelectorButton.Name = "mediaSelectorButton";
        mediaSelectorButton.Size = new Size(264, 38);
        mediaSelectorButton.TabIndex = 13;
        mediaSelectorButton.Text = "Select New Media";
        mediaSelectorButton.UseVisualStyleBackColor = false;
        mediaSelectorButton.Click += mediaSelectorButton_Click;
        // 
        // timeLeft
        // 
        timeLeft.AutoSize = true;
        timeLeft.BackColor = Color.FromArgb(76, 88, 68);
        timeLeft.ForeColor = Color.White;
        timeLeft.Location = new Point(823, 742);
        timeLeft.Name = "timeLeft";
        timeLeft.Size = new Size(49, 15);
        timeLeft.TabIndex = 12;
        timeLeft.Text = "00:00:00";
        // 
        // timePassed
        // 
        timePassed.AutoSize = true;
        timePassed.BackColor = Color.FromArgb(65, 44, 30);
        timePassed.ForeColor = Color.White;
        timePassed.Location = new Point(143, 742);
        timePassed.Name = "timePassed";
        timePassed.Size = new Size(49, 15);
        timePassed.TabIndex = 11;
        timePassed.Text = "00:00:00";
        // 
        // progressBar
        // 
        progressBar.BackColor = Color.FromArgb(76, 88, 68);
        progressBar.LargeChange = 10000;
        progressBar.Location = new Point(126, 715);
        progressBar.Margin = new Padding(0);
        progressBar.Maximum = 10000000;
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(763, 45);
        progressBar.TabIndex = 10;
        progressBar.ValueChanged += progressBar_ValueChanged;
        progressBar.MouseCaptureChanged += progressBar_MouseCaptureChanged;
        progressBar.MouseDown += progressBar_MouseDown;
        progressBar.MouseUp += progressBar_MouseUp;
        // 
        // volumeBar
        // 
        volumeBar.BackColor = Color.FromArgb(76, 88, 68);
        volumeBar.Location = new Point(189, 790);
        volumeBar.Maximum = 100;
        volumeBar.Name = "volumeBar";
        volumeBar.RightToLeft = RightToLeft.No;
        volumeBar.Size = new Size(145, 45);
        volumeBar.TabIndex = 19;
        volumeBar.Value = 100;
        volumeBar.ValueChanged += volumeBar_ValueChanged;
        // 
        // volMinLabel
        // 
        volMinLabel.AutoSize = true;
        volMinLabel.BackColor = Color.FromArgb(76, 88, 68);
        volMinLabel.ForeColor = Color.White;
        volMinLabel.Location = new Point(189, 832);
        volMinLabel.Name = "volMinLabel";
        volMinLabel.Size = new Size(23, 15);
        volMinLabel.TabIndex = 20;
        volMinLabel.Text = "0%";
        // 
        // volMaxLabel
        // 
        volMaxLabel.AutoSize = true;
        volMaxLabel.BackColor = Color.FromArgb(76, 88, 68);
        volMaxLabel.ForeColor = Color.White;
        volMaxLabel.Location = new Point(299, 832);
        volMaxLabel.Name = "volMaxLabel";
        volMaxLabel.Size = new Size(35, 15);
        volMaxLabel.TabIndex = 21;
        volMaxLabel.Text = "100%";
        // 
        // currentMediaLabel
        // 
        currentMediaLabel.AutoSize = true;
        currentMediaLabel.BackColor = Color.FromArgb(76, 88, 68);
        currentMediaLabel.Location = new Point(139, 695);
        currentMediaLabel.Name = "currentMediaLabel";
        currentMediaLabel.Size = new Size(118, 15);
        currentMediaLabel.TabIndex = 24;
        currentMediaLabel.Text = "Current Media: None";
        currentMediaLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // currentHostLabel
        // 
        currentHostLabel.AutoSize = true;
        currentHostLabel.BackColor = Color.FromArgb(76, 88, 68);
        currentHostLabel.Location = new Point(915, 713);
        currentHostLabel.Name = "currentHostLabel";
        currentHostLabel.Size = new Size(98, 15);
        currentHostLabel.TabIndex = 25;
        currentHostLabel.Text = "currentHostLabel";
        // 
        // volumeLabel
        // 
        volumeLabel.AutoSize = true;
        volumeLabel.BackColor = Color.FromArgb(76, 88, 68);
        volumeLabel.Location = new Point(237, 772);
        volumeLabel.Name = "volumeLabel";
        volumeLabel.Size = new Size(47, 15);
        volumeLabel.TabIndex = 26;
        volumeLabel.Text = "Volume";
        // 
        // MainForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackgroundImage = Properties.Resources.FINALBACKGROUND;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(1584, 861);
        Controls.Add(volumeLabel);
        Controls.Add(currentHostLabel);
        Controls.Add(currentMediaLabel);
        Controls.Add(volMaxLabel);
        Controls.Add(volMinLabel);
        Controls.Add(volumeBar);
        Controls.Add(stopButton);
        Controls.Add(skipForward30Button);
        Controls.Add(skipBack10Button);
        Controls.Add(pauseButton);
        Controls.Add(playButton);
        Controls.Add(mediaSelectorButton);
        Controls.Add(timeLeft);
        Controls.Add(timePassed);
        Controls.Add(progressBar);
        Controls.Add(videoView);
        DoubleBuffered = true;
        ForeColor = Color.White;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(2);
        MaximumSize = new Size(1600, 900);
        MinimumSize = new Size(1600, 900);
        Name = "MainForm";
        Text = "SyncView";
        ((System.ComponentModel.ISupportInitialize)videoView).EndInit();
        ((System.ComponentModel.ISupportInitialize)progressBar).EndInit();
        ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private LibVLCSharp.WinForms.VideoView videoView;
    private Button stopButton;
    private Button skipForward30Button;
    private Button skipBack10Button;
    private Button pauseButton;
    private Button playButton;
    private Button mediaSelectorButton;
    private Label timeLeft;
    private Label timePassed;
    private TrackBar progressBar;
    private TrackBar volumeBar;
    private Label volMinLabel;
    private Label volMaxLabel;
    private Label currentMediaLabel;
    private Label currentHostLabel;
    private Label volumeLabel;
}
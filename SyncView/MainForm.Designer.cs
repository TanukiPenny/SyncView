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
        testPlay = new Button();
        testNickBox = new TextBox();
        testLogin = new Button();
        testOpenMediaSelector = new Button();
        ((System.ComponentModel.ISupportInitialize)videoView).BeginInit();
        SuspendLayout();
        // 
        // videoView
        // 
        videoView.BackColor = Color.Black;
        videoView.Location = new Point(8, 7);
        videoView.Margin = new Padding(2);
        videoView.MediaPlayer = null;
        videoView.Name = "videoView";
        videoView.Size = new Size(1200, 675);
        videoView.TabIndex = 0;
        videoView.Text = "videoView1";
        // 
        // testPlay
        // 
        testPlay.Location = new Point(33, 687);
        testPlay.Name = "testPlay";
        testPlay.Size = new Size(192, 43);
        testPlay.TabIndex = 1;
        testPlay.Text = "Test Play";
        testPlay.UseVisualStyleBackColor = true;
        testPlay.Click += testPlay_Click;
        // 
        // testNickBox
        // 
        testNickBox.Location = new Point(873, 693);
        testNickBox.Name = "testNickBox";
        testNickBox.Size = new Size(394, 31);
        testNickBox.TabIndex = 2;
        testNickBox.Text = "Tester 1";
        // 
        // testLogin
        // 
        testLogin.Location = new Point(971, 754);
        testLogin.Name = "testLogin";
        testLogin.Size = new Size(187, 40);
        testLogin.TabIndex = 3;
        testLogin.Text = "Test Login";
        testLogin.UseVisualStyleBackColor = true;
        testLogin.Click += testLogin_Click;
        // 
        // testOpenMediaSelector
        // 
        testOpenMediaSelector.Location = new Point(363, 757);
        testOpenMediaSelector.Name = "testOpenMediaSelector";
        testOpenMediaSelector.Size = new Size(205, 43);
        testOpenMediaSelector.TabIndex = 4;
        testOpenMediaSelector.Text = "Test Media Selector";
        testOpenMediaSelector.UseVisualStyleBackColor = true;
        testOpenMediaSelector.Click += testOpenMediaSelector_Click;
        // 
        // MainForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1578, 844);
        Controls.Add(testOpenMediaSelector);
        Controls.Add(testLogin);
        Controls.Add(testNickBox);
        Controls.Add(testPlay);
        Controls.Add(videoView);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(2);
        MaximumSize = new Size(1600, 900);
        MinimumSize = new Size(1600, 900);
        Name = "MainForm";
        Text = "SyncView";
        ((System.ComponentModel.ISupportInitialize)videoView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private LibVLCSharp.WinForms.VideoView videoView;
    private Button testPlay;
    private TextBox testNickBox;
    private Button testLogin;
    private Button testOpenMediaSelector;
}
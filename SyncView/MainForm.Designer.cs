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
        videoView = new LibVLCSharp.WinForms.VideoView();
        ((System.ComponentModel.ISupportInitialize)videoView).BeginInit();
        SuspendLayout();
        // 
        // videoView
        // 
        videoView.BackColor = Color.Black;
        videoView.Location = new Point(12, 12);
        videoView.MediaPlayer = null;
        videoView.Name = "videoView";
        videoView.Size = new Size(776, 426);
        videoView.TabIndex = 0;
        videoView.Text = "videoView1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(videoView);
        Name = "MainForm";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)videoView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private LibVLCSharp.WinForms.VideoView videoView;
}
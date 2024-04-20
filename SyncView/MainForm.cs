// PB, JP start
using System.ComponentModel;
using LibVLCSharp.Shared;
using Serilog;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public partial class MainForm : Form
{
    public Label CurrentHostLabel => currentHostLabel;
    public Label CurrentMediaLabel => currentMediaLabel;

    public MainForm()
    {
        InitializeComponent();
        
        AddChatMessage("System", $"{Program.SvClient.Nick} has joined!"); //Announce to the chat when a user joins using their Nickname

        VideoView_Loaded();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);

        // Gotta really make sure its dead
        Application.Exit();
    }


    private void VideoView_Loaded()
    {
        // Prepare the player and video view
        Core.Initialize();
        videoView.MediaPlayer = Program.MediaManager.Player;
    }

    private int _tempTime;

    public void VideoDataUpdate(long time, long length) //updates the video timing 
    {
        progressBar.Maximum = (int)length;

        TimeSpan timeLeftSpan = TimeSpan.FromMilliseconds(length - time);
        string timeLeftText = timeLeftSpan.ToString(@"hh\:mm\:ss");
        timeLeft.Text = timeLeftText;

        if (_mouseDown) return;

        TimeSpan timePassedSpan = TimeSpan.FromMilliseconds(time);
        string timePassedText = timePassedSpan.ToString(@"hh\:mm\:ss");
        timePassed.Text = timePassedText;

        progressBar.Value = (int)time;
    }

    private void progressBar_ValueChanged(object sender, EventArgs e)
    {
        _tempTime = progressBar.Value;
        if (!_mouseDown) return;
        TimeSpan timePassedSpan = TimeSpan.FromMilliseconds(progressBar.Value);
        string timePassedText = timePassedSpan.ToString(@"hh\:mm\:ss");
        timePassed.Text = timePassedText;
    }

    private void progressBar_MouseCaptureChanged(object sender, EventArgs e)
    {
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.SeekTo(_tempTime);
    }

    // Store mouse state
    private bool _mouseDown;

    // handles mouse state changes
    private void progressBar_MouseDown(object sender, EventArgs e)
    {
        _mouseDown = true;
    }

    // handles mouse state changes
    private void progressBar_MouseUp(object sender, EventArgs e)
    {
        _mouseDown = false;
    }
    
    private void playButton_Click(object sender, EventArgs e)
    {
        // Only continue if we are host and are not playing`
        if (!Program.SvClient.IsHost) return;
        if (Program.MediaManager.Player.IsPlaying) return;
        
        if (Program.MediaManager.Player.Time > 0)
        {
            Program.MediaManager.Pause();
            return;
        }
        Program.MediaManager.Play();
    }

    private void pauseButton_Click(object sender, EventArgs e) //allows users to pause with a button
    {
        // Only respect pause click if we are playing and are host
        if (!Program.MediaManager.Player.IsPlaying) return;
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.Pause();
    }

    private void skipForward30Button_Click(object sender, EventArgs e) //30 second fast foward
    {
        // Only respect click if we are host
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.SeekTo(Program.MediaManager.Player.Time + 30000);
    }
    private void SkipBack10ButtonClick(object sender, EventArgs e) //10 second rewind
    {
        // Only respect click if we are host
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.SeekTo(Program.MediaManager.Player.Time - 10000);
    }

    private void stopButton_Click(object sender, EventArgs e) //allows users to stop the video entierly
    {
        // Only respect click if we are host
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.Stop();
        Program.SvClient.Send(new Stop(), MessageType.Stop);
    }

    private void mediaSelectorButton_Click(object sender, EventArgs e) //allows users to select different files to play
    {
        // Create media selector and show it
        MediaSelector mediaSelector = new MediaSelector();
        mediaSelector.ShowDialog();
    }

    private void volumeBar_ValueChanged(object sender, EventArgs e) //allows users to adjust the volume
    {
        Program.MediaManager.SetVolume(volumeBar.Value);
        volMaxLabel.Text = $"{volumeBar.Value}%";
    }

    private void chatEntryBox_KeyDown(object sender, KeyEventArgs e) //Allow messages to be sent with the enter key
    {
        // if we hit enter and chat is not empty send the message and reset text box
        if (e.KeyCode != Keys.Enter || chatEntryBox.Text == "") return;
        e.Handled = true;
        e.SuppressKeyPress = true;
        var chatMessage = new ChatMessage
        {
            Nick = Program.SvClient.Nick,
            Message = chatEntryBox.Text,
            
        };
        Program.SvClient.Send(chatMessage, MessageType.ChatMessage);
        chatEntryBox.Text = "";
    }

    public void AddChatMessage(string nick, string msg) //Adding the chat message including the users Nickname and the Date and Time
    {
        // Format and add line to text box
        string msgStr = $"\n{DateTime.Now.ToShortTimeString()} | {nick} | {msg}";
        chatBox.AppendText(msgStr + Environment.NewLine);
    }
}
// PB, JP end
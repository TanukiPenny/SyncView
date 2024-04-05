using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = System.Windows.Forms.HtmlDocument;

namespace SyncView;

public partial class MediaSelector : Form
{
    private readonly BindingList<Uri> _availableMedia = new();
    
    public MediaSelector()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedDialog;
        mediaList.DataSource = _availableMedia;
        RequestAvailableMedia();
    }

    private void RequestAvailableMedia()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument htmlDoc = web.Load("http://15.204.205.117/");
        HtmlNodeCollection? nodes = htmlDoc.DocumentNode.SelectNodes("//a");
        nodes.RemoveAt(0);

        foreach (HtmlNode htmlNode in nodes)
        {
            _availableMedia.Add(new Uri($"http://15.204.205.117/{htmlNode.Attributes.First().Value}"));
        }
    }

    private void mediaList_DoubleClick(object sender, EventArgs e)
    {
        if (mediaList.SelectedItem != null)
        {
            Program.SyncViewForm.MediaManager.CurrentMedia = (Uri?)mediaList.SelectedItem;
        }
        Close();
    }
}
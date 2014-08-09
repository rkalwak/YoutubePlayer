using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.YouTube;
using Google.GData.YouTube;
using Google.GData.Client;
namespace YTPlayer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            axShockwaveFlash1.Movie = "http://www.youtube.com/v/yXLL46xkdlY";
            login = "";
            password = "";
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        //53253
        YouTubeRequestSettings yousettings;
        YouTubeRequest yourequest;
        Feed<Video> videofeed, relatedvideofeed;
        Feed<Playlist> fp;
        List<string> videoIDs = new List<string>();
        int videofeedcount = 0, totalpages = 0;

        private bool logged = false;
        private void button1_Click(object sender, EventArgs e)
        {
            login = "rafal.kalwak@gmail.com";
            password = "bochora36";
            if (!logged)
            {
                YouTubeService service = new YouTubeService("Manager");
                service.setUserCredentials(login, password);

                try
                {
                    service.QueryClientLoginToken();
                }
                catch (System.Net.WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                yousettings = new YouTubeRequestSettings("YTPlayer","AI39si40b25zgBg_U7eheiSnNeb2UMF-3x35HLBYxQDXJEzYOrA8GSQ1vKikFIRSMGOTjBdFvUx4QPz3q72gUkUqOmg9JBx3bQ", login, password);
                yourequest = new YouTubeRequest(yousettings);
                
                logged = true;
            }
            YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);
            query.OrderBy = "viewCount";
            query.Query = textBox1.Text;
            videofeed = yourequest.Get<Video>(query);
            videofeedcount = videofeed.TotalResults;
            totalpages = videofeedcount / 25;
            if (videofeedcount % 25 != 0)
                totalpages = totalpages + 1;
            listView1.Items.Clear();
            videoIDs.Clear();
            foreach (Video entry in videofeed.Entries)
            {
                listView1.Items.Add(entry.Title);
                videoIDs.Add(entry.VideoId);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int itemIndex = listView1.SelectedIndices[0];
            axShockwaveFlash1.Movie = "http://www.youtube.com/v/" + videoIDs[itemIndex];
            MessageBox.Show(videoIDs[itemIndex]);
        }

        
    }
}

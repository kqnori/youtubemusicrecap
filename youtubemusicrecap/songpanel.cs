using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtubemusicrecap
{
    public partial class songpanel : UserControl
    {
        public string url;
        public songpanel()
        {
            InitializeComponent();
        }

        private void songpanel_Load(object sender, EventArgs e)
        {
            // Source - https://stackoverflow.com/a
            // Posted by BrunoLM
            // Retrieved 2025-11-16, License - CC BY-SA 3.0

            if (!Directory.Exists("images"))
                Directory.CreateDirectory("images");
            if (!File.Exists($"images\\{url}.jpg"))
            {

                WebClient cli = new WebClient();

                var imgBytes = cli.DownloadData($"http://img.youtube.com/vi/{url}/mqdefault.jpg");

                File.WriteAllBytes($"images\\{url}.jpg", imgBytes);
            }
            pictureBox1.Image = Image.FromFile($"images\\{url}.jpg");

        }
    }
}

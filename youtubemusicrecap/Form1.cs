using System.Runtime.InteropServices;

namespace youtubemusicrecap
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        public Form1()
        {
            AllocConsole();


            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var _ = await code.GetJson();

            for (int i = 0; i < 20; i++)
            {
                songpanel sp = new songpanel();
                sp.Location = new Point(0, 100*i+(30/4*i));
                sp.name_song.Text = _.musicVids[i].title;
                sp.url = _.musicVids[i].vid_id;
                sp.view_count.Text = $"Watched {_.musicVids[i].views} times!";
                this.top_songs.Controls.Add(sp);

            }

            for (int i = 0; i < 20; i++)
            {
                AuthorsPanel sp = new AuthorsPanel();
                sp.Location = new Point(0, 100 * i + (30 / 4 * i));
                sp.label1.Text = $"{_.authorStats[i].name}";
                sp.Duration.Text = $"Watched for {TimeSpan.FromSeconds(_.authorStats[i].sec_watched).TotalHours:N1} hours!";

                this.top_authors.Controls.Add(sp);

            }

        }

    }
}

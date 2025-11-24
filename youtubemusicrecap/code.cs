
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace youtubemusicrecap
{
    internal class code
    {

        public static async Task<ReturnObj> GetJson()
        {
            Console.WriteLine("start getting.");

            string jsonstring = File.ReadAllText("sample.json");
            Json[] jsonlist = System.Text.Json.JsonSerializer.Deserialize<Json[]>(jsonstring);

            if(!File.Exists("cache"))
                File.Create("cache").Close();
            jsonlist = jsonlist.Where(item => item.header == "YouTube Music").ToArray();

            List<MusicVid> musicVids = new List<MusicVid>();

            foreach (var item in jsonlist)
            {
                if (musicVids.Find(b => b.title == item.title.Substring(7)) == null)
                {
                    MusicVid mv = new MusicVid();
                    mv.title = item.title.Substring(7);
                    mv.vid_id = item.titleUrl.Split("v=")[1];
                    mv.author = item.subtitles[0].name;
                    musicVids.Add(mv);
                }
                else
                {
                    MusicVid mv = musicVids.Find(b => b.title == item.title.Substring(7));
                    mv.views += 1;
                }

            }
            string[] cache = File.ReadAllLines("cache");
            musicVids.Sort((x, y) => y.views.CompareTo(x.views));

            var tasks = musicVids
                                .DistinctBy(x => x.vid_id)
                                .Select(async item =>
            {
                string[] hello = cache.Where(b => b.Split(' ').First() == item.vid_id).ToArray();
                TimeSpan duration;
                if (hello.Length == 0)
                {

                    TimeSpan ts = await GetDuration(item.vid_id);
                    duration = ts;
                    item.duration = duration;
                    return (item.vid_id, duration, isNew: true);
                }
                else
                {
                    duration = TimeSpan.FromSeconds(double.Parse( hello[0].Split(' ').Last()));
                    item.duration = duration;
                    return (item.vid_id, duration, isNew: false);
                }
            });
            var results_of_parr = await Task.WhenAll(tasks);

            string[] meow = results_of_parr.Where(b => b.isNew).Select(x => $"{x.vid_id} {x.duration.TotalSeconds}").ToArray();


            File.AppendAllLines("cache", meow );
            Console.WriteLine("Finished fetching durations.");


            #region stara wersja
            //foreach (var item in musicVids)
            //{
            //    string[] hello = cache.Where(b => b.Split(' ').First() == item.vid_id).ToArray();
            //    TimeSpan duration;
            //    if(hello.Length ==0)
            //    {

            //        TimeSpan ts = await GetDuration(item.vid_id);
            //        File.AppendAllLines("cache",new string[] {$"{item.vid_id} {ts.TotalSeconds}"});
            //        duration = ts;
            //    }
            //    else
            //    {
            //        duration = TimeSpan.Parse(hello[0].Split(' ').Last());
            //    }
            //}
            #endregion



            List<AuthorStat> authorStats = new List<AuthorStat>();

            foreach (var item in musicVids)
            {
                if(authorStats.Find(x => x.name == item.author) == null)
                {
                    AuthorStat au = new AuthorStat();
                    au.name = item.author;
                    au.sec_watched = (int)item.duration.TotalSeconds * item.views;
                    authorStats.Add(au);
                }
                else
                {
                    AuthorStat au = authorStats.Find(x => x.name == item.author);

                    au.sec_watched += (int)item.duration.TotalSeconds * item.views;
                }

            }
            authorStats.Sort((x, y) => y.sec_watched.CompareTo(x.sec_watched));

            return new ReturnObj(musicVids.ToArray(),authorStats.ToArray());

        }
        public class ReturnObj
        {
            public MusicVid[] musicVids { get; set; }
            public AuthorStat[] authorStats { get; set; }
            public ReturnObj(MusicVid[] musicVidss, AuthorStat[] authorStatss)
            {
                musicVids = musicVidss;
                authorStats = authorStatss;
            }
        }
        public class AuthorStat
        {
            public string name { get; set; }
            public int sec_watched { get; set; }
        }
        public class MusicVid
        {
            public string title { get; set; }
            public string vid_id { get; set; }
            public string author { get; set; }
            public int views { get; set; }
            public TimeSpan duration { get; set; }
            public MusicVid()
            {
                views = 0;
            }
        }

        class Json
        {
            public string header { get; set; }
            public string title { get; set; }
            public string titleUrl { get; set; }
            public Subtitles[] subtitles { get; set; }
            public string time { get; set; }
            public string[] products { get; set; }
            public string[] activityControls { get; set; }
        }

        class Subtitles
        {
            public string name { get; set; }
            public string url { get; set; }
        }
        private static async Task<TimeSpan> GetDuration(string videoId)
        {
            try
            {
                var youtube = new YoutubeClient();


                Console.WriteLine($"Fetching duration for ID: {videoId}");
                var video = await youtube.Videos.GetAsync(videoId).ConfigureAwait(false);

                Console.WriteLine($"✓ Got duration: {video.Duration} for {video.Title}");
                return video.Duration ?? TimeSpan.Zero;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching duration for {videoId}: {ex.Message}");
                return TimeSpan.Zero;
            }
        }
    }
}

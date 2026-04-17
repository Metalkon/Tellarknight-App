using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class NewsService
    {
        public List<NewsEntry> Entries { get; set; } 

        public NewsService()
        {
            Entries = new List<NewsEntry>();
        }

        public async Task GetNewsAsync()
        {
            if (Entries.Count > 0) 
                return;

            Entries.Clear();
            HttpClient client = new HttpClient();
            var csv = await client.GetStringAsync("https://docs.google.com/spreadsheets/d/e/2PACX-1vSucAIVLHb6_L10XKCrEkLA270gF0eljGACEe2umn8Y6iDR3CSMRCKFaUPWuEvBKphFTo7woE5RDUWb/pub?output=csv");

            var lines = csv.Split('\n');

            for (int i = 1; i < lines.Length; i++)
            {
                var cols = lines[i].Trim().Split(',');

                if (cols.Length < 4) 
                    continue;

                var entry = new NewsEntry
                {
                    Date = cols[0],
                    Header = cols[1],
                    Version = cols[2],
                    Content = cols[3]
                };

                Entries.Add(entry);
            }
        }
    }
}
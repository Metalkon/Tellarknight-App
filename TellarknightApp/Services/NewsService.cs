using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class NewsService
    {
        private readonly HttpClient _http;
        private const string SheetUrl = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSucAIVLHb6_L10XKCrEkLA270gF0eljGACEe2umn8Y6iDR3CSMRCKFaUPWuEvBKphFTo7woE5RDUWb/pub?output=csv";

        public NewsService(HttpClient http) => _http = http;

        public async Task<List<NewsEntry>> GetNewsAsync()
        {
            var csv = await _http.GetStringAsync(SheetUrl);

            var lines = csv.Split('\n');
            var entries = new List<NewsEntry>();

            for (int i = 1; i < lines.Length; i++)
            {
                var cols = lines[i].Trim().Split(',');

                if (cols.Length < 4) continue;

                var entry = new NewsEntry
                {
                    Date = cols[0],
                    Header = cols[1],
                    Version = cols[2],
                    Content = cols[3]
                };

                entries.Add(entry);
            }

            return entries;
        }
    }
}
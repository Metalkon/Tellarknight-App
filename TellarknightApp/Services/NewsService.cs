using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class NewsService
    {
        private const string NewsUrl =
            "https://docs.google.com/spreadsheets/d/e/2PACX-1vSucAIVLHb6_L10XKCrEkLA270gF0eljGACEe2umn8Y6iDR3CSMRCKFaUPWuEvBKphFTo7woE5RDUWb/pub?output=csv";

        public List<NewsEntry> Entries { get; private set; } = new();

        public async Task GetNewsAsync()
        {
            if (Entries.Count > 0) return;

            try
            {
                using var client = new HttpClient();
                var csv = await client.GetStringAsync(NewsUrl);

                var entries = new List<NewsEntry>();
                var row = new List<string>();
                var field = new StringBuilder();
                bool inQuotes = false, isHeader = true;

                void EndRow()
                {
                    row.Add(field.ToString());
                    field.Clear();

                    if (isHeader) isHeader = false;
                    else if (row.Count >= 4)
                        entries.Add(new NewsEntry
                        {
                            Date = row[0].Trim(),
                            Header = row[1].Trim(),
                            Version = row[2].Trim(),
                            Content = string.Join(",", row.GetRange(3, row.Count - 3)).Trim()
                        });

                    row = new List<string>();
                }

                foreach (char c in csv)
                {
                    if (inQuotes)
                    {
                        if (c == '"') inQuotes = false;
                        else field.Append(c);
                    }
                    else if (c == '"') inQuotes = true;
                    else if (c == ',') { row.Add(field.ToString()); field.Clear(); }
                    else if (c == '\n') EndRow();
                    else if (c != '\r') field.Append(c);
                }
                if (field.Length > 0 || row.Count > 0) EndRow();

                entries.Reverse();
                Entries = entries;
            }
            catch
            {
                // leave Entries empty on failure
            }
        }
    }
}
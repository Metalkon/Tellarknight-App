using CommunityToolkit.Maui.Storage;
using Microsoft.AspNetCore.Components;
using System.Text;
using TellarknightApp.Cards;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class CardManager
    {
        private readonly SupportedCards _supportedCards;

        public List<Card> MainDeck { get; set; }
        public List<Card> ExtraDeck { get; set; }
        public SearchValues SearchValues { get; set; }
        public List<Card> CardResults { get; set; }

        public CardManager(SupportedCards supportedCards)
        {
            _supportedCards = supportedCards;

            MainDeck = new List<Card>();
            ExtraDeck = new List<Card>();
            SearchValues = new SearchValues();
            CardResults = _supportedCards.Cards.ToList();

            BuildDecklist();
        }

        // Clears the statistics
        public void RefreshCards()
        {
            SearchValues = new SearchValues();
            BuildDecklist();
        }

        public void BuildDecklist()
        {
            MainDeck.Clear();
            ExtraDeck.Clear();

            foreach (Card card in _supportedCards.Cards)
            {
                if (card.Quantity > 3 && card is not Level4 && card is not EmptyCard)
                {
                    card.Quantity = 3;
                }
                if (card.Quantity > 0 && card.Role != "Extra Deck")
                {
                    for (int i = 0; i < card.Quantity; i++)
                    {
                        MainDeck.Add(card);
                    }
                }
                if (card.Quantity > 0 && card.Role == "Extra Deck")
                {
                    for (int i = 0; i < card.Quantity; i++)
                    {
                        ExtraDeck.Add(card);
                    }
                }
            }
            while (MainDeck.Count < 40)
            {
                MainDeck.Add(new EmptyCard());
            }
            //Action?.Invoke();
        }

        public async Task Search()
        {
            var filtered = _supportedCards.Cards
                .Where(x =>
                    string.IsNullOrEmpty(SearchValues.SearchQuery) ||
                    x.Name.ToLower().Contains(SearchValues.SearchQuery.ToLower()))

                .Where(x =>
                    string.IsNullOrEmpty(SearchValues.ArchetypeQuery) ||
                    (x.Archetype != null && x.Archetype.Contains(SearchValues.ArchetypeQuery)))

                .Where(x =>
                    string.IsNullOrEmpty(SearchValues.TypeQuery) ||
                    (SearchValues.TypeQuery == "Monster"
                        ? (x.Type != "Spell" && x.Type != "Field Spell" && x.Type != "Trap")
                    : SearchValues.TypeQuery == "Spell (includes Field Spell)"
                        ? (x.Type == "Spell" || x.Type == "Field Spell")
                    : SearchValues.TypeQuery == "Extender"
                        ? x.Role == "Extender"
                    : SearchValues.TypeQuery == "Hand Trap"
                        ? x.Role == "Hand Trap"
                    : x.Type == SearchValues.TypeQuery))
                .ToList();

            SearchValues.TotalItems = filtered.Count;

            CardResults = filtered
                .Skip((SearchValues.CurrentPage - 1) * SearchValues.ItemsPerPage)
                .Take(SearchValues.ItemsPerPage)
                .ToList();
        }

        public async Task ExportYdk()
        {
            using var filecontent = new MemoryStream(Encoding.UTF8.GetBytes(GenerateYdk()));
            var fileSaverResult = await FileSaver.SaveAsync("tellarknight.ydk", filecontent);
        }

        public async Task ImportYdk()
        {
            var YdkFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>> { { DevicePlatform.WinUI, new[] { ".ydk" } } });

            var result = await FilePicker.PickAsync(new PickOptions { FileTypes = YdkFileType });

            if (result is null)
                return;

            using var stream = await result.OpenReadAsync();
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();

            ReadYdk(content);
        }

        private string GenerateYdk()
        {
            BuildDecklist();
            var sb = new StringBuilder();

            sb.AppendLine("#main");
            foreach (var card in MainDeck.Where(x => x.Role != "Extra Deck" && x.Id != 0))
            {
                sb.AppendLine(card.Id.ToString());
            }

            sb.AppendLine("#extra");
            foreach (var card in ExtraDeck.Where(x => x.Id != 0))
            {
                sb.AppendLine(card.Id.ToString());
            }

            sb.AppendLine("!side");

            return sb.ToString();
        }

        private void ReadYdk(string content)
        {
            RefreshCards();
            _supportedCards.RefreshUpdate();

            var lines = content.Split('\n');

            foreach (var line in lines)
            {
                var isCardId = int.TryParse(line.Trim(), out int cardId);

                if (!isCardId)
                    continue;

                var card = _supportedCards.Cards.FirstOrDefault(x => x.Id == cardId);

                if (card != null)
                    card.Quantity++;
                else
                    _supportedCards.Cards.FirstOrDefault(x => x is EmptyCard).Quantity++;
            }
        }
    }
}


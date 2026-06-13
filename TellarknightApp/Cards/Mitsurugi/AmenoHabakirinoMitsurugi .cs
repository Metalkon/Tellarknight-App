using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class AmenoHabakirinoMitsurugi : Card
    {
        public AmenoHabakirinoMitsurugi()
        {
            Name = "Ame no Habakiri no Mitsurugi";
            Type = "Reptile";
            Attribute = "Dark";
            Level = 8;
            Attack = 2400;
            Defense = 1800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Mitsurugi" };
            Id = 13332685;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class AmenoMurakumonoMitsurugi : Card
    {
        public AmenoMurakumonoMitsurugi()
        {
            Name = "Ame no Murakumo no Mitsurugi";
            Type = "Reptile";
            Attribute = "Dark";
            Level = 8;
            Attack = 3200;
            Defense = 800;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Mitsurugi" };
            Id = 19899073;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MitsuruginoMikotoAramasa : Card
    {
        public MitsuruginoMikotoAramasa()
        {
            Name = "Mitsurugi no Mikoto, Aramasa";
            Type = "Reptile";
            Attribute = "Dark";
            Level = 4;
            Attack = 1200;
            Defense = 900;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Mitsurugi" };
            Id = 40543231;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
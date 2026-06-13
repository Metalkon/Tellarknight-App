using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MitsuruginoMikotoSaji : Card
    {
        public MitsuruginoMikotoSaji()
        {
            Name = "Mitsurugi no Mikoto, Saji";
            Type = "Reptile";
            Attribute = "Dark";
            Level = 4;
            Attack = 1000;
            Defense = 1700;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Mitsurugi" };
            Id = 18176525;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
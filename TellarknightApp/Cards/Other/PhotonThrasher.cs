using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class PhotonThrasher : Card
    {
        public PhotonThrasher()
        {
            Name = "Photon Thrasher";
            Type = "Warrior";
            Attribute = "Light";
            Level = 4;
            Attack = 2100;
            Defense = 0;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "None" };
            Id = 65367484;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Extender + Any Lv4 "Tellar"
            if (hand.Any(x => x.Level == 4 && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar"))))
            {
                localStats.AverageXyzOneTellar = true;
            }

            // Extender + Any Other Lv4
            if (hand.Any(x => x is not PhotonThrasher && x.Level == 4))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}
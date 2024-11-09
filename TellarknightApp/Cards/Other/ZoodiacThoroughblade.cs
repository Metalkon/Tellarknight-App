using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class ZoodiacThoroughblade : Card
    {
        public ZoodiacThoroughblade()
        {
            Name = "Zoodiac Thoroughblade";
            Type = "Beast-Warrior";
            Attribute = "Earth";
            Level = 4;
            Attack = 1600;
            Defense = 0;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Zoodiac" };
            Id = 77150143;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
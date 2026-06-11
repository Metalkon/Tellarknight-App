using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class EpsilonTheMagnetWarrior : Card
    {
        public EpsilonTheMagnetWarrior()
        {
            Name = "Epsilon The Magnet Warrior";
            Type = "Rock";
            Attribute = "Earth";
            Level = 4;
            Attack = 1300;
            Defense = 1500;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Magnet" };
            Id = 52566270;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
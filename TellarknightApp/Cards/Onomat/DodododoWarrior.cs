using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class DodododoWarrior : Card
    {
        public DodododoWarrior()
        {
            Name = "Dodododo Warrior";
            Type = "Warrior";
            Attribute = "Earth";
            Level = 6;
            Attack = 2300;
            Defense = 900;
            Scale = null;
            Role = "Extender";
            Archetype = new List<string> { "Onomat" };
            Id = 62880279;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class MajestyPegasusTheDracoslayer : Card
    {
        public MajestyPegasusTheDracoslayer()
        {
            Name = "Majesty Pegasus, the Dracoslayer";
            Type = "Spellcaster";
            Attribute = "Wind";
            Level = 4;
            Attack = 1500;
            Defense = 1500;
            Scale = 2;
            Role = string.Empty;
            Archetype = new List<string> { "None" };
            Id = 92332424;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            return localStats;
        }
    }
}
using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class MonsterReborn : Card
    {
        public MonsterReborn()
        {
            Name = "Monster Reborn";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 83764718;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            // Reborn + Unuk
            if (hand.Any(x => x is SatellarknightUnukalhai) && deck.Any(x => x.Level == 4 && x.Archetype.Contains("Tellarknight") && x is not SatellarknightUnukalhai))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Reborn + Nabla
            if (hand.Any(x => x is MathmechNabla) && deck.Any(x => x.Level == 4 && x.Archetype.Contains("Mathmech")))
            {
                localStats.AverageXyzNoTellar = true;
            }

            return localStats;
        }
    }
}
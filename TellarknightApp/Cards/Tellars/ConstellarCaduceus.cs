
/* Unmerged change from project 'TellarknightApp (net8.0-ios)'
Before:
using TellarknightApp.Models;
After:
using TellarknightApp;
using TellarknightApp.Cards;
using TellarknightApp.Cards;
using TellarknightApp.Cards.Constellar;
using TellarknightApp.Models;
*/
using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp.Cards
{
    public class ConstellarCaduceus : Card
    {
        public ConstellarCaduceus()
        {
            Name = "Constellar Caduceus";
            Type = "Spellcaster";
            Attribute = "Light";
            Level = 4;
            Attack = 1600;
            Defense = 1550;
            Scale = null;
            Role = string.Empty;
            Archetype = new List<string> { "Constellar" };
            Image = "./CardArt/Caduceus.png";
            Id = 82913020;
        }

        public override LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> scales, List<Card> extraDeck)
        {
            // Caduceus + Lv4 Constellar
            if (hand.Any(x => x is not ConstellarCaduceus && x.Level == 4 && x.Archetype.Contains("Constellar")))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            // Caduceus + Lv4 Tellarknight (Spell Search)
            if (hand.Any(x => x is not ConstellarCaduceus && x.Level == 4 && x.Archetype.Contains("Tellarknight"))
                && (hand.Any(x => x is ConstellarTellarknights) || deck.Any(x => x is ConstellarTellarknights)))
            {
                localStats.AverageXyzTwoTellar = true;
            }

            return localStats;
        }
    }
}
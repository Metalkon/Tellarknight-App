using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

/* 
 NOTES:
- Transfer all of the helper methods into a service that can be used within the card classes

 */

namespace TellarknightApp.Services
{
    internal class HandAnalyzer        
    {
        private readonly CardHelper _cardHelper;

        public HandAnalyzer(CardHelper cardHelper)
        {
            _cardHelper = cardHelper;
        }

        public static DeckStatistics HandCheck(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales, List<Card> extraDeck, DeckStatistics stats)
        {
            LocalStats localStats = new LocalStats();

            // Gamestate For Easy Transfer (will need to add to Home later)
            GameState gameState = new GameState()
            {
                LocalStats = localStats,
                Hand = hand,
                Deck = deck,
                Gy = gy,
                OnField = onField,
                Scales = scales,
                ExtraDeck = extraDeck,
                NormalSummoned = normalSummoned
            };

            // Test New Stuff Here

            //Temporary Revert
            localStats = gameState.LocalStats;
            hand = gameState.Hand;
            deck = gameState.Deck;
            gy = gameState.Gy;
            onField = gameState.OnField;
            scales = gameState.Scales;
            extraDeck = gameState.ExtraDeck;
            normalSummoned = gameState.NormalSummoned;




            // Corrections
            if (localStats.AverageXyzSpellOrAltairan || localStats.AverageXyzTwoTellars)
            {
                localStats.AverageXyzWithTellar = true;
            }
            if (localStats.AverageXyzNoTellar && (localStats.AverageXyzWithTellar || localStats.AverageXyzSpellOrAltairan))
            {
                localStats.AverageXyzNoTellar = false;
            }
            if (localStats.AverageXyzWithTellar && (hand.Any(x => x.Name == "Satellarknight Unukalhai") || hand.Any(x => x.Name == "Tellarknight Altairan") || hand.Any(x => x.Name == "Constellar Tellarknights")))
            {
                localStats.AverageXyzSpellOrAltairan = true;
            }
            if (localStats.ZefraathAndSHS || localStats.ZefraathAndThuban || localStats.ZefraComboWithTrap)
            {
                localStats.PendulumnSummon = true;
            }
            if (localStats.ZefraathAndThuban)
            {
                localStats.AverageXyzWithTellar = true;
            }
            if (localStats.ZefraathAndSHS || localStats.ZefraathAndThuban)
            {
                localStats.AverageXyzWithTellar = true;
            }


            // Check For Hand Brick
            if (!localStats.AverageXyzNoTellar
                && !localStats.AverageXyzWithTellar
                && !localStats.AverageXyzSpellOrAltairan
                && !localStats.AverageXyzTwoTellars
                && !localStats.AverageXyzUnknown
                && !localStats.PendulumnSummon
                && !localStats.ZefraathAndSHS
                && !localStats.ZefraathAndThuban
                && !localStats.ZefraComboWithTrap
                && !localStats.ZefraComboWithNormalAvailable)
            {
                localStats.BrickChance = true;
            }

            if (localStats.BrickChance == false && hand.Any(x => x.Name == "Zefra Divine Strike"))
            {
                localStats.ZefraComboWithTrap = true;
            }

            string test = string.Join(", ", hand.Select(x => x.Name));

            // Isolde Bricking
            if (
                (deck.Count(x => x.Name == "Living Fossil" || x.Name == "\"Infernoble Arms - Durendal\"") == 0
                || deck.Count(x => x.Name == "Infernoble Knight - Renaud" || x.Name == "Fire Flint Lady") == 0))
            {
                localStats.IsoldeBrick = true;
            }

            stats.AverageHandTraps = stats.AverageHandTraps + hand.Count(x => x.Role == "HandTrap");
            stats.AverageBystials = stats.AverageBystials + hand.Count(x => x.Archetype.Contains("Bystial"));

            stats.AverageTellars = stats.AverageTellars + hand.Count(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4);

            stats = UpdateStats(localStats, stats);

            return stats;
        }

        public static DeckStatistics UpdateStats(LocalStats localStats, DeckStatistics stats)
        {
            if (localStats.BrickChance) stats.BrickChance++;
            if (localStats.AverageTellars) stats.AverageTellars++;
            if (localStats.AverageXyzNoTellar) stats.AverageXyzNoTellar++;
            if (localStats.AverageXyzWithTellar) stats.AverageXyzWithTellar++;
            if (localStats.AverageXyzSpellOrAltairan) stats.AverageXyzSpellOrAltairan++;
            if (localStats.AverageXyzTwoTellars) stats.AverageXyzTwoTellars++;
            if (localStats.ZefraathAndSHS) stats.ZefraathAndSHS++;
            if (localStats.ZefraathAndThuban) stats.ZefraathAndThuban++;
            if (localStats.ZefraComboWithTrap) stats.ZefraComboWithTrap++;
            if (localStats.ZefraComboWithNormalAvailable) stats.ZefraComboWithNormalAvailable++;
            if (localStats.AverageHandTraps) stats.AverageHandTraps++;
            if (localStats.IsoldeBrick) stats.IsoldeBrick++;
            if (localStats.PendulumnSummon) stats.PendulumnSummon++;
            if (localStats.AverageXyzUnknown) stats.AverageXyzUnknown++;

            return stats;
        }



    }
}

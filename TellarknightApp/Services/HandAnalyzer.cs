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
        public static DeckStatistics HandCheck(GameState gameState, DeckStatistics stats)
        {
            // New Code Goes Here
            // Loop over each card in hand with their own AnalyzeHand methods

            // Corrections
            if (gameState.LocalStats.AverageXyzSpellOrAltairan || gameState.LocalStats.AverageXyzTwoTellars)
            {
                gameState.LocalStats.AverageXyzWithTellar = true;
            }
            if (gameState.LocalStats.AverageXyzNoTellar && (gameState.LocalStats.AverageXyzWithTellar || gameState.LocalStats.AverageXyzSpellOrAltairan))
            {
                gameState.LocalStats.AverageXyzNoTellar = false;
            }
            if (gameState.LocalStats.AverageXyzWithTellar && (gameState.Hand.Any(x => x.Name == "Satellarknight Unukalhai") || gameState.Hand.Any(x => x.Name == "Tellarknight Altairan") || gameState.Hand.Any(x => x.Name == "Constellar Tellarknights")))
            {
                gameState.LocalStats.AverageXyzSpellOrAltairan = true;
            }
            if (gameState.LocalStats.ZefraathAndSHS || gameState.LocalStats.ZefraathAndThuban || gameState.LocalStats.ZefraComboWithTrap)
            {
                gameState.LocalStats.PendulumnSummon = true;
            }
            if (gameState.LocalStats.ZefraathAndThuban)
            {
                gameState.LocalStats.AverageXyzWithTellar = true;
            }
            if (gameState.LocalStats.ZefraathAndSHS || gameState.LocalStats.ZefraathAndThuban)
            {
                gameState.LocalStats.AverageXyzWithTellar = true;
            }


            // Check For Hand Brick
            if (!gameState.LocalStats.AverageXyzNoTellar
                && !gameState.LocalStats.AverageXyzWithTellar
                && !gameState.LocalStats.AverageXyzSpellOrAltairan
                && !gameState.LocalStats.AverageXyzTwoTellars
                && !gameState.LocalStats.AverageXyzUnknown
                && !gameState.LocalStats.PendulumnSummon
                && !gameState.LocalStats.ZefraathAndSHS
                && !gameState.LocalStats.ZefraathAndThuban
                && !gameState.LocalStats.ZefraComboWithTrap
                && !gameState.LocalStats.ZefraComboWithNormalAvailable)
            {
                gameState.LocalStats.BrickChance = true;
            }

            if (gameState.LocalStats.BrickChance == false && gameState.Hand.Any(x => x.Name == "Zefra Divine Strike"))
            {
                gameState.LocalStats.ZefraComboWithTrap = true;
            }

            string test = string.Join(", ", gameState.Hand.Select(x => x.Name));

            // Isolde Bricking
            if (
                (gameState.Deck.Count(x => x.Name == "Living Fossil" || x.Name == "\"Infernoble Arms - Durendal\"") == 0
                || gameState.Deck.Count(x => x.Name == "Infernoble Knight - Renaud" || x.Name == "Fire Flint Lady") == 0))
            {
                gameState.LocalStats.IsoldeBrick = true;
            }

            stats.AverageHandTraps = stats.AverageHandTraps + gameState.Hand.Count(x => x.Role == "HandTrap");
            stats.AverageBystials = stats.AverageBystials + gameState.Hand.Count(x => x.Archetype.Contains("Bystial"));

            stats.AverageTellars = stats.AverageTellars + gameState.Hand.Count(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4);

            stats = UpdateStats(gameState.LocalStats, stats);

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

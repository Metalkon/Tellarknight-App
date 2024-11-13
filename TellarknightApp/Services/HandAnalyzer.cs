using TellarknightApp.Cards;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    internal class HandAnalyzer        
    {
        public static DeckStatistics HandCheck(GameState gameState, DeckStatistics stats)
        {
            // Loop over each card in hand with their own AnalyzeHand methods
            foreach (Card card in gameState.Hand)
            {
                if (card.Analyzed == false)
                {
                    gameState.LocalStats = card.AnalyzeHand(gameState.LocalStats, gameState.Hand, gameState.Deck, gameState.Gy, gameState.ExtraDeck);
                    card.Analyzed = true;
                }
            }

            // Undo Analyzed Boolean After AnalyzeHand Loop
            foreach (Card card in gameState.Hand)
            {
                card.Analyzed = false;
            }

            // Corrections
            if (gameState.LocalStats.OracleCombo)
            {
                gameState.LocalStats.PendulumSummon = true;
            }
            if (gameState.LocalStats.ZefraathAndThuban)
            {
                gameState.LocalStats.AverageXyzOneTellar = true;
            }
            if (gameState.LocalStats.OracleCombo || gameState.LocalStats.ZefraathAndThuban)
            {
                gameState.LocalStats.AverageXyzOneTellar = true;
            }
            if (gameState.LocalStats.PendulumSummon == true)
            {
                gameState.LocalStats.AverageXyzNoTellar = true;
            }
            if (gameState.LocalStats.RyzealLock == true
                && (gameState.LocalStats.PendulumSummon 
                || gameState.LocalStats.OracleCombo 
                || gameState.LocalStats.PendulumSummon 
                || gameState.LocalStats.AverageXyzNoTellar 
                || gameState.LocalStats.AverageXyzOneTellar 
                || gameState.LocalStats.AverageXyzTwoTellar))
            {
                gameState.LocalStats.RyzealLock = false;
            }

            // Average Tellar Count
            if (gameState.LocalStats.AverageXyzTwoTellar == true)
            {
                gameState.LocalStats.AverageXyzOneTellar = false;
                gameState.LocalStats.AverageXyzNoTellar = false;
            }
            if (gameState.LocalStats.AverageXyzOneTellar == true)
            {
                gameState.LocalStats.AverageXyzNoTellar = false;
            }

            // Check For Hand Brick
            if (!gameState.LocalStats.AverageXyzNoTellar
                && !gameState.LocalStats.AverageXyzOneTellar
                && !gameState.LocalStats.AverageXyzTwoTellar
                && !gameState.LocalStats.PendulumSummon
                && !gameState.LocalStats.OracleCombo
                && !gameState.LocalStats.RyzealLock)
            {
                gameState.LocalStats.BrickChance = true;
            }

            // Isolde Bricking
            if ((gameState.Deck.Count(x => x.Name == "Living Fossil" || x.Name == "\"Infernoble Arms - Durendal\"") == 0
                || gameState.Deck.Count(x => x.Name == "Infernoble Knight - Renaud" || x.Name == "Fire Flint Lady") == 0))
            {
                gameState.LocalStats.IsoldeBrick = true;
            }

            // Drawing An Armored Xyz Card / Not Being Able to Search x2
            if ((gameState.Deck.Count(x => x is ArmoredXyz) == 0
                || gameState.Deck.Count(x => x is FullArmoredXyz) == 0))
            {
                gameState.LocalStats.ArmoredBrick = true;
            }

            // Average Hand Traps/Extenders
            stats.AverageHandTraps = stats.AverageHandTraps + gameState.Hand.Count(x => x.Role == "Hand Trap");
            stats.AverageExtenders = stats.AverageExtenders + gameState.Hand.Count(x => x.Role == "Extender");

            // Average # Tellars
            stats.AverageTellars = stats.AverageTellars + gameState.Hand.Count(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4);

            // Update DeckStatistics "stats" From gameData.LocalStats
            stats = UpdateStats(gameState.LocalStats, stats);

            return stats;
        }

        public static DeckStatistics UpdateStats(LocalStats localStats, DeckStatistics stats)
        {
            if (localStats.BrickChance) stats.BrickChance++;
            if (localStats.AverageTellars) stats.AverageTellars++;
            if (localStats.AverageXyzNoTellar) stats.AverageXyzNoTellar++;
            if (localStats.AverageXyzOneTellar) stats.AverageXyzOneTellar++;
            if (localStats.AverageXyzTwoTellar) stats.AverageXyzTwoTellar++;
            if (localStats.PendulumSummon) stats.PendulumSummon++;
            if (localStats.OracleCombo) stats.OracleCombo++;
            if (localStats.AverageHandTraps) stats.AverageHandTraps++;
            if (localStats.AverageExtenders) stats.AverageExtenders++;
            if (localStats.IsoldeBrick) stats.IsoldeBrick++;
            if (localStats.ArmoredBrick) stats.ArmoredBrick++;
            if (localStats.RyzealLock) stats.RyzealLock++;

            return stats;
        }
    }
}

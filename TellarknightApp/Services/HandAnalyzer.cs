using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    internal class HandAnalyzer
    {
        public static DeckStatistics HandCheck(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummon, List<Card> onField, List<Card> scales, DeckStatistics stats)
        {
            LocalStats localStats = new LocalStats();
            
            // SHS
            if (onField.Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi")
                && onField.Any(x => x.Name == "Superheavy Samurai Soulgaia Booster"))
            {
                localStats.AverageXyzNoTellar = true;
                if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                {
                    localStats.AverageXyzWithTellar = true;
                }
            }

            // Extenders
            if (hand.Any(x => x.Role.Contains("Extender")))
            {
                if (hand.Any(x => x.Name == "Sakitama") && CountCards(hand, 4, "Any") >= 2)
                {
                    localStats.AverageXyzNoTellar = true;
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                }
                if (hand.Any(x => x.Name == "ZS - Ascended Sage") && CountCards(hand, 4, "Any") >= 2)
                {
                    localStats.AverageXyzNoTellar = true;
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                }
                if (hand.Any(x => x.Name == "Photon Thrasher") && CountCards(hand, "Photon Thrasher", 4, "Any") >= 1)
                {
                    localStats.AverageXyzNoTellar = true;
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                }
                if ((hand.Any(x => x.Name == "Fire Flint Lady") || (hand.Any(x => x.Name == "Infernoble Arms - Durendal") && deck.Any(x => x.Name == "Fire Flint Lady")))
                    && hand.Where(x => x.Type.Contains("Warrior") && x.Level == 4).Count() >= 2)
                {
                    localStats.AverageXyzNoTellar = true;
                    if (hand.Where(x => x.Type.Contains("Warrior") && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4).Count() >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                    if (hand.Where(x => x.Type.Contains("Warrior") && (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4).Count() >= 2)
                    {
                        localStats.AverageXyzTwoTellars = true;
                    }
                    if (hand.Any(x => x.Name == "Tellarknight Lyran") || hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                    {
                        localStats.AverageXyzUnukOrLyran = true;
                    }
                }
                // add sheratan without another tellar/constellar
            }

            // Tellarknight/Constellars
            if (hand.Any(x => x.Archetype.Contains("Tellarknight")))
            {
                
                // Continuous Spell
                if (hand.Any(x => x.Name == "Constellar Tellarknights") && CountCards(hand, 4, "Tellarknight", "Constellar") >= 1 && CountCards(hand, 4, "Any") >= 2)
                {
                    localStats.AverageXyzWithTellar = true;
                    if (hand.Any(x => x.Name == "Tellarknight Lyran") || hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                    {
                        localStats.AverageXyzUnukOrLyran = true;
                    }
                }
                if (hand.Any(x => x.Name == "Constellar Tellarknights") && CountCards(hand, 4, "Tellarknight", "Constellar") >= 2)
                {
                    localStats.AverageXyzTwoTellars = true;
                    if (hand.Any(x => x.Name == "Tellarknight Lyran") || hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                    {
                        localStats.AverageXyzUnukOrLyran = true;
                    }
                }
                if (hand.Any(x => x.Name == "Constellar Tellarknights") && (hand.Any(x => x.Name == "Satellarknight Deneb") || hand.Any(x => x.Name == "Satellarknight Unukalhai")))
                {
                    localStats.AverageXyzTwoTellars = true;
                    localStats.AverageXyzUnukOrLyran = true;                    
                }

                // Skybridge
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && CountCards(hand, 4, "Tellarknight") >= 2)
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && hand.Any(x => x.Name == "Constellar Tellarknights") && CountCards(hand, 4, "Tellarknight") >= 1)
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && CheckUniqueCards(hand, "Min", 1, "Satellarknight Deneb", "Satellarknight Unukalhai", "Tellarknight Lyran"))
                {
                    localStats.AverageXyzTwoTellars = true;
                    if (hand.Any(x => x.Name == "Tellarknight Lyran") || hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                    {
                        localStats.AverageXyzUnukOrLyran = true;
                    }
                }

                // Monster Effects
                
                if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1 && hand.Any(x => x.Role.Contains("Extender") && x.Level == 4))
                {
                    localStats.AverageXyzWithTellar = true;
                }                
                if (hand.Any(x => x.Name == "Tellarknight Lyran") && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") >= 1)
                {
                    localStats.AverageXyzUnukOrLyran = true;
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Where(x => x.Name == "Tellarknight Lyran").Count() >= 2
                    && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") == 0
                    && (
                        (hand.Any(x => x.Name == "Satellarknight Skybridge") || deck.Any(x => x.Name == "Satellarknight Skybridge"))
                        || (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights"))
                       )
                   )
                {
                    localStats.AverageXyzTwoTellars = true;
                }

                if (hand.Any(x => x.Name == "Satellarknight Vega") && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
                {
                    localStats.AverageXyzWithTellar = true;
                }
                if (hand.Any(x => x.Name == "Constellar Caduceus") && CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1)
                {
                    localStats.AverageXyzWithTellar = true;
                }
                if (hand.Any(x => x.Name == "Constellar Sheratan") && (CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1 || (CountCards(hand, 4, "Tellarknight", "Constellar") >= 2))
                    && (deck.Any(x => x.Name == "Constellar Caduceus") || deck.Any(x => x.Name == "Constellar Caduceus"))
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzWithTellar = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Living Fossil"))
                {
                    localStats.AverageXyzUnukOrLyran = true;
                    localStats.AverageXyzTwoTellars = true;
                }
            }
            













                
            // Corrections
            if (localStats.AverageXyzUnukOrLyran || localStats.AverageXyzTwoTellars)
            {
                localStats.AverageXyzWithTellar = true;
            }
            if (localStats.AverageXyzNoTellar && (localStats.AverageXyzWithTellar || localStats.AverageXyzUnukOrLyran))
            {
                localStats.AverageXyzNoTellar = false;
            }

            // Check For Hand Brick
            if (!localStats.AverageXyzNoTellar 
                && !localStats.AverageXyzWithTellar 
                && !localStats.AverageXyzUnukOrLyran 
                && !localStats.AverageXyzTwoTellars 
                && !localStats.ZefraathAndSHS 
                && !localStats.ZefraathAndThuban 
                && !localStats.ZefraComboWithTrap 
                && !localStats.ZefraComboWithNormalAvailable)
            {
                localStats.BrickChance = true;
            }

            // Note: Add stats for hands that can achieve both unuk effect and have the spell by the xyz, that covers when lyran cannot search cont spell
            // Note: Add stats for unuk that tags altair being unusable later

            stats = UpdateStats(localStats, stats);

            return stats;
        }

        public static bool CheckUniqueCards(List<Card> hand, string minMax, int targetNumber, params string[] cards)
        {
            List<Card> handCopy = hand.ToList();

            int count = 0;
            foreach (var card in cards)
            {
                if (handCopy.Any(x => x.Name == card))
                {
                    count++;
                    handCopy.RemoveAll(x => x.Name == card);
                }
            }

            if (minMax == "Min" && count >= targetNumber)
            {
                return true;
            }
            if (minMax == "Max" && count <= targetNumber)
            {
                return true;
            }

            return false;
        }

        public static DeckStatistics UpdateStats(LocalStats localStats, DeckStatistics stats)
        {
            if (localStats.BrickChance) stats.BrickChance++;
            if (localStats.AverageTellars) stats.AverageTellars++;
            if (localStats.AverageXyzNoTellar) stats.AverageXyzNoTellar++;
            if (localStats.AverageXyzWithTellar) stats.AverageXyzWithTellar++;
            if (localStats.AverageXyzUnukOrLyran) stats.AverageXyzUnukOrLyran++;
            if (localStats.AverageXyzTwoTellars) stats.AverageXyzTwoTellars++;
            if (localStats.ZefraathAndSHS) stats.ZefraathAndSHS++;
            if (localStats.ZefraathAndThuban) stats.ZefraathAndThuban++;
            if (localStats.ZefraComboWithTrap) stats.ZefraComboWithTrap++;
            if (localStats.ZefraComboWithNormalAvailable) stats.ZefraComboWithNormalAvailable++;
            if (localStats.AverageHandTraps) stats.AverageHandTraps++;

            return stats;
        }

        public class LocalStats
        {
            public bool BrickChance { get; set; } = false;
            public bool AverageTellars { get; set; } = false;
            public bool AverageExtenders { get; set; } = false;
            public bool AverageXyzNoTellar { get; set; } = false;
            public bool AverageXyzWithTellar { get; set; } = false;
            public bool AverageXyzUnukOrLyran { get; set; } = false;
            public bool AverageXyzTwoTellars { get; set; } = false;
            public bool ZefraathAndSHS { get; set; } = false;
            public bool ZefraathAndThuban { get; set; } = false;
            public bool ZefraComboWithTrap { get; set; } = false;
            public bool ZefraComboWithNormalAvailable { get; set; } = false;
            public bool AverageHandTraps { get; set; } = false;
        }

        public static int CountCards(List<Card> hand, int level)
        {
            var matchingCards = hand.Where(x => x.Level == level);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude, int level)
        {
            var matchingCards = hand.Where(x => x.Level == level && x.Name != exclude);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, int level, string archetype1)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) && x.Level == level));

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude, int level, string archetype1)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) && x.Level == level && x.Name != exclude));

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, int level, string archetype1, string archetype2)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level);

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string exclude, int level, string archetype1, string archetype2)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level && x.Name != exclude);

            return matchingCards.Count();
        }
    }
}

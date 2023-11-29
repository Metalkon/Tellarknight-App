using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    internal class HandAnalyzer
    {
        public static DeckStatistics HandCheck(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummon, List<Card> onField, List<Card> scales, DeckStatistics stats)
        {
            LocalStats localStats = new LocalStats()
            {
                BrickChance = false,
                AverageTellars = false,
                AverageDelterosNoTellar = false,
                AverageDelterosWithTellar = false,
                AverageDelterosUnukOrLyran = false,
                AverageHandTraps = false
            };      

            // LOGIC FOR METHOD

            stats = UpdateStats(localStats, stats);

            return stats;
        }


        public static DeckStatistics UpdateStats(LocalStats localStats, DeckStatistics stats)
        {
            if (localStats.BrickChance == true)
            {
                stats.BrickChance++;
            }
            if (localStats.AverageTellars == true)
            {
                stats.AverageTellars++;
            }
            if (localStats.AverageDelterosNoTellar == true)
            {
                stats.AverageDelterosNoTellar++;
            }
            if (localStats.AverageDelterosWithTellar == true)
            {
                stats.AverageDelterosWithTellar++;
            }
            if (localStats.AverageDelterosUnukOrLyran == true)
            {
                stats.AverageDelterosUnukOrLyran++;
            }
            if (localStats.AverageHandTraps == true)
            {
                stats.AverageHandTraps++;
            }

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

        public class LocalStats
        {
            public bool BrickChance { get; set; }
            public bool AverageTellars { get; set; }
            public bool AverageExtenders { get; set; }
            public bool AverageDelterosNoTellar { get; set; }
            public bool AverageDelterosWithTellar { get; set; }
            public bool AverageDelterosUnukOrLyran { get; set; }
            public bool AverageHandTraps { get; set; }
        }
    }
}

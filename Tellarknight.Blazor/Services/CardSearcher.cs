using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tellarknight.Blazor.Models;

namespace Tellarknight.Blazor.Services
{
    internal class CardSearcher
    {
        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) CardSearch(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            // SHS Search & Summon
            if ((hand.Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi") || hand.Any(x => x.Name == "Superheavy Samurai Motorbike"))
                && deck.Any(x => x.Name == "Superheavy Samurai Monk Big Benkei"))
            {
                (hand, deck, gy, normalSummoned, onField, scales) = SuperheavySamurai(hand, deck, gy, normalSummoned, onField, scales);
            }

            // Cynet Mining
            if (hand.Any(x => x.Name == "Cynet Mining") && deck.Any(x => x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                (hand, deck, gy, normalSummoned, onField, scales) = Mathmech(hand, deck, gy, normalSummoned, onField, scales);
            }

            // Add Small World
            // Automatically Adds +1 Lv4 & +1 HT
            // Does Calculation based on statistics to draw the bridge with lv4's and ht's in hand, if it will skip the search or not

            // Zefra Searchers
            if (hand.Any(x => x.Archetype.Contains("Zefra")))
            {
                string test = string.Join(", ", hand.Select(x => x.Name));

                if (hand.Any(x => x.Name == "Terraforming") && deck.Any(x => x.Name == "Oracle of Zefra"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, "Terraforming", "Oracle of Zefra");
                }
                if (hand.Any(x => x.Name.Contains("Reinforcement of the Army")))
                {
                    (hand, deck, gy, normalSummoned, onField, scales) = ZefraRota(hand, deck, gy, normalSummoned, onField, scales);
                }
                if (hand.Any(x => x.Name.Contains("Satellarknight Deneb")))
                {
                    (hand, deck, gy, normalSummoned, onField, scales) = ZefraDeneb(hand, deck, gy, normalSummoned, onField, scales);
                }
                if (hand.Any(x => x.Name.Contains("Zefra Providence")))
                {
                    (hand, deck, gy, normalSummoned, onField, scales) = ProvidenceSearch(hand, deck, gy, normalSummoned, onField, scales);
                }
                if (hand.Any(x => x.Name.Contains("Oracle of Zefra")))
                {
                    (hand, deck, gy, normalSummoned, onField, scales) = OracleSearch(hand, deck, gy, normalSummoned, onField, scales);
                }
            }

            // Rota Search (Standard)
            if (hand.Any(x => x.Name.Contains("Reinforcement of the Army")) && !hand.Any(x => x.Archetype.Contains("Zefra")))
            {
                (hand, deck, gy, normalSummoned, onField, scales) = StandardRota(hand, deck, gy, normalSummoned, onField, scales);
            }

            return (hand, deck, gy, normalSummoned, onField, scales);
        }

        public static (List<Card>, List<Card>, List<Card>) UpdateCards(List<Card> hand, List<Card> deck, List<Card> gy, string searchCard, string searchTarget)
        {
            var cardDeck = deck.First(x => x.Name == searchTarget);
            var cardHand = hand.First(x => x.Name == searchCard);

            deck.Remove(deck.First(x => x.Name == searchTarget));
            hand = hand.OrderByDescending(x => x.Name == searchCard).ToList();
            hand[0] = cardDeck;

            gy.Add(cardHand);

            return (hand, deck, gy);
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

        public static bool CheckSHS(List<Card> onField, List<Card> scales)
        {
            if (onField.Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi") 
                && onField.Any(x => x.Name == "Superheavy Samurai Soulgaia Booster")
                && scales.Any(x => x.Name == "Superheavy Samurai Monk Big Benkei"))
            {
                return true;
            }
            return false;
        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) SuperheavySamurai(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            // HAND: Motorbike -> Search Wakaushi
            if (hand.Any(x => x.Name == "Superheavy Samurai Motorbike") 
                && deck.Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, "Superheavy Samurai Motorbike", "Superheavy Samurai Prodigy Wakaushi");
            }

            // HAND: Wakaushi Summon & Benkei Scales
            if (hand.Any(x => x.Name == "Superheavy Samurai Prodigy Wakaushi")
                && deck.Any(x => x.Name == "Superheavy Samurai Monk Big Benkei"))
            {
                Card benkei = deck.First(x => x.Name == "Superheavy Samurai Monk Big Benkei");
                Card wakaushi = hand.First(x => x.Name == "Superheavy Samurai Prodigy Wakaushi");
                deck.Remove(deck.First(x => x.Name == "Superheavy Samurai Monk Big Benkei"));
                hand.Remove(hand.First(x => x.Name == "Superheavy Samurai Prodigy Wakaushi"));
                onField.Add(wakaushi);
                scales.Add(benkei);

                // Add booster from deck if one there exists, and then any boosters in hand summon to field (leaving any duplicates in hand)
                if (deck.Any(x => x.Name == "Superheavy Samurai Soulgaia Booster"))
                {
                    Card booster = deck.First(x => x.Name == "Superheavy Samurai Soulgaia Booster");
                    deck.Remove(deck.First(x => x.Name == "Superheavy Samurai Soulgaia Booster"));
                    onField.Add(booster);
                }
                if (hand.Any(x => x.Name == "Superheavy Samurai Soulgaia Booster"))
                {
                    Card booster = hand.First(x => x.Name == "Superheavy Samurai Soulgaia Booster");
                    hand.Remove(hand.First(x => x.Name == "Superheavy Samurai Soulgaia Booster"));
                    onField.Add(booster);
                }
            }

            return (hand, deck, gy, normalSummoned, onField, scales);
        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) Mathmech(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            if (deck.Any(x => x.Name == "Mathmech Circular") && deck.Any(x => x.Name != "Mathmech Circular" && x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, "Cynet Mining", "Mathmech Circular");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }
            if (hand.Any(x => x.Name == "Mathmech Equation") && deck.Any(x => x.Name == "Mathmech Nabla") && deck.Any(x => x.Name != "Mathmech Nabla" && x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, "Cynet Mining", "Mathmech Nabla");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }
            if (deck.Any(x => x.Archetype.Contains("Mathmech") && x.Level == 4))
            {
                string mathName = deck.First(x => x.Archetype.Contains("Mathmech") && x.Level == 4).Name;
                (hand, deck, gy) = UpdateCards(hand, deck, gy, "Cynet Mining", mathName);
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            return (hand, deck, gy, normalSummoned, onField, scales);
        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) ZefraRota(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            string searchCard = "Reinforcement of the Army";

            // ----- Zefra SHS -----

            // Zefrathuban Search
            if (CheckUniqueCards(hand, "Max", 1, "Oracle of Zefra", "Zefra Providence", "Zefraath")
                && !hand.Any(x => x.Name == "Satellarknight Deneb") && !hand.Any(x => x.Name == "Satellarknight Zefrathuban")
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // HAND: SHS & (Min x2 Unique Oracle/Prov/Zefraath In Hand, or Min x1 & Lv4 Zefra) ----- Search Tellarknight
            if (CheckSHS(onField, scales)
                && (CheckUniqueCards(hand, "Min", 2, "Oracle of Zefra", "Zefra Providence", "Zefraath")
                || (CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Zefra Providence", "Zefraath") && hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                if (!hand.Any(x => x.Name == "Tellarknight Lyran") && deck.Any(x => x.Name == "Tellarknight Lyran"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Tellarknight Lyran");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Unukalhai") && deck.Any(x => x.Name == "Satellarknight Unukalhai"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Unukalhai");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Deneb") && deck.Any(x => x.Name == "Satellarknight Deneb"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Deneb");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Tellarknight Altairan") && deck.Any(x => x.Name == "Tellarknight Altairan"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Tellarknight Altairan");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Zefrathuban") && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (deck.Any(x => x.Archetype == "Tellarknight" && x.Level == 4 && x.Type == "Warrior"))
                {
                    string tellarName = deck.First(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x.Type == "Warrior").Name;
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, tellarName);
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
            }

            // HAND: SHS & Min x1 Unique Oracle/Prov/Zefraath In Hand --- Search Zefrathuban
            if (CheckSHS(onField, scales) && CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Zefra Providence", "Zefraath")
                && !hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4)
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // ----- Zefra Normal -----

            // HAND: x2 Unique Zefraath/Oracle/Prov/Thuban In Hand, or None ----- Search Tellarknight
            if ((CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban")
                || !CheckUniqueCards(hand, "Min", 2, "Zefraath", "Oracle of Zefra", "Zefra Providence", "Satellarknight Zefrathuban"))
                && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                if (!hand.Any(x => x.Name == "Tellarknight Lyran") && deck.Any(x => x.Name == "Tellarknight Lyran"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Tellarknight Lyran");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Unukalhai") && deck.Any(x => x.Name == "Satellarknight Unukalhai"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Unukalhai");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Deneb") && deck.Any(x => x.Name == "Satellarknight Deneb"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Deneb");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Tellarknight Altairan") && deck.Any(x => x.Name == "Tellarknight Altairan"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Tellarknight Altairan");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Zefrathuban") && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (deck.Any(x => x.Archetype == "Tellarknight" && x.Level == 4 && x.Type == "Warrior"))
                {
                    string tellarName = deck.First(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x.Type == "Warrior").Name;
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, tellarName);
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
            }

            // HAND: Min x1 Unique Oracle/Prov/Zefraath In Hand --- Search Zefrathuban
            if (CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Zefra Providence", "Zefraath")
                && !hand.Any(x => x.Name == "Satellarknight Zefrathuban")
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // Backup Search
            if (hand.Any(x => x.Name.Contains("Reinforcement of the Army")))
            {
                //(hand, deck, gy, normalSummoned, onField, scales) = StandardRota(hand, deck, gy, normalSummoned, onField, scales);
            }

            return (hand, deck, gy, normalSummoned, onField, scales);
        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) ZefraDeneb(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            string searchCard = "Satellarknight Deneb";

            // Zefrathuban Search
            if (CheckUniqueCards(hand, "Max", 1, "Oracle of Zefra", "Zefra Providence", "Zefraath")
                && !hand.Any(x => x.Name == "Satellarknight Zefrathuban")
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
            {
                Card thuban = deck.First(x => x.Name == "Satellarknight Zefrathuban");
                Card deneb = hand.First(x => x.Name == "Satellarknight Deneb");
                deck.Remove(deck.First(x => x.Name == "Satellarknight Zefrathuban"));
                hand.Remove(hand.First(x => x.Name == "Satellarknight Deneb"));
                onField.Add(deneb);
                hand.Add(thuban);
                normalSummoned = true;

                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // Add Zefraxciton +2 Tellars/Zefra

            return (hand, deck, gy, normalSummoned, onField, scales);

        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) ProvidenceSearch(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            string searchCard = "Zefra Providence";
            
            // REMINDER: ADD TRAP SEARCH CONDITIONS LATER

            // Oracle Search
            if (!hand.Any(x => x.Name == "Oracle of Zefra")
                && deck.Any(x => x.Name == "Oracle of Zefra"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Oracle of Zefra");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // Zefraath Search
            if ((CheckSHS(onField, scales) 
                || CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Satellarknight Zefrathuban")
                || (CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Stellarknight Zefraxciton") && hand.Any(x => x.Level == 4)))
                && !hand.Any(x => x.Name == "Zefraath")
                && deck.Any(x => x.Name == "Zefraath"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Zefraath");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // Zefrathuban Search
            if (CheckUniqueCards(hand, "Min", 1, "Oracle of Zefra", "Zefraath")
                && !hand.Any(x => x.Name == "Satellarknight Zefrathuban")
                && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))

            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // Zefra "Other" Search
            if (deck.Any(x => x.Archetype.Contains("Zefra")))
            {
                if (!hand.Any(x => x.Name == "Satellarknight Zefrathuban") && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Stellarknight Zefraxciton") && deck.Any(x => x.Name == "Stellarknight Zefraxciton"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Stellarknight Zefraxciton");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Shaddoll Zefracore") && deck.Any(x => x.Name == "Shaddoll Zefracore"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Shaddoll Zefracore");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
            }

            return (hand, deck, gy, normalSummoned, onField, scales);
        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) OracleSearch(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            string searchCard = "Oracle of Zefra";

            // Zefraath Search
            if ((CheckSHS(onField, scales)
                || (hand.Any(x => x.Name == "Satellarknight Zefrathuban") || hand.Any(x => x.Name == "Satellarknight Deneb"))
                || (hand.Any(x => x.Name == "Stellarknight Zefraxciton") && hand.Any(x => x.Level == 4) && deck.Any(x => x.Name == "Satellarknight Zefrathuban")))
                && !hand.Any(x => x.Name == "Zefraath")
                && deck.Any(x => x.Name == "Zefraath"))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Zefraath");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // Zefra "Other" Search
            if (deck.Any(x => x.Archetype.Contains("Zefra")))
            {
                if (!hand.Any(x => x.Name == "Satellarknight Zefrathuban") && deck.Any(x => x.Name == "Satellarknight Zefrathuban"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Zefrathuban");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Stellarknight Zefraxciton") && deck.Any(x => x.Name == "Stellarknight Zefraxciton"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Stellarknight Zefraxciton");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Shaddoll Zefracore") && deck.Any(x => x.Name == "Shaddoll Zefracore"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Shaddoll Zefracore");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
            }

            return (hand, deck, gy, normalSummoned, onField, scales);
        }

        public static (List<Card>, List<Card>, List<Card>, bool, List<Card>, List<Card>) StandardRota(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummoned, List<Card> onField, List<Card> scales)
        {
            string searchCard = "Reinforcement of the Army";

            // Constellar Pollux
            if (deck.Any(x => x.Name == "Constellar Pollux") && hand.Any(x => x.Archetype.Contains("Tellarknight Lyran")
                && deck.Count(x => x.Archetype.Contains("Constellar") != x.Archetype.Contains("Tellarknight") && x.Level == 4) >= 4))
            {
                (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Constellar Pollux");
                return (hand, deck, gy, normalSummoned, onField, scales);
            }

            // HAND: No SHS, No Tellars, Lv4 In Hand ----- Search Extender
            if (!CheckSHS(onField, scales)
                && !hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4) && hand.Any(x => x.Level == 4)
                && deck.Any(x => x.Role.Contains("Extender") && x.Level == 4 && x.Type == "Warrior"))
            {
                if (!hand.Any(x => x.Name == "ZS - Ascended Sage") && deck.Any(x => x.Name == "ZS - Ascended Sage"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "ZS - Ascended Sage");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Photon Thrasher") && deck.Any(x => x.Name == "Photon Thrasher"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Photon Thrasher");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Fire Flint Lady") && deck.Any(x => x.Name == "Fire Flint Lady"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Fire Flint Lady");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Infernoble Knight - Renaud") && deck.Any(x => x.Name == "Infernoble Knight - Renaud"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Infernoble Knight - Renaud");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
            }

            // HAND: No Condition: Search Tellarknights
            if (deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
            {
                if (!hand.Any(x => x.Name == "Tellarknight Lyran") && deck.Any(x => x.Name == "Tellarknight Lyran"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Tellarknight Lyran");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Unukalhai") && deck.Any(x => x.Name == "Satellarknight Unukalhai"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Unukalhai");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Satellarknight Deneb") && deck.Any(x => x.Name == "Satellarknight Deneb"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Satellarknight Deneb");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (!hand.Any(x => x.Name == "Tellarknight Altairan") && deck.Any(x => x.Name == "Tellarknight Altairan"))
                {
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, "Tellarknight Altairan");
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }
                if (deck.Any(x => x.Archetype == "Tellarknight" && x.Level == 4 && x.Type == "Warrior"))
                {
                    string tellarName = deck.First(x => x.Archetype.Contains("Tellarknight") && x.Level == 4 && x.Type == "Warrior").Name;
                    (hand, deck, gy) = UpdateCards(hand, deck, gy, searchCard, tellarName);
                    return (hand, deck, gy, normalSummoned, onField, scales);
                }            
            }        

            return (hand, deck, gy, normalSummoned, onField, scales);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;

/*
 
 NOTES:
- Add pend stats for two tellars
- Add double zefraath to summon a tellar or zefraniu with lv4 in hand
- Add Skybridge/Lyran/Deneb activated effects instead of just normal summon, so card searcher can include those to grab a zefrathuban.
- Add zefra providence boolean
- Add stats for unuk that tags altair being unusable later

- Old Notes:
- "Add Skybridge Swap For Unuk/Lyran Stats" (found in the skybridge section)
- "Add stats for hands that can achieve both unuk effect and have the spell by the xyz, that covers when lyran cannot search cont spell"

 
 */




namespace TellarknightApp.Services
{
    internal class HandAnalyzer
    {
        public static DeckStatistics HandCheck(List<Card> hand, List<Card> deck, List<Card> gy, bool normalSummon, List<Card> onField, List<Card> scales, List<Card> extraDeck, DeckStatistics stats)
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
                if (hand.Any(x => x.Name == "Mathmech Circular") && CountCards(deck, "Mathmech Circular", 4, "Mathmech") >= 1 && CountCards(hand, 4, "Any") >= 2)
                {
                    localStats.AverageXyzNoTellar = true;
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                }
                if (hand.Any(x => x.Name == "Mathmech Circular") && hand.Any(x => x.Name == "Mathmech Equation") && CountCards(deck, "Mathmech Circular", 4, "Mathmech") >= 1)
                {
                    localStats.AverageXyzNoTellar = true;
                }
                if (hand.Any(x => x.Name == "Mathmech Nabla") && hand.Any(x => x.Name == "Mathmech Equation") && CountCards(deck, "Mathmech Nabla", 4, "Mathmech") >= 1)
                {
                    localStats.AverageXyzNoTellar = true;
                }
                if (hand.Any(x => x.Name == "Zoodiac Barrage") && deck.Any(x => x.Name == "Zoodiac Thoroughblade" && x.Level == 4)
                    && (CountCards(hand, 4, "Any") >= 1 || (hand.Any(x => x.Name == "The Phantom Knights of Shade Brigandine") || ((hand.Any(x => x.Archetype.Contains("Runick") && x.Type == "Spell") && extraDeck.Any(x => x.Name == "Geri the Runick Fangs"))))))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                }
                if (hand.Any(x => x.Name == "Madolche Petingcessoeur") && CountCards(hand, 4, "Any") >= 2)
                {
                    if (!hand.Any(x => x.Role.Contains("HandTrap")))
                    {
                        localStats.AverageXyzNoTellar = true;
                        if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                        {
                            localStats.AverageXyzWithTellar = true;
                        }
                    }
                    if (hand.Any(x => x.Role.Contains("HandTrap")))
                    {
                        Random random = new Random();
                        if (random.Next(2) == 0)
                        {
                            localStats.AverageXyzNoTellar = true;
                            if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                            {
                                localStats.AverageXyzWithTellar = true;
                            }
                        }
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
                if (hand.Any(x => x.Name == "The Phantom Knights of Shade Brigandine") && CountCards(hand, "The Phantom Knights of Shade Brigandine", 4, "Any") >= 1)
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
                        localStats.AverageXyzSpellOrAltairan = true;
                    }
                }
                if (hand.Any(x => x.Name == "Constellar Sheratan" && x.Level == 4) && CheckUniqueCards(hand, "Min", 1, "Sakitama", "ZS - Ascended Sage", "Photon Thrasher")
                    && (deck.Any(x => x.Name == "Constellar Caduceus") || deck.Any(x => x.Name == "Constellar Caduceus"))
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzWithTellar = true;
                }
                if (hand.Any(x => x.Name == "Aratama")
                    && (hand.Any(x => x.Name == "Sakitama") || deck.Any(x => x.Name == "Sakitama")))
                {
                    localStats.AverageXyzNoTellar = true;
                }
                if (hand.Any(x => x.Archetype.Contains("Runick") && x.Type == "Spell") && extraDeck.Any(x => x.Name == "Geri the Runick Fangs") 
                    && (CountCards(hand, 4, "Any") >= 1 || (hand.Any(x => x.Name == "The Phantom Knights of Shade Brigandine") || (hand.Any(x => x.Name == "Zoodiac Barrage") && deck.Any(x => x.Name == "Zoodiac Thoroughblade" && x.Level == 4)))))
                {
                    localStats.AverageXyzNoTellar = true;
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1)
                    {
                        localStats.AverageXyzWithTellar = true;
                    }
                }
                if (CheckUniqueCards(hand, "Min", 2, "Runick Tip", "Runick Freezing Curses", "Runick Destruction", "Runick Flashing Fire", "Runick Slumber")
                    && extraDeck.Count(x => x.Name == "Geri the Runick Fangs") >= 2)
                {
                    localStats.AverageXyzNoTellar = true;
                }
            }

            // Tellarknight/Constellars
            if (hand.Any(x => x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")))
            {                
                // Continuous Spell
                if (hand.Any(x => x.Name == "Constellar Tellarknights") && CountCards(hand, 4, "Tellarknight", "Constellar") >= 1 && CountCards(hand, 4, "Any") >= 2)
                {
                    localStats.AverageXyzWithTellar = true;
                    localStats.AverageXyzSpellOrAltairan = true;
                    if (hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                    {
                        localStats.AverageXyzSpellOrAltairan = true;
                    }
                    if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 2)
                    {
                        localStats.AverageXyzTwoTellars = true;
                    }
                }
                if (hand.Any(x => x.Name == "Constellar Tellarknights") && ((hand.Any(x => x.Name == "Satellarknight Deneb") 
                    && CountCards(hand, "Satellarknight Deneb", 4, "Tellarknight") >= 1) || (hand.Any(x => x.Name == "Satellarknight Unukalhai") && CountCards(hand, "Satellarknight Unukalhai", 4, "Tellarknight") >= 1)))
                {
                    localStats.AverageXyzTwoTellars = true;
                    localStats.AverageXyzSpellOrAltairan = true;
                }

                // Skybridge
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && (hand.Any(x => x.Name == "Satellarknight Deneb")))
                {
                    if (deck.Any(x => x.Name == "Satellarknight Vega") && CountCards(deck, "Satellarknight Deneb", "Satellarknight Vega", 4, "Tellarknight") >= 1)
                    {
                        localStats.AverageXyzTwoTellars = true;
                    }
                    if (deck.Any(x => x.Name == "Tellarknight Lyran") && CountCards(deck, "Satellarknight Deneb", 4, "Tellarknight") >= 1
                        && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                    {
                        localStats.AverageXyzTwoTellars = true;
                        localStats.AverageXyzSpellOrAltairan = true;
                    }
                }
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && hand.Any(x => x.Name == "Satellarknight Unukalhai") && CheckUniqueCards(deck, "Min", 1, "Satellarknight Altair", "Tellarknight Lyran"))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && hand.Any(x => x.Name == "Satellarknight Lyran") 
                    && ((deck.Any(x => x.Name == "Satellarknight Unukalhai") && CountCards(deck, "Satellarknight Unukalhai", 4, "Tellarknight") >= 1) 
                    || (deck.Any(x => x.Name == "Satellarknight Deneb") && CountCards(deck, "Satellarknight Deneb", 4, "Tellarknight") >= 1))
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && CountCards(hand, 4, "Tellarknight") >= 2
                    && ((deck.Any(x => x.Name == "Constellar Tellarknights") && deck.Any(x => x.Name == "Tellarknight Lyran")) || (deck.Any(x => x.Name == "Satellarknight Vega") && CountCards(hand, "Satellarknight Vega", 4, "Tellarknight") >= 1)))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Skybridge") && hand.Any(x => x.Name == "Constellar Tellarknights") && CountCards(hand, 4, "Tellarknight") >= 1)
                {
                    if ((hand.Any(x => x.Name == "Satellarknight Deneb" && CountCards(deck, "Satellarknight Deneb", 4, "Tellarknight") >= 1))
                        || (hand.Any(x => x.Name == "Satellarknight Unukalhai" && CountCards(deck, "Satellarknight Unukalhai", 4, "Tellarknight") >= 1)))
                    {
                        localStats.AverageXyzTwoTellars = true;
                    }
                }

                // Tellarknight/Constellar Monster Effects

                if (CountCards(hand, 4, "Tellarknight", "Constellar") >= 1 && hand.Any(x => x.Role.Contains("Extender") && x.Level == 4))
                {
                    localStats.AverageXyzWithTellar = true;
                }                
                if (hand.Any(x => x.Name == "Tellarknight Lyran") && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") >= 1)
                {
                    localStats.AverageXyzSpellOrAltairan = true;
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Where(x => x.Name == "Tellarknight Lyran").Count() >= 2
                    && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") == 0
                    && ((hand.Any(x => x.Name == "Satellarknight Skybridge" || x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Satellarknight Skybridge" || x.Name == "Constellar Tellarknights"))))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Vega") && CountCards(hand, "Satellarknight Vega", 4, "Tellarknight") >= 1)
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Caduceus") && CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Sheratan") && (CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1 || (CountCards(hand, 4, "Tellarknight", "Constellar") >= 2))
                    && (deck.Any(x => x.Name == "Constellar Caduceus") || deck.Any(x => x.Name == "Constellar Caduceus"))
                    && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
                {
                    localStats.AverageXyzWithTellar = true;
                }
                if (hand.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Living Fossil")
                    && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
                {
                    // Assuming altairan is sent, may need more specific dontiions in future
                    localStats.AverageXyzSpellOrAltairan = true;
                    localStats.AverageXyzTwoTellars = true;
                }

                // Constellar-Specific Monster Effects
                if (hand.Any(x => x.Name == "Constellar Pollux") && hand.Any(x => x.Archetype.Contains("Constellar") && x.Level == 4))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Algiedi") && hand.Any(x => x.Archetype.Contains("Constellar") && x.Level == 4))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
                if (hand.Any(x => x.Name == "Constellar Sheratan") 
                    && (deck.Any(x => x.Name == "Constellar Twinkle") || hand.Any(x => x.Name == "Constellar Twinkle"))
                    && (deck.Any(x => x.Name == "Constellar Caduceus" && x.Level == 4) || hand.Any(x => x.Name == "Constellar Caduceus")))
                {
                    localStats.AverageXyzTwoTellars = true;
                }
            }

            // Zefra Pendulumns (No SHS)         
            if (hand.Any(x => x.Archetype.Contains("Zefra")))
            {
                if (!CheckSHS(onField, scales) && hand.Any(x => x.Name == "Zefraath") && hand.Any(x => x.Name == "Satellarknight Zefrathuban"))
                {
                    AddScale(hand, scales, "Satellarknight Zefrathuban");
                    localStats.ZefraathAndThuban = true;

                    // Normal Summoned, Tellar/Zefra/Extender In Hand
                    if (normalSummon == true && (CountCards(hand, 4, "Tellarknight", "Zefra") >= 1 || hand.Any(x => x.Role.Contains("Extender"))))
                    {
                        localStats.AverageXyzWithTellar = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                        if (CountCards(hand, 4, "Tellarknight") >= 1)
                        {
                            localStats.AverageXyzTwoTellars = true;
                        }
                        if (hand.Any(x => x.Name == "Tellarknight Lyran") || hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                        {
                            localStats.AverageXyzTwoTellars = true;
                        }
                    }
                    // Normal Summoned, Lyran/Unuk In Hand
                    if (normalSummon == true && hand.Any(x => x.Name == "Tellarknight Lyran") || hand.Any(x => x.Name == "Satellarknight Unukalhai"))
                    {
                        localStats.AverageXyzSpellOrAltairan = true;
                        localStats.AverageXyzTwoTellars = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                    }
                    // Normal Summoned, Zefraniu In Hand
                    if (normalSummon == true && hand.Any(x => x.Name == "Zefraniu, Secret of the Yang Zing"))
                    {
                        localStats.AverageXyzWithTellar = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                    }

                    // Didn't Normal, Double Zefraath 
                    if (normalSummon == false && hand.Count(x => x.Name == "Zefraath") >= 2 && deck.Count(x => x.Archetype.Contains("Satellarknight Zefrathuban")) >= 1 && (hand.Any(x => x.Level == 4)))
                    {
                        localStats.AverageXyzWithTellar = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                    }

                    // Didn't Summoned, With Extender
                    if (hand.Any(x => x.Role.Contains("Extender")))
                    {
                        localStats.AverageXyzWithTellar = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                    }
                    // Didn't Normal, Deneb In Hand
                    if (normalSummon == false && hand.Any(x => x.Name == "Tellarknight Deneb") && CountCards(deck, 4, "Tellarknight") >= 1)
                    {
                        localStats.AverageXyzSpellOrAltairan = true;
                        normalSummon = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                        if (deck.Any(x => x.Name == "Satellarknight Unukalhai"))
                        {
                            localStats.AverageXyzSpellOrAltairan = true;
                        }                        
                    }
                    // Didn't Normal, Lyran In Hand (Search Skybridge, Summon Deneb)
                    if (normalSummon == false && hand.Any(x => x.Name == "Tellarknight Lyran") 
                        && deck.Any(x => x.Name == "Satellarknight Skybridge") 
                        && deck.Any(x => x.Name == "Satellarknight Deneb") 
                        && CountCards(deck, "Satellarknight Deneb", 4, "Tellarknight") >= 1)
                    {
                        localStats.AverageXyzTwoTellars = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                        if (deck.Any(x => x.Name == "Satellarknight Unukalhai"))
                        {
                            localStats.AverageXyzSpellOrAltairan = true;
                        }
                    }
                    // Didn't Normal, Tellar & Skybridge In Hand for Deneb
                    if (normalSummon == false && hand.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4)
                        && hand.Any(x => x.Name == "Satellarknight Skybridge") 
                        && deck.Any(x => x.Name == "Satellarknight Deneb") 
                        && CountCards(deck, "Satellarknight Deneb", 4, "Tellarknight") >= 1)
                    {
                        localStats.AverageXyzTwoTellars = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                        if (deck.Any(x => x.Name == "Satellarknight Unukalhai"))
                        {
                            localStats.AverageXyzSpellOrAltairan = true;
                        }
                    }

                    // Didn't Normal, Tellar & Any Lv4 In Hand
                    if (normalSummon == false 
                        && (CountCards(hand, 4, "Tellarknight", "Zefra") >= 1 && hand.Count(x => x.Level == 4) >= 2) 
                        || CountCards(hand, 4, "Tellarknight", "Zefra") >= 2)
                    {
                        normalSummon = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                        if (deck.Any(x => x.Archetype.Contains("Tellarknight")))
                        {
                            localStats.AverageXyzWithTellar = true;
                        }
                        if (deck.Any(x => x.Name == "Satellarknight Unukalhai" || x.Name == "Tellarknight Lyran"))
                        {
                            localStats.AverageXyzSpellOrAltairan = true;
                        }
                    }
                    // Didn't Normal, 2 Tellarknight And 1 Constellars
                    if (normalSummon == false 
                        && (CountCards(hand, 4, "Tellarknight", "Constellar") >= 2) && (CountCards(hand, 4, "Tellarknight") >= 1))
                    {
                        localStats.AverageXyzTwoTellars = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                    }

                    // Trap Counting Extenders
                    if (normalSummon == false
                        && (CountCards(hand, 4, "Tellarknight", "Zefra") >= 2)
                        || (CountCards(hand, 4, "Tellarknight", "Zefra") >= 1 && hand.Any(x => x.Role.Contains("Extender")))
                        || CheckUniqueCards(hand, "Min", 2, "Sakitama", "ZS - Ascended Sage", "Photon Thrasher", "The Phantom Knights of Shade Brigandine", "Madolche Petingcessoeur")
                        || (CheckUniqueCards(hand, "Min", 1, "Sakitama", "ZS - Ascended Sage", "Photon Thrasher", "The Phantom Knights of Shade Brigandine", "Madolche Petingcessoeur") && hand.Any(x => x.Name == "Zoodiac Barrage") && deck.Any(x => x.Name == "Zoodiac Thoroughblade" && x.Level == 4))
                        || (CountCards(hand, 4, "Tellarknight", "Zefra") >= 1 && hand.Any(x => x.Name == "Zoodiac Barrage") && deck.Any(x => x.Name == "Zoodiac Thoroughblade" && x.Level == 4)))
                    {
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                        if (CountCards(hand, 4, "Tellarknight") >= 1)
                        {
                            localStats.AverageXyzTwoTellars = true;
                        }
                    }
                    RemoveScale(hand, scales, "Satellarknight Zefrathuban");
                }



                // Zefra SHS
                if (CheckSHS(onField, scales) && hand.Any(x => x.Name == "Zefraath"))
                {
                    localStats.ZefraathAndSHS = true;
                    if (hand.Any(x => x.Archetype.Contains("Zefra") && x.Level == 4))
                    {
                        localStats.ZefraComboWithNormalAvailable = true;
                        if (hand.Any(x => x.Name == "Zefra Divine Strike") || deck.Any(x => x.Name == "Zefra Divine Strike"))
                        {
                            localStats.ZefraComboWithTrap = true;
                        }
                    }
                }
                if (CheckSHS(onField, scales) && hand.Any(x => x.Name == "Zefraath"))
                {
                    localStats.ZefraathAndSHS = true;
                }


            }

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
            stats.AverageTellars = stats.AverageTellars + hand.Count(x => (x.Archetype.Contains("Tellarknight") || x.Archetype.Contains("Constellar")) && x.Level == 4);

            stats = UpdateStats(localStats, stats);

            return stats;
        }

        public static (List<Card>, List<Card>) AddScale(List<Card> hand, List<Card> scales, string targetCard)
        {
            var cardHand = hand.First(x => x.Name == targetCard);

            hand.Remove(hand.First(x => x.Name == targetCard));
            scales.Add(cardHand);

            return (hand, scales);
        }

        public static (List<Card>, List<Card>) RemoveScale(List<Card> hand, List<Card> scales, string targetCard)
        {
            var cardHand = scales.First(x => x.Name == targetCard);

            scales.Remove(scales.First(x => x.Name == targetCard));
            hand.Add(cardHand);

            return (hand, scales);
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

        public class LocalStats
        {
            public bool BrickChance { get; set; } = false;
            public bool AverageTellars { get; set; } = false;
            public bool AverageExtenders { get; set; } = false;
            public bool AverageXyzNoTellar { get; set; } = false;
            public bool AverageXyzWithTellar { get; set; } = false;
            public bool AverageXyzSpellOrAltairan { get; set; } = false;
            public bool AverageXyzTwoTellars { get; set; } = false;
            public bool ZefraathAndSHS { get; set; } = false;
            public bool ZefraathAndThuban { get; set; } = false;
            public bool ZefraComboWithTrap { get; set; } = false;
            public bool ZefraComboWithNormalAvailable { get; set; } = false;
            public bool AverageHandTraps { get; set; } = false;
            public bool IsoldeBrick { get; set; } = false;
            public bool PendulumnSummon { get; set; } = false;
            public bool AverageXyzUnknown { get; set; } = false;

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

        public static int CountCards(List<Card> hand, string exclude1, string exclude2, int level)
        {
            var matchingCards = hand.Where(x => x.Level == level && x.Name != exclude1 && x.Name != exclude2);

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
        public static int CountCards(List<Card> hand, string exclude1, string exclude2, int level, string archetype1)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) && x.Level == level && x.Name != exclude1 && x.Name != exclude2));

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

        public static int CountCards(List<Card> hand, string exclude1, string exclude2, int level, string archetype1, string archetype2)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level && x.Name != exclude1 && x.Name != exclude2);

            return matchingCards.Count();
        }


        /*
        public static int CountCards(List<Card> hand, string archetype1, int level, params string[] exclusions)
        {
            var matchingCards = hand.Where(x => x.Level == level && x.Archetype.Contains(archetype1) && !exclusions.Contains(x.Name));

            return matchingCards.Count();
        }

        public static int CountCards(List<Card> hand, string archetype1, string archetype2, int level, params string[] exclusions)
        {
            var matchingCards = hand.Where(x => (x.Archetype.Contains(archetype1) || x.Archetype.Contains(archetype2)) && x.Level == level && !exclusions.Contains(x.Name));

            return matchingCards.Count();
        }
         */
    }
}

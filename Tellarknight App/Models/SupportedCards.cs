﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellarknight_App.Models
{
    internal class SupportedCards
    {
        public List<Card> Cards { get; set; }

        public SupportedCards()
        {
            Cards = new List<Card>()
            {
                new Card() { Name = "Satellarknight Deneb", Type = "Warrior", Level = 4, Archetype = "Tellarknight", Image = "./CardArt/Deneb.png", Role = "Search" },
                new Card() { Name = "Satellarknight Altair", Type = "Warrior", Level = 4, Archetype = "Tellarknight", Image = "./CardArt/Altair.png", Role = "" },
                new Card() { Name = "Satellarknight Vega", Type = "Warrior", Level = 4, Archetype = "Tellarknight", Image = "./CardArt/Vega.png", Role = "" },
                new Card() { Name = "Satellarknight Unukalhai", Type = "Warrior", Level = 4, Archetype = "Tellarknight", Image = "./CardArt/Unuk.png", Role = "Search" },
                new Card() { Name = "Satellarknight Sirius", Type = "Warrior", Level = 4, Archetype = "Tellarknight", Image = "./CardArt/Sirius.png", Role = "" },
                new Card() { Name = "Tellarknight Lyran", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Constellar", Image = "./CardArt/Lyran.png", Role = "Search" },
                new Card() { Name = "Tellarknight Altairan", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Constellar", Image = "./CardArt/Altairan.png", Role = "" },

                new Card() { Name = "Constellar Sheratan", Type = "Beast", Level = 3, Archetype = "Constellar", Image = "./CardArt/Sheratan.png", Role = "Search" },
                new Card() { Name = "Constellar Caduceus", Type = "Spellcaster", Level = 4, Archetype = "Constellar", Image = "./CardArt/Caduceus.png", Role = "Search" },

                new Card() { Name = "Satellarknight Skybridge", Type = "Spell", Level = null, Archetype = "Tellarknight", Image = "./CardArt/Skybridge.png", Role = "" },
                new Card() { Name = "Constellar Tellarknights", Type = "Spell", Level = null, Archetype = "Tellarknight/Constellar", Image = "./CardArt/ConstellarTellarknights.png", Role = "" },

                new Card() { Name = "Living Fossil", Type = "Spell", Level = null, Archetype = "", Image = "./CardArt/Fossil.png", Role = "" },
                new Card() { Name = "\"Infernoble Arms - Durendal\"", Type = "Spell", Level = null, Archetype = "", Image = "./CardArt/Durendal.png", Role = "Search" },
                new Card() { Name = "Infernoble Knight - Renaud", Type = "Warrior", Level = 1, Archetype = "", Image = "./CardArt/Renaud.png", Role = "Extender" },
                new Card() { Name = "Fire Flint Lady", Type = "Warrior", Level = 1, Archetype = "", Image = "./CardArt/FireFlint.png", Role = "Extender" },

                new Card() { Name = "Sakitama", Type = "Fairy", Level = 4, Archetype = "", Image = "./CardArt/Sakitama.png", Role = "Extender" },
                new Card() { Name = "ZS - Ascended Sage", Type = "Warrior", Level = 4, Archetype = "", Image = "./CardArt/AscendedSage.png", Role = "Extender" },
                new Card() { Name = "Photon Thrasher", Type = "Warrior", Level = 4, Archetype = "", Image = "./CardArt/Thrasher.png", Role = "Extender" },
                new Card() { Name = "Reinforcement of the Army", Type = "Spell", Level = null, Archetype = "", Image = "./CardArt/Rota.png", Role = "Search" },
                new Card() { Name = "Terraforming", Type = "Spell", Level = null, Archetype = "", Image = "./CardArt/Terraforming.png", Role = "Search" },

                new Card() { Name = "Oracle of Zefra", Type = "Spell", Level = null, Archetype = "Zefra", Image = "./CardArt/Oracle.png", Role = "" },
                new Card() { Name = "Zefra Providence", Type = "Spell", Level = null, Archetype = "Zefra", Image = "./CardArt/ZefraProvidence.png", Role = "" },
                new Card() { Name = "Zefraath", Type = "Monster", Level = 11, Archetype = "Zefra", Image = "./CardArt/Zefraath.png", Role = "" },
                new Card() { Name = "Satellarknight Zefrathuban", Type = "Monster", Level = 4, Archetype = "Zefra/Tellarknight", Image = "./CardArt/Zefrathuban.png", Role = "" },
                new Card() { Name = "Stellarknight Zefraxciton", Type = "Monster", Level = 4, Archetype = "Zefra/Tellarknight", Image = "./CardArt/Zefraxciton.png", Role = "" },
                new Card() { Name = "Shaddoll Zefracore", Type = "Monster", Level = 4, Archetype = "Zefra/Shaddoll", Image = "./CardArt/Zefracore.png", Role = "" },
                new Card() { Name = "Zefraniu, Secret of the Yang Zing", Type = "Monster", Level = 6, Archetype = "Zefra/Yang Zing", Image = "./CardArt/Zefraniu.png", Role = "" },
                new Card() { Name = "Zefra Divine Strike", Type = "Trap", Level = null, Archetype = "Zefra", Image = "./CardArt/DivineStrike.png", Role = "Omni" },

                new Card() { Name = "Superheavy Samurai Prodigy Wakaushi", Type = "Monster", Level = 4, Archetype = "SHS", Image = "./CardArt/Wakaushi.png", Role = "Extender" },
                new Card() { Name = "Superheavy Samurai Monk Big Benkei", Type = "Monster", Level = 8, Archetype = "SHS", Image = "./CardArt/Benkei.png", Role = "Extender" },
                new Card() { Name = "Superheavy Samurai Motorbike", Type = "Monster", Level = 2, Archetype = "SHS", Image = "./CardArt/Motorbike.png", Role = "Extender" },
                new Card() { Name = "Superheavy Samurai Soulgaia Booster", Type = "Monster", Level = 4, Archetype = "SHS", Image = "./CardArt/Booster.png", Role = "Extender" },

                new Card() { Name = "Level 4", Type = "", Level = 4, Archetype = "", Image = "./CardArt/CelticGuardian.png", Role = "" },
                new Card() { Name = "Hand Trap", Type = "", Level = null, Archetype = "", Image = "./CardArt/HandTrap.png", Role = "HandTrap" },
                new Card() { Name = "Empty Card", Type = "", Level = null, Archetype = "", Image = "./CardArt/CardBack.png", Role = "" },
                      
                //new Card() { Name = "The Phantom Knights of Shade Brigandine", Level = 4, Type = "Monster", Archetype = ("", ""), Image = "./CardArt/Brigandine.png", Role = "Extender" },
            };
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    internal class SupportedCards
    {
        public List<Card> Cards { get; set; }

        public SupportedCards()
        {
            Cards = new List<Card>()
            {
                new Card() { Name = "Satellarknight Deneb", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Any", Image = "./CardArt/Deneb.png", Role = "Search" },
                new Card() { Name = "Satellarknight Altair", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Any", Image = "./CardArt/Altair.png", Role = "None" },
                new Card() { Name = "Satellarknight Vega", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Any", Image = "./CardArt/Vega.png", Role = "None" },
                new Card() { Name = "Satellarknight Unukalhai", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Any", Image = "./CardArt/Unuk.png", Role = "Search" },
                new Card() { Name = "Satellarknight Sirius", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Any", Image = "./CardArt/Sirius.png", Role = "None" },
                new Card() { Name = "Tellarknight Lyran", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Constellar/Any", Image = "./CardArt/Lyran.png", Role = "Search" },
                new Card() { Name = "Tellarknight Altairan", Type = "Warrior", Level = 4, Archetype = "Tellarknight/Constellar/Any", Image = "./CardArt/Altairan.png", Role = "None" },
                new Card() { Name = "Constellar Sheratan", Type = "Beast", Level = 3, Archetype = "Constellar/Any", Image = "./CardArt/Sheratan.png", Role = "Search" },
                new Card() { Name = "Constellar Caduceus", Type = "Spellcaster", Level = 4, Archetype = "Constellar/Any", Image = "./CardArt/Caduceus.png", Role = "Search" },
                new Card() { Name = "Satellarknight Skybridge", Type = "Spell", Level = null, Archetype = "Tellarknight", Image = "./CardArt/Skybridge.png", Role = "None" },
                new Card() { Name = "Constellar Tellarknights", Type = "Spell", Level = null, Archetype = "Tellarknight/Constellar", Image = "./CardArt/ConstellarTellarknights.png", Role = "None" },

                new Card() { Name = "Living Fossil", Type = "Equip", Level = null, Archetype = "None", Image = "./CardArt/Fossil.png", Role = "None" },
                new Card() { Name = "\"Infernoble Arms - Durendal\"", Type = "Equip", Level = null, Archetype = "None", Image = "./CardArt/Durendal.png", Role = "Extender" },
                new Card() { Name = "Infernoble Knight - Renaud", Type = "Warrior", Level = 1, Archetype = "None/Any", Image = "./CardArt/Renaud.png", Role = "None" },
                new Card() { Name = "Fire Flint Lady", Type = "Warrior", Level = 1, Archetype = "None/Any", Image = "./CardArt/FireFlint.png", Role = "Extender" },
                
                new Card() { Name = "Constellar Pollux", Type = "Warrior", Level = 4, Archetype = "Constellar/Any", Image = "./CardArt/Pollux.png", Role = "None" },
                new Card() { Name = "Constellar Algiedi", Type = "Spellcaster", Level = 4, Archetype = "Constellar/Any", Image = "./CardArt/Algiedi.png", Role = "None" },
                new Card() { Name = "Constellar Sombre", Type = "Fairy", Level = 4, Archetype = "Constellar/Any", Image = "./CardArt/Sombre.png", Role = "None" },
                
                new Card() { Name = "Reinforcement of the Army", Type = "Spell", Level = null, Archetype = "None/Any", Image = "./CardArt/Rota.png", Role = "Search" },
                new Card() { Name = "Constellar Twinkle", Type = "Spell", Level = null, Archetype = "Constellar", Image = "./CardArt/Twinkle.png", Role = "None" },

                new Card() { Name = "The Phantom Knights of Shade Brigandine", Level = 4, Type = "Spell", Archetype = "None", Image = "./CardArt/Brigandine.png", Role = "Extender" },
                new Card() { Name = "Photon Thrasher", Type = "Warrior", Level = 4, Archetype = "None/Any", Image = "./CardArt/Thrasher.png", Role = "Extender" },
                new Card() { Name = "ZS - Ascended Sage", Type = "Warrior", Level = 4, Archetype = "None/Any", Image = "./CardArt/AscendedSage.png", Role = "Extender" },

                new Card() { Name = "Sakitama", Type = "Fairy", Level = 4, Archetype = "None/Any", Image = "./CardArt/Sakitama.png", Role = "Extender" },
                new Card() { Name = "Aratama", Type = "Fairy", Level = 4, Archetype = "None/Any", Image = "./CardArt/Aratama.png", Role = "Extender" },

                new Card() { Name = "Level 4", Type = "", Level = 4, Archetype = "None/Any", Image = "./CardArt/CelticGuardian.png", Role = "None" },
                new Card() { Name = "Empty Card", Type = "", Level = null, Archetype = "None", Image = "./CardArt/CardBack.png", Role = "None" },

                new Card() { Name = "Terraforming", Type = "Spell", Level = null, Archetype = "None/Any", Image = "./CardArt/Terraforming.png", Role = "Search" },
                new Card() { Name = "Oracle of Zefra", Type = "Spell", Level = null, Archetype = "Zefra", Image = "./CardArt/Oracle.png", Role = "None" },
                new Card() { Name = "Zefra Providence", Type = "Spell", Level = null, Archetype = "Zefra", Image = "./CardArt/ZefraProvidence.png", Role = "None" },
                new Card() { Name = "Zefraath", Type = "Monster", Level = 11, Archetype = "Zefra/Any", Image = "./CardArt/Zefraath.png", Role = "None" },
                new Card() { Name = "Satellarknight Zefrathuban", Type = "Monster", Level = 4, Archetype = "Zefra/Tellarknight/Any", Image = "./CardArt/Zefrathuban.png", Role = "None" },
                new Card() { Name = "Stellarknight Zefraxciton", Type = "Monster", Level = 4, Archetype = "Zefra/Tellarknight/Any", Image = "./CardArt/Zefraxciton.png", Role = "None" },
                new Card() { Name = "Shaddoll Zefracore", Type = "Monster", Level = 4, Archetype = "Zefra/Shaddoll/Any", Image = "./CardArt/Zefracore.png", Role = "None" },
                new Card() { Name = "Zefraniu, Secret of the Yang Zing", Type = "Monster", Level = 6, Archetype = "Zefra/Yang Zing/Any", Image = "./CardArt/Zefraniu.png", Role = "None" },
                new Card() { Name = "Zefra Divine Strike", Type = "Trap", Level = null, Archetype = "Zefra", Image = "./CardArt/DivineStrike.png", Role = "Omni" },
                
                new Card() { Name = "Superheavy Samurai Prodigy Wakaushi", Type = "Monster", Level = 4, Archetype = "SHS/Any", Image = "./CardArt/Wakaushi.png", Role = "Extender/Bridge" },
                new Card() { Name = "Superheavy Samurai Monk Big Benkei", Type = "Monster", Level = 8, Archetype = "SHS/Any", Image = "./CardArt/Benkei.png", Role = "Extender" },
                new Card() { Name = "Superheavy Samurai Motorbike", Type = "Monster", Level = 2, Archetype = "SHS/Any", Image = "./CardArt/Motorbike.png", Role = "Extender" },
                new Card() { Name = "Superheavy Samurai Soulgaia Booster", Type = "Monster", Level = 4, Archetype = "SHS/Any", Image = "./CardArt/Booster.png", Role = "Extender" },
                
                new Card() { Name = "Mathmech Circular", Type = "Cyberse", Level = 4, Archetype = "Mathmech/Any", Image = "./CardArt/Circular.png", Role = "Extender" },
                new Card() { Name = "Mathmech Nabla", Type = "Cyberse", Level = 4, Archetype = "Mathmech/Any", Image = "./CardArt/Nabla.png", Role = "Extender" },
                new Card() { Name = "Mathmech Diameter", Type = "Cyberse", Level = 4, Archetype = "Mathmech/Any", Image = "./CardArt/Diameter.png", Role = "None" },
                new Card() { Name = "Mathmech Equation", Type = "Spell", Level = null, Archetype = "Mathmech", Image = "./CardArt/Equation.png", Role = "None" },
                new Card() { Name = "Mathmech Superfactorial", Type = "Trap", Level = null, Archetype = "Mathmech", Image = "./CardArt/Superfactorial.png", Role = "None" },

                new Card() { Name = "Runick Tip", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickTip.png", Role = "Extender" },
                new Card() { Name = "Runick Freezing Curses", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickFreezingCurses.png", Role = "Extender" },
                new Card() { Name = "Runick Destruction", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickDestruction.png", Role = "Extender" },
                new Card() { Name = "Runick Flashing Fire", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickFlashingFire.png", Role = "Extender" },
                new Card() { Name = "Runick Slumber", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickSlumber.png", Role = "Extender" },
                
                new Card() { Name = "Runick Smiting Storm", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickSmitingStorm.png", Role = "Extender" },
                new Card() { Name = "Runick Dispelling", Type = "Spell", Level = null, Archetype = "Runick", Image = "./CardArt/RunickDispelling.png", Role = "Extender" },
                new Card() { Name = "Geri the Runick Fangs", Type = "Beast", Level = 4, Archetype = "Runick", Image = "./CardArt/Geri.png", Role = "ExtraDeck" },                

                new Card() { Name = "Cynet Mining", Type = "", Level = null, Archetype = "None", Image = "./CardArt/CynetMining.png", Role = "Search" },

                new Card() { Name = "Hand Trap", Type = "", Level = null, Archetype = "None", Image = "./CardArt/HandTrap.png", Role = "HandTrap" },
                new Card() { Name = "Infinite Impermanence", Type = "Trap", Level = null, Archetype = "None", Image = "./CardArt/Imperm.png", Role = "HandTrap" },
                new Card() { Name = "Ash Blossom & Joyous Spring", Type = "Zombie", Level = 3, Archetype = "None", Image = "./CardArt/Ash.png", Role = "HandTrap" },
                new Card() { Name = "Effect Veiler", Type = "Zombie", Level = 3, Archetype = "None", Image = "./CardArt/Veiler.png", Role = "HandTrap" },
                new Card() { Name = "Droll & Lock Bird", Type = "Spellcaster", Level = 1, Archetype = "None", Image = "./CardArt/Droll.png", Role = "HandTrap" },
                new Card() { Name = "Ghost Ogre & Snow Rabbit", Type = "Psychic", Level = 3, Archetype = "None", Image = "./CardArt/GhostOgre.png", Role = "HandTrap" },
                new Card() { Name = "Maxx \"C\"", Type = "Insect", Level = 2, Archetype = "None", Image = "./CardArt/MaxxC.png", Role = "HandTrap" },
                new Card() { Name = "Nibiru, the Primal Being", Type = "Rock", Level = 11, Archetype = "None", Image = "./CardArt/Nibiru.png", Role = "HandTrap" },
                new Card() { Name = "PSY-Framegear Gamma", Type = "Psychic", Level = 2, Archetype = "None", Image = "./CardArt/Gamma.png", Role = "HandTrap" },
                //new Card() { Name = "PSY-Frame Driver", Type = "Psychic", Level = 7, Archetype = "None", Image = "./CardArt/Driver.png", Role = "None" },
                new Card() { Name = "Small World", Level = null, Type = "Spell", Archetype = "None", Image = "./CardArt/SmallWorld.png", Role = "" },
                new Card() { Name = "Called by the Grave", Level = null, Type = "Spell", Archetype = "None", Image = "./CardArt/CalledBy.png", Role = "" },
                new Card() { Name = "Crossout Designator", Level = null, Type = "Spell", Archetype = "None", Image = "./CardArt/Crossout.png", Role = "" },
                new Card() { Name = "Zoodiac Barrage", Level = null, Type = "Spell", Archetype = "None", Image = "./CardArt/Barrage.png", Role = "Extender" },
                new Card() { Name = "Zoodiac Thoroughblade", Type = "Beast-Warrior", Level = 4, Archetype = "Zoodiac/Any", Image = "./CardArt/Thoroughblade.png", Role = "Extender" },
                new Card() { Name = "Madolche Petingcessoeur", Type = "Fairy", Level = 4, Archetype = "None/Any", Image = "./CardArt/Peting.png", Role = "Extender/Bridge" },
                new Card() { Name = "Amorphage Pride", Level = 4, Type = "Dragon", Archetype = "None", Image = "./CardArt/Pride.png", Role = "" },
                new Card() { Name = "Ignis Phoenix, the Dracoslayer", Level = 4, Type = "Warrior", Archetype = "Dracoslayer", Image = "./CardArt/Ignis.png", Role = "" },
                new Card() { Name = "Majesty Pegasus, the Dracoslayer", Level = 4, Type = "Spellcaster", Archetype = "Dracoslayer", Image = "./CardArt/Majesty.png", Role = "" },
                new Card() { Name = "Chaos Angel", Level = 10, Type = "Fiend", Archetype = "None", Image = "./CardArt/ChaosAngel.png", Role = "ExtraDeck" },
                new Card() { Name = "The Bystial Lubellion", Level = 8, Type = "Dragon", Archetype = "Bystial", Image = "./CardArt/Lubellion.png", Role = "" },
                new Card() { Name = "Bystial Magnamhut", Level = 6, Type = "Dragon", Archetype = "Bystial", Image = "./CardArt/Magnamhut.png", Role = "" },
                new Card() { Name = "Bystial Druiswurm", Level = 6, Type = "Dragon", Archetype = "Bystial", Image = "./CardArt/Druiswurm.png", Role = "" },
                new Card() { Name = "Bystial Baldrake", Level = 6, Type = "Dragon", Archetype = "Bystial", Image = "./CardArt/Baldrake.png", Role = "" },
                new Card() { Name = "Bystial Saronir", Level = 6, Type = "Dragon", Archetype = "Bystial", Image = "./CardArt/Saronir.png", Role = "" },


            };
        }
    }
}

﻿using TellarknightApp.Cards;

namespace TellarknightApp.Models
{
    public class SupportedCards
    {
        public List<Card> Cards { get; set; }

        public SupportedCards()
        {
            Cards = new List<Card>()
            {
                // Neutral Cards && Hand Traps
                new EmptyCard(), // Done
                new Level4(), // Done
                new SmallWorld(),
                new Terraforming(), // Done
                new ReinforcementOfTheArmy(), // Done

                // Tellarknights & Constellars
                new SatellarknightDeneb(),
                new SatellarknightAltair(), // Done
                new SatellarknightVega(), // Done
                new SatellarknightUnukalhai(), // Done
                new SatellarknightSirius(), // Done
                new TellarknightLyran(),
                new TellarknightAltairan(), // Done
                new SatellarknightSkybridge(),
                new ConstellarTellarknights(), //  Done
                new ConstellarCaduceus(), // Done
                new ConstellarSheratan(), // Done
                new ConstellarPollux(), // Done
                new ConstellarAlgiedi(), // Done
                new ConstellarSombre(), // Done
                new ConstellarTwinkle(), // Done

                // Extenders
                new ThePhantomKnightsOfShadeBrigandine(), // Done
                new PhotonThrasher(), // Done
                new ZSAscendedSage(), // Done
                new Sakitama(), // Done
                new Aratama(), // Done

                // Note: Zefra Pends (without zefraath) need more work and testing, paired with non-zefra scales too

                // Zefra
                new Zefraath(), // Done
                new SatellarknightZefrathuban(), // Done
                new StellarknightZefraxciton(),
                new ShaddollZefracore(),
                new ZefraniuSecretOfTheYangZing(), // Done
                new OracleOfZefra(), // Done
                new ZefraProvidence(), // Done
                new ZefraDivineStrike(),

                // Superheavy Samurai                
                new SuperheavySamuraiProdigyWakaushi(), // Done
                new SuperheavySamuraiMonkBigBenkei(), // Done
                new SuperheavySamuraiMotorbike(), // Done
                new SuperheavySamuraiSoulgaiaBooster(), // Done
            };
        }
    }
}

/*
 * new HandTrap(),
new InfiniteImpermanence(),
new AshBlossomJoyousSpring(),
new EffectVeiler(),
new DrollLockBird(),
new GhostOgreSnowRabbit(),
new MaxxC(),
new NibiruThePrimalBeing(),
new PSY-FramegearGamma(),
new PSY-FrameDriver(),
new CalledByTheGrave(),
new CrossoutDesignator(),

                new Terraforming(),
                new ReinforcementOfTheArmy(),




new LivingFossil(),
new InfernobleArmsDurendal(),
new InfernobleKnightRenaud(),
new FireFlintLady(),

new MathmechCircular(),
new MathmechNabla(),
new MathmechDiameter(),
new MathmechEquation(),
new MathmechSuperfactorial(),
new RunickTip(),
new RunickFreezingCurses(),
new RunickDestruction(),
new RunickFlashingFire(),
new RunickSlumber(),
new RunickSmitingStorm(),
new RunickDispelling(),
new GeriTheRunickFangs(),
new CynetMining(),



new ZoodiacBarrage(),
new ZoodiacThoroughblade(),
new MadolchePetingcessoeur(),
new AmorphagePride(),
new IgnisPhoenixTheDracoslayer(),
new MajestyPegasusTheDracoslayer(),
new ChaosAngel(),
new TheBystialLubellion(),
new BystialMagnamhut(),
new BystialDruiswurm(),
new BystialBaldrake(),
new BystialSaronir(),
*/

// ---------------------------------------------------

/* ORIGINAL FOR STAT REFERENCE

new Card() { Name = "Satellarknight Deneb", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Any", Image = "./CardArt/Deneb.png", Role = "Search" },
new Card() { Name = "Satellarknight Altair", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Any", Image = "./CardArt/Altair.png", Role = "None" },
new Card() { Name = "Satellarknight Vega", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Any", Image = "./CardArt/Vega.png", Role = "None" },
new Card() { Name = "Satellarknight Unukalhai", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Any", Image = "./CardArt/Unuk.png", Role = "Search" },
new Card() { Name = "Satellarknight Sirius", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Any", Image = "./CardArt/Sirius.png", Role = "None" },
new Card() { Name = "Tellarknight Lyran", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Constellar/Any", Image = "./CardArt/Lyran.png", Role = "Search" },
new Card() { Name = "Tellarknight Altairan", Type = "Warrior", Level = 4, Scale = null, Archetype = "Tellarknight/Constellar/Any", Image = "./CardArt/Altairan.png", Role = "None" },
new Card() { Name = "Constellar Sheratan", Type = "Beast", Level = 3, Scale = null, Archetype = "Constellar/Any", Image = "./CardArt/Sheratan.png", Role = "Search" },
new Card() { Name = "Constellar Caduceus", Type = "Spellcaster", Level = 4, Scale = null, Archetype = "Constellar/Any", Image = "./CardArt/Caduceus.png", Role = "Search" },
new Card() { Name = "Satellarknight Skybridge", Type = "Spell", Level = null, Scale = null, Archetype = "Tellarknight", Image = "./CardArt/Skybridge.png", Role = "None" },
new Card() { Name = "Constellar Tellarknights", Type = "Spell", Level = null, Scale = null, Archetype = "Tellarknight/Constellar", Image = "./CardArt/ConstellarTellarknights.png", Role = "None" },

new Card() { Name = "Living Fossil", Type = "Equip", Level = null, Scale = null, Archetype = "None", Image = "./CardArt/Fossil.png", Role = "None" },
new Card() { Name = "\"Infernoble Arms - Durendal\"", Type = "Equip", Level = null, Scale = null, Archetype = "None", Image = "./CardArt/Durendal.png", Role = "Extender" },
new Card() { Name = "Infernoble Knight - Renaud", Type = "Warrior", Level = 1, Scale = null, Archetype = "None/Any", Image = "./CardArt/Renaud.png", Role = "None" },
new Card() { Name = "Fire Flint Lady", Type = "Warrior", Level = 1, Scale = null, Archetype = "None/Any", Image = "./CardArt/FireFlint.png", Role = "Extender" },
                
new Card() { Name = "Constellar Pollux", Type = "Warrior", Level = 4, Scale = null, Archetype = "Constellar/Any", Image = "./CardArt/Pollux.png", Role = "None" },
new Card() { Name = "Constellar Algiedi", Type = "Spellcaster", Level = 4, Scale = null, Archetype = "Constellar/Any", Image = "./CardArt/Algiedi.png", Role = "None" },
new Card() { Name = "Constellar Sombre", Type = "Fairy", Level = 4, Scale = null, Archetype = "Constellar/Any", Image = "./CardArt/Sombre.png", Role = "None" },
                
new Card() { Name = "Reinforcement of the Army", Type = "Spell", Level = null, Scale = null, Archetype = "None/Any", Image = "./CardArt/Rota.png", Role = "Search" },
new Card() { Name = "Constellar Twinkle", Type = "Spell", Level = null, Scale = null, Archetype = "Constellar", Image = "./CardArt/Twinkle.png", Role = "None" },

new Card() { Name = "The Phantom Knights of Shade Brigandine", Level = 4, Type = "Spell", Scale = null, Archetype = "None", Image = "./CardArt/Brigandine.png", Role = "Extender" },
new Card() { Name = "Photon Thrasher", Type = "Warrior", Level = 4, Scale = null, Archetype = "None/Any", Image = "./CardArt/Thrasher.png", Role = "Extender" },
new Card() { Name = "ZS - Ascended Sage", Type = "Warrior", Level = 4, Scale = null, Archetype = "None/Any", Image = "./CardArt/AscendedSage.png", Role = "Extender" },

new Card() { Name = "Sakitama", Type = "Fairy", Level = 4, Scale = null, Archetype = "None/Any", Image = "./CardArt/Sakitama.png", Role = "Extender" },
new Card() { Name = "Aratama", Type = "Fairy", Level = 4, Scale = null, Archetype = "None/Any", Image = "./CardArt/Aratama.png", Role = "Extender" },

new Card() { Name = "Level 4", Type = "", Level = 4, Scale = null, Archetype = "None/Any", Image = "./CardArt/CelticGuardian.png", Role = "None" },
new Card() { Name = "Empty Card", Type = "", Level = null, Scale = null, Archetype = "None", Image = "./CardArt/CardBack.png", Role = "None" },

new Card() { Name = "Terraforming", Type = "Spell", Level = null, Scale = null, Archetype = "None/Any", Image = "./CardArt/Terraforming.png", Role = "Search" },
new Card() { Name = "Oracle of Zefra", Type = "Spell", Level = null, Scale = null, Archetype = "Zefra", Image = "./CardArt/Oracle.png", Role = "None" },
new Card() { Name = "Zefra Providence", Type = "Spell", Level = null, Scale = null, Archetype = "Zefra", Image = "./CardArt/ZefraProvidence.png", Role = "None" },
new Card() { Name = "Zefraath", Type = "Monster", Level = 11, Scale = 5, Archetype = "Zefra/Any", Image = "./CardArt/Zefraath.png", Role = "None" },
new Card() { Name = "Satellarknight Zefrathuban", Type = "Monster", Level = 4, Scale = 1, Archetype = "Zefra/Tellarknight/Any", Image = "./CardArt/Zefrathuban.png", Role = "None" },
new Card() { Name = "Stellarknight Zefraxciton", Type = "Monster", Level = 4, Scale = 7, Archetype = "Zefra/Tellarknight/Any", Image = "./CardArt/Zefraxciton.png", Role = "None" },
new Card() { Name = "Shaddoll Zefracore", Type = "Monster", Level = 4, Scale = 7, Archetype = "Zefra/Shaddoll/Any", Image = "./CardArt/Zefracore.png", Role = "None" },
new Card() { Name = "Zefraniu, Secret of the Yang Zing", Type = "Monster", Level = 6, Scale = 7, Archetype = "Zefra/Yang Zing/Any", Image = "./CardArt/Zefraniu.png", Role = "None" },
new Card() { Name = "Zefra Divine Strike", Type = "Trap", Level = null, Scale = null, Archetype = "Zefra", Image = "./CardArt/DivineStrike.png", Role = "Omni" },
                
new Card() { Name = "Superheavy Samurai Prodigy Wakaushi", Type = "Monster", Level = 4, Scale = 8, Archetype = "SHS/Any", Image = "./CardArt/Wakaushi.png", Role = "Extender/Bridge" },
new Card() { Name = "Superheavy Samurai Monk Big Benkei", Type = "Monster", Level = 8, Scale = 1, Archetype = "SHS/Any", Image = "./CardArt/Benkei.png", Role = "Extender" },
new Card() { Name = "Superheavy Samurai Motorbike", Type = "Monster", Level = 2, Scale = null, Archetype = "SHS/Any", Image = "./CardArt/Motorbike.png", Role = "Extender" },
new Card() { Name = "Superheavy Samurai Soulgaia Booster", Type = "Monster", Level = 4, Scale = null, Archetype = "SHS/Any", Image = "./CardArt/Booster.png", Role = "Extender" },
                
new Card() { Name = "Mathmech Circular", Type = "Cyberse", Level = 4, Scale = null, Archetype = "Mathmech/Any", Image = "./CardArt/Circular.png", Role = "Extender" },
new Card() { Name = "Mathmech Nabla", Type = "Cyberse", Level = 4, Scale = null, Archetype = "Mathmech/Any", Image = "./CardArt/Nabla.png", Role = "Extender" },
new Card() { Name = "Mathmech Diameter", Type = "Cyberse", Level = 4, Scale = null, Archetype = "Mathmech/Any", Image = "./CardArt/Diameter.png", Role = "None" },
new Card() { Name = "Mathmech Equation", Type = "Spell", Level = null, Scale = null, Archetype = "Mathmech", Image = "./CardArt/Equation.png", Role = "None" },
new Card() { Name = "Mathmech Superfactorial", Type = "Trap", Level = null, Scale = null, Archetype = "Mathmech", Image = "./CardArt/Superfactorial.png", Role = "None" },

new Card() { Name = "Runick Tip", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickTip.png", Role = "Extender" },
new Card() { Name = "Runick Freezing Curses", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickFreezingCurses.png", Role = "Extender" },
new Card() { Name = "Runick Destruction", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickDestruction.png", Role = "Extender" },
new Card() { Name = "Runick Flashing Fire", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickFlashingFire.png", Role = "Extender" },
new Card() { Name = "Runick Slumber", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickSlumber.png", Role = "Extender" },
                
new Card() { Name = "Runick Smiting Storm", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickSmitingStorm.png", Role = "Extender" },
new Card() { Name = "Runick Dispelling", Type = "Spell", Level = null, Scale = null, Archetype = "Runick", Image = "./CardArt/RunickDispelling.png", Role = "Extender" },
new Card() { Name = "Geri the Runick Fangs", Type = "Beast", Level = 4, Scale = null, Archetype = "Runick", Image = "./CardArt/Geri.png", Role = "ExtraDeck" },                

new Card() { Name = "Cynet Mining", Type = "", Level = null, Scale = null, Archetype = "None", Image = "./CardArt/CynetMining.png", Role = "Search" },

new Card() { Name = "Hand Trap", Type = "", Level = null, Scale = null, Archetype = "None", Image = "./CardArt/HandTrap.png", Role = "HandTrap" },
new Card() { Name = "Infinite Impermanence", Type = "Trap", Level = null, Scale = null, Archetype = "None", Image = "./CardArt/Imperm.png", Role = "HandTrap" },
new Card() { Name = "Ash Blossom & Joyous Spring", Type = "Zombie", Level = 3, Scale = null, Archetype = "None", Image = "./CardArt/Ash.png", Role = "HandTrap" },
new Card() { Name = "Effect Veiler", Type = "Zombie", Level = 3, Scale = null, Archetype = "None", Image = "./CardArt/Veiler.png", Role = "HandTrap" },
new Card() { Name = "Droll & Lock Bird", Type = "Spellcaster", Level = 1, Scale = null, Archetype = "None", Image = "./CardArt/Droll.png", Role = "HandTrap" },
new Card() { Name = "Ghost Ogre & Snow Rabbit", Type = "Psychic", Level = 3, Scale = null, Archetype = "None", Image = "./CardArt/GhostOgre.png", Role = "HandTrap" },
new Card() { Name = "Maxx \"C\"", Type = "Insect", Level = 2, Scale = null, Archetype = "None", Image = "./CardArt/MaxxC.png", Role = "HandTrap" },
new Card() { Name = "Nibiru, the Primal Being", Type = "Rock", Level = 11, Scale = null, Archetype = "None", Image = "./CardArt/Nibiru.png", Role = "HandTrap" },
new Card() { Name = "PSY-Framegear Gamma", Type = "Psychic", Level = 2, Scale = null, Archetype = "None", Image = "./CardArt/Gamma.png", Role = "HandTrap" },
                //new Card() { Name = "PSY-Frame Driver", Type = "Psychic", Level = 7, Scale = null, Archetype = "None", Image = "./CardArt/Driver.png", Role = "None" },
new Card() { Name = "Small World", Level = null, Type = "Spell", Scale = null, Archetype = "None", Image = "./CardArt/SmallWorld.png", Role = "" },
new Card() { Name = "Called by the Grave", Level = null, Type = "Spell", Scale = null, Archetype = "None", Image = "./CardArt/CalledBy.png", Role = "" },
new Card() { Name = "Crossout Designator", Level = null, Type = "Spell", Scale = null, Archetype = "None", Image = "./CardArt/Crossout.png", Role = "" },
new Card() { Name = "Zoodiac Barrage", Level = null, Type = "Spell", Scale = null, Archetype = "None", Image = "./CardArt/Barrage.png", Role = "Extender" },
new Card() { Name = "Zoodiac Thoroughblade", Type = "Beast-Warrior", Level = 4, Scale = null, Archetype = "Zoodiac/Any", Image = "./CardArt/Thoroughblade.png", Role = "Extender" },
new Card() { Name = "Madolche Petingcessoeur", Type = "Fairy", Level = 4, Scale = null, Archetype = "None/Any", Image = "./CardArt/Peting.png", Role = "Extender/Bridge" },
new Card() { Name = "Amorphage Pride", Level = 4, Type = "Dragon", Scale = 3, Archetype = "None", Image = "./CardArt/Pride.png", Role = "" },
new Card() { Name = "Ignis Phoenix, the Dracoslayer", Level = 4, Type = "Warrior", Scale = 7, Archetype = "Dracoslayer", Image = "./CardArt/Ignis.png", Role = "" },
new Card() { Name = "Majesty Pegasus, the Dracoslayer", Level = 4, Type = "Spellcaster", Scale = 2, Archetype = "Dracoslayer", Image = "./CardArt/Majesty.png", Role = "" },
new Card() { Name = "Chaos Angel", Level = 10, Type = "Fiend", Scale = null, Archetype = "None", Image = "./CardArt/ChaosAngel.png", Role = "ExtraDeck" },
new Card() { Name = "The Bystial Lubellion", Level = 8, Type = "Dragon", Scale = null, Archetype = "Bystial", Image = "./CardArt/Lubellion.png", Role = "" },
new Card() { Name = "Bystial Magnamhut", Level = 6, Type = "Dragon", Scale = null, Archetype = "Bystial", Image = "./CardArt/Magnamhut.png", Role = "" },
new Card() { Name = "Bystial Druiswurm", Level = 6, Type = "Dragon", Scale = null, Archetype = "Bystial", Image = "./CardArt/Druiswurm.png", Role = "" },
new Card() { Name = "Bystial Baldrake", Level = 6, Type = "Dragon", Scale = null, Archetype = "Bystial", Image = "./CardArt/Baldrake.png", Role = "" },
new Card() { Name = "Bystial Saronir", Level = 6, Type = "Dragon", Scale = null, Archetype = "Bystial", Image = "./CardArt/Saronir.png", Role = "" },

 
 
 
 
 
 
 
 
 
 
 
 public class TemporaryStuff
{
    public void Temp()
    {
        if (hand.Any(x => x.Name == "Tellarknight Lyran") && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") >= 1)
        {
            localStats.AverageXyzSpellOrAltairan = true;
            localStats.AverageXyzTwoTellar = true;
        }
        if (hand.Where(x => x.Name == "Tellarknight Lyran").Count() >= 2
            && CountCards(hand, "Tellarknight Lyran", 4, "Tellarknight", "Constellar") == 0
            && ((hand.Any(x => x.Name == "Satellarknight Skybridge" || x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Satellarknight Skybridge" || x.Name == "Constellar Tellarknights"))))
        {
            localStats.AverageXyzTwoTellar = true;
        }
        if (hand.Any(x => x.Name == "Satellarknight Vega") && CountCards(hand, "Satellarknight Vega", 4, "Tellarknight") >= 1)
        {
            localStats.AverageXyzTwoTellar = true;
        }
        if (hand.Any(x => x.Name == "Constellar Caduceus") && CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1
            && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
        {
            localStats.AverageXyzTwoTellar = true;
        }
        if (hand.Any(x => x.Name == "Constellar Sheratan") && (CountCards(hand, "Constellar Caduceus", 4, "Tellarknight", "Constellar") >= 1 || (CountCards(hand, 4, "Tellarknight", "Constellar") >= 2))
            && (deck.Any(x => x.Name == "Constellar Caduceus") || deck.Any(x => x.Name == "Constellar Caduceus"))
            && (hand.Any(x => x.Name == "Constellar Tellarknights") || deck.Any(x => x.Name == "Constellar Tellarknights")))
        {
            localStats.AverageXyzOneTellar = true;
        }
        if (hand.Any(x => x.Name == "Satellarknight Unukalhai") && hand.Any(x => x.Name == "Living Fossil")
            && deck.Any(x => x.Archetype.Contains("Tellarknight") && x.Level == 4))
        {
            // Assuming altairan is sent, may need more specific dontiions in future
            localStats.AverageXyzSpellOrAltairan = true;
            localStats.AverageXyzTwoTellar = true;
        }

        // Constellar-Specific Monster Effects
        if (hand.Any(x => (x.Name == "Constellar Pollux" || x.Name == "Constellar Algiedi")) && hand.Count(x => x.Archetype.Contains("Constellar") && x.Level == 4) >= 2)
        {
            localStats.AverageXyzTwoTellar = true;
        }
        if (hand.Any(x => x.Name == "Constellar Sheratan")
            && (deck.Any(x => x.Name == "Constellar Twinkle") || hand.Any(x => x.Name == "Constellar Twinkle"))
            && (deck.Any(x => x.Name == "Constellar Caduceus" && x.Level == 4) || hand.Any(x => x.Name == "Constellar Caduceus")))
        {
            localStats.AverageXyzTwoTellar = true;
        }
    }
}
 
 
 */
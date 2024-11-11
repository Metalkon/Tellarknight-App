using TellarknightApp.Cards;

namespace TellarknightApp.Models
{
    public class SupportedCards
    {
        public event Action? Action;
        public List<Card> Cards { get; set; }

        public SupportedCards()
        {
            InitializeCards();
        }

        // Resets the Cards list
        public async Task RefreshUpdate()
        {
            Cards.Clear();
            InitializeCards();
            Action?.Invoke();
        }

        private void InitializeCards()
        {
            Cards = new List<Card>
            {
                new EmptyCard(),
                new Level4(),
                new SmallWorld(), // Incomplete
                new Terraforming(),
                new ReinforcementOfTheArmy(),
                new SeventhAscension(),
                new SeventhTachyon(),
                new Number104Masquerade(),

                new SatellarknightDeneb(),
                new SatellarknightAltair(),
                new SatellarknightVega(),
                new SatellarknightUnukalhai(),
                new SatellarknightSirius(),
                new TellarknightLyran(),
                new TellarknightAltairan(),
                new SatellarknightAlsahm(),
                new SatellarknightBetelgeuse(),
                new SatellarknightCapella(),
                new SatellarknightProcyon(),
                new SatellarknightRigel(),
                new TellarknightGenesis(),
                new SatellarknightSkybridge(),
                new ConstellarTellarknights(),
                new ConstellarCaduceus(),
                new ConstellarSheratan(),
                new ConstellarPollux(),
                new ConstellarAlgiedi(),
                new ConstellarKaus(),
                new ConstellarSombre(),
                new ConstellarTwinkle(),

                new PhotonThrasher(),
                new ZSAscendedSage(),
                new ZSArmedSage(),
                new Sakitama(),
                new Aratama(),
                new TenyiSpiritNahata(),
                new TenyiSpiritMapura(),
                new TenyiSpiritShthana(),
                new VanquishSoulPantera(),
                new AbyssActorCurtainRaiser(),
                new ThePhantomKnightsOfShadeBrigandine(),

                new Zefraath(),
                new SatellarknightZefrathuban(),
                new StellarknightZefraxciton(), 
                new ShaddollZefracore(),
                new ZefraniuSecretOfTheYangZing(),
                new OracleOfZefra(),
                new ZefraProvidence(),
                new ZefraDivineStrike(),

                new SuperheavySamuraiProdigyWakaushi(),
                new SuperheavySamuraiMonkBigBenkei(),
                new SuperheavySamuraiMotorbike(),
                new SuperheavySamuraiSoulgaiaBooster(),

                new CenturIonPrimera(),
                new CenturIonTrudea(),
                new CenturIonAtrii(),
                new CenturIonChimerea(),
                new CenturIonGargoyleII(),
                new CenturIonEmethVI(),
                new StandUpCenturIon(),
                new EmblemaOath(),
                new CenturIonBonds(),
                new CenturIonTrueAwakening(),

                new MathmechCircular(),
                new MathmechNabla(),
                new MathmechDiameter(),
                new MathmechEquation(),
                new CynetMining(),
                new MathmechSuperfactorial(),

                new GeriTheRunickFangs(),
                new RunickTip(),
                new RunickFreezingCurses(),
                new RunickDestruction(),
                new RunickFlashingFire(),
                new RunickSlumber(),
                new RunickSmitingStorm(),
                new RunickDispelling(),
                new RunickGoldenDroplet(),
                new RunickAllure(),
                new RunickFountain(),

                new ZoodiacThoroughblade(),
                new ZoodiacRatpier(),
                new ZoodiacBarrage(),

                new MadolcheMagileine(),
                new MadolchePetingcessoeur(),

                new MonsterReborn(),
                new SpellCardMonsterReborn(),
                new ArmoredXyz(),
                new FullArmoredXyz(),

                new CalledByTheGrave(),
                new CrossoutDesignator(),
                
                new ArtifactScythe(),
                new ArtifactMjollnir(),
                
                new TherionKingRegulus(),
                new TherionDiscolosseum(),
                new SecretVillageOfTheSpellcasters(),
                new IgnisPhoenixTheDracoslayer(),
                new MajestyPegasusTheDracoslayer(),
                new AmorphagePride(),

                new InfernobleKnightRenaud(),
                new FireFlintLady(),
                new LivingFossil(),
                new InfernobleArmsDurendal(),
                
                new TheBystialLubellion(),
                new BystialBaldrake(),
                new BystialDruiswurm(),
                new BystialMagnamhut(),
                new BystialSaronir(),
                new AshBlossomJoyousSpring(),
                new GhostOgreSnowRabbit(),
                new GhostBelleHauntedMansion(),
                new GhostMournerMoonlitChill(),
                new GhostReaperWinterCherries(),
                new GhostSisterSpookyDogwood(),
                new EffectVeiler(),
                new DrollLockBird(),
                new NibiruThePrimalBeing(),
                new MulcharmyFuwalos(),
                new MulcharmyPurulia(),
                new MulcharmyNyalus(),
                new MaxxC(),
                new DDCrow(),
                new DimensionShifter(),
                new PSYFramegearGamma(),
                new PSYFrameDriver(),
                new SkullMeister(),
                new InfiniteImpermanence(),
                new RedReboot(),
            };
        }
    }
}

/*


add cards:
kashtira
ryzeal
melodious

Bonfire
Agnimal Candle
*/
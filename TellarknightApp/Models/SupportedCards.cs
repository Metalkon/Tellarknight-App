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
                new Terraforming(), // Fix condition not counting lack of oracle and add field spell to all roles
                new ReinforcementOfTheArmy(),

                new SatellarknightDeneb(), // Pend Search
                new SatellarknightAltair(),
                new SatellarknightVega(),
                new SatellarknightUnukalhai(),
                new SatellarknightSirius(),
                new TellarknightLyran(), // Pend Search
                new TellarknightAltairan(),
                new SatellarknightAlsahm(),
                new SatellarknightBetelgeuse(),
                new SatellarknightCapella(),
                new SatellarknightProcyon(),
                new SatellarknightRigel(),
                new TellarknightGenesis(),
                new SatellarknightSkybridge(), // Incomplete
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
                new ThePhantomKnightsOfShadeBrigandine(),

                new Zefraath(),
                new SatellarknightZefrathuban(),
                new StellarknightZefraxciton(), // Pend Summon
                new ShaddollZefracore(), // Pend Summon
                new ZefraniuSecretOfTheYangZing(), // Pend Summon
                new OracleOfZefra(),
                new ZefraProvidence(),
                new ZefraDivineStrike(),

                new SuperheavySamuraiProdigyWakaushi(),
                new SuperheavySamuraiMonkBigBenkei(),
                new SuperheavySamuraiMotorbike(), // Add Conditional Search, Maybe Change It's Level During Search?
                new SuperheavySamuraiSoulgaiaBooster(),

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

                new TherionKingRegulus(),
                new TherionDiscolosseum(),
                new SecretVillageOfTheSpellcasters(),
                new IgnisPhoenixTheDracoslayer(),
                new MajestyPegasusTheDracoslayer(),

                new InfernobleKnightRenaud(),
                new FireFlintLady(),
                new LivingFossil(), // Add Nabla
                new InfernobleArmsDurendal(), // Turn Into Searcher

                new CalledByTheGrave(),
                new CrossoutDesignator(),

                new AshBlossomJoyousSpring(),
                new GhostOgreSnowRabbit(),
                new GhostBelleHauntedMansion(),
                new GhostMournerMoonlitChill(),
                new GhostReaperWinterCherries(),
                new GhostSisterSpookyDogwood(),
                new MulcharmyFuwalos(),
                new MulcharmyPurulia(),
                new MulcharmyNyalus(),
                new SkullMeister(),
                new DDCrow(),
                new DimensionShifter(),
                new EffectVeiler(),
                new DrollLockBird(),
                new MaxxC(),
                new NibiruThePrimalBeing(),
                new PSYFramegearGamma(),
                new PSYFrameDriver(),
                new InfiniteImpermanence(),
                new RedReboot(),
                new BystialBaldrake(),
                new BystialDruiswurm(),
                new BystialMagnamhut(),
                new BystialSaronir()
            };
        }
    }
}

/*


add cards:
monster reborn (Both kind)
kashtira
centur-ion
ryzeal
melodious
7th tachyon & ed slot
7th ascension (searches tachyon)
artifact scy/mjol
armored



new AmorphagePride(),
new ChaosAngel(),
new TheBystialLubellion(),
*/
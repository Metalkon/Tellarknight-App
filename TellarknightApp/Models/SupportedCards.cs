using Microsoft.Maui.Controls;
using Microsoft.Maui.Primitives;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices.JavaScript;
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

                new ThePhantomKnightsOfShadeBrigandine(),
                new PhotonThrasher(),
                new ZSAscendedSage(),
                new ZSArmedSage(),
                new Sakitama(),
                new Aratama(),
                new TenyiSpiritNahata(),
                new TenyiSpiritMapura(),
                new TenyiSpiritShthana(),
                new VanquishSoulPantera(),

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
                new SuperheavySamuraiMotorbike(),
                new SuperheavySamuraiSoulgaiaBooster(),

                new InfiniteImpermanence(),
                new RedReboot(),
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
                new BystialBaldrake(),
                new BystialDruiswurm(),
                new BystialMagnamhut(),
                new BystialSaronir()
            };
        }
    }
}

/*
new CalledByTheGrave(),
new CrossoutDesignator(),

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
*/
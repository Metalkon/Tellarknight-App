using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TellarknightApp.Components.Pages;
using TellarknightApp.Models;

namespace TellarknightApp.Services
{
    public class StatisticsManager
    {
        private readonly GameState _gameState;

        public event Action? ActionRefresh;
        public StatValues StatValues { get; set; }
        public DisplayValues DisplayValues { get; set; }
        public List<DisplayValues> DisplayValuesVariance { get; set; }
        public DeckStatistics DeckStatistics { get; set; }
        public DeckStatistics DeckStatisticsHand { get; set; }
        public StatisticsManager(GameState gameState)
        {
            _gameState = gameState;

            StatValues = new StatValues();
            DisplayValues = new DisplayValues();
            DisplayValuesVariance = new List<DisplayValues>();
            DeckStatistics = new DeckStatistics();
            DeckStatisticsHand = new DeckStatistics();
        }

        // Clears the statistics
        public void RefreshStatistics()
        {
            DeckStatistics = new DeckStatistics();
            DeckStatisticsHand = new DeckStatistics();
            DisplayValuesVariance = new List<DisplayValues>();
            StatValues.CurrentCount = 0;
            ActionRefresh?.Invoke();
        }

        public async Task CheckDeck(List<Card> mainDeck, List<Card> extraDeck)
        {
            StatValues.Active = true;
            StatValues.Idle = false;

            StatValues.MaximumCount = (StatValues.MaximumCount > 100000) ? 100000 : (StatValues.MaximumCount < 5000 ? 5000 : StatValues.MaximumCount);
            StatValues.StartingHand = (StatValues.StartingHand < 1) ? 1 : (StatValues.StartingHand > 6 ? 6 : StatValues.StartingHand);

            RefreshStatistics();

            int uiInterval = StatValues.MaximumCount / 50;
            int nextUiCheckpoint = uiInterval;

            int recordInterval = CalculateRecordInterval(StatValues.MaximumCount);
            int nextRecordCheckpoint = recordInterval;

            for (int i = 0; i < StatValues.MaximumCount; i++)
            {
                StatValues.CurrentCount++;
                StatValues.ProgressCount++;

                _gameState.RefreshGameState(mainDeck, extraDeck);
                _gameState.ShuffleDeck();
                _gameState.DrawHand(StatValues.StartingHand);

                CardSearcher.CardSearch(_gameState);
                HandAnalyzer.HandCheck(_gameState, DeckStatistics);

                if (StatValues.CurrentCount == nextUiCheckpoint)
                {
                    DisplayValues = UpdateValues(mainDeck, extraDeck);
                    nextUiCheckpoint += uiInterval;
                    ActionRefresh?.Invoke();
                    await Task.Yield();
                }

                if (StatValues.CurrentCount == nextRecordCheckpoint)
                {
                    DisplayValuesVariance.Add(UpdateValues(mainDeck, extraDeck));
                    nextRecordCheckpoint += recordInterval;
                }
            }

            ActionRefresh?.Invoke();
            await Task.Delay(500);
            StatValues.ProgressCount = 0;
            StatValues.Active = false;
        }

        private static int CalculateRecordInterval(int maximumCount)
        {
            // Linearly scale target checkpoints: 20 at MaximumCount=5,000 up to 50 at MaximumCount=100,000
            const int minCount = 5000;
            const int maxCount = 100000;
            const int minCheckpoints = 20;
            const int maxCheckpoints = 50;

            double t = Math.Clamp((maximumCount - minCount) / (double)(maxCount - minCount), 0, 1);
            int targetCheckpoints = minCheckpoints + (int)Math.Round(t * (maxCheckpoints - minCheckpoints));

            int rawInterval = Math.Max(1000, maximumCount / targetCheckpoints);

            // Snap to a clean step: multiples of 500 under 5000, multiples of 1000 at/above
            int step = rawInterval < 5000 ? 500 : 1000;
            int interval = (int)Math.Round(rawInterval / (double)step) * step;

            return Math.Max(1000, interval);
        }

        public async Task<GameState> CheckHand(List<Card> mainDeck, List<Card> extraDeck, GameState tempGameState)
        {
            StatValues.StartingHand = (StatValues.StartingHand < 1) ? 1 : (StatValues.StartingHand > 6 ? 6 : StatValues.StartingHand);

            RefreshStatistics();

            tempGameState.RefreshGameState(mainDeck, extraDeck);
            tempGameState.ShuffleDeck();
            tempGameState.DrawHand(StatValues.StartingHand);

            CardSearcher.CardSearch(tempGameState);
            HandAnalyzer.HandCheck(tempGameState, DeckStatisticsHand);

            StatValues.HandTest.Clear();

            foreach (Card card in tempGameState.Hand)
                StatValues.HandTest.Add(card);

            StatValues.HandTested = true;
            ActionRefresh?.Invoke();

            return tempGameState;
        }

        public DisplayValues UpdateValues(List<Card> mainDeck, List<Card> extraDeck)
        {
            var display = new DisplayValues();

            display.Count = StatValues.CurrentCount;
            display.DeckSize = mainDeck.Count();
            display.TotalMonsters = mainDeck.Count(x => x.Level != null);

            display.BrickChance = Math.Round((DeckStatistics.BrickChance / StatValues.CurrentCount) * 100, 2);
            display.ComboChance = Math.Round(100 - display.BrickChance, 2);
            display.BrickRate = Math.Round(StatValues.CurrentCount / (double)DeckStatistics.BrickChance, 2);

            display.XyzSummonZero = Math.Round((DeckStatistics.AverageXyzNoTellar / StatValues.CurrentCount) * 100, 2);
            display.XyzSummonOne = Math.Round((DeckStatistics.AverageXyzOneTellar / StatValues.CurrentCount) * 100, 2);
            display.XyzSummonTwo = Math.Round((DeckStatistics.AverageXyzTwoTellar / StatValues.CurrentCount) * 100, 2);
            display.PendulumnChance = Math.Round((DeckStatistics.PendulumSummon / StatValues.CurrentCount) * 100, 2);
            display.OracleChance = Math.Round((DeckStatistics.OracleCombo / StatValues.CurrentCount) * 100, 2);

            display.AverageHandTellars = Math.Round(DeckStatistics.AverageTellars / StatValues.CurrentCount, 2);
            display.AverageHandExtenders = Math.Round(DeckStatistics.AverageExtenders / StatValues.CurrentCount, 2);
            display.AverageHandHT = Math.Round(DeckStatistics.AverageHandTraps / StatValues.CurrentCount, 2);

            display.RyzealLockChance = Math.Round((DeckStatistics.RyzealLock / StatValues.CurrentCount) * 100, 2);

            return display;
        }

        public List<StatValues> ReturnDisplayValues(string propertyName)
        {
            var property = DisplayValues.GetType().GetProperty(propertyName);

            if (property?.GetValue(this) is List<StatValues> values)
            {
                return values;
            }

            return new List<StatValues>();
        }
    }
}

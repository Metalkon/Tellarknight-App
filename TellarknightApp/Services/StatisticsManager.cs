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
        public DeckStatistics DeckStatistics { get; set; }
        public DeckStatistics DeckStatisticsHand { get; set; }
        public List<DeckStatistics> DeckStatisticsRecord { get; set; }

        public StatisticsManager(GameState gameState)
        {
            _gameState = gameState;

            StatValues = new StatValues();
            DisplayValues = new DisplayValues();
            DeckStatistics = new DeckStatistics();
            DeckStatisticsHand = new DeckStatistics();
            DeckStatisticsRecord = new List<DeckStatistics>();
        }

        // Clears the statistics
        public void RefreshStatistics()
        {
            DeckStatistics = new DeckStatistics();
            DeckStatisticsHand = new DeckStatistics();
            DeckStatisticsRecord = new List<DeckStatistics>();
            StatValues.CurrentCount = 0;
            ActionRefresh?.Invoke();
        }

        public async Task CheckDeck(List<Card> mainDeck, List<Card> extraDeck)
        {
            StatValues.Active = true;
            StatValues.Idle = false;

            StatValues.MaximumCount = (StatValues.MaximumCount > 10000) ? 10000 : (StatValues.MaximumCount < 1000 ? 1000 : StatValues.MaximumCount);
            StatValues.StartingHand = (StatValues.StartingHand < 1) ? 1 : (StatValues.StartingHand > 6 ? 6 : StatValues.StartingHand);

            RefreshStatistics();


            int interval = StatValues.MaximumCount / 20;
            int nextCheckpoint = interval * 5;

            for (int i = 0; i < StatValues.MaximumCount; i++) 
            {
                StatValues.CurrentCount++;
                _gameState.RefreshGameState(mainDeck, extraDeck);
                _gameState.ShuffleDeck();
                _gameState.DrawHand(StatValues.StartingHand);

                // Check Hand & Deck For Optimal Searches
                CardSearcher.CardSearch(_gameState);

                // Analyze Hand & Update Hand Statistics
                HandAnalyzer.HandCheck(_gameState, DeckStatistics);

                if (StatValues.CurrentCount == nextCheckpoint)
                {
                    DeckStatisticsRecord.Add(DeckStatistics.Clone());
                    UpdateValues(mainDeck, extraDeck);
                    nextCheckpoint += interval;
                    ActionRefresh?.Invoke();
                    await Task.Yield(); // Releases the thread so Blazor can re-render
                }
            }

            ActionRefresh?.Invoke();
            StatValues.Active = false;
        }

        public void CheckHand(List<Card> mainDeck, List<Card> extraDeck)
        {
            // will finish this method later 
            StatValues.Active = true;

            StatValues.StartingHand = (StatValues.StartingHand < 1) ? 1 : (StatValues.StartingHand > 6 ? 6 : StatValues.StartingHand);

            RefreshStatistics();
            _gameState.RefreshGameState(mainDeck, extraDeck);



            StatValues.Active = false;
        }

        public void UpdateValues(List<Card> mainDeck, List<Card> extraDeck)
        {
            DisplayValues.DeckSize = mainDeck.Count();
            DisplayValues.TotalMonsters = mainDeck.Count(x => x.Level != null);

            DisplayValues.BrickChance.Value = Math.Round((DeckStatistics.BrickChance / StatValues.CurrentCount) * 100, 2);
            DisplayValues.ComboChance.Value = Math.Round(100 - DisplayValues.BrickChance.Value, 2);
            DisplayValues.BrickRate.Value = Math.Round(StatValues.CurrentCount / (double)DeckStatistics.BrickChance, 2);


            DisplayValues.XyzSummonZero.Value = Math.Round((DeckStatistics.AverageXyzNoTellar / StatValues.CurrentCount) * 100, 2);
            DisplayValues.XyzSummonOne.Value = Math.Round((DeckStatistics.AverageXyzOneTellar / StatValues.CurrentCount) * 100, 2);
            DisplayValues.XyzSummonTwo.Value = Math.Round((DeckStatistics.AverageXyzTwoTellar / StatValues.CurrentCount) * 100, 2);
            DisplayValues.PendulumnChance.Value = Math.Round((DeckStatistics.PendulumSummon / StatValues.CurrentCount) * 100, 2);
            DisplayValues.OracleChance.Value = Math.Round((DeckStatistics.OracleCombo / StatValues.CurrentCount) * 100, 2);

            DisplayValues.AverageHandTellars.Value = Math.Round(DeckStatistics.AverageTellars / StatValues.CurrentCount, 2);
            DisplayValues.AverageHandExtenders.Value = Math.Round(DeckStatistics.AverageExtenders / StatValues.CurrentCount, 2);
            DisplayValues.AverageHandHT.Value = Math.Round(DeckStatistics.AverageHandTraps / StatValues.CurrentCount, 2);

            DisplayValues.IsoldeBrickChance.Value = Math.Round((DeckStatistics.IsoldeBrick / StatValues.CurrentCount) * 100, 2);
            DisplayValues.ArmoredBrickChance.Value = Math.Round((DeckStatistics.ArmoredBrick / StatValues.CurrentCount) * 100, 2);
            DisplayValues.RyzealLockChance.Value = Math.Round((DeckStatistics.RyzealLock / StatValues.CurrentCount) * 100, 2);



        }
    }
}

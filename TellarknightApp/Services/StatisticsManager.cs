using System;
using System.Collections.Generic;
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
        public DeckStatistics DeckStatistics { get; set; }
        public DeckStatistics DeckStatisticsHand { get; set; }
        public List<DeckStatistics> DeckStatisticsRecord { get; set; }

        public StatisticsManager(GameState gameState)
        {
            _gameState = gameState;

            StatValues = new StatValues();
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

                // Visual updates (old)
                StatValues.CurrentCount++;

                if (StatValues.CurrentCount == nextCheckpoint)
                {
                    DeckStatisticsRecord.Add(DeckStatistics.Clone());
                    nextCheckpoint += interval;
                    ActionRefresh?.Invoke();
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
    }
}

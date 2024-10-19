using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TellarknightApp.Models;
using TellarknightApp.Cards;

namespace TellarknightApp.Services
{
    internal class CardSearcher
    {
        public static GameState CardSearch(GameState gameState)
        {
            // Terraforming
            if (gameState.Hand.FirstOrDefault(x => x is Terraforming) is Terraforming terra)
            {
                (gameState.Hand, gameState.Deck, gameState.Gy) = terra.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                gameState = DisableSearchers(gameState, terra);
            }

            // Rota
            if (gameState.Hand.FirstOrDefault(x => x is ReinforcementOfTheArmy) is ReinforcementOfTheArmy rota)
            {
                (gameState.Hand, gameState.Deck, gameState.Gy) = rota.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                gameState = DisableSearchers(gameState, rota);
            }
            
            // Providence
            if (gameState.Hand.FirstOrDefault(x => x is ZefraProvidence) is ZefraProvidence prov)
            {
                (gameState.Hand, gameState.Deck, gameState.Gy) = prov.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                gameState = DisableSearchers(gameState, prov);
            }
            
            // Oracle
            if (gameState.Hand.FirstOrDefault(x => x is OracleOfZefra) is OracleOfZefra oracle)
            {
                (gameState.Hand, gameState.Deck, gameState.Gy) = oracle.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                gameState = DisableSearchers(gameState, oracle);
            }

            // Small World
            if (gameState.Hand.FirstOrDefault(x => x is SmallWorld) is SmallWorld smallWorld)
            {
                (gameState.Hand, gameState.Deck, gameState.Gy) = smallWorld.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                gameState = DisableSearchers(gameState, smallWorld);
            }

            // Loop All Other Searchers (Note: May Need Tweeks Later)
            foreach (Card card in gameState.Hand)
            {
                if (card.Searcher && card.Enabled)
                {
                    (gameState.Hand, gameState.Deck, gameState.Gy) = card.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                    gameState = DisableSearchers(gameState, card);
                }
            }            

            // Send Any Disabled Cards To Gy
            var removeCards = gameState.Hand.Where(card => !card.Enabled).ToList();

            foreach (var card in removeCards)
            {
                gameState.Gy.Add(card);
            }

            gameState.Hand.RemoveAll(card => removeCards.Contains(card));

            return gameState;
        }

        public static GameState DisableSearchers(GameState gameState, Card inputCard)
        {
            var target = inputCard.GetType();
            foreach (Card card in gameState.Hand)
            {
                if (card.GetType() == target)
                {
                    card.Enabled = false;
                }
            }

            return gameState;
        }
    }
}

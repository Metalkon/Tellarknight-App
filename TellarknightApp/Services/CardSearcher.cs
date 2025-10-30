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
            List<Card> searchers = new List<Card>();

            // Find Search Cards
            foreach (var card in gameState.Hand)
            {
                if (card.Searcher && searchers.Any(x => x.GetType() == card.GetType()) == false)
                {
                    searchers.Add(card);
                }
            }

            // Priority Search Order
            var searcherTypes = new List<Type>
            {
                typeof(Terraforming),
                typeof(StellarnovaBonds),
                typeof(SeventhAscension),
                typeof(SeventhTachyon),
                typeof(ReinforcementOfTheArmy),
                typeof(SmallWorld),
                typeof(ZefraProvidence),
                typeof(OracleOfZefra),
            };

            foreach (var searcherType in searcherTypes)
            {
                if (gameState.Hand.FirstOrDefault(x => x.GetType() == searcherType) is Card foundCard)
                {
                    (gameState, searchers) = HandleSearch(gameState, searchers, foundCard);
                    searchers.RemoveAll(x => x.GetType() == foundCard.GetType());
                }
            }

            // SearchDeck Method
            foreach (var card in searchers)
            {
                (gameState, searchers) = HandleSearch(gameState, searchers, card);
            }

            return gameState;
        }

        public static (GameState, List<Card>) HandleSearch(GameState gameState, List<Card> searchers, Card card)
        {
            bool searched = true;
            (gameState.Hand, gameState.Deck, gameState.ExtraDeck, gameState.Gy, searched) = card.SearchDeck(gameState.Hand, gameState.Deck, gameState.ExtraDeck, gameState.Gy, searched);
            if (searched == true)
            {
                gameState.Gy.Add(card);
                gameState.Hand.Remove(card);
            }
            return (gameState, searchers);
        }
    }
}

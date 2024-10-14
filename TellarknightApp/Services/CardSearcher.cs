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
            // Small World (First Priority)
            if (gameState.Hand.FirstOrDefault(x => x is SmallWorld) is SmallWorld smallWorld)
            {
                (gameState.Hand, gameState.Deck, gameState.Gy) = smallWorld.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);

                smallWorld.Enabled = false;
                gameState.Gy.Add(smallWorld);
                gameState.Hand.Remove(smallWorld);
            }

            // Loop through each card in the hand (Note: May Need Tweeks Later)
            foreach (Card card in gameState.Hand)
            {
                if (card.Searcher && card.Enabled)
                {
                    (gameState.Hand, gameState.Deck, gameState.Gy) = card.SearchDeck(gameState.Hand, gameState.Deck, gameState.Gy);
                    var currentBaseClass = card.GetType().BaseType;
                    foreach (Card Card in gameState.Hand)
                    {
                        if (card.GetType().BaseType == currentBaseClass)
                        {
                            card.Enabled = false; 
                        }
                    }
                }
            }

            // Send Any Disabled Cards To Gy
            var removeCards = gameState.Hand.Where(card => !card.Enabled).ToList();  

            foreach (var card in removeCards)
            {
                gameState.Gy.Add(card);
                gameState.Hand.Remove(card);
            }

            return gameState;
        }
    }
}

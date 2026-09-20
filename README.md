# Tellarknight App

This is a Windows and Android application built for the Tellarknight community for the Yu-Gi-Oh! Card Game. It's used for creating Tellarknight decklists and testing their consistency rates and other statistics to optimize the deckbuilding experience.

[Download The Latest Release Version](https://github.com/Metalkon/Tellarknight-App/releases)

## Features
- Deck statistics that calculate the chances of summoning a Rank 4 monster, primarily Tellarknight Constellar Caduceus and Tellarknight Constellar Delteros.
- Deckbuilding with nearly 200 cards that are most commonly used with the Tellarknight archetype.
- Individual hand tests to see the brick rate and your drawn hands.
- A card browser to filter and find the cards you want to work with.
- The ability to import and export your decklist as a YDK file to be used with other Yu-Gi-Oh! services and clients.

-----

## Simplified App Overview:

### Main
- The user imports their deck or builds one from the selection of cards provided.
- When the user presses the "Check Deck" button on the Statistics page, it starts a loop that runs the deck through thousands of individual test hands, cloning the built decklist into a fresh GameState (containing the hand, deck, extra deck, and graveyard) for each run so nothing carries over between them.
- Each loop passes the GameState into the Card Searcher, which checks for "searcher" cards in your hand and runs through several hand and deck checks to see if you have certain card combinations and available search targets before deciding which card to search for and add to GameState.Hand from GameState.Deck.
- The loop then passes the GameState into the Hand Analyzer, which calls each card's own AnalyzeHand method to check for certain card combinations and sets the corresponding GameState.LocalStats boolean values to true.
- At the end of the Hand Analyzer, those booleans are converted into integers and added to the DeckStatistics object, which does not reset while going through the loops and is used for calculating the statistics shown in the app.
- After the loop has run several thousand times, the user is given the full statistics of their deck, such as brick rate and combo chance, along with other helpful statistics.

### Important Files
- [Statistics Manager](TellarknightApp/Services/StatisticsManager.cs) - Handles all of the statistics code in the app.
- [Card Manager](TellarknightApp/Services/CardManager.cs) - Handles the state of the created deck, ydk imports/exports, and the card search/filter tool used to browse the card list.
- [Hand Analyzer](TellarknightApp/Services/HandAnalyzer.cs) - Checks the drawn hand for card combinations and updates the deck's statistics.
- [Card Searcher](TellarknightApp/Services/CardSearcher.cs) - Checks the drawn hand for searcher effects and moves the searched card from the deck to the hand.
- [Game State](TellarknightApp/Services/GameState.cs) - Holds the hand, deck, extra deck, and graveyard for a single loop, and handles shuffling and drawing.
- [Supported Cards](TellarknightApp/Services/SupportedCards.cs) - Holds the master list of cards supported by the app.
- [Card Class](TellarknightApp/Models/Card.cs) / [Card Example #1](TellarknightApp/Cards/Tellars/ConstellarCastor.cs) / [Card Example #2](TellarknightApp/Cards/Tellars/TellarknightCygnian.cs) / [Card Example #3 (Searcher)](TellarknightApp/Cards/Other/ReinforcementOfTheArmy.cs)

![Example Image](tellar_app_windows.PNG)

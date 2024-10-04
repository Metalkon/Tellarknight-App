# Tellarknight App
This is a personal project intended to be shared with a small archetype community for the Yu-Gi-Oh Card Game, the project is used for creating Tellarknight Decklists and testing their consistency rates and other statistics.

#### NOTE: This project is currently in the early process of being rebuilt and updated with new content, the original running app can be downloaded below.

-----

## Simplified App Overview:

### Main
- User selects cards for their deck.
- The app then starts a loop that uses the card selection to build a Decklist object, which is then cloned to a fresh GameState object which contains the hand/deck/extradeck/etc.
- The loop inputs the GameState into a Card Searcher service which checks for search cards in your hand and then goes through several hand/deck checks to see if you have certain card combinations and available search targets before deciding on the card to be searched.
- The loop then inputs the GameState into a Hand Analyzer service that runs an override method within each card in your hand which checks for certain card combinations in your hand to set GameState.LocalStat boolean values to true.
- At the end of the Hand Analyzer, all of the booleans are converted into integers to be added to a DeckStatistics object which is not reset during each loop.
- After the loop has been done at least a few thousand times, the user is given the full statistics of their deck such as brick rate and combo chance, as well as some other helpful statistics.

#### Original App Release (Picture Below):
- https://github.com/Metalkon/Tellarknight-App/releases/tag/v0.1.0beta

![Example Image](tellar_app_window.PNG)

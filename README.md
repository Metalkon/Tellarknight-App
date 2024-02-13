# Tellarknight App
This is a personal project intended to be shared with a small community for the Yu-Gi-Oh Card Game, the original project in the solution is created with .NET MAUI (.NET8) and the current beta release is running on Winforms with Blazor WebAssembly due to some issues with MAUI.

The project is used for creating Tellarknight Decklists and testing their consistency and statistics.

-----

Simplified App Overview:

Main
- User selects cards for their deck.
- The app then starts a loop that uses the card selection to build a deck object, which is then shuffled, and separated into hand and deck lists (along with a few empty lists/variables).
- The loop inputs the hand/deck/etc into a Card Searcher which checks for searchers in your hand and then goes through several hand/deck checks to see if you have certain card combinations and available search targets before deciding on the card to be searched.
- The loop then inputs the hand/deck/etc into a Hand Analyzer that checks for certain cards in your hand and then checks the rest of the hand and deck/field/etc for other cards and sets boolean values to true.
- At the end of the Hand Analyzer, all of the booleans are converted into int's to be added to a Statistics object which is not reset during each loop.
- After the loop has been done at least a few thousand times, the user is given the full statistics of their deck such as brick rate and combo chance, as well as some other statistics.

The app is heavy on cpu load and uses a lot of if statements in it's services due to a lot of custom checks that requires game knowledge for combo's.

Beta Release:
- https://github.com/Metalkon/Tellarknight-App/releases/tag/v0.1.0beta

![Example Image](tellar_app_window.PNG)

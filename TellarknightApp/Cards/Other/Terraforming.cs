﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Terraforming : Card
    {
        public Terraforming() 
        {
            Name = "Reinforcement of the Army";
            Type = "Spell";
            Attribute = string.Empty;
            Level = null;
            Attack = null;
            Defense = null;
            Scale = null;
            Role = string.Empty;
            Searcher = true;
            Archetype = new List<string> { "None" };
            Id = 73628505;
            Image = $"./CardArt/{Id}.jpg";
        }

        public override (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck, List<Card> gy, bool searched)
        {
            // Oracle
            if (hand.Count(x => x is OracleOfZefra) == 0 && deck.Any(x => x is OracleOfZefra))
            {
                Card searchedCard = deck.First(x => x is OracleOfZefra);
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            // Add any priority cards in the future

            // Other Field Spells
            if (deck.Any(x => x is not OracleOfZefra && x.Type == "Field Spell"))
            {
                Card searchedCard = deck.First(x => x is not OracleOfZefra && x.Type == "Field Spell");
                hand.Add(searchedCard);
                deck.Remove(searchedCard);
                return (hand, deck, extraDeck, gy, searched);
            }

            return (hand, deck, extraDeck, gy, searched = false);
        }
    }
}
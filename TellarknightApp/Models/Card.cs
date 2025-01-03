﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TellarknightApp.Models
{
    public class Card
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Attribute { get; set; }
        public int? Level { get; set; }
        public int? Attack { get; set; }
        public int? Defense { get; set; }
        public int? Scale { get; set; } 
        public List<string>? Archetype { get; set; }
        public string? Role { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public bool Analyzed { get; set; }
        public bool Enabled { get; set; }
        public bool Searcher { get; set; }
        public int Id { get; set; }

        public Card()
        {
            Name = string.Empty;
            Type = string.Empty;
            Attribute = string.Empty;
            Archetype = new List<string> { "None" };
            Role = string.Empty;
            Quantity = 0;
            Analyzed = false;
            Enabled = true;
            Searcher = false;
            Id = 0;
            Image = $"./CardArt/EmptyCard.jpg";
        }

        public virtual LocalStats AnalyzeHand(LocalStats localStats, List<Card> hand, List<Card> deck, List<Card> gy, List<Card> extraDeck)
        {
            return localStats;
        }

        public virtual (List<Card>, List<Card>, List<Card>, List<Card>, bool) SearchDeck(List<Card> hand, List<Card> deck, List<Card> extraDeck,  List<Card> gy, bool searched)
        {
            return (hand, deck, extraDeck, gy, searched = false);
        }

        public virtual Card Clone()
        {
            return (Card)Activator.CreateInstance(this.GetType());
        }

        public (List<Card>, List<Card>, List<Card>) SearchSwap(List<Card> hand, List<Card> deck, List<Card> gy, Card card)
        {
            hand.Add(card);
            deck.Remove(card);
            gy.Add(this);
            hand.Remove(this);

            return (hand, deck, gy);
        }
    }
}

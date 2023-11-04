using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellarknight_App.Models
{
    internal class SupportedCards
    {
        public List<Card> Cards { get; set; }

        public SupportedCards()
        {
            Cards = new List<Card>()
            {
                new Card() { Name = "Satellarknight Deneb", Type = "Monster", Archetype = "Tellarknight", Image = "./CardArt/Deneb.png", Role = "" },
                new Card() { Name = "Satellarknight Altair", Type = "Monster", Archetype = "Tellarknight", Image = "./CardArt/Altair.png", Role = "" },
                new Card() { Name = "Satellarknight Vega", Type = "Monster", Archetype = "Tellarknight", Image = "./CardArt/Vega.png", Role = "" },
                new Card() { Name = "Satellarknight Unukalhai", Type = "Monster", Archetype = "Tellarknight", Image = "./CardArt/Unuk.png", Role = "" },
                new Card() { Name = "Satellarknight Sirius", Type = "Monster", Archetype = "Tellarknight", Image = "./CardArt/Sirius.png", Role = "" },
                new Card() { Name = "Tellarknight Lyran", Type = "Monster", Archetype = "Both", Image = "./CardArt/Lyran.png", Role = "ExtenderBoth" },
                new Card() { Name = "Tellarknight Altairan", Type = "Monster", Archetype = "Both", Image = "./CardArt/Altairan.png", Role = "" },

                new Card() { Name = "Constellar Sheratan", Type = "Monster", Archetype = "Constellar", Image = "./CardArt/Sheratan.png", Role = "" },
                new Card() { Name = "Constellar Caduceus", Type = "Monster", Archetype = "Constellar", Image = "./CardArt/Caduceus.png", Role = "ExtenderConstellar" },

                new Card() { Name = "Sakitama", Type = "Monster", Archetype = "None", Image = "./CardArt/Sakitama.png", Role = "Extender" },
                new Card() { Name = "ZS - Ascended Sage", Type = "Monster", Archetype = "None", Image = "./CardArt/AscendedSage.png", Role = "Extender" },

                new Card() { Name = "Satellarknight Skybridge", Type = "Spell", Archetype = "Tellarknight", Image = "./CardArt/Skybridge.png", Role = "" },
                new Card() { Name = "Constellar Tellarknights", Type = "Spell", Archetype = "Both", Image = "./CardArt/ConstellarTellarknights.png", Role = "" },

                new Card() { Name = "Reinforcement of the Army", Type = "Spell", Archetype = "None", Image = "./CardArt/Rota.png", Role = "Rota" },
                new Card() { Name = "Living Fossil", Type = "Spell", Archetype = "None", Image = "./CardArt/Fossil.png", Role = "" },
            };
        }
    }
}

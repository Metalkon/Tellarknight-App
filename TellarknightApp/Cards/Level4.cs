﻿using TellarknightApp.Models;

namespace TellarknightApp.Cards
{
    public class Level4 : Card
    {
        public Level4()
        {
            Name = "Level 4 Monster";
            Level = 4;
            Image = "./CardArt/CelticGuardian.jpg";
        }

        public override Card Clone()
        {
            return this;
        }
    }
}
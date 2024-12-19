﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P230611988.Classes
{
    internal class HeiXiong:Actor
    {
        MainGame game;
        public HeiXiong(string name, Point position, Image image, MainGame game) :base(name, position, image, 100, 10, game)
        {
            this.Name = "黑熊";
            this.Type = 1;
            this.PositionX = 1;
            this.PositionY = 17;
            this.game = game;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);
            this.Defension += 1;
        }
    }
}

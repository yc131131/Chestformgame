using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P230611988.Classes
{
    internal class HongHaiEr:Actor
    {
        MainGame game;
        public HongHaiEr(string name, Point position, Image image, MainGame game) : base(name, position, image, 100, 10, game)
        {
            this.Name = "红孩儿";
            this.Type = 1;
            this.PositionX = 2;
            this.PositionY = 17;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);

            this.DealDamageInSurroundingArea();
        }

    }
}

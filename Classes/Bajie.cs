using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P230611988.Classes
{
    internal class Bajie:Actor
    {
        MainGame game;
        public  Bajie(string name, Point position, Image image, MainGame game) :base(name, position, image, 100, 10, game)
        {
            this.Name = "八戒";
            this.Type = 0;
            this.PositionX = 3;
            this.PositionY = 0;
            this.game = game;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);

            this.HP += 15;

        }
    }
}

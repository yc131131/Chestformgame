using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P230611988.Classes
{
    internal class ErLangSheng:Actor
    {
        MainGame game;

        public ErLangSheng(string name, Point position, Image image, MainGame game) :base(name, position, image, 100, 10, game)
        {
            this.Name = "二郎神";
            this.Type = 1;
            this.PositionX = 3;
            this.PositionY = 17;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);
            this.FMoveTwords(game.FindClosestActor(this, 1));//远离敌人
            game.GetAboard().UpdateActorPosition(this, this.PositionY, this.PositionX);
            this.HP += 10;
        }
    }
}

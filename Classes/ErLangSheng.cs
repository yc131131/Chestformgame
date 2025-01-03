﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.game = game;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);
            this.FMoveTwords(game.FindClosestActor(this, 1));//远离敌人
            game.GetAboard().UpdateActorPosition(this, this.PositionY, this.PositionX);
            this.HP += 5;
            MessageBox.Show("二郎神移动,治愈了自己5点HP");
            //game.GetAboard().SetLabelText("二郎神远离敌人,治愈了自己10点HP");
        }
    }
}

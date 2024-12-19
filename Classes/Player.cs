using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;

namespace P230611988
{
    internal class Player:Actor
    {
        MainGame game;


        public Player(string name,Point position,Image image,MainGame game):base(name, position, image,100,10,game)
        {
            this.Name = "孙悟空";
            this.Type = 0;
            this.PositionX = 2;
            this.PositionY = 0;
            this.game = game;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);

            this.DamageAmount += 5;
        }

        public void Attack1(Point MousePosition,Point PicturePositon)
        {
            int deltaX = MousePosition.X - PicturePositon.X;
            int deltaY = MousePosition.Y - PicturePositon.Y;

            int attackrangex=0;
            int attackrangey=0;

            bool isHorizontal = Math.Abs(deltaX) > Math.Abs(deltaY);

            if (isHorizontal)  // 水平方向
            {
                if (deltaX > 0)  // 右侧
                {
                    attackrangex = 5;
                }
                else if (deltaX < 0)  // 左侧
                {
                    attackrangex = -5;
                }
            }
            else  // 垂直方向
            {
                if (deltaY > 0)  // 下方
                {
                    attackrangey = 5;
                }
                else if (deltaY < 0)  // 上方
                {
                    attackrangey = -5;
                }
            }

            foreach (Actor actor in game._actors)
            {
                if (actor.Type == 0)
                    continue;
                if (attackrangey == 0)  // 如果是水平方向的攻击
                {
                    // 判断目标角色是否在攻击范围内
                    if (this.PositionY == actor.PositionY) // 确保在同一水平线上
                    {
                        if ((this.PositionX + attackrangex >= actor.PositionX && actor.PositionX >= this.PositionX) ||
                            (this.PositionX + attackrangex <= actor.PositionX && actor.PositionX <= this.PositionX))
                        {
                            Attack(actor, this.DamageAmount);
                        }
                    }
                }
                else  // 垂直方向的攻击
                {
                    // 判断目标角色是否在攻击范围内
                    if (this.PositionX == actor.PositionX) // 确保在同一垂直线上
                    {
                        if ((this.PositionY + attackrangey >= actor.PositionY && actor.PositionY >= this.PositionY) ||
                            (this.PositionY + attackrangey <= actor.PositionY && actor.PositionY <= this.PositionY))
                        {
                            Attack(actor, this.DamageAmount);
                        }
                    }
                }
            }
        }

    }
}

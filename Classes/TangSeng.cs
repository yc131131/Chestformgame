using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P230611988.Classes
{
    internal class TangSeng:Actor
    {
        MainGame game;
        public TangSeng(string name, Point position, Image image, MainGame game) :base(name, position, image, 100, 5, game)
        {
            this.Name = "唐僧";
            this.Type = 0;
            this.PositionX = 1;
            this.PositionY = 0;
            this.game = game;
        }

        public override void PassiveSkill(Actor sender)
        {
            base.PassiveSkill(sender);
            MessageBox.Show("唐僧治愈了所有队友5点HP");
            for (int i = 0; i < 3; i++)
            {
                game._actors[i].HP += 5;
                game.GetAboard().AHealPictureBoxShow(game._actors[i]);
                //game.GetAboard().SetLabelText("唐僧治愈了所有队友5点HP");

            }
        }

        public void DealAllDamage()
        {
            MessageBox.Show("唐僧使用了魂火，对所有敌人造成伤害 ");
            //game.GetAboard().SetLabelText("唐僧使用了魂火，对所有敌人造成了5点伤害");
            for (int i = 3; i < 6; i++)
            {
                if(game._actors[i].IsAlive)
                {
                    game._actors[i].TakeDamage(this.DamageAmount);
                    game.GetAboard().TangSengAPictureBoxShow(game._actors[i]);
                    
                }
            }
        }
    }
}

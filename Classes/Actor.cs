using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using P230611988.Classes;
using System.Runtime.CompilerServices;
using System.Windows.Forms;



namespace P230611988
{


    public interface IAction
    {
        void Execute();
    }

    internal class Actor
    {
        public int Type;//0为队友1为敌人
        public string Name { get; set; }
        public Point Position { get; set; }//form调用
        public int PositionX { get; set; }//map调用
        public int PositionY { get; set; }
        public Image CharacterImage { get; set; }
        public int HP { get; set; }
        public int DamageAmount { get; set; }

        public int Defension = 0;

        public bool IsAlive = true;

        MainGame game;


        public delegate void DamageTakenHandler(Actor sender);
        public event DamageTakenHandler OnDamageTaken;

        public Actor(string name, Point position, Image image, int hp, int damageamount, MainGame game)
        {
            OnDamageTaken += PassiveSkill;
            Name = name;
            Position = position;
            CharacterImage = image;
            HP = hp;
            DamageAmount = damageamount;
            this.game = game;
        }

        public void TakeDamage(int damage)
        {
            int Damage = (damage - Defension) >= 0 ? damage - Defension : 0;
            HP -= Damage;

            MessageBox.Show($"{this.Name}收到了{Damage}点伤害，还剩{this.HP}生命值");
            if (HP > 0)
            {
                OnDamageTaken?.Invoke(this);
                //game.GetAboard().SetLabelText($"{this.Name}收到了{damage}点伤害");
            }
            else
            {
                IsAlive = false;
            }
            
        }


        public void Action(Actor sender)
        {

        }

        public virtual void PassiveSkill(Actor sender)
        {
            
        }
        //form中 根据e计算 
        //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 Y-> 
        //1
        //2
        //3
        //4
        //5
        //X
        //|
        //V
        public void Move(int newX, int newY, Map map)
        {
            if (map.IsWalkable(newX, newY))
            {
                map.Tiles[this.PositionX, this.PositionY].IsWalkable = true;
                this.PositionX = newX;
                this.PositionY = newY;
                map.Tiles[newX, newY].IsWalkable = false;  // 更新地图状态
             
            }
        }

        public void Attack(Actor actor, int damage)
        {
            actor.TakeDamage(damage);
        }

        public void FMoveTwords(Actor actor)//actor 是找到的最近的敌对actor
        {
            if (!IsAlive)
            {
                return;
            }
            if (actor != null)
            {
                int deltaX = actor.PositionX - this.PositionX;
                int deltaY = actor.PositionY - this.PositionY;

                // 计算水平和垂直方向的移动距离
                if (Math.Abs(deltaX) > Math.Abs(deltaY))
                {
                    if (deltaX > 0)
                    {
                        Move(PositionX + 1, PositionY, game.GetMap()); // 下移动
                    }
                    else
                    {
                        Move(PositionX - 1, PositionY, game.GetMap()); // 向上移动
                    }
                }
                else
                {
                    if (deltaY > 0)
                    {
                        Move(PositionX, PositionY + 1, game.GetMap()); // 向右移动
                    }
                    else
                    {
                        Move(PositionX, PositionY - 1, game.GetMap()); // 向左移动
                    }
                }
            }

        }

        public async void DealDamageInSurroundingArea()
        {
            foreach (Actor target in game._actors)
            {
                // 跳过自己
                if (this == target) continue;

                // 判断目标是否在自己周围 8 格范围内
                if (Math.Abs(this.PositionX - target.PositionX) <= 1 && Math.Abs(this.PositionY - target.PositionY) <= 1)
                {
                    // 如果目标是敌人，造成伤害
                    if (target.Type != this.Type&&target.IsAlive)  // 1表示敌人
                    {
                        Attack(target, this.DamageAmount);
                        game.GetAboard().AARangeBoxShow(this);
                    }
                }
            }

        }
    }
}

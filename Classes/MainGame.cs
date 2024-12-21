using P230611988.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P230611988
{
    internal class MainGame
    {
        Task run;

        private MainForm _mainForm;



        private TurnManager _turnManager { get; set; }
        private GameHistory _gameHistory { get; set; }
        public List<Actor> _actors { get; set; }
        private Map _map { get; set; }



        private Aboard _aboard { get; set; }



        public bool _isInputEnabled = true;
        public bool _isInputFinished  = false;
        public bool _isMovementEnabled = false; // 控制是否启用Tile点击移动
        public bool _isAttackEnabled  = false;

        public MainGame(MainForm mainForm)
        {
            _mainForm = mainForm;

            _aboard = new Aboard(mainForm, this);

            // 初始化角色、地图、游戏历史等
            _map = new Map(6, 18);
            _actors = new List<Actor>
            {
                new Player("孙悟空", new Point(0, 100), Properties.Resources.Wukong,this),//Tile 的递增53，50
                new Bajie("八戒",new Point(0,150), Properties.Resources.Bajie,this),
                new TangSeng("唐僧",new Point(0,50),Properties.Resources.TangSeng,this),
                new HongHaiEr("红孩儿",new Point(908,100),Properties.Resources.Honghaier,this),
                new HeiXiong("黑熊",new Point(908,50),Properties.Resources.HeiXiong,this),
                new ErLangSheng("二郎神",new Point(908,150),Properties.Resources.ErLangSheng,this),
            };

            _gameHistory = new GameHistory(new GameState(_actors, null));
            _turnManager = new TurnManager(_actors, _gameHistory, _aboard);

        }



        public async Task StartGame()
        {
            _aboard.GameStart();

            while (_actors[0].HP > 0 || (_actors[3].IsAlive || _actors[4].IsAlive || _actors[5].IsAlive))
            {
                await WaitForInputAsync();
                //playerturn


                //进一步等待操作
                await Task.Delay(6000);
                //allyturn
                _turnManager.NextTurn();
                ActionActor(_actors[1]);
                ActionActor(_actors[2]);
                if(!(_actors[3].IsAlive || _actors[4].IsAlive || _actors[5].IsAlive))
                    MessageBox.Show("胜利");
                //await Task.Delay(6000);
                //enemyturn
                _turnManager.NextTurn();
                ActionActor(_actors[3]);
                ActionActor(_actors[4]);
                ActionActor(_actors[5]);
                if(_actors[0].HP <= 0)
                    MessageBox.Show("失败");
                await Task.Delay(3000);
                _isInputEnabled = true;
                _isInputFinished = false;
                _turnManager.NextTurn();
                //record turn,update turn
            }




        }

        private async Task WaitForInputAsync()
        {
            // 异步等待直到输入完成
            while (!_isInputFinished)
            {
                await Task.Delay(100); // 稍微延迟，避免占用过多 CPU 时间
                Application.DoEvents(); // 允许 UI 线程继续处理其他消息
            }
        }


        public void ProcessInput(Keys key)
        {
            if (!_isInputEnabled) return;

            // 根据按键执行游戏行动
            switch (key)
            {
                case Keys.Q:
                    MessageBox.Show("移动已启用"); // 按下 Q 键后启用移动
                    _isMovementEnabled = true; // 启用点击事件处理
                    //actor 类里的实际调用
                    //mainForm类中
                    

                    break;
                case Keys.W:
                    //Attack
                    MessageBox.Show("攻击已启用");


                    _isAttackEnabled = true;
                    break;
                case Keys.E:
                    _aboard.AHealPictureBoxShow(_actors[0]);
                    _actors[0].HP += 10;
                    _isInputFinished = true;
                    _mainForm.PlayerSkillInfoLabel.Visible = false;
                    MessageBox.Show("孙悟空治愈了自己10点HP");
                    break;
                case Keys.R:
                    _aboard.PBuffPictureBoxShow(_actors[0]);
                    _actors[0].DamageAmount += 5;
                    _isInputFinished = true;
                    _mainForm.PlayerSkillInfoLabel.Visible = false;
                    MessageBox.Show("孙悟空提升了自己5点攻击力");
                    break;
                default:

                    break;
            }
            _isInputEnabled = false;
        }

        public Actor FindClosestActor(Actor Self,int actorType)//输入self的type
        {
            Actor closestActor = null;
            double closestDistance = double.MaxValue;

            // 遍历所有角色，查找指定类型的敌人或队友
            foreach (var actor in _actors)
            {
                // 检查目标是否存活且是指定类型的角色
                if (actor.IsAlive && actor.Type != actorType && actor != Self)
                {
                    double distance = Math.Sqrt(Math.Pow(actor.PositionX - Self.PositionX, 2) + Math.Pow(actor.PositionY - Self.PositionY, 2));
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestActor = actor;
                    }
                }
            }

            return closestActor;
        }



        public Actor GetPlayerCharacter()
        {
            return _actors.FirstOrDefault(c => c is Player);
        }

        public TurnManager GetTurnManager()
        {
            return _turnManager;
        }

        public Aboard GetAboard()
        {
            return _aboard;
        }

        public Map GetMap()
        {
            return _map;
        }

        public void ActionActor(Actor actor)
        {
            if (!actor.IsAlive)
                return;
            if (actor is Player)
                return;
            for (int i = 0; i < 3; i++)
            {
                actor.FMoveTwords(FindClosestActor(actor,actor.Type));
               _aboard.UpdateActorPosition(actor, actor.PositionY, actor.PositionX);
            }
            if (actor is TangSeng t)
            {
                t.DealAllDamage();
            }
            actor.DealDamageInSurroundingArea();
        }

    }
}

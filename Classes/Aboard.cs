using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P230611988.Classes
{
    internal class Aboard
    {
        private Map _map;
        private TurnManager _turnManager;
        private MainForm _mainForm;
        private MainGame _game;


        private PictureBox _turnMessagePictureBox; // 用于显示回合信息的图片
        private Timer _turnMessageTimer; // 控制回合信息的动态效果
        private float _turnMessageCurrentPositionY;  // 控制 PictureBox 从顶部滑入的 Y 位置
        private bool _isMessageVisible;  // 控制 PictureBox 是否可见
        private Dictionary<TurnPhase, Image> _turnImages; // 存储回合阶段对应的图片

        private PictureBox _ShouldMovedPictureBox;
        private Timer _MovePictureBoxTimer;
        private Point Newposition;
        private bool _isHorizontalMoveComplete = false;

        public Aboard(MainForm mainForm , MainGame game)
        {
            _mainForm = mainForm;
            _game = game;
            _map = game.GetMap();


            _mainForm._turnMessagePictureBox = new PictureBox()
            {
                Size = new Size(192, 96), // 根据需要调整大小
                Location = new Point(_mainForm.ClientSize.Width / 2 - 150, 200), // 初始位置在窗体顶部之外
                BackColor = Color.Transparent, // 无背景色
                Visible = false // 默认隐藏
            };
            _turnMessagePictureBox = mainForm._turnMessagePictureBox;
            _mainForm.Controls.Add(_turnMessagePictureBox);

            // 初始化定时器
            _turnMessageTimer = new Timer();
            _turnMessageTimer.Interval = 10;  // 每30ms更新一次位置
            _turnMessageTimer.Tick += TurnMessageTimer_Tick;

            _turnImages = new Dictionary<TurnPhase, Image>
            {
                { TurnPhase.PlayerTurn, Properties.Resources.msesageyour },  // 你可以替换为实际的图片资源
                { TurnPhase.AllyTurn, Properties.Resources.msesageAllyTurn },
                { TurnPhase.EnemyTurn, Properties.Resources.msesageEnemyTurn }
            };

        }

        // 启动回合提示的动画
        public void StartTurnMessageEffect(TurnPhase phase)
        {
            // 根据回合阶段选择对应的图片
            if (_turnImages.ContainsKey(phase))
            {
                _turnMessagePictureBox.Image = _turnImages[phase];
            }

            _turnMessageCurrentPositionY = 50;
            _turnMessagePictureBox.Location = new Point(_mainForm.ClientSize.Width / 2 - 110, (int)_turnMessageCurrentPositionY);
            _turnMessagePictureBox.Visible = true;
            _isMessageVisible = true;

            // 启动定时器，开始滑动
            _turnMessageTimer.Interval = 15;
            _turnMessageTimer.Start();  
        }

        // 结束回合提示的动画
        private void StopTurnMessageEffect()
        {
            _turnMessageTimer.Stop();  // 停止定时器
            _mainForm._turnMessagePictureBox.Visible = false;  // 隐藏提示
            _isMessageVisible = false;
            _turnMessageCurrentPositionY = 50; // 重置位置
        }

        // 定时器的 Tick 事件，控制回合信息的动态效果
        private void TurnMessageTimer_Tick(object sender, EventArgs e)
        {
            if (_isMessageVisible)
            {
                if (_turnMessageCurrentPositionY <= _mainForm.ClientSize.Height)
                {
                    if (_turnMessageCurrentPositionY <= _mainForm.ClientSize.Height / 2 - 70) // 当到达中间时
                    {
                        // 滑动动画：从上到中间
                        _turnMessageCurrentPositionY += 2;

                    }
                    else if (_turnMessageCurrentPositionY <= _mainForm.ClientSize.Height / 2 && _turnMessageCurrentPositionY > _mainForm.ClientSize.Height / 2 - 70)
                    {
                        _turnMessageCurrentPositionY += 1;
                    }
                    else
                    {
                        _turnMessageCurrentPositionY += 30;
                    }

                }
                else
                {
                    StopTurnMessageEffect();
                }
            }
            _turnMessagePictureBox.Location = new Point(_mainForm.ClientSize.Width / 2-110, (int)_turnMessageCurrentPositionY);
        }

        public void GameStart()
        {
            StartTurnMessageEffect(_game.GetTurnManager()._currentPhase);
        }
        //XY反
        public void UpdateActorPosition(Actor actor,int NewPositionX,int NewPositonY)
        {
            Newposition = new Point(NewPositionX*53+3,NewPositonY*50);
            switch (actor.Name)
            {
                case "孙悟空":
                    _ShouldMovedPictureBox = _mainForm._playerPictureBox;
                    break;
                case "八戒":
                    _ShouldMovedPictureBox = _mainForm._BajiePictureBox;
                    _ShouldMovedPictureBox.Location = Newposition;
                    break;
                case "唐僧":
                    _ShouldMovedPictureBox = _mainForm._TangSengPictureBox;
                    _ShouldMovedPictureBox.Location = Newposition;
                    break;
                case "红孩儿":
                    _ShouldMovedPictureBox = _mainForm._HonghaierPictureBox;
                    _ShouldMovedPictureBox.Location = Newposition;
                    break;
                case "黑熊":
                    _ShouldMovedPictureBox = _mainForm._HeiXiongPictureBox;
                    _ShouldMovedPictureBox.Location = Newposition;
                    break;
                case "二郎神":
                    _ShouldMovedPictureBox = _mainForm._ErLangShengPictureBox;
                    _ShouldMovedPictureBox.Location = Newposition;
                    break;
                default:
                break;

            }
            StartPicturnBoxMoveTimer();

        }

        public void StartPicturnBoxMoveTimer()
        {


            if (_MovePictureBoxTimer == null)
            {
                _MovePictureBoxTimer = new Timer();
                _MovePictureBoxTimer.Interval = 20; // 每50ms触发一次
                _MovePictureBoxTimer.Tick += PictureBoxMoveTimer_Tick;
            }

            _MovePictureBoxTimer.Start();

            _isHorizontalMoveComplete = false;
        }

        public void PictureBoxMoveTimer_Tick(object sender, EventArgs e)
        {
            Point currentPosition = _ShouldMovedPictureBox.Location;

            // 先进行水平移动
            if (!_isHorizontalMoveComplete)
            {
                // 水平位置调整
                if (currentPosition.X < Newposition.X)
                {
                    //int stepX = (int)Math.Sign(Newposition.X - currentPosition.X) *5; // 每次移动5像素
                    currentPosition.X += 5;
                    _ShouldMovedPictureBox.Location = new Point(currentPosition.X /*+*/ /*stepX*/, currentPosition.Y);//抽搐
                }
                if (currentPosition.X > Newposition.X)
                {
                    currentPosition.X = Newposition.X;
                }
                // 如果水平对齐，设置标志位并开始垂直移动
                if (currentPosition.X == Newposition.X)
                {
                    _isHorizontalMoveComplete = true;
                }
            }
            // 水平完成后，进行垂直移动
            else
            {
                // 垂直位置调整
                if (currentPosition.Y != Newposition.Y)
                {
                    int stepY = (int)Math.Sign(Newposition.Y - currentPosition.Y) * 5; // 每次移动5像素
                    _ShouldMovedPictureBox.Location = new Point(currentPosition.X, currentPosition.Y + stepY);
                }
                // 如果垂直对齐，停止定时器
                if (currentPosition.Y == Newposition.Y)
                {
                    _MovePictureBoxTimer.Stop(); // 停止定时器
                }
            }
        }

        //倾斜45度X分割
        public void PictureBoxAttackRangeShow(Point mousePosition)//totally mistake of gpt
        {
            // 计算鼠标相对于玩家的位置
            int deltaX = mousePosition.X - _mainForm._playerPictureBox.Location.X;
            int deltaY = mousePosition.Y - _mainForm._playerPictureBox.Location.Y;

            int startX = 0;
            int startY = 0;

            // 水平方向或垂直方向
            bool isHorizontal = Math.Abs(deltaX) > Math.Abs(deltaY);

            if (isHorizontal)  // 水平方向
            {
                if (deltaX > 0)  // 右侧
                {
                    startX = _game._actors[0].PositionX;
                    startY = _game._actors[0].PositionY + 1;  // 上下范围
                    _mainForm._AttackRangePictureBox.Size = new Size(5 * 53, 50);  // 水平5格
                }
                else if (deltaX < 0)  // 左侧
                {
                    startX = _game._actors[0].PositionX;
                    startY = _game._actors[0].PositionY - 5;
                    _mainForm._AttackRangePictureBox.Size = new Size(5 * 53, 50);  // 水平5格
                }
            }
            else  // 垂直方向
            {
                if (deltaY > 0)  // 下方
                {
                    startX = _game._actors[0].PositionX+1;
                    startY = _game._actors[0].PositionY;
                    _mainForm._AttackRangePictureBox.Size = new Size(50, 5 * 53);  // 垂直5格
                }
                else if (deltaY < 0)  // 上方
                {
                    startX = _game._actors[0].PositionX - 5;
                    startY = _game._actors[0].PositionY;
                    _mainForm._AttackRangePictureBox.Size = new Size(50, 5 * 53);  // 垂直5格
                }
            }
            // 更新 PictureBox 的位置
            UpdatePictureBoxAttackRangePosition(startX, startY, isHorizontal);
        }

        private void UpdatePictureBoxAttackRangePosition(int startX, int startY, bool isHorizontal)
        {
            // 更新 PictureBox 的位置和大小
            _mainForm._AttackRangePictureBox.Location = new Point(startY * 53+2, startX * 50+2);
            // 显示攻击范围
            _mainForm._AttackRangePictureBox.Visible = true;
        }

        public async void AARangeBoxShow(Actor actor)
        {
            _mainForm._AARangePictureBox.Location = new Point(actor.PositionY * 53-50, actor.PositionX * 50-50);
            _mainForm._AARangePictureBox.Visible = true;
            await Task.Delay(100);
            _mainForm._AARangePictureBox.Visible = false;
        }

        public async void TangSengAPictureBoxShow(Actor actor)
        {
            for (int i = 3; i < 6; i++)
            {
                _mainForm._TangSengAPictureBox.Location = new Point(actor.PositionY * 53,actor.PositionX * 50+10);
                _mainForm._TangSengAPictureBox.Visible = true;
                await Task.Delay(50);
                _mainForm._TangSengAPictureBox.Visible= false;
            }
        }

        public async void AHealPictureBoxShow(Actor actor)
        {
            for (int i = 0;i<3;i++)
            {
                _mainForm._AHealPictureBox.Location = new Point(actor.PositionY * 53, actor.PositionX * 50-10);
                _mainForm._AHealPictureBox.Visible= true;
                await Task.Delay(100);
                _mainForm._AHealPictureBox.Visible = false;
            }
        }

        public async void PBuffPictureBoxShow(Actor actor)
        {
            _mainForm._PBuffPictureBox.Location = new Point(actor.PositionY * 53, actor.PositionX * 50-10);
            _mainForm._PBuffPictureBox.Visible = true;
            await Task.Delay(100);
            _mainForm._PBuffPictureBox.Visible = false;
        }

        //public async void SetLabelText(string text)
        //{
        //    _mainForm.label1.Text = text;
        //    await Task.Delay(100);
        //}
    }
}

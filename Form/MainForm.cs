using P230611988.Classes;
using P230611988.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P230611988
{
    public partial class MainForm : Form
    {



        MainGame game= null;
        Aboard _aboard = null;

        public MainForm()
        {
            InitializeComponent();
            Init();
            
            game.StartGame();
        }

        private void Init()
        {
            
            //Game
            game = new MainGame(this);

            _aboard = game.GetAboard();

            _AARangePictureBox = new PictureBox()
            {
                Image = Resources.Sprite_0001,
                BackColor = Color.Transparent,
                Size = new Size(150, 150),
                Visible = false,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            this.Controls.Add(_AARangePictureBox);

            _AHealPictureBox = new PictureBox()
            {
                Image = Resources.heart,
                BackColor = Color.Transparent,
                Size = new Size(40, 40),
                Visible = false,
                SizeMode= PictureBoxSizeMode.StretchImage,
            };
            this.Controls.Add (_AHealPictureBox);

            _PBuffPictureBox = new PictureBox()
            {
                Image = Resources.heart_export1,
                BackColor = Color.Transparent,
                Size = new Size(40,40),
                Visible=false,
                SizeMode = PictureBoxSizeMode.StretchImage,

            };
            this.Controls.Add(_PBuffPictureBox);


            //Player
            Actor player = game.GetPlayerCharacter();

            if (player != null)
            {
                _playerPictureBox = new PictureBox()
                {
                    Image = player.CharacterImage,
                    Location = player.Position,
                    Size = new Size(52, 50),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                this.Controls.Add(_playerPictureBox);
            }

            PlayerSkillInfoLabel = new Label()
            {
                Location = new Point(10, 320),
                Size = new Size(300, 50),
                Visible = false,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                AutoSize = false,
            };
            PlayerSkillInfoLabel.Font = new Font(PlayerSkillInfoLabel.Font.Name, 16);//16 为字号
            this.Controls.Add(PlayerSkillInfoLabel);

            _playerPictureBox.Click += PlayerPictureBox_Click;

            this._AttackRangePictureBox = new Button()
            {
                Visible = false,
                BackColor= Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                
            };
            this.Controls.Add(_AttackRangePictureBox);
            //Ally
            _BajiePictureBox = new PictureBox()
            {
                Image = game._actors[1].CharacterImage,
                Location = game._actors[1].Position,
                Size = new Size(52, 50),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(_BajiePictureBox);

            _TangSengPictureBox = new PictureBox()
            {
                Image = game._actors[2].CharacterImage,
                Location = game._actors[2].Position,
                Size = new Size(52, 50),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(_TangSengPictureBox);

            _TangSengAPictureBox = new PictureBox()
            {
                Image= Resources.breath_export,
                Visible = false,
                Size = new Size(60,50),
                BackColor = Color.Transparent,
                SizeMode= PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(_TangSengAPictureBox);
            //Ememy
            Actor honghaier = game._actors[3];
            if (honghaier != null)
            {
                _HonghaierPictureBox = new PictureBox()
                {
                    Image = honghaier.CharacterImage,
                    Location = honghaier.Position,
                    Size = new Size(51, 50),
                    SizeMode= PictureBoxSizeMode.StretchImage
                };
                this.Controls.Add(_HonghaierPictureBox);
            }

            _HeiXiongPictureBox = new PictureBox()
            {
                Image = game._actors[4].CharacterImage,
                Location = game._actors[4].Position,
                Size = new Size(52, 50),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(_HeiXiongPictureBox);

            _ErLangShengPictureBox = new PictureBox()
            {
                Image = game._actors[5].CharacterImage,
                Location = game._actors[5].Position,
                Size = new Size(52, 50),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(_ErLangShengPictureBox);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            game.ProcessInput(keyData);
            return base.ProcessCmdKey(ref msg, keyData);

        }







        //Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Focus();
            //Init();
            

        }



        private void PlayerPictureBox_Click(object sender, EventArgs e)
        {
            // 设置 PictureBox 边框为 3D 风格
            _playerPictureBox.BorderStyle = BorderStyle.Fixed3D;

            PlayerSkillInfoLabel.Text = "Q:筋斗云" +
                "W:金箍棒" +
                "E:打坐"+
                "R:修行";
            PlayerSkillInfoLabel.Visible = true;
            
        }

        

        private void MainForm_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (game._isMovementEnabled)//移动操作
            {
                // 计算点击的 Tile 坐标
                int clickedTileX = e.X / 53;  // 根据点击的 X 坐标计算 Tile X
                int clickedTileY = e.Y / 50;  // 根据点击的 Y 坐标计算 Tile Y

                // 获取玩家角色
                Actor player = game.GetPlayerCharacter();

                // 调用更新角色位置
                _aboard.UpdateActorPosition(player, clickedTileX, clickedTileY);
                player.Move(clickedTileY, clickedTileX, game.GetMap());

                game._isInputFinished = true;  // 设置输入完成，游戏才继续
                game._isMovementEnabled = false; // 禁用移动状态，防止重复点击
            }
            else if(game._isAttackEnabled)//其他操作的调用
            {
                if (game._actors[0] is Player player)
                {
                    player.Attack1(e.Location,_playerPictureBox.Location);
                }


                this._AttackRangePictureBox.Visible = false;
                game._isInputFinished = true;  // 设置输入完成，游戏才继续
                game._isAttackEnabled = false;
            }
            else
            {
                // 执行原本的点击逻辑，例如关闭边框、隐藏 UI 等
                _playerPictureBox.BorderStyle = BorderStyle.None;
                PlayerSkillInfoLabel.Visible = false;
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            // 设置 Form 的标题栏显示鼠标坐标
            this.Text = $"Mouse Position: X={mouseX}, Y={mouseY}，x={game._actors[0].PositionX},y={game._actors[0].PositionY}.{game._actors[1].PositionX},{game._actors[1].PositionY},{game.GetMap().IsWalkable(mouseY/50,mouseX/53)}";
            //
            if (game._isAttackEnabled)
            {
                //Point mousePosition = new Point(e.X / 53, e.Y / 50);  // 假设每个格子的大小是 50x50
                _aboard.PictureBoxAttackRangeShow(e.Location);
            }
        }

    }
}

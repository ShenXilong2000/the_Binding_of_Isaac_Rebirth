using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;


namespace The_Binding_of_Isaac_Rebirth
{
    public partial class FormMain : Form
    {
        //游戏状态
        public enum gameState
        {
            title = 0, menu = 1, open = 2, stop = 3,over = 4,win=5,next = 6
        }
        //游戏菜单选择
        public enum menuChoose
        {
            New_Run = 0, Continue = 1, Test = 2,Back =3
        }
        public enum playerUP
        {
            DMG = 0,SPEED = 1,HP = 2
        }
        public enum side
        {
            player = 0, enemy = 1
        }

        private gameState _nowgame = gameState.title;
        private menuChoose _playerChoose = menuChoose.New_Run;
        private DrawBackground _drawdg = new DrawBackground();
        private Player _player = new Player();
        private List<Tears> _tearList = new List<Tears>();
        private boss_0 _boss_0 = new boss_0();
        private DrawHP _drawHp = new DrawHP();
        private int _delayShoot = 0;
        private playerUP _playerUP = playerUP.DMG;
        private Tears _tear = new Tears(Tears.side.player);
        private SoundPlayer _Sound_player = new SoundPlayer("sounds\\book page turn.wav");
        private SoundPlayer _Sound_Speed = new SoundPlayer("sounds\\speed up 2.wav");
        private SoundPlayer _Sound_Tear = new SoundPlayer("sounds\\tears up 2.wav");
        private SoundPlayer _Sound_Hp = new SoundPlayer("sounds\\battery charge.wav");


        //受伤后无敌时间
        private int _can_not_BeDMG = 0;
        //是否能收到攻击
        private bool _canBeDMG = true;
        //boss 攻击间隔
        private int _bossTime = 4000;
        //boss 是否在攻击
        private bool _true_attack = false;
        private int _Way = 3;
        private Point p = new Point();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetAsyncKeyState(int keyCode);



        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _drawdg.Transsprent();
            _player.Transsprent();
            _player._Position = new Point(this.pictureBoxBackground.Width / 2, this.pictureBoxBackground.Height / 2);
            _boss_0.creat();
        }


        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {

            #region 菜单界面的简单控制
            //进入菜单
            if (_nowgame == gameState.title && (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter))
            {
                _nowgame = gameState.menu;
                _Sound_player.Play();
            }
            //选择菜单选项
            else if (_nowgame == gameState.menu)
            {
                //进入游戏
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    if (_playerChoose == menuChoose.New_Run)
                    {
                        _nowgame = gameState.open;
                        _Sound_player.Play();
                        _boss_0.creat();
                        _player.creat();
                        _player._Speed = 5;
                        _player._Hp_B = 10;
                        _player._Dmg = 1;
                    }
                    else if (_playerChoose == menuChoose.Continue)
                    {
                        _nowgame = gameState.open;
                        _Sound_player.Play();
                        _boss_0.creat();
                        _player.creat();
                        _boss_0._Hp = _boss_0._Hp_B;
                    }
                }
                else if (e.KeyCode == Keys.Down && _playerChoose == menuChoose.New_Run)
                    _playerChoose = menuChoose.Continue;
                else if (e.KeyCode == Keys.Down && _playerChoose == menuChoose.Continue)
                    _playerChoose = menuChoose.Test;
                else if (e.KeyCode == Keys.Up && _playerChoose == menuChoose.Test)
                    _playerChoose = menuChoose.Continue;
                else if (e.KeyCode == Keys.Up && _playerChoose == menuChoose.Continue)
                    _playerChoose = menuChoose.New_Run;
                else if (e.KeyCode == Keys.Escape)
                    _nowgame = gameState.title;
            }
            else if (_nowgame == gameState.open)
            {
                timer1.Enabled = true;
                _playerChoose = menuChoose.Back;
                if (e.KeyCode == Keys.P)
                {
                    timer1.Enabled = !timer1.Enabled;
                }
            }
            else if (_nowgame == gameState.win)
            {
                if (e.KeyCode == Keys.Right && _playerChoose == menuChoose.Back)
                    _playerChoose = menuChoose.Continue;
                else if (e.KeyCode == Keys.Left && _playerChoose == menuChoose.Continue)
                    _playerChoose = menuChoose.Back;
                else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && _playerChoose == menuChoose.Continue)
                {
                    _nowgame = gameState.next;
                    _Sound_player.Play();
                }
                else if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) && _playerChoose == menuChoose.Back)
                {
                    _nowgame = gameState.menu;
                    _playerChoose = menuChoose.New_Run;
                    _Sound_player.Play();
                }
            }
            else if (_nowgame == gameState.next)
            {
                if (e.KeyCode == Keys.Down && _playerUP == playerUP.DMG)
                    _playerUP = playerUP.SPEED;
                else if (e.KeyCode == Keys.Down && _playerUP == playerUP.SPEED)
                    _playerUP = playerUP.HP;
                else if (e.KeyCode == Keys.Up && _playerUP == playerUP.SPEED)
                    _playerUP = playerUP.DMG;
                else if (e.KeyCode == Keys.Up && _playerUP == playerUP.HP)
                    _playerUP = playerUP.SPEED;
                else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    if (_playerUP == playerUP.DMG)
                    {
                        _Sound_Tear.Play();
                        _player._Dmg *= 2;
                        _tear._Size = _player._Dmg * 2;
                    }
                    else if (_playerUP == playerUP.HP)
                    {
                        _player._Hp_B += 2;
                        _Sound_Hp.Play();
                    }
                    else if (_playerUP == playerUP.SPEED)
                    {
                        _Sound_Speed.Play();
                        _player._Speed += 5;
                        _tear._Speed = _player._Speed * 2;
                    }
                    _nowgame = gameState.open;
                    _boss_0.creat();
                    _player.creat();
                    _boss_0._Hp_B *= 4;
                    _boss_0._Hp = _boss_0._Hp_B;
                    _player._Hp = _player._Hp_B;
                    _tearList.Clear();
                }
            }
            else if (_nowgame == gameState.over)
            {
                timer1.Enabled = false;
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
                {
                    _nowgame = gameState.menu;
                    _Sound_player.Play();
                    _playerChoose = menuChoose.New_Run;
                }
            }
            #endregion

            pictureBoxBackground.Invalidate();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 对键盘输入的相应
            if (_nowgame == gameState.open)
            {
                bool keyDown = (((ushort)GetAsyncKeyState((int)Keys.Down)) & 0xffff) != 0;
                bool keyUp = (((ushort)GetAsyncKeyState((int)Keys.Up)) & 0xffff) != 0;
                bool keyRight = (((ushort)GetAsyncKeyState((int)Keys.Right)) & 0xffff) != 0;                
                bool keyLeft = (((ushort)GetAsyncKeyState((int)Keys.Left)) & 0xffff) != 0;

                bool keyDownMove = (((ushort)GetAsyncKeyState((int)Keys.W)) & 0xffff) != 0;
                bool keyUpMove = (((ushort)GetAsyncKeyState((int)Keys.S)) & 0xffff) != 0;
                bool keyRightMove = (((ushort)GetAsyncKeyState((int)Keys.A)) & 0xffff) != 0;
                bool keyLeftMove = (((ushort)GetAsyncKeyState((int)Keys.D)) & 0xffff) != 0;

                Tears _myTears;

                if (keyDown == true)
                {
                    if (_delayShoot <= 0)
                    {
                        _delayShoot = _player._DelayShoot;
                        _player._PlayerShoot = Player.PlayerShoot.Up;
                        _myTears = _player.Shoot(true);
                        _tearList.Add(_myTears);
                    }
                    else if (_player._DelayShoot - _delayShoot <= timer1.Interval * 3)
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerMove = Player.PlayerMove.Up;
                        _myTears = _player.Shoot(true);
                    }
                    else
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerShoot = Player.PlayerShoot.Up;
                        _myTears = _player.Shoot(false);
                    }
                }
                else if (keyUp == true)
                {
                    if (_delayShoot <= 0)
                    {
                        _delayShoot = _player._DelayShoot;
                        _player._PlayerShoot = Player.PlayerShoot.Down;
                        _myTears = _player.Shoot(true);
                        _tearList.Add(_myTears);
                    }
                    else if (_player._DelayShoot - _delayShoot <= timer1.Interval * 3)
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerMove = Player.PlayerMove.Down;
                        _myTears = _player.Shoot(true);
                    }
                    else
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerShoot = Player.PlayerShoot.Down;
                        _myTears = _player.Shoot(false);
                    }
                }
                else if (keyLeft == true)
                {

                    if (_delayShoot <= 0)
                    {
                        _delayShoot = _player._DelayShoot;
                        _player._PlayerShoot = Player.PlayerShoot.Left;
                        _myTears = _player.Shoot(true);
                        _tearList.Add(_myTears);
                    }
                    else if (_player._DelayShoot - _delayShoot <= timer1.Interval * 3)
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerMove = Player.PlayerMove.Left;
                        _myTears = _player.Shoot(true);
                    }
                    else
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerShoot = Player.PlayerShoot.Left;
                        _myTears = _player.Shoot(false);
                    }
                }
                else if (keyRight == true)
                {
                    if (_delayShoot <= 0)
                    {
                        _delayShoot = _player._DelayShoot;
                        _player._PlayerShoot = Player.PlayerShoot.Right;
                        _myTears = _player.Shoot(true);
                        _tearList.Add(_myTears);
                    }
                    else if (_player._DelayShoot - _delayShoot <= timer1.Interval * 3)
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerMove = Player.PlayerMove.Right;
                        _myTears = _player.Shoot(true);
                    }
                    else
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerShoot = Player.PlayerShoot.Right;
                        _myTears = _player.Shoot(false);
                    }
                }
                else
                {
                    _player._PlayerShoot = Player.PlayerShoot.Stop;
                    if (_delayShoot > 0)
                        _delayShoot -= 100;
                    else
                    {
                        _delayShoot -= timer1.Interval / 2;
                        _player._PlayerShoot = Player.PlayerShoot.Stop;
                        _myTears = _player.Shoot(false);
                    }
                }
                //判断按键且是否碰撞
                if (keyDownMove == true )//&& !_boss_0.ifMakeDMG(_player._NowplayerMove, new Point(_player._Position.X, _player._Position.Y - _player._Speed)))
                    _player.Move(Player.PlayerMove.Down);
                if (keyUpMove == true )//&& !_boss_0.ifMakeDMG(_player._NowplayerMove, new Point(_player._Position.X, _player._Position.Y + _player._Speed)))
                    _player.Move(Player.PlayerMove.Up);
                if (keyLeftMove == true )//&& !_boss_0.ifMakeDMG(_player._NowplayerMove, new Point(_player._Position.X- _player._Speed, _player._Position.Y )))
                    _player.Move(Player.PlayerMove.Left);
                if (keyRightMove == true )//&& !_boss_0.ifMakeDMG(_player._NowplayerMove, new Point(_player._Position.X+ _player._Speed, _player._Position.Y )))
                    _player.Move(Player.PlayerMove.Right);
                if (keyLeftMove == false && keyRightMove == false && keyDownMove == false && keyUpMove == false)
                    _player.Move(Player.PlayerMove.Stop);
                foreach (Tears t in _tearList)
                    t.Move();

            }
            #endregion
            #region 检测攻击与被攻击
            bool _IfGameOver = _player.ifGameOver();
            if (_can_not_BeDMG == 0)
            {
                _canBeDMG = true;
                _can_not_BeDMG = 2000;
            }
            else _can_not_BeDMG -= 100;
            if (_can_not_BeDMG == 1000)
                _player._IfHurt = false;
            if (_boss_0.ifMakeDMG(_player._NowplayerMove, _player._Position) && _canBeDMG)
            {
                _player.hurt();
                _canBeDMG = false;
                _can_not_BeDMG = 2000;
                _player._IfHurt = true;
            }
            if (_IfGameOver) _nowgame = gameState.over;
            for (int i = 0; i < _tearList.Count; i++)
            {
                if (_tearList[i]._Side == Tears.side.player &&_boss_0.ifMakeDMG(_tearList[i]._Tear_0,_tearList[i]._Position))
                {
                    _boss_0.hurt(_player._Dmg);
                     _tearList.RemoveAt(i);
                }
                else if (_tearList[i]._Side == Tears.side.enemy && _player.ifTakeDMG(_tearList[i]._Tear_0, _tearList[i]._Position))
                {
                    if (_canBeDMG)
                    {
                        _player.hurt();
                        _canBeDMG = false;
                        _can_not_BeDMG = 2000;
                        _player._IfHurt = true;
                    }
                    else _tearList.RemoveAt(i);
                }
                if (_boss_0.ifBossDied())
                {
                    _nowgame = gameState.win;
                    timer1.Enabled = false;
                    _tearList.Clear();
                }
                if (_player.ifGameOver())
                {

                    _nowgame = gameState.over;
                    timer1.Enabled = false;
                    _tearList.Clear();
                }
            }
            #endregion
            #region Boss攻击
            Random ran = new Random();
            if (_bossTime == 0) _Way = ran.Next(0, 2);

            if (_bossTime <= 3000)
            {
                _bossTime += timer1.Interval;
                if (_true_attack == true)
                {
                    // 攻击方式===================0
                    if (_Way == 0)
                    {
                        _boss_0.attackWay(0, _bossTime);
                        if (_bossTime >= 1000 && _bossTime % 50 == 0)
                        {

                            // boss 射方向
                            Player.PlayerShoot _d = Player.PlayerShoot.Left;
                            Tears _t;
                            //随机眼泪方向
                            Point p = new Point();
                            if (_boss_0._Position.X < _player._Position.X)
                            {
                                _d = Player.PlayerShoot.Right;
                                int x = ran.Next((int)(_boss_0._Position.X + _boss_0._Nowenemy.Width * _boss_0._Size / 2), (int)(_boss_0._Position.X + _boss_0._Nowenemy.Width * _boss_0._Size));
                                int y = ran.Next((int)(_boss_0._Position.Y), (int)(_boss_0._Position.Y + _boss_0._Nowenemy.Height * _boss_0._Size));
                                p = new Point(x, y);
                            }
                            else if (_boss_0._Position.X > _player._Position.X)
                            {
                                _d = Player.PlayerShoot.Left;
                                int x = ran.Next((int)(_boss_0._Position.X), (int)(_boss_0._Position.X + _boss_0._Nowenemy.Width * _boss_0._Size / 2));
                                int y = ran.Next((int)(_boss_0._Position.Y), (int)(_boss_0._Position.Y + _boss_0._Nowenemy.Height * _boss_0._Size));
                                p = new Point(x, y);
                            }

                            _t = _boss_0.shoot(p, _d);
                            _tearList.Add(_t);
                        }
                        if (_bossTime == 2000)
                            _true_attack = false;
                    }

                    //======================== 1
                    if (_Way == 1)
                    {
                        _boss_0.attackWay(1, _bossTime);
                        //记录boss起跳时玩家位置
                        if (_bossTime >= 1000 && _bossTime <= 1100)
                        {
                            _boss_0._Position = new Point(0, 100000);
                            p = new Point(_player._Position.X - (int)(_boss_0._Nowenemy.Width * _boss_0._Size / 2), _player._Position.Y - (int)(_boss_0._Nowenemy.Height * _boss_0._Size / 2));

                        }
                        else if (_bossTime == 2000)
                            _boss_0._Position = p;
                        if (_bossTime == 3000)
                            _true_attack = false;
                    }

                }
            }
            else
            {
                _bossTime = 0;
                _true_attack = true;
            }
            
            #endregion

            pictureBoxBackground.Invalidate();
        }


        private void pictureBoxBackground_Paint(object sender, PaintEventArgs e)
        {
            _drawdg._WidthBackground = this.pictureBoxBackground.Width;
            _drawdg._HeightBackground = this.pictureBoxBackground.Height;


            if (_nowgame == gameState.title)
                _drawdg.DrawTitle(e.Graphics);
            else if (_nowgame == gameState.menu)
                _drawdg.DrawMenu(e.Graphics, (int)_playerChoose);
            else if (_nowgame == gameState.open)
            {
                _drawdg.DrawBackdrop(e.Graphics);

                _drawHp.Draw_playerHp(_player._Hp,_player._Hp_B,e.Graphics);
                _drawHp.Draw_BossHp(_boss_0._Hp,_boss_0._Hp_B, e.Graphics);
                #region 判断敌人、眼泪、玩家的绘画顺序
                if (_player._Position.Y >= _boss_0._Position.Y + _boss_0._Nowenemy.Height / 2)
                {
                    _boss_0.Drawenemy(e.Graphics);
                    _player.Drawplayer(e.Graphics);

                }
                else
                { 
                    _player.Drawplayer(e.Graphics);
                    _boss_0.Drawenemy(e.Graphics);
                }                  
                for (int i = 0; i < _tearList.Count; i++)
                {
                    if (_tearList[i]._Direction == Player.PlayerShoot.Stop)
                        _tearList.RemoveAt(i);
                    else
                        _tearList[i].DrawTears(e.Graphics);
                }
                #endregion

            }
            else if(_nowgame == gameState.over)
            {
                _drawdg.DrawBackdrop(e.Graphics);
                _drawdg.DrawGameOver(e.Graphics);
            }
            else if (_nowgame == gameState.win)
            {
                _drawdg.DrawBackdrop(e.Graphics);
                _drawdg.DrawYouWin(e.Graphics,(int)_playerChoose);
            }
            else if (_nowgame == gameState.next)
            {
                _drawdg.DrawBackdrop(e.Graphics);
                _drawdg.Draw_playerUP((int)_playerUP, e.Graphics);
            }
                
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _drawdg._TitleChange = !_drawdg._TitleChange;
            pictureBoxBackground.Invalidate();
        }
    }
}

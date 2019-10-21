using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;

namespace The_Binding_of_Isaac_Rebirth
{
    class Player
    {
        #region 属性
        //窗口宽度
        private double _widthBackground;
        //窗口高度
        private double _heightBackground;
        //角色位置
        private Point _position = new Point();
        //角色大小
        private double _size = 2;
        //生命值
        private int _hp = 10;
        private int _hp_B = 10;
        //攻击力
        private int _dmg = 1;
        //速度
        private int _speed = 5;
        //射击延迟  (控制射击间隔)
        private int _delayShoot = 400;
        private PlayerMove _playerMove = PlayerMove.Stop;
        private PlayerShoot _playerShoot = PlayerShoot.Stop;
        private bool _ifHurt = false;




        public double _WidthBackground
        {
            get { return _widthBackground; }
            set { _widthBackground = value; }
        }
        public double _HeightBackground
        {
            get { return _heightBackground; }
            set { _heightBackground = value; }
        }
        public Point _Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public int _Hp_B
        {
            get { return _hp_B; }
            set { _hp_B = value; }
        }
        public int _Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public int _Dmg
        {
            get { return _dmg; }
            set { _dmg = value; }
        }
        public int _Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int _DelayShoot
        {
            get { return _delayShoot; }
            set { _delayShoot = value; }
        }
        public enum PlayerMove
        {
            Stop =  0, Up = 1, Down = 2, Right = 3, Left = 4
        }
        public enum PlayerShoot
        {
            Stop = 0, Up = 1, Down = 2, Right = 3, Left = 4
        }
        internal PlayerMove _PlayerMove
        {
            get { return _playerMove; }
            set { _playerMove = value; }
        }
        internal PlayerShoot _PlayerShoot
        {
            get { return _playerShoot; }
            set { _playerShoot = value; }
        }
        public bool _IfHurt
        {
            get { return _ifHurt; }
            set { _ifHurt = value; }
        }
        #endregion

        #region Drawplayer
        //角色头部图片
        private Bitmap _player_head_Back = new Bitmap("Image\\player\\player_head_Back.png");
        private Bitmap _player_head_Back_Shoot = new Bitmap("Image\\player\\player_head_Back_Shoot.png");
        private Bitmap _player_head_frond = new Bitmap("Image\\player\\player_head_frond.png");
        private Bitmap _player_head_frond_Shoot = new Bitmap("Image\\player\\player_head_frond_Shoot.png");
        private Bitmap _player_head_Right = new Bitmap("Image\\player\\player_head_Right.png");
        private Bitmap _player_head_Right_Shoot = new Bitmap("Image\\player\\player_head_Right_Shoot.png");
        private Bitmap _player_head_Left = new Bitmap("Image\\player\\player_head_Left.png");
        private Bitmap _player_head_Left_Shoot = new Bitmap("Image\\player\\player_head_Left_Shoot.png");
        //角色身体图片
        private Bitmap _player_Body_front_0 = new Bitmap("Image\\player\\player_Body_front(0).png");
        private Bitmap _player_Body_front_1 = new Bitmap("Image\\player\\player_Body_front(1).png");
        private Bitmap _player_Body_front_2 = new Bitmap("Image\\player\\player_Body_front(2).png");
        private Bitmap _player_Body_front_3 = new Bitmap("Image\\player\\player_Body_front(3).png");
        private Bitmap _player_Body_front_4 = new Bitmap("Image\\player\\player_Body_front(4).png");
        private Bitmap _player_Body_front_5 = new Bitmap("Image\\player\\player_Body_front(5).png");
        private Bitmap _player_Body_front_6 = new Bitmap("Image\\player\\player_Body_front(6).png");
        private Bitmap _player_Body_front_7 = new Bitmap("Image\\player\\player_Body_front(7).png");
        private Bitmap _player_Body_front_8 = new Bitmap("Image\\player\\player_Body_front(8).png");
        private Bitmap _player_Body_front_9 = new Bitmap("Image\\player\\player_Body_front(9).png");
        private Bitmap _player_hurt = new Bitmap("Image\\player\\player_hurt.png");



        private Bitmap _nowplayerMove;

        public Bitmap _NowplayerMove
        {
            get { return _nowplayerMove; }
            set { _nowplayerMove = value; }
        }
        private Bitmap _nowplayerShoot;

        public Bitmap _NowplayerShoot
        {
            get { return _nowplayerShoot; }
            set { _nowplayerShoot = value; }
        }




        //隐藏绿色区域
        public void Transsprent()
        {
            _player_Body_front_0.MakeTransparent(Color.Red);
            _player_Body_front_1.MakeTransparent(Color.Red);
            _player_Body_front_2.MakeTransparent(Color.Red);
            _player_Body_front_3.MakeTransparent(Color.Red);
            _player_Body_front_4.MakeTransparent(Color.Red);
            _player_Body_front_5.MakeTransparent(Color.Red);
            _player_Body_front_6.MakeTransparent(Color.Red);
            _player_Body_front_7.MakeTransparent(Color.Red);
            _player_Body_front_8.MakeTransparent(Color.Red);
            _player_Body_front_9.MakeTransparent(Color.Red);

            _player_head_Back.MakeTransparent(Color.Red);
            _player_head_Back_Shoot.MakeTransparent(Color.Red);
            _player_head_frond.MakeTransparent(Color.Red);
            _player_head_frond_Shoot.MakeTransparent(Color.Red);
            _player_head_Left.MakeTransparent(Color.Red); ;
            _player_head_Left_Shoot.MakeTransparent(Color.Red);
            _player_head_Right.MakeTransparent(Color.Red);
            _player_head_Right_Shoot.MakeTransparent(Color.Red);

            _player_hurt.MakeTransparent(Color.Red);

            _nowplayerMove = _player_Body_front_0;
            _nowplayerShoot = _player_head_frond;
        }

        public void Drawplayer(Graphics g)
        {
            if (_ifHurt)
                g.DrawImage(_player_hurt, new Rectangle(_position.X, _position.Y, (int)((double)_player_hurt.Width * _size * 1.0), (int)((double)_player_hurt.Height * _size * 1.0)));
            else
            {
                g.DrawImage(_nowplayerMove, new Rectangle(_position.X + (int)(_size * 5), _position.Y + (int)(_size * 20), (int)((double)_nowplayerMove.Width * _size * 1.0), (int)((double)_nowplayerMove.Height * _size * 1.0)));
                g.DrawImage(_nowplayerShoot, new Rectangle(_position.X, _position.Y, (int)((double)_nowplayerShoot.Width * _size * 1.0), (int)((double)_nowplayerShoot.Height * _size * 1.0)));
            }

            
        }
        #endregion

        #region 移动 射击
        public void Move(PlayerMove playerMove)
        {
            _playerMove = playerMove;
            if (_playerMove == PlayerMove.Stop)
            {
                _nowplayerMove = _player_Body_front_0;
            }
            else
            {
                if (_nowplayerMove == _player_Body_front_0)
                    _nowplayerMove = _player_Body_front_1;
                else if(_nowplayerMove == _player_Body_front_1)
                    _nowplayerMove = _player_Body_front_2;
                else if (_nowplayerMove == _player_Body_front_2)
                    _nowplayerMove = _player_Body_front_3;
                else if (_nowplayerMove == _player_Body_front_3)
                    _nowplayerMove = _player_Body_front_4;
                else if (_nowplayerMove == _player_Body_front_4)
                    _nowplayerMove = _player_Body_front_5;
                else if (_nowplayerMove == _player_Body_front_5)
                    _nowplayerMove = _player_Body_front_6;
                else if (_nowplayerMove == _player_Body_front_6)
                    _nowplayerMove = _player_Body_front_7;
                else if (_nowplayerMove == _player_Body_front_7)
                    _nowplayerMove = _player_Body_front_8;
                else if (_nowplayerMove == _player_Body_front_8)

                    _nowplayerMove = _player_Body_front_9;
                else if (_nowplayerMove == _player_Body_front_9)
                    _nowplayerMove = _player_Body_front_0;

                if (_playerMove == PlayerMove.Up && _position.Y <= 320)
                {
                    _position.Y += _speed;
                    //if (_playerShoot != PlayerShoot.Stop)
                    //    _nowplayerShoot = _player_head_frond;
                }
                else if (_playerMove == PlayerMove.Down && _position.Y >= 30)
                {
                    _position.Y -= _speed;
                    //if (_playerShoot != PlayerShoot.Stop)
                    //    _nowplayerShoot = _player_head_Back_Shoot;
                }
                else if (_playerMove == PlayerMove.Left && _position.X <= 720)
                {
                    _position.X += _speed;
                    //if (_playerShoot != PlayerShoot.Stop)
                    //    _nowplayerShoot = _player_head_Left;
                }
                else if (_playerMove == PlayerMove.Right && _position.X >= 70)
                {
                    _position.X -= _speed;
                    //if (_playerShoot != PlayerShoot.Stop)
                    //    _nowplayerShoot = _player_head_Right;
                }
                    
            }

        }

        public Tears Shoot(bool trueshoot)
        {
            Tears _tear = new Tears(0);
            if (_playerShoot == PlayerShoot.Stop)
            {
                _nowplayerShoot = _player_head_frond;
            }
            else if (_playerShoot == PlayerShoot.Up)
            {
                if (trueshoot == false)
                    _nowplayerShoot = _player_head_frond;
                else
                {
                    _nowplayerShoot = _player_head_frond_Shoot;
                    _tear.Shoot(_position, (int)(_nowplayerShoot.Width*_size), (int)(_nowplayerShoot.Height*_size), _playerShoot);
                    _tear._Direction = _playerShoot;
                }
            }
            else if (_playerShoot == PlayerShoot.Down)
            {
                if (trueshoot == false)
                    _nowplayerShoot = _player_head_Back;
                else
                {
                    _nowplayerShoot = _player_head_Back_Shoot;
                    _tear.Shoot(_position, (int)(_nowplayerShoot.Width * _size), (int)(_nowplayerShoot.Height * _size), _playerShoot);
                    _tear._Direction = _playerShoot;
                }
            }
            else if (_playerShoot == PlayerShoot.Right)
            {
                if (trueshoot == false)
                    _nowplayerShoot = _player_head_Right;
                else
                {
                    _nowplayerShoot = _player_head_Right_Shoot;
                    _tear.Shoot(_position, (int)(_nowplayerShoot.Width * _size), (int)(_nowplayerShoot.Height * _size), _playerShoot);
                    _tear._Direction = _playerShoot;
                }
            }
            else if (_playerShoot == PlayerShoot.Left)
            {
                if (trueshoot == false)
                    _nowplayerShoot = _player_head_Left;
                else
                {
                    _nowplayerShoot = _player_head_Left_Shoot;
                    _tear.Shoot(_position, (int)(_nowplayerShoot.Width * _size), (int)(_nowplayerShoot.Height * _size), _playerShoot);
                    _tear._Direction = _playerShoot;
                }
            }
            return _tear;
        }
        #endregion

        #region 攻击判定

        SoundPlayer _Sound_hurt = new SoundPlayer("sounds\\hurt grunt .wav");
        SoundPlayer _Sound_player_died = new SoundPlayer("sounds\\isaac dies new.wav");

        public void hurt()
        {
            _hp -= 1;
            _Sound_hurt.Play();
        }
        public Boolean ifGameOver()
        {
            if (_hp <= 0)
            {
                _Sound_player_died.Play();
                return true;
            }
            return false;
        }
        //是否收到攻击
        public Boolean ifTakeDMG(Bitmap _tear, Point _player)
        {
            int x1 = _position.X;
            int y1 = _position.Y;
            int w1 = (int)(_tear.Width * _size);
            int h1 = (int)(_tear.Height * _size / 2);

            int x2 = _player.X;
            int y2 = _player.Y;
            int w2 = _tear.Width;
            int h2 = _tear.Height;

            if (x1 + w1 > x2 && x2 + w2 > x1 && y1 + h1 > y2 && y2 + h2 > y1)
                return true;
            else return false;
        }
        #endregion

        public void creat()
        {
            _hp = _hp_B;
            _position = new Point(400, 200);
            _ifHurt = false;
        }
    }
}

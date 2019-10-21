using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Drawing;

namespace The_Binding_of_Isaac_Rebirth
{
    class Tears
    {

        private double _size = 1;
        private int _speed = 10;
        private Point _position = new Point(200, 200);
        private side _side = side.enemy;
        private Player.PlayerShoot _direction = Player.PlayerShoot.Down;
        private Bitmap _tear_0 = new Bitmap("Image\\Tears\\tear_0.png");
        private Bitmap _tear_boss = new Bitmap("Image\\Tears\\tear_Boss.png");
        private double _size_B = 1;
        private int _speed_B = 5;
        private Bitmap _nowTear;
        private SoundPlayer _sound_Shoot = new SoundPlayer("sounds\\blood.wav");




        public double _Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public int _Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Point _Position
        {
            get { return _position; }
            set { _position = value; }
        }
        internal side _Side
        {
            get { return _side; }
            set { _side = value; }
        }
        internal Player.PlayerShoot _Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        public Bitmap _Tear_0
        {
            get { return _tear_0; }
            set { _tear_0 = value; }
        }
        public enum side
        {
            player = 0, enemy = 1
        }
        public Tears(side Side)
        {
            _side = Side;
        }
        public void Shoot(Point _Position, int Width, int Height, Player.PlayerShoot _playerShoot)
        {
            _sound_Shoot.Play();
            _nowTear = _tear_0;
            if (_playerShoot == Player.PlayerShoot.Up)
                _position = new Point(_Position.X + (Width) / 2 - _tear_0.Width/2, _Position.Y + Height);
            else if (_playerShoot == Player.PlayerShoot.Down)
                _position = new Point(_Position.X + (Width)/ 2 - _tear_0.Width/2, _Position.Y);
            else if (_playerShoot == Player.PlayerShoot.Left)
                _position = new Point(_Position.X - _tear_0.Width, _Position.Y + Height / 2);
            else if (_playerShoot == Player.PlayerShoot.Right)
                _position = new Point(_Position.X + Width, _Position.Y + Height / 2);
        }
        public void ShootBoss(Point _p, Player.PlayerShoot _d)
        {
            _position = _p;
            _direction = _d;
            _nowTear = _tear_boss;
        }
        public void DrawTears(Graphics g)
        {
            if (_side == side.enemy)
            {
                _nowTear = _tear_boss;
                _tear_boss.MakeTransparent(Color.Blue);
                _speed_B = 5;
                _size_B = 1;
            }
            else
            {
                _nowTear = _tear_0;
                _tear_0.MakeTransparent(Color.Red);
                _size_B = _size;
                
            }
            g.DrawImage(_nowTear, new Rectangle(_position.X, _position.Y, (int)((double)_nowTear.Width * _size_B * 1.0), (int)((double)_nowTear.Height * _size_B * 1.0)));
        }
        public void Move()
        {
            if (_side == side.player)
            {
                _speed_B = _speed;
            }
            else if (_side == side.enemy)
            {
                _speed_B = 5;
            }
            if (_direction == Player.PlayerShoot.Up )
                if(_position.Y <= 380)
                    _position.Y += _speed_B;
                else _direction = Player.PlayerShoot.Stop;
            else if (_direction == Player.PlayerShoot.Down  )
                if(_position.Y>=40)
                    _position.Y -= _speed_B;
                else _direction = Player.PlayerShoot.Stop;
            else if (_direction == Player.PlayerShoot.Left)
                if (_position.X >= 70)
                    _position.X -= _speed_B;
                else _direction = Player.PlayerShoot.Stop;
            else if (_direction == Player.PlayerShoot.Right)
                if(_position.X <= 760)
                    _position.X += _speed_B;
                else _direction = Player.PlayerShoot.Stop;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;

namespace The_Binding_of_Isaac_Rebirth
{
    class enemy
    {
        private int _hp_B = 10;
        private int _hp;
        private double _size;
        private Point _position;
        private Bitmap _nowenemy;



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
        public double _Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public Point _Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Bitmap _Nowenemy
        {
            get { return _nowenemy; }
            set { _nowenemy = value; }
        }
        public void Drawenemy(Graphics g)
        {
            g.DrawImage(_nowenemy, new Rectangle(_position.X, _position.Y, (int)((double)_nowenemy.Width * _size), (int)((double)_nowenemy.Height * _size)));
        }
        public Boolean ifMakeDMG(Bitmap _nowplayer, Point _player)
        {
            int x1 = _position.X;
            int y1 = _position.Y;
            int w1 = (int)(_nowenemy.Width*_size);
            int h1 = (int)(_nowenemy.Height*_size/2);

            int x2 = _player.X;
            int y2 = _player.Y;
            int w2 = _nowplayer.Width;
            int h2 = _nowplayer.Height;

            if (x1 + w1 > x2 && x2 + w2 > x1 && y1 + h1 > y2 && y2 + h2 > y1)
                return true;
            else return false;
        }
        public void hurt(int _dmg)
        {
            _hp -= _dmg;
        }
        public Boolean ifBossDied()
        {
            if (_hp <= 0) return true;
            return false;
        }
    }




    class boss_0 : enemy
    {
        private Bitmap _boss_0 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_0.png");
        private Bitmap _boss_1 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_1.png");
        private Bitmap _boss_2 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_2.png");
        private Bitmap _boss_3 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_3.png");
        private Bitmap _boss_4 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_4.png");
        private Bitmap _boss_5 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_5.png");
        private Bitmap _boss_6 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_6.png");
        private Bitmap _boss_7 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_7.png");
        private Bitmap _boss_8 = new Bitmap("Image\\Boss\\monstro\\boss_monstro_8.png");

        private SoundPlayer _sound_play = new SoundPlayer("sounds\\maw of the void.wav");
        private bool _sound = true;

        public void creat()
        {
            _boss_0.MakeTransparent(Color.Red);
            _boss_1.MakeTransparent(Color.Red);
            _boss_2.MakeTransparent(Color.Red);
            _boss_3.MakeTransparent(Color.Red);
            _boss_4.MakeTransparent(Color.Red);
            _boss_5.MakeTransparent(Color.Red);
            _boss_6.MakeTransparent(Color.Red);
            _boss_7.MakeTransparent(Color.Red);
            _boss_8.MakeTransparent(Color.Red);

            _Hp = 10;
            _Nowenemy = _boss_2;
            _Position = new Point(200, 200);
            _Size = 2.5;
        }
        public void attackWay(int _way,int _time)
        {
            
            if(_way == 0)
            {
                if (_time <= 500) _Nowenemy = _boss_0;
                else if (_time <= 1000) _Nowenemy = _boss_1;
                else if (_time <= 2000) _Nowenemy = _boss_3;
                else _Nowenemy = _boss_2;
            }
            else if (_way == 1)
            {
                if (_time <= 500)
                {
                    _Nowenemy = _boss_4;
                    if(_sound == true)
                    {
                        _sound_play.Play();
                        _sound = false;
                    }
                }
                else if (_time <= 1000) _Nowenemy = _boss_6;
                else if (_time <= 3000) _Nowenemy = _boss_5;
                else
                {
                    _Nowenemy = _boss_2;
                    _sound = true;
                }
            }
        }

        public Tears shoot(Point _p, Player.PlayerShoot _d)
        {
            Tears _tear = new Tears(Tears.side.enemy);
            _tear._Position = _p;
            _tear._Direction = _d;
            return _tear;
        }
    }
}

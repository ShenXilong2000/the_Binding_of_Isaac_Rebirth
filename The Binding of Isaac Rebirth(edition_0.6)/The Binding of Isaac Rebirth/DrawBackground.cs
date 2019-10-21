using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Binding_of_Isaac_Rebirth
{

    class DrawBackground
    {
        #region 属性
        //窗口宽度
        private double _widthBackground;
        public double _WidthBackground
        {
            get { return _widthBackground; }
            set { _widthBackground = value; }
        }

        //窗口高度
        private double _heightBackground;
        public double _HeightBackground
        {
            get { return _heightBackground; }
            set { _heightBackground = value; }
        }

        //宽度缩放倍率
        double _widthB;
        //宽度缩放倍率
        double _heightB;

        bool _titleChange = true;

        public bool _TitleChange
        {
            get { return _titleChange; }
            set { _titleChange = value; }
        }

        #endregion


        #region title
        private Bitmap title_background = new Bitmap("Image\\titlemenu\\title_background.png");
        private Bitmap title_ISAAC = new Bitmap("Image\\titlemenu\\title_ISAAC.png");
        private Bitmap title_PREE_STATRT_1 = new Bitmap("Image\\titlemenu\\title_PREE_START(1).png");
        private Bitmap title_PREE_STATRT_2 = new Bitmap("Image\\titlemenu\\title_PREE_START(2).png");



        //画标题
        public void DrawTitle(Graphics g)
        {
            _widthB = _widthBackground / title_background.Width;
            _heightB = _heightBackground / title_background.Height;

            g.DrawImage(title_background, new Rectangle(0, 0, (int)_widthBackground, (int)_heightBackground));
            if(_titleChange == true)
                g.DrawImage(title_PREE_STATRT_1,new Rectangle((int)(_widthBackground / 3),(int)(_heightBackground / 2.6), (int)((double)title_PREE_STATRT_1.Width*_widthB*1),(int)((double)title_PREE_STATRT_1.Height*_heightB*1.0)));
            else
                g.DrawImage(title_PREE_STATRT_2,new Rectangle((int)(_widthBackground / 3),(int)(_heightBackground / 2.6), (int)((double)title_PREE_STATRT_1.Width*_widthB*1),(int)((double)title_PREE_STATRT_1.Height*_heightB*1.0)));
            g.DrawImage(title_ISAAC, new Rectangle((int)(_widthBackground / 4.3), (int)(_heightBackground / 11),(int)((double) title_ISAAC.Width * _widthB *1.0),(int)((double) title_ISAAC.Height * _heightB*1.0)));

        }
        #endregion

        #region menu
        private Bitmap menu_background = new Bitmap("Image\\gamemenu\\gamemenu_background.png");
        private Bitmap menu_Array = new Bitmap("Image\\gamemenu\\Array.png");
        private Bitmap menu_Continue_1 = new Bitmap("Image\\gamemenu\\Continue(1).png");
        private Bitmap menu_Continue_2 = new Bitmap("Image\\gamemenu\\Continue(2).png");
        private Bitmap menu_New_Run = new Bitmap("Image\\gamemenu\\New_Run.png");
        private Bitmap menu_Test = new Bitmap("Image\\gamemenu\\Test.png");

        //画菜单
        public void DrawMenu(Graphics g ,int _playerChoose)
        {
            _widthB = _widthBackground / menu_background.Width;
            _heightB = _heightBackground / menu_background.Height;

            g.DrawImage(menu_background, new Rectangle(0, 0,(int)_widthBackground, (int)_heightBackground));
            g.DrawImage(menu_New_Run, new Rectangle((int)(_widthBackground / 2.8), (int)(_heightBackground / 7), (int)((double)menu_New_Run.Width * _widthB * 1.2), (int)((double)menu_New_Run.Height * _heightB * 1.2)));
            g.DrawImage(menu_Continue_2, new Rectangle((int)(_widthBackground / 2.6), (int)(_heightBackground / 3), (int)((double)menu_Continue_2.Width * _widthB * 1.2), (int)((double)menu_Continue_2.Height * _heightB * 1.2)));
            g.DrawImage(menu_Test, new Rectangle((int)(_widthBackground / 2.5), (int)(_heightBackground / 1.8),(int)((double)menu_Test.Width * _widthB * 1.2) , (int)((double)menu_Test.Height*_heightB*1.2)));
            //绘制选择箭头
            if (_playerChoose == 0)
                g.DrawImage(menu_Array, new Rectangle((int)(_widthBackground / 3.3), (int)(_heightBackground / 4.6), (int)((double)menu_Array.Width* _widthB*1.2) ,(int)((double)menu_Array.Height*_heightB*1.2)));
            else if(_playerChoose == 1)
                g.DrawImage(menu_Array, new Rectangle((int)(_widthBackground / 3.1), (int)(_heightBackground / 2.5), (int)((double)menu_Array.Width * _widthB * 1.2), (int)((double)menu_Array.Height * _heightB * 1.2)));
            else if(_playerChoose == 2)
                g.DrawImage(menu_Array, new Rectangle((int)(_widthBackground / 2.9), (int)(_heightBackground / 1.65), (int)((double)menu_Array.Width * _widthB * 1.2), (int)((double)menu_Array.Height * _heightB * 1.2)));
        }
        #endregion

        #region backdrop
        private Bitmap _back_0 = new Bitmap("Image\\backdrop\\Back_.png");

        public void DrawBackdrop(Graphics g)
        {
            g.DrawImage(_back_0, new Rectangle(0, 0, (int)_widthBackground, (int)_heightBackground));
        }

        #endregion

        #region Gameover
        private Bitmap _gameover = new Bitmap("Image\\gamemenu\\gameover.png");
        private Bitmap _youDied = new Bitmap("Image\\gamemenu\\YOU_DIED.png");

        public void DrawGameOver(Graphics g)
        {
            _gameover.MakeTransparent(Color.White);
            _youDied.MakeTransparent(Color.White);
            g.DrawImage(_gameover, new Rectangle(200, 150, _gameover.Width * 1, _gameover.Height * 1));
            g.DrawImage(_youDied, new Rectangle(240, 220, _youDied.Width * 2, _youDied.Height * 2));
        }

        #endregion

        #region youWin
        private Bitmap _youWin = new Bitmap("Image\\gamemenu\\YOU_WIN.png");
        private Bitmap _back = new Bitmap("Image\\gamemenu\\Back.png");

        public void DrawYouWin(Graphics g,int _playerChoose)
        {
            _gameover.MakeTransparent(Color.White);
            menu_Continue_1.MakeTransparent(Color.White);
            menu_Array.MakeTransparent(Color.White);
            _back.MakeTransparent(Color.White);
            _youWin.MakeTransparent(Color.White);


            g.DrawImage(_gameover, new Rectangle(200, 150, _gameover.Width * 1, _gameover.Height * 1));
            g.DrawImage(_youWin, new Rectangle(280, 170, _youWin.Width * 2, _youWin.Height * 2));
            g.DrawImage(_back, new Rectangle(240, 300, (int)(_back.Width * 1.5),(int)( _back.Height * 1.5)));
            g.DrawImage(menu_Continue_1, new Rectangle(400, 280,(int)( menu_Continue_1.Width * 1.5),(int)( menu_Continue_1.Height * 1.5)));
            //绘制选择箭头
            if (_playerChoose == 3)
                g.DrawImage(menu_Array, new Rectangle(200, 305, (int)((double)menu_Array.Width  * 2), (int)((double)menu_Array.Height * 2)));
            else if(_playerChoose == 1)
                g.DrawImage(menu_Array, new Rectangle(370, 305, (int)((double)menu_Array.Width * 2), (int)((double)menu_Array.Height * 2)));

        }

        #endregion

        #region next

        private Bitmap _option = new Bitmap("Image\\gamemenu\\option.png");
        private Bitmap _speed_Up = new Bitmap("Image\\gamemenu\\SPEED.png");
        private Bitmap _DMG_Up = new Bitmap("Image\\gamemenu\\DMGUP.png");
        private Bitmap _HP_Up = new Bitmap("Image\\gamemenu\\HP.png");

        public void Draw_playerUP(int _playerUP, Graphics g)
        {
            _option.MakeTransparent(Color.White);
            _speed_Up.MakeTransparent(Color.White);
            _DMG_Up.MakeTransparent(Color.White);
            _HP_Up.MakeTransparent(Color.White);
            menu_Array.MakeTransparent(Color.White);

            g.DrawImage(_option, new Rectangle(280, 120, (int)(_option.Width * 1.3), (int)(_option.Height * 1.3)));
            g.DrawImage(_DMG_Up, new Rectangle(350, 165, (int)(_DMG_Up.Width * 1.5), (int)(_DMG_Up.Height * 1.5)));
            g.DrawImage(_speed_Up, new Rectangle(350, 250, (int)(_speed_Up.Width * 1.5), (int)(_speed_Up.Height * 1.5)));
            g.DrawImage(_HP_Up, new Rectangle(350, 340, (int)(_HP_Up.Width * 1.5), (int)(_HP_Up.Height * 1.5)));

            if(_playerUP == 0)
                g.DrawImage(menu_Array, new Rectangle(300, 180, (int)((double)menu_Array.Width * 2), (int)((double)menu_Array.Height * 2)));
            else if(_playerUP == 1)
                g.DrawImage(menu_Array, new Rectangle(300, 250,(int)((double)menu_Array.Width * 2), (int)((double)menu_Array.Height * 2)));
            else if (_playerUP == 2)
                g.DrawImage(menu_Array, new Rectangle(300, 340, (int)((double)menu_Array.Width * 2), (int)((double)menu_Array.Height * 2)));

        }
        

        #endregion

        #region 隐藏
        public void Transsprent()
        {
            //隐藏白色区域
            menu_background.MakeTransparent(Color.White);
            menu_Continue_1.MakeTransparent(Color.White);
            menu_Continue_2.MakeTransparent(Color.White);
            menu_New_Run.MakeTransparent(Color.White);
            menu_Array.MakeTransparent(Color.White);
            menu_Test.MakeTransparent(Color.White);

            //隐藏白色区域
            title_background.MakeTransparent(Color.White);
            title_ISAAC.MakeTransparent(Color.White);
            title_PREE_STATRT_1.MakeTransparent(Color.White);
            title_PREE_STATRT_2.MakeTransparent(Color.White);
            _back_0.MakeTransparent(Color.White);
        }

        #endregion
    }
}

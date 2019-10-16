using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Binding_of_Isaac_Rebirth
{

    class DrawBackground
    {

        //窗口宽度
        double _widthBackground;
        public double _WidthBackground
        {
            get { return _widthBackground; }
            set { _widthBackground = value; }
        }

        //窗口高度
        double _heightBackground;
        public double _HeightBackground
        {
            get { return _heightBackground; }
            set { _heightBackground = value; }
        }

        //宽度缩放倍率
        double _widthB;
        //宽度缩放倍率
        double _heightB;

        #region title
        private Bitmap title_background = new Bitmap("Image\\titlemenu\\title_background.png");
        private Bitmap title_ISAAC = new Bitmap("Image\\titlemenu\\title_ISAAC.png");
        private Bitmap title_PREE_STATRT_1 = new Bitmap("Image\\titlemenu\\title_PREE_START(1).png");
        private Bitmap title_PREE_STATRT_2 = new Bitmap("Image\\titlemenu\\title_PREE_START(1).png");

        //画标题
        public void DrawTitle(Graphics g)
        {
            //隐藏白色区域
            title_background.MakeTransparent(Color.White);
            title_ISAAC.MakeTransparent(Color.White);
            title_PREE_STATRT_1.MakeTransparent(Color.White);
            title_PREE_STATRT_2.MakeTransparent(Color.White);

            _widthB = _widthBackground / title_background.Width;
            _heightB = _heightBackground / title_background.Height;

            g.DrawImage(title_background, new Rectangle(0, 0, (int)_widthBackground, (int)_heightBackground));
            g.DrawImage(title_PREE_STATRT_1,new Rectangle((int)(_widthBackground / 3),(int)(_heightBackground / 3), (int)((double)title_PREE_STATRT_1.Width*_widthB*1),(int)((double)title_PREE_STATRT_1.Height*_heightB*1.0)));
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
            //隐藏白色区域
            menu_background.MakeTransparent(Color.White);
            menu_Continue_1.MakeTransparent(Color.White);
            menu_Continue_2.MakeTransparent(Color.White);
            menu_New_Run.MakeTransparent(Color.White);
            menu_Array.MakeTransparent(Color.White);
            menu_Test.MakeTransparent(Color.White);

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
    }
}

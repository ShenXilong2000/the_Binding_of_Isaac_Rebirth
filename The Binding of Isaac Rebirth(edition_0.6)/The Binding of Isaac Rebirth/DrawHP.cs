using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace The_Binding_of_Isaac_Rebirth
{
    class DrawHP
    {
        private Bitmap _hpPlayer_0 = new Bitmap("Image\\HP\\heatrs\\HP_0.png");
        private Bitmap _hpPlayer_1 = new Bitmap("Image\\HP\\heatrs\\HP_1.png");
        private Bitmap _hpPlayer_2 = new Bitmap("Image\\HP\\heatrs\\HP_2.png");

        private Bitmap _hpBoss_0 = new Bitmap("Image\\HP\\bosshealthbar\\bosshealthbar_0.png");
        private Bitmap _hpBoss_1 = new Bitmap("Image\\HP\\bosshealthbar\\bosshealthbar_1.png");

        public void Draw_playerHp(int _hp,int _hp_B,Graphics g)
        {
            _hpPlayer_2.MakeTransparent(Color.White);
            _hpPlayer_1.MakeTransparent(Color.White);
            _hpPlayer_0.MakeTransparent(Color.White);


            //心之间的间隔
            int jiange = 35;
            Point _p = new Point(20,15);
            if (_hp_B > 20) _hp_B = 20;
            for (int i = 1; i <= (_hp_B + 1) / 2; i++)
            {
                if (_hp - i * 2 >= 0) g.DrawImage(_hpPlayer_2, new Rectangle(_p.X + (i - 1) * jiange, _p.Y, _hpPlayer_2.Width * 3, _hpPlayer_2.Height * 3));
                else if (_hp - i * 2 == -1) g.DrawImage(_hpPlayer_1, new Rectangle(_p.X + (i - 1) * jiange, _p.Y, _hpPlayer_1.Width * 3, _hpPlayer_1.Height * 3));
                else if (_hp - i * 2 < -1) g.DrawImage(_hpPlayer_0, new Rectangle(_p.X + (i - 1) * jiange, _p.Y, _hpPlayer_0.Width * 3, _hpPlayer_0.Height * 3));
            }
        }

        public void Draw_BossHp(int _hp,int _hp_B, Graphics g)
        {
            _hpBoss_0.MakeTransparent(Color.White);
            _hpBoss_1.MakeTransparent(Color.White);
            //剩余血量百分数
            double lastHp =(double)_hp / (double)_hp_B;
            Point _p = new Point(200, 400);
            g.DrawImage(_hpBoss_0, new Rectangle(_p.X, _p.Y, _hpBoss_0.Width * 3, _hpBoss_0.Height * 3));
            g.DrawImage(_hpBoss_1, new Rectangle(_p.X+55, _p.Y+10, (int)((double)_hpBoss_1.Width * 3.3 * lastHp), _hpBoss_1.Height * 3));
        }

    }
}

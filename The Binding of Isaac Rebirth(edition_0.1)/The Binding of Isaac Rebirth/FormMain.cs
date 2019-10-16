using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace The_Binding_of_Isaac_Rebirth
{
    public partial class FormMain : Form
    {

        BufferedGraphicsContext _bufGraphCont = null;
        BufferedGraphics _bufGraph = null;


        //游戏状态
        public enum gameState
        {
            title = 0, menu = 1, open = 2, stop = 3 
        }
        //游戏菜单选择
        public enum menuChoose
        {
            New_Run = 0, Continue = 1, Test = 2
        }

        private gameState _nowgame = gameState.title;
        private menuChoose _playerChoose = menuChoose.New_Run;
        private DrawBackground _drawdg = new DrawBackground();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _bufGraphCont = BufferedGraphicsManager.Current;
            _bufGraph = _bufGraphCont.Allocate(panelBackground.CreateGraphics(), panelBackground.ClientRectangle);
            _bufGraph.Graphics.Clear(Color.White);
            //_bufGraph.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private void panelBackground_Paint(object sender, PaintEventArgs e)
        {
            
            _drawdg._WidthBackground = this.panelBackground.Width;
            _drawdg._HeightBackground = this.panelBackground.Height;
            if (_nowgame == gameState.title)
                _drawdg.DrawTitle(_bufGraph.Graphics);
            else if (_nowgame == gameState.menu)
                _drawdg.DrawMenu(_bufGraph.Graphics, (int)_playerChoose);
            _bufGraph.Render(panelBackground.CreateGraphics());
            //测试
            //_drawdg.DrawMenu(e.Graphics,(int)_playerChoose);
           // _buffergra.Render(panelBackground.CreateGraphics());
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            //进入菜单
            if (_nowgame == gameState.title && (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter))
            {
                _nowgame = gameState.menu;
                panelBackground.Invalidate();
            }
            //选择菜单选项
            else if (_nowgame == gameState.menu)
            {
                //进入游戏
                if (e.KeyCode == Keys.Enter)
                {
                    _nowgame = gameState.open;
                    //panelBackground.Invalidate();
                }
                else if (e.KeyCode == Keys.Down && _playerChoose == menuChoose.New_Run)
                {
                    _playerChoose = menuChoose.Continue;
                    panelBackground.Invalidate();
                }
                else if (e.KeyCode == Keys.Down && _playerChoose == menuChoose.Continue)
                {
                    _playerChoose = menuChoose.Test;
                    panelBackground.Invalidate();
                }
                else if (e.KeyCode == Keys.Up && _playerChoose == menuChoose.Test)
                {
                    _playerChoose = menuChoose.Continue;
                    panelBackground.Invalidate();
                }
                else if(e.KeyCode == Keys.Up && _playerChoose == menuChoose.Continue)
                {
                    _playerChoose = menuChoose.New_Run;
                    panelBackground.Invalidate();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    _nowgame = gameState.title;
                    panelBackground.Invalidate();
                }
            }

        }
    }
}

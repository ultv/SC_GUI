using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    public partial class Form1 : Form
    {
        static Game game;

        public Form1()
        {            
            InitializeComponent();
            Width = 300;
            Height = 520;
            panelAccount.Top = 40;
            panelAccount.Left = 20;

            game = new Game(panelGame, 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static public void Button_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            SetBtnText(game, btn);

            int position = Int32.Parse(btn.Name);
            game.GameField.ReviseRows(position);
            game.GameField.ReviseCols(position);
            game.GameField.ReviseMainDiag(position);
            game.GameField.ReviseSecDiag(position);

            /// labelFocus.Focus();
        }

        // Поочерёдная установка "крестик" или "нолик".
        static private void SetBtnText(Game game, Button btn)
        {
            if (game.PrevX)
            {
                btn.Text = "O";
                game.PrevX = false;
            }
            else
            {
                btn.Text = "X";
                game.PrevX = true;
            }

            btn.Enabled = false;            
        }

        static public void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            HelpBtnText(game, btn);            
        }

        // Подсветка кнопок при наведении курсора.
        static private void HelpBtnText(Game game, Button btn)
        {
            if (game.PrevX)
            {
                btn.Text = "O";
            }
            else
            {
                btn.Text = "X";
            }
        }

        // Покидание курсором границ кнопки.
        static public void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Enabled)
            {
                btn.Text = "";
            }
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();           
        }
    }
}

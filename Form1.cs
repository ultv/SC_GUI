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
            game = new Game(this, 3);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static public void buttonIJ_Click(object sender, EventArgs e)
        {
            ButtonIJ btn = ((ButtonIJ)sender);

            btn.SetBtnText(game);           

            game.GameField.ReviseRows(btn.I);
            game.GameField.ReviseCols(btn.J);
            game.GameField.ReviseMainDiag(btn.I, btn.J);
            game.GameField.ReviseSecDiag(btn.I, btn.J);

        }

        // Наведение курсора на кнопку.
        static public void buttonIJ_MouseEnter(object sender, EventArgs e)
        {
            ButtonIJ btn = (ButtonIJ)sender;

            btn.GetBtnText(game);
                                    
        }

        // Покидание курсором границ кнопки.
        static public void buttonIJ_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Enabled)
            {
                btn.Text = "";
            }

        }
    }
}

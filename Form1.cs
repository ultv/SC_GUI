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
            ButtonIJ presBtn = ((ButtonIJ)sender);

            presBtn.SetBtnText(game);

            game.GameField.ReviseRows(presBtn.I);
            game.GameField.ReviseCols(presBtn.J);
            game.GameField.ReviseMainDiag(presBtn.I, presBtn.J);
            game.GameField.ReviseSecDiag(presBtn.I, presBtn.J);

        }
    }
}

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

        public delegate void Start();
        public event Start StartGame;

        public Form1()
        {
            game = new Game(this, 3);
            InitializeComponent();
            StartGame += ShowPanelButtonIJ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static public void buttonIJ_Click(object sender, EventArgs e)
        {
            ButtonIJ btn = ((ButtonIJ)sender);

            btn.SetBtnText(game);
            game.DecStep();
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

        private void buttonComeIn_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonRegistrate.Enabled = true;
        }

        private void buttonRegistrate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;

            if (labelPlayer1.Enabled == true)
            {                
                game.Players[0].Name = name;
                textBoxName.Clear();
                labelPlayer1.Enabled = false;
                labelPlayer2.Enabled = true;

                ToolStripLabel infoPlayer1 = new ToolStripLabel();
                infoPlayer1.Text += "Игрок 1: " + name;
                statusStripInfo.Items.Add(infoPlayer1);                
            }
            else
            {
                game.Players[1].Name = name;
                panelAccount.Visible = false;

                ToolStripLabel infoPlayer2 = new ToolStripLabel();
                infoPlayer2.Text += "Игрок 2: " + name;
                statusStripInfo.Items.Add(infoPlayer2);

                StartGame();
            }            
        }

        public void ShowPanelButtonIJ()
        {
            game.GameField.panelButtonIJ.Visible = true;
        }
    }
}

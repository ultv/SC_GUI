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
        Players players;

        //public delegate void Start(Label player, Label victory);
        //static public event Start StartGame;

        public Form1()
        {            
            InitializeComponent();
            Width = 300;
            Height = 520;
            panelAccount.Top = 40;
            panelAccount.Left = 20;

            game = new Game(this, panelBtns, 3);
            game.GameField.NowEquality += FinalyGame;

            players = new Players();
            players = players.LoadJSON();

            foreach (Player pl in players.PlayerS)
            {
                comboBoxName.Items.Add(pl.Name);
            }
            comboBoxName.Enabled = true;
            comboBoxName.Text = comboBoxName.Items[0].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Button_Click(object sender, EventArgs e)
        {
            
            Button btn = ((Button)sender);
            SetBtnText(game, btn);                        

            int position = Int32.Parse(btn.Name);
            game.Steps[game.HowStep] = position;

            game.GameField.ReviseRows(position);
            game.GameField.ReviseCols(position);
            game.GameField.ReviseMainDiag(position);
            game.GameField.ReviseSecDiag(position);

            labelFocus.Focus();

            // Пока идёт игра - результат принимаем за ничейный.
            if (game.NameVictory == "Ничья")
            {
                game.ChangePlaying();
                labelNamePlayer.Text = game.Players[game.NowPlaying].Name;
            }            
            
            game.IncStep();

            
            if (game.Repeat && game.NameVictory == "Ничья")
            {
                //System.Threading.Thread.Sleep(1000); /// Не подходит - "Скрывается" имя игрока.                
                MessageBox.Show("Смотреть следующий ход.");
            }
            
        }

        // Поочерёдная установка "крестик" или "нолик".
        private void SetBtnText(Game game, Button btn)
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

        public void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);

            HelpBtnText(game, btn);            
        }

        // Подсветка кнопок при наведении курсора.
        private void HelpBtnText(Game game, Button btn)
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
        public void Button_MouseLeave(object sender, EventArgs e)
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonRegistrate.Enabled = true;
        }

        private void buttonRegistrate_Click(object sender, EventArgs e)
        {
            if(labelPlayer1.Enabled)
            {
                game.Players[0].Name = textBoxName.Text;
                players.PlayerS.Add(game.Players[0]);

                ToolStripLabel infoGamer1 = new ToolStripLabel();
                infoGamer1.Text += "Игрок 1: " + game.Players[0].Name;
                statusStripInfo.Items.Add(infoGamer1);

                labelPlayer1.Enabled = false;
                labelPlayer2.Enabled = true;
                textBoxName.Clear();
                buttonRegistrate.Enabled = false;
            }
            else
            {
                game.Players[1].Name = textBoxName.Text;
                players.PlayerS.Add(game.Players[1]);

                ToolStripLabel infoGamer2 = new ToolStripLabel();
                infoGamer2.Text += "Игрок 2: " + game.Players[1].Name;
                statusStripInfo.Items.Add(infoGamer2);

                InitGame();
                                
            }
        }

        // Подготовка элементов к началу игры.
        public void InitGame()
        {
            panelAccount.Visible = false;
            panelGame.Top = panelAccount.Top;
            panelGame.Left = panelAccount.Left;
            panelGame.Visible = true;

            game.NowPlaying = 0;
            game.NameVictory = "Ничья";            
            game.HowStep = 0;
            labelNamePlayer.Text = game.Players[game.NowPlaying].Name;
            labelNameVictory.Visible = false;
            panelBtns.Enabled = true;
            game.Repeat = false;
            RestoreBtns();
            
        }

        // Действия по завершению игры.
        // На повторе меняется последовательновть имен игроков.
        // Показываем кто сделал ход, а не будет делать.
        public void FinalyGame(string message)
        {
            if(!game.Repeat)
            {
                game.NameVictory = game.Players[game.NowPlaying].Name;
                labelNameVictory.Visible = true;
                labelNameVictory.Text = "Победил: " + game.NameVictory + " !";
            }
            else
            {
                if(game.NameVictory == "Ничья")
                {
                    game.ChangePlaying();
                    labelNamePlayer.Text = game.Players[game.NowPlaying].Name;
                    game.NameVictory = game.Players[game.NowPlaying].Name;
                    labelNameVictory.Visible = true;
                    labelNameVictory.Text = "Победил: " + game.NameVictory + " !";
                }                
            }

            panelBtns.Enabled = false;
            MessageBox.Show(message);
            buttonNewGame.Visible = true;
            buttonNewGame.Focus();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            game.SaveJSON();
            players.SaveJSON();
            InitGame();
        }

        public void RestoreBtns()
        {
            for(int i = 0; i < game.GameField.Size; i++)
            {
                for (int j = 0; j < game.GameField.Size; j++)
                {
                    game.GameField.Cells[i, j].Text = "";
                    game.GameField.Cells[i, j].Enabled = true;
                }
            }
        }      

        // Сохраняем если не повтор и не выход до регистрации.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((game.Players[0].Name != null) && !game.Repeat)
            {
                game.SaveJSON();
                players.SaveJSON();
            }
        }

        private void buttonComeIn_Click(object sender, EventArgs e)
        {
            if (labelPlayer1.Enabled)
            {
                game.Players[0].Name = comboBoxName.Text;
                players.PlayerS.Add(game.Players[0]);

                ToolStripLabel infoGamer1 = new ToolStripLabel();
                infoGamer1.Text += "Игрок 1: " + game.Players[0].Name;
                statusStripInfo.Items.Add(infoGamer1);

                labelPlayer1.Enabled = false;
                labelPlayer2.Enabled = true;
                //textBoxName.Clear();
                //buttonRegistrate.Enabled = false;
            }
            else
            {
                game.Players[1].Name = comboBoxName.Text;
                players.PlayerS.Add(game.Players[1]);

                ToolStripLabel infoGamer2 = new ToolStripLabel();
                infoGamer2.Text += "Игрок 2: " + game.Players[1].Name;
                statusStripInfo.Items.Add(infoGamer2);

                InitGame();

            }
        }

        private void посмотретьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!game.Repeat)
            {
                game.SaveJSON();
            }


            if (openFileDialogGame.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
                
            string path = openFileDialogGame.FileName;

            Game gameRepeat = new Game(this, panelBtns, 3);
            gameRepeat = gameRepeat.LoadJSON(path); /// У загруженного не все параметры Size = null...
            InitGame();
            
            //На повторе показываем игравшего, а не чья очередь.
            game.ChangePlaying();

            game.Players[0].Name = gameRepeat.Players[0].Name;
            game.Players[1].Name = gameRepeat.Players[1].Name;            
            game.Repeat = true;
                       
            panelAccount.Enabled = false;
           
            for(int i = 0; i < gameRepeat.HowStep; i++)
            {                
                int position = gameRepeat.Steps[i];
                int ii = position / 3; /// gameRepeat.GameField.Size /// нету. Брать у Game?
                int jj = position % 3; /// gameRepeat.GameField.Size
               
                game.GameField.Cells[ii, jj].PerformClick();
            }            
        }
    }
}

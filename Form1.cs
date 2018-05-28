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

            if(comboBoxName.Items.Count != 0)
            {
                comboBoxName.Enabled = true;
                comboBoxName.Text = comboBoxName.Items[0].ToString();
                buttonComeIn.Enabled = true;
            }
            
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

                // Пробуем статус второго игрока.
                if(game.Players[game.NowPlaying].Brains != null)
                {
                    game.Players[game.NowPlaying].Brains.PlayingIndenpendently(game, position);
                    NoTextButton(game);
                }
            }

            game.IncStep();

            if (game.Repeat && game.NameVictory == "Ничья")
            {
                //System.Threading.Thread.Sleep(1000); /// Не подходит - "Скрывается" имя игрока.                
                if(game.HowStep != (game.GameField.Size * game.GameField.Size))
                {
                    MessageBox.Show("Смотреть следующий ход.");                    
                }
                else
                {
                    NoVictory("");
                }
            }           
        }

        public void NoVictory(string message)
        {
            buttonNewGame.Visible = true;
            buttonNewGame.Focus();
            посмотретьИгруToolStripMenuItem.Enabled = true;
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

            if (!IsExistName(textBoxName.Text))
            {
                buttonRegistrate.Enabled = true;

                if (statusStripInfo.Items.Count != 0)
                {
                    if (statusStripInfo.Items[statusStripInfo.Items.Count - 1].Text.Contains(" уже зарегистрирован."))
                    {
                        statusStripInfo.Items.RemoveAt(statusStripInfo.Items.Count - 1);
                    }
                }
            }
            else
            {
                buttonRegistrate.Enabled = false;

                ToolStripLabel infoGamerExist = new ToolStripLabel();
                infoGamerExist.Text += textBoxName.Text + " уже зарегистрирован.";
                statusStripInfo.Items.Add(infoGamerExist);
            }
      
        }


        // Возвращает истину если игрок уже зарегистрирован.
        private bool IsExistName(string name)
        {

            foreach (Player p in players.PlayerS)
            {
                if (p.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        private void buttonRegistrate_Click(object sender, EventArgs e)
        {
            if(labelPlayer1.Enabled)
            {
                game.Players[0].Name = textBoxName.Text;
                players.PlayerS.Add(game.Players[0]);

                // Дублируем игроков в базу данных.
                using (var db = new PlayerGameContext())
                {                                  
                    db.PlayersEF.Add(game.Players[0]);                    
                    db.SaveChanges();
                }

                    ToolStripLabel infoGamer1 = new ToolStripLabel();
                infoGamer1.Text += "Игрок 1: " + game.Players[0].Name;
                statusStripInfo.Items.Add(infoGamer1);

                labelPlayer1.Enabled = false;
                labelPlayer2.Enabled = true;
                checkBoxComp.Visible = true;
                textBoxName.Clear();
                buttonRegistrate.Enabled = false;
            }
            else
            {                                
                game.Players[1].Name = textBoxName.Text;
                players.PlayerS.Add(game.Players[1]);

                // Дублируем игроков в базу данных.
                using (var db = new PlayerGameContext())
                {
                    db.PlayersEF.Add(game.Players[1]);
                    db.SaveChanges();
                }

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
            buttonNewGame.Visible = false;
            RestoreBtns();
            посмотретьИгруToolStripMenuItem.Enabled = false;
            checkBoxComp.Visible = false;


        }

        // Действия по завершению игры.
        // На повторе меняется последовательновть имен игроков.
        // Показываем кто сделал ход, а не будет делать.
        public void FinalyGame(string message)
        {
            if(!game.Repeat)
            {
                game.NameVictory = game.Players[game.NowPlaying].Name;
                players.PlayerS[FindIndexByName(game.NameVictory)].CurVic++;
                players.PlayerS[FindIndexByName(game.NameVictory)].TotalVic++;
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
            посмотретьИгруToolStripMenuItem.Enabled = true;
        }

        public int FindIndexByName(string name)
        {
            int index = 0;
            
            foreach (Player p in players.PlayerS)
            {
                if (p.Name == name)
                {            
                    index = players.PlayerS.IndexOf(p);
                }
            }

            return index;
        }


        // Реакция на кнопку - Новая игра.
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            if(!game.Repeat)
            {
                // Сохраняем историю игры в базу данных.
                game.SaveJSON();

                // Дублируем историю игры в базу данных.
                using (var db = new PlayerGameContext())
                {
                    db.GameEF.Add(game);                    
                    db.SaveChanges();
                }
            }
            
            /// players.SaveJSON(); /// результаты нужны. - пусть копятся, сохраним при выходе.


            InitGame();
        }

        // Сброс всех кнопок к исходному состоянию.
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

        // Сохраняем игроков, если была регистрация.
        // Сохраняем игру если ничья с использованием всех ходов или определен победитель.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((game.Players[0].Name != null) && !game.Repeat)
            {
                // Сохраняем список игроков в JSON.
                players.SaveJSON();

                /*
                // Дублируем игроков в базу данных.
                using (var db = new PlayerGameContext())
                {
                    foreach(Player p in players.PlayerS)
                    {
                        db.PlayersEF.Add(p);
                    }

                    db.SaveChanges();
                }                                       
                */

                if ((game.HowStep < 9) && (game.NameVictory == "Ничья"))
                {
                    
                }
                else
                {
                    // Сохраняем историю игры в базу данных.
                    game.SaveJSON();

                    // Дублируем историю игры в базу данных.
                    using (var db = new PlayerGameContext())
                    {                        
                        db.GameEF.Add(game);                        
                        db.SaveChanges();
                    }
                }
            }
        }

        // 
        private void buttonComeIn_Click(object sender, EventArgs e)
        {
            if (labelPlayer1.Enabled)
            {        

                SelectPlayer(0);

                // Помещаем данные игрока на информационную панель.
                ToolStripLabel infoGamer1 = new ToolStripLabel();
                infoGamer1.Text += "Игрок 1: " + game.Players[0].Name;
                statusStripInfo.Items.Add(infoGamer1);

                labelPlayer1.Enabled = false;
                labelPlayer2.Enabled = true;
                checkBoxComp.Visible = true;

            }
            else
            {                
                SelectPlayer(1);

                // Помещаем данные игрока на информационную панель.
                ToolStripLabel infoGamer2 = new ToolStripLabel();
                infoGamer2.Text += "Игрок 2: " + game.Players[1].Name;
                statusStripInfo.Items.Add(infoGamer2);

                // Запускаем игру после формирования обоих игроков.
                InitGame();
            }
        }

        public void SelectPlayer(int num)
        {
            // Берем имя, выбранное в выпадающем списке.
            int index = 0;
            string name = comboBoxName.SelectedItem.ToString();

            // Находим игрока по имени, принимаем в игру, удаляем из списка возможных участников.
            foreach (Player p in players.PlayerS)
            {
                if (p.Name == name)
                {
                    game.Players[num] = p;
                    index = players.PlayerS.IndexOf(p);
                }
            }

            comboBoxName.Items.Remove(name);

            // Обновляем список, если в нем остались игроки.
            if (comboBoxName.Items.Count == 0)
            {
                comboBoxName.Text = "";
                comboBoxName.Enabled = false;
            }
            else
            {
                comboBoxName.Text = comboBoxName.Items[0].ToString();
            }
        }


        private void посмотретьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonNewGame.Visible = false;

            // Сохранение последней перед просмотром.
            if (!game.Repeat)
            {
                if ((game.HowStep < 9) && (game.NameVictory == "Ничья"))
                {

                }
                else
                {
                    // Сохраняем историю игры в JSON.
                    game.SaveJSON();

                    // Дублируем историю игры в базу данных.
                    using (var db = new PlayerGameContext())
                    {
                        db.GameEF.Add(game);
                        db.SaveChanges();
                    }
                }
            } 

            // Выбор файла.
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

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxComp_CheckedChanged(object sender, EventArgs e)
        {
            game.Players[1].Name = "Компьютер";
            game.Players[1].Brains = new Brain();

            ToolStripLabel infoGamer2 = new ToolStripLabel();
            infoGamer2.Text += "Игрок 2: " + game.Players[1].Name;
            statusStripInfo.Items.Add(infoGamer2);

            InitGame();
        }

        ///// Временная заплатка.
        public void NoTextButton(Game game)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game.GameField.Cells[i, j].Enabled)
                    {
                        game.GameField.Cells[i, j].Text = "";
                    }
                }
            }
        }
    }
}

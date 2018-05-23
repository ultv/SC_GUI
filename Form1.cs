using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace CS_GUI
{

    public partial class Form1 : Form
    {
        int numGame = 0;
        int howSteps = 9;
        bool stopGame = false;
        static bool lastX = true;        

        Gamer gamer1;
        Gamer gamer2;
        ListGamers gamers = new ListGamers();
        Button[,] but = new Button[3, 3];

        // Игрок.
        [DataContract]
        public class Gamer
        {
            [DataMember]
            public string Name { get; set; }                        
            [DataMember]
            public int HowTotalVictories { get; set; }
            public int HowCurVictories { get; set; }

            public Gamer(string name)
            {
                Name = name;
                HowCurVictories = 0;
                HowCurVictories = 0;
            }
        }

        // Список игроков.
        [DataContract]
        public class ListGamers
        {
            [DataMember]
            public List<Gamer> Gamers { get; set; }

            public ListGamers()
            {
                Gamers = new List<Gamer>();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }       

        private void Form1_Load(object sender, EventArgs e)
        {            

            LoadJSON();            

            foreach (Gamer gamer in gamers.Gamers)
            {
                nameSelect.Items.Add(gamer.Name);
            }
            nameSelect.Enabled = true;
            nameSelect.Text = nameSelect.Items[0].ToString();
            
        }
        
        // Подготовка элементов формы к началу игры.
        protected void InitGame()
        {

            stopGame = false;
            howSteps = 9;

            nameReg.Visible = false;
            nameSelect.Visible = false;
            btnReg.Visible = false;            
            btnComeIn.Visible = false;
            btnRepeat.Visible = false;
            mVictory.Visible = true;
            mVictory.Text = "";

            labelGamer.Top = 35;
            labelGamer.Visible = true;
            labelGamer.Focus();

            AllNotYesEnabled(true);
            AllBtnClear();

            if (numGame == 0)
            {
                labelGamer.Text = gamer1.Name;
            }
            else
            {
                ChangeName();
            }

            numGame++;
        }

        // Инициализация кнопок.
        protected void InitButton()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    but[i, j] = new Button();
                    but[i, j].Text = "";
                    but[i, j].Top = j * 75 + 100;
                    but[i, j].Left = i * 75 + 65;
                    but[i, j].BackColor = Color.White;
                    but[i, j].Size = new Size(75, 75);
                    but[i, j].Font = new Font("Arial", 40);
                    but[i, j].Click += but_Click;
                    but[i, j].MouseEnter += but_MouseEnter;
                    but[i, j].MouseLeave += but_MouseLeave;
                    this.Controls.Add(but[i, j]);
                }
            }

            labelGamer.Focus();
        }

        // Регистрация нового игрока.
        private void btnReg_Click(object sender, EventArgs e)
        {
            string name = nameReg.Text;

            if (labelGamer.Text == "ИГРОК 1")
            {
                gamer1 = new Gamer(nameReg.Text);
                labelGamer.Text = "ИГРОК 2";
                nameReg.Clear();

                ToolStripLabel infoGamer1 = new ToolStripLabel();
                infoGamer1.Text += "ИГРОК 1: " + name;
                statusInfo.Items.Add(infoGamer1);
            }
            else
            {
                gamer2 = new Gamer(nameReg.Text);
                
                InitButton();
                InitGame();

                ToolStripLabel infoGamer2 = new ToolStripLabel();
                infoGamer2.Text += "ИГРОК 2: " + name;
                statusInfo.Items.Add(infoGamer2);
            }
        }

        // Выбор игрока из списка зарегистрированных.
        private void btnComeIn_Click(object sender, EventArgs e)
        {
            nameReg.Clear();

            if (labelGamer.Text == "ИГРОК 1")
            {

                int index = 0;
                string name = nameSelect.SelectedItem.ToString();

                foreach (Gamer gm in gamers.Gamers)
                {
                    if (gm.Name == name)
                    {
                        gamer1 = gm;
                        index = gamers.Gamers.IndexOf(gm);
                    }
                }

                gamers.Gamers.RemoveAt(index);
                nameSelect.Items.Remove(name);

                if (nameSelect.Items.Count == 0)
                {
                    nameSelect.Text = "";
                    nameSelect.Enabled = false;
                }
                else
                {
                    nameSelect.Text = nameSelect.Items[0].ToString();
                }

                labelGamer.Text = "ИГРОК 2";
                ToolStripLabel infoGamer1 = new ToolStripLabel();
                infoGamer1.Text += "ИГРОК 1: " + name;
                statusInfo.Items.Add(infoGamer1);

            }
            else
            {
                int index = 0;
                string name = nameSelect.SelectedItem.ToString();

                foreach (Gamer gm in gamers.Gamers)
                {
                    if (gm.Name == name)
                    {
                        gamer2 = gm;
                        index = gamers.Gamers.IndexOf(gm);
                    }
                }

                gamers.Gamers.RemoveAt(index);
                nameSelect.Items.Remove(name);
                
                if (nameSelect.Items.Count == 0)
                {
                    nameSelect.Text = "";
                    nameSelect.Enabled = false;
                }
                else
                {
                    nameSelect.Text = nameSelect.Items[0].ToString();
                }


                ToolStripLabel infoGamer2 = new ToolStripLabel();
                infoGamer2.Text += "ИГРОК 2: " + name;
                statusInfo.Items.Add(infoGamer2);

                InitButton();

                InitGame();

            }
        }

        // Запрет повторной регистрации.
        private void nameReg_TextChanged(object sender, EventArgs e)
        {
            if (!IsExistName(nameReg.Text))
            {
                btnReg.Enabled = true;
                
                if(statusInfo.Items.Count != 0)
                {
                    if(statusInfo.Items[statusInfo.Items.Count - 1].Text.Contains(" уже зарегистрирован."))
                    {
                        statusInfo.Items.RemoveAt(statusInfo.Items.Count - 1);
                    }
                }                
            }
            else
            {
                btnReg.Enabled = false;

                ToolStripLabel infoGamerExist = new ToolStripLabel();
                infoGamerExist.Text += nameReg.Text + " уже зарегистрирован.";
                statusInfo.Items.Add(infoGamerExist);
            }
        }

        // Активация кнопки регистрации во время ввода имени игрока.
        private void nameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnComeIn.Enabled = true;
        }

        // Возвращает истину если игрок уже зарегистрирован.
        private bool IsExistName(string name)
        {            
            if(gamer1 != null)
            {
                if ((gamer1.Name == name))
                {
                    return true;
                }
            }

            if (gamer2 != null)
            {
                if ((gamer2.Name == name))
                {
                    return true;
                }
            }

            foreach (Gamer gamer in gamers.Gamers)
            {
                if (gamer.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        // Извлечение из списка выбранного игрока.
        protected void RemoveItemByGamerName(Gamer gamer)
        {
            int index = 0;
            string name = nameSelect.SelectedItem.ToString();

            foreach (Gamer gm in gamers.Gamers)
            {
                if (gm.Name == name)
                {
                    gamer = gm;
                    index = gamers.Gamers.IndexOf(gm);
                }
            }

            gamers.Gamers.RemoveAt(index);
            nameSelect.Items.Remove(name);
            nameSelect.Text = nameSelect.Items[0].ToString();
        }

        // Обработка события - игрок сделал ход.
        private void but_Click(object sender, EventArgs e)
        {
            howSteps--;

            labelGamer.Focus();

            Button btn = (Button)sender;

            SetValue(btn);

            btn.Enabled = false;

            ReviseRows();

            ReviseCols();

            ReviseMainDiag();

            ReviseSecDiag();

            FinaliseGame();            

        }

        // Поочерёдная установка "крестик" или "нолик".
        protected void SetValue(Button btn)
        {
            if (lastX)
            {
                btn.Text = "O";
                lastX = false;

            }
            else
            {
                btn.Text = "X";
                lastX = true;
            }
        }

        // Сообщение о переходе хода другому игроку.
        protected void ChangeName()
        {
            if (labelGamer.Text == gamer1.Name)
            {
                labelGamer.Text = gamer2.Name;
            }
            else
            {
                labelGamer.Text = gamer1.Name;
            }
        }

        // "Заморозка/разморозка" всех кнопок.
        protected void AllNotYesEnabled(bool faltry)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    but[i, j].Enabled = faltry;
                }
            }
        }

        // "Сброс" всех кнопок.
        protected void AllBtnClear()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    but[i, j].Text = "";
                }
            }
        }

        // Наведение курсора на кнопку.
        private void but_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (lastX)
            {
                btn.Text = "O";
            }
            else
            {
                btn.Text = "X";
            }
        }

        // Покидание курсором границ кнопки.
        private void but_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Enabled)
            {
                btn.Text = "";
            }

        }

        // Проверка элементов строки на равенство первому элементу в строке.
        protected void ReviseRows()
        {
            for (int j = 0; j < 3; j++)
            {
                bool equal = true;

                for (int i = 0; i < 3; i++)
                {
                    if ((but[i, j].Text != but[0, j].Text) || (but[i, j].Text == ""))
                    {
                        equal = false;
                    }
                }

                if (equal)
                {
                    AllNotYesEnabled(false);
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов в строке!\n";
                }
            }
        }

        // Проверка элементов столбца на равенство первому элементу в столбце.            
        protected void ReviseCols()
        {
            for (int i = 0; i < 3; i++)
            {
                bool equal = true;

                for (int j = 0; j < 3; j++)
                {
                    if ((but[i, j].Text != but[i, 0].Text) || (but[i, j].Text == ""))
                    {
                        equal = false;
                    }
                }

                if (equal)
                {
                    AllNotYesEnabled(false);
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов в столбце!\n";
                }
            }
        }

        // Проверка элементов главной диагонали.
        protected void ReviseMainDiag()
        {
            if (but[0, 0].Text != "")
            {
                bool equal = true;

                for (int i = 0; i < 3; i++)
                {
                    if ((but[i, i].Text != but[0, 0].Text))
                    {
                        equal = false;
                    }
                }

                if (equal)
                {
                    AllNotYesEnabled(false);
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов главной диагонали!\n";
                }
            }
        }

        // Проверка элементов побочной диагонали.
        protected void ReviseSecDiag()
        {
            if (but[0, 3 - 1].Text != "")
            {
                bool equal = true;

                for (int i = 0; i < 3; i++)
                {
                    if (but[i, 3 - (i + 1)].Text != but[0, 3 - 1].Text)
                    {
                        equal = false;
                    }
                }

                if (equal)
                {
                    AllNotYesEnabled(false);
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов побочной диагонали!\n";
                }
            }
        }

        // Ожидание окончания игры.
        protected void FinaliseGame()
        {
            if((howSteps == 0) && (!stopGame))
            {
                mVictory.Text = "Победителей нет!";
                btnRepeat.Visible = true;
            }
            else if (!stopGame)
            {
                ChangeName();
            }
            else
            {
                if (labelGamer.Text == gamer1.Name)
                {
                    gamer1.HowCurVictories++;
                    mVictory.Text += labelGamer.Text + " выиграл " + gamer1.HowCurVictories + " раз!";
                    mVictory.Text += "\nПобедил во всех играх " + (gamer1.HowTotalVictories + gamer1.HowCurVictories) + " раз!";
                }
                else
                {
                    gamer2.HowCurVictories++;
                    mVictory.Text += labelGamer.Text + " выигрывал " + gamer2.HowCurVictories + " раз!";
                    mVictory.Text += "\nПобедил во всех играх " + (gamer2.HowTotalVictories + gamer2.HowCurVictories) + " раз!";
                }                

                btnRepeat.Visible = true;
            }
        }

        // Завершающие действия по выходу из игры.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gamer1 != null)
            {
                gamer1.HowTotalVictories += gamer1.HowCurVictories;
                gamers.Gamers.Add(gamer1);
            }
            if (gamer2 != null)
            {
                gamer2.HowTotalVictories += gamer2.HowCurVictories;
                gamers.Gamers.Add(gamer2);
            }

            SaveJSON();
        }

        // Запуск новой игры с выбранными ранее игроками.
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            InitGame();

        }

        // Запись списка игроков с параметрами.
        private void SaveJSON()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ListGamers));

            if (!FileIsLocked("Gamers.json", FileAccess.ReadWrite))
            {                
                using (FileStream fs = new FileStream("Gamers.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, gamers);
                }
                // Не выведет, т.к. сохранение происходит по закрытию формы.
                MessageBox.Show("Файл со списком игроков заблокирован. Данные сохранятся в новом файле.");
            }
            else
            {
                using (FileStream fs = new FileStream(DateTime.Now.ToFileTime() + "Gamers.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, gamers);
                }
            }
        }

        // Загрузка списка игроков с параметрами.
        protected void LoadJSON()
        {
            using (FileStream fs = new FileStream("Gamers.json", FileMode.Open, FileAccess.Read))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ListGamers));

                gamers = (ListGamers)jsonFormatter.ReadObject(fs);
                
            }
        }

        // Возвращает истину если файл заблокирован.
        protected bool FileIsLocked(string path, FileAccess access)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, access);
                fs.Close();
                return false;
            }
            catch (UnauthorizedAccessException)
            {                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
    
}

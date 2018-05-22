﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        static bool X = true;    
        Button[,] but = new Button[3, 3];
        Gamer gamer1;
        Gamer gamer2;
        ListGamers gamers = new ListGamers();
        bool stopGame = false;

        private void Form1_Load(object sender, EventArgs e)
        {

            mVictory.Text = "";

            LoadJSON();            

            foreach (Gamer gamer in gamers.Gamers)
            {
                nameSelect.Items.Add(gamer.Name);
            }
            nameSelect.Enabled = true;
            nameSelect.Text = nameSelect.Items[0].ToString();
            
        }

        // Инициализирует кнопки.
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
                    this.Controls.Add(but[i, j]);
                }
            }
        }

        [DataContract]
        public class Gamer
        {
            [DataMember]
            public string Name { get; set; }            
            [DataMember]
            public int HowVictories { get; set; }

            public Gamer(string name)
            {
                Name = name;                
                HowVictories = 0;
            }
        }

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

        private void but_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            SetValue(btn);

            btn.Enabled = false;

            ReviseRows();

            ReviseCols();

            ReviseMainDiag();

            ReviseSecDiag();

            if(!stopGame)
            {
                ChangeName();
            }
            else
            {
                if(labelGamer.Text == gamer1.Name)
                {
                    gamer1.HowVictories++;
                }
                else
                {
                    gamer2.HowVictories++;
                }

                gamers.Gamers.Add(gamer1);
                gamers.Gamers.Add(gamer2);

                SaveJSON();
            }
            

        }

        // Поочерёдно устанавливает "крестик" или "нолик".
        protected void SetValue(Button btn)
        {
            if (X)
            {
                btn.Text = "O";
                X = false;

            }
            else
            {
                btn.Text = "X";
                X = true;
            }
        }

        // Сообщает о переходе хода другому игроку.
        protected void ChangeName()
        {
            if(labelGamer.Text == gamer1.Name)
            {
                labelGamer.Text = gamer2.Name;
            }
            else
            {
                labelGamer.Text = gamer1.Name;
            }
        }

        // "Замораживает" все кнопки.
        protected void AllNotEnabled()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    but[i, j].Enabled = false;
                }
            }
        }

        // Проверяет элементы строки на равенство первому элементу в строке.
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
                    AllNotEnabled();
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов в строке!\n";
                }
            }
        }

        // Проверяет элементы столбца на равенство первому элементу в столбце.            
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
                    AllNotEnabled();
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов в столбце!\n";
                }
            }
        }

        // Проверяет элементы главной диагонали.
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
                    AllNotEnabled();
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов главной диагонали!\n";
                }
            }
        }

        // Проверяет элементы побочной диагонали.
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
                    AllNotEnabled();
                    stopGame = true;
                    mVictory.Text += "Совпадение элементов побочной диагонали!\n";
                }
            }
        }

        private void nameReg_TextChanged(object sender, EventArgs e)
        {
            btnReg.Enabled = true;
        }

        private void nameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnComeIn.Enabled = true;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if(labelGamer.Text == "ИГРОК 1")
            {
                gamer1 = new Gamer(nameReg.Text);            
                labelGamer.Text = "ИГРОК 2";                
                nameReg.Clear();                
            }
            else
            {
                gamer2 = new Gamer(nameReg.Text);            
                nameReg.Visible = false;
                btnReg.Visible = false;
                nameSelect.Visible = false;
                btnComeIn.Visible = false;                
                labelGamer.Top = 35;                
                labelGamer.Text = gamer1.Name;
                InitButton();
            }           
        }

        private void btnComeIn_Click(object sender, EventArgs e)
        {
            if (labelGamer.Text == "ИГРОК 1")
            {                
                int index = 0;

                foreach (Gamer gm in gamers.Gamers)
                {
                    if(gm.Name == nameSelect.SelectedItem.ToString())
                    {
                        gamer1 = gm;
                        index = gamers.Gamers.IndexOf(gm);
                    }
                }

                gamers.Gamers.RemoveAt(index);
                labelGamer.Text = "ИГРОК 2";
            }
            else
            {                
                int index = 0;

                foreach (Gamer gm in gamers.Gamers)
                {
                    if (gm.Name == nameSelect.SelectedItem.ToString())
                    {
                        gamer2 = gm;
                        index = gamers.Gamers.IndexOf(gm);
                    }
                }

                gamers.Gamers.RemoveAt(index);

                nameReg.Visible = false;
                btnReg.Visible = false;
                nameSelect.Visible = false;
                btnComeIn.Visible = false;
                labelGamer.Top = 35;
                labelGamer.Text = gamer1.Name;
                InitButton();
            }


        }

        // Записываем параметры игрока.
        private void SaveJSON()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ListGamers));

            using (FileStream fs = new FileStream("Gamers.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, gamers);                
            }
        }

        protected void LoadJSON()
        {
            using (FileStream fs = new FileStream("Gamers.json", FileMode.Open))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ListGamers));

                gamers = (ListGamers)jsonFormatter.ReadObject(fs);
                
            }
        }

        
    }

    
}

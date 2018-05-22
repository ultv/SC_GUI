﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] but = new Button[3, 3];

        private void Form1_Load(object sender, EventArgs e)
        {

            mVictory.Text = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    but[i, j] = new Button();
                    but[i, j].Text = "";
                    but[i, j].Top = j * 75 + 25;
                    but[i, j].Left = i * 75 + 65;
                    but[i, j].BackColor = Color.White;
                    but[i, j].Size = new Size(75, 75);
                    but[i, j].Font = new Font("Arial", 40);
                    but[i, j].Click += but_Click;
                    this.Controls.Add(but[i, j]);
                }
            }


        }

        static bool X = true;

        public class Gamer
        {
            public string Name { get; set; }
            public string WhatPlays { get; set; }
            public int HowVictories { get; set; }
            public bool IGo { get; set; }

            public Gamer(string name, string what)
            {
                Name = name;
                WhatPlays = what;
                HowVictories = 0;
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
                    mVictory.Text += "Совпадение элементов побочной диагонали!\n";
                }
            }
        }
        


    }

    
}

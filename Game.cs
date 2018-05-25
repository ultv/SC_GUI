using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_GUI
{
    public class Game
    {
        public int NumGame { get; set; }
        public int HowStepToEnd { get; set; }
        public bool StopGame { get; set; }
        public bool PrevX { get; set; }
        public DateTime Date { get; set; }
        public string NameVictory { get; set; }
        public Player[] Players { get; set; }
        public Matrix GameField { get; set; }

        public Game(Form1 form, int num)
        {
            HowStepToEnd = num * num;
            StopGame = false;
            PrevX = false;
            Date = DateTime.Now;
            Player player1 = new Player();
            Player player2 = new Player();
            Players = new Player[] { player1, player2 };
            GameField = new Matrix(form, num, 50, 50);

        }

        public void DecStep()
        {
            HowStepToEnd--;
            ///Выводит кол-во ходов до конца игры;
            ///MessageBox.Show(HowStepToEnd.ToString());          
        }        

    }
}

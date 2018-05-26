using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class Game
    {
        public int NumGame { get; set; }
        public int HowStepToEnd { get; set; }
        public bool PrevX { get; set; }
        public DateTime Date { get; set; }
        public string NameVictory { get; set; }
        public Player[] Players { get; set; }        
        public Matrix GameField { get; set; }
        public int NowPlaying { get; set; }



        public delegate void Stop(string message);
        public event Stop StopGame;

        public Game(Form1 form, Panel panel, int size)
        {
            HowStepToEnd = size * size;
            PrevX = false;
            Date = DateTime.Now;
            Player player1 = new Player();
            Player player2 = new Player();
            Players = new Player[] { player1, player2 };
            GameField = new Matrix(form, panel, size);

            StopGame += ShowResult;
            StopGame += form.FinalyGame;    

        }

        public void DecStep()
        {
            HowStepToEnd--;

            if (HowStepToEnd == 0)
            {
                StopGame("Игра закончена.");
            }
        }

        public void ShowResult(string message)
        {
            MessageBox.Show(message);
        }

        public void ChangePlaying()
        {            
            if (NowPlaying == 0)
            {
                NowPlaying = 1;
            }
            else
            {
                NowPlaying = 0;
            }
        }

    }
}

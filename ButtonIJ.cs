using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace CS_GUI
{
    // Каждая кнопка будет содержать значение индексов по которым она находится в массиве.
    public class ButtonIJ : Button
    {
        public int I { get; set; }
        public int J { get; set; }

        public ButtonIJ(int i, int j, int top, int left)
        {
            I = i;
            J = j;
            Text = "";
            Top = i * 75 + top;
            Left = j * 75 + left;
            BackColor = Color.White;
            Size = new Size(75, 75);
            Font = new Font("Arial", 10); //40);
            Click += Form1.buttonIJ_Click;
        }

        // Поочерёдная установка "крестик" или "нолик".
        public void SetBtnText(Game game)
        {
            if (game.NowX)
            {
                Text = "O";
                game.NowX = false;

            }
            else
            {
                Text = "X";
                game.NowX = true;
            }

            Enabled = false;
        }
    }

}

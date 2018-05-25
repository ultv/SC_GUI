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
            MouseEnter += Form1.buttonIJ_MouseEnter;
            MouseLeave += Form1.buttonIJ_MouseLeave;
        }

        // Поочерёдная установка "крестик" или "нолик".
        public void SetBtnText(Game game)
        {
            if (game.PrevX)
            {
                Text = "O";
                game.PrevX = false;

            }
            else
            {
                Text = "X";
                game.PrevX = true;
            }

            Enabled = false;
        }

        // Подсветка кнопок при наведении курсора.
        public void GetBtnText(Game game)
        {
            if (game.PrevX)
            {
                Text = "O";
            }
            else
            {
                Text = "X";
            }
        }
    }

}

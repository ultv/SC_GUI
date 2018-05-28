using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class Brain
    {
        public void MakeStep(Game game, int i, int j)
        {
            game.GameField.Cells[i, j].PerformClick();
        }

        public void Think(Game game)
        {

        }
        
        // Найти противоположный угол.
        public int FindAngleOnDiag(Game game, int position)
        {
            /*
            switch (position)
            {
                case 0:
                    return 8;
                case 8:
                    return 0;
                case 2:
                    return 6;
                case 6:
                    return 2;                
            }
            */
            
            return (game.GameField.Size - position);                 
        }

        // Возвращает позицию свободного угла сбоку или отрицательное значение, если требуемые углы заняты.
        public int FindAngleOnSide(Game game, int position)
        {
            if((position == 0) || (position == 8))
            {
                if (game.GameField.Cells[0, 2].Enabled)
                {
                    return 2;
                }
                else if (game.GameField.Cells[2, 0].Enabled)
                {
                    return 6;
                }                
            }

            if ((position == 2) || (position == 6))
            {
                if (game.GameField.Cells[0, 0].Enabled)
                {
                    return 0;
                }
                else if (game.GameField.Cells[2, 2].Enabled)
                {
                    return 8;
                }                
            }

            return -1;
        }


        public bool CentrIsFree(Game game)
        {
            if (game.GameField.Cells[1, 1].Enabled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

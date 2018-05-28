using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    public class Brain
    {        

        public int BrainId { get; set; }

        public void MakeStep(Game game, int i, int j)
        {
            game.GameField.Cells[i, j].PerformClick();
        }

        public void Think(Game game)
        {

        }

        // Вычислить индекс строки по порядковому номеру.
        public int GetIndexIOfPosition(Game game, int position)
        {
            return position / game.GameField.Size;
        }

        // Вычислить индекс столбца по порядковому номеру.
        public int GetIndexJOfPosition(Game game, int position)
        {
            return position % game.GameField.Size;
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

        // Возвращает позицию свободного угла сбоку от указанного или отрицательное значение, если требуемые углы заняты.
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

        // Проверка свободен ли центр.
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

        // Поиск свободного угла.        
        public int FindFreeAngle(Game game)
        {
            if (game.GameField.Cells[0, 0].Enabled)
            {
                return 0;
            }
            else if (game.GameField.Cells[0, 2].Enabled)
            {
                return 2;
            }
            else if (game.GameField.Cells[2, 2].Enabled)
            {
                return 8;
            }
            else if (game.GameField.Cells[2, 0].Enabled)
            {
                return 6;
            }
            else
                return -1;
        }

        // В данной реализации - соперник всегда начинает первым. 
        public void PlayingIndenpendently(Game game, int position)
        {

            //MessageBox.Show(game.HowStep.ToString());

            // На первом своем ходу проверяем центр. Ходы считаются от нуля и инкрементируются после очередного хода???
            // Если центр занят - находим свободный угол.
            if (game.HowStep == 0)
            {
                if (CentrIsFree(game))
                {
                    MakeStep(game, 1, 1);
                }
                else
                {
                    if(FindFreeAngle(game) != -1)
                    {
                        int pos = FindFreeAngle(game);
                        int i = GetIndexIOfPosition(game, pos);
                        int j = GetIndexJOfPosition(game, pos);

                        MakeStep(game, i, j);
                    }
                    
                }
            }
            else if(game.HowStep == 2)
            {
                // Продолжаем занимать углы. (Центр уже 100% кем-то занят) - /// легко проиграть...
                /*
                if (FindFreeAngle(game) != -1)
                {
                    int position = FindFreeAngle(game);
                    int i = GetIndexIOfPosition(game, position);
                    int j = GetIndexJOfPosition(game, position);

                    MakeStep(game, i, j);
                }
                */

                FindElForBlocking(game, position);





            }
            else if (game.HowStep == 4)
            {

            }
            else if (game.HowStep == 6)
            {

            }
            else if (game.HowStep == 8)
            {

            }
           
        }

        public void FindElForBlocking(Game game, int position)
        {

            /*
            Matrix testGameField = game.GameField;

            testGameField.NowEquality += IsNeedBloking;

            for (int position = 0; position < 9; position++)
            {
                testGameField.ReviseRows(position);
                testGameField.ReviseCols(position);
                testGameField.ReviseMainDiag(position);
                testGameField.ReviseSecDiag(position);
            }
            */

            //CloneMatrix CloneGameField = (CloneMatrix)game.GameField;            

            CloneMatrix CloneGameField = new CloneMatrix(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CloneGameField.Cells[i,j] = game.GameField.Cells[i, j];

                    //MessageBox.Show(CloneGameField.Cells[i, j].Text);
                }
            }
            
                CloneGameField.ReviseRows(position);
            //    CloneGameField.ReviseCols(position);
            //    CloneGameField.ReviseMainDiag(position);
            //    CloneGameField.ReviseSecDiag(position);


        }

        public void IsNeedBloking(string message)
        {
            MessageBox.Show("Срочно меня блокируй");
        }
    }
}

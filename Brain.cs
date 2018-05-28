using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{

    // Тактика игры:
    // В данной версии программы компьютер играет вторым номером и соперник иммеет
    // преимущество в виде лишнего хода и более "агрессивной" стратегии игры. 
    // Задача компьютера - не проиграть сопернику. Победа возможна в случае тактических ошибок соперника.
    // Принципиальную важность имеет первый ход соперника. Если он займет угол - компьютеру остаётся
    // Занять середину и блокировать последующие ходы пользователя, чтобы свести игру к ничьей.
    // Если на первом ходу все углы свободны - компьютер должен выбрать стратегию захвата трёх углов,
    // что не оставит сопернику шансов на победу.
    // В следующей версии будет реализована возможность смены очерёдности игроков
    // и смена тактики игры на достижение победы.

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

          ///  MessageBox.Show(game.HowStep.ToString());

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
                    AttackAngle(game);
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

                if(!BlockingRows(game, position))
                {
                    if(!BlockingCols(game, position))
                    {
                        AttackAngle(game);
                    }
                }                                
            }
            else if (game.HowStep == 4)
            {
                if (!BlockingRows(game, position))
                {
                    if (!BlockingCols(game, position))
                    {
                        AttackAngle(game);
                    }
                }
            }
            else if (game.HowStep == 6)
            {
                if (!BlockingRows(game, position))
                {
                    if (!BlockingCols(game, position))
                    {
                        AttackAngle(game);
                    }
                }
            }
            else if (game.HowStep == 8)
            {
                if (!BlockingRows(game, position))
                {
                    if (!BlockingCols(game, position))
                    {
                        AttackAngle(game);
                    }
                }
            }
           
        }

        public void AttackAngle(Game game)
        {
            if (FindFreeAngle(game) != -1)
            {
                int pos = FindFreeAngle(game);
                int i = GetIndexIOfPosition(game, pos);
                int j = GetIndexJOfPosition(game, pos);

                MakeStep(game, i, j);
            }
        }

        public bool BlockingRows(Game game, int position)
        {
            CloneMatrix CloneGameField = MakeClone(game);

            // Блокировка строки в случае вероятной опасности.                
            int rowsDangerJ = CloneGameField.ReviseRows(position);

            if (rowsDangerJ != -1)
            {
                int rowsDangerI = GetIndexIOfPosition(game, position);

       //         MessageBox.Show(rowsDangerI + " ; " + rowsDangerJ);

                MakeStep(game, rowsDangerI, rowsDangerJ);

                return true;
            }

            return false;
        }

        public bool BlockingCols(Game game, int position)
        {
            CloneMatrix CloneGameField = MakeClone(game);

            // Блокировка столбца в случае вероятной опасности.
            int colsDangerI = CloneGameField.ReviseCols(position);

            if (colsDangerI != -1)
            {
                int colsDangerJ = GetIndexJOfPosition(game, position);

         //       MessageBox.Show(colsDangerI + " ; " + colsDangerJ);

                MakeStep(game, colsDangerI, colsDangerJ);

                return true;
            }

            return false;
        }


        // не смогу различить какой элемент сработал. Проверю сразу в проверке хода. /// не планирую больше использовать.
        public int FindElForBlocking(Game game, int position)
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

            // Копируем элементы матрицы.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CloneGameField.Cells[i,j] = game.GameField.Cells[i, j];

                    //MessageBox.Show(CloneGameField.Cells[i, j].Text);
                }
            }
            
            // Проверка строки.
            int cols = CloneGameField.ReviseRows(position);
            if(cols != -1)
            {                
                return cols;
            }

            //      CloneGameField.ReviseCols(position);
            //    CloneGameField.ReviseMainDiag(position);
            //    CloneGameField.ReviseSecDiag(position);

            
            
            // Опасный элемент не выявлен.
            return -1;
        }






        // Перенос данных в клон.
        private CloneMatrix MakeClone(Game game)
        {
            CloneMatrix clon = new CloneMatrix(3);

            // Копируем элементы матрицы.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    clon.Cells[i, j] = game.GameField.Cells[i, j];                    
                }
            }

            return clon;
        }

        public void IsNeedBloking(string message)
        {
            MessageBox.Show("Срочно меня блокируй");
        }
    }
}

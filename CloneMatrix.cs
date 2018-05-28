using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class CloneMatrix : Matrix
    {
        public CloneMatrix(int size) : base(size)
        {

        }
  
        // !!! Проверяя строку, возвращает индекс опасного столбца или -1.            
        public override int ReviseRows(int position)
        {
            int i = position / Size;

            // Поочерёдная подстановка значения в каждую ячейку строки.
            for (int j = 0; j < Size; j++)
            {
                // Если есть "мой знак" - совпадение невозможно.
                if (Cells[i, j].Text == "O")
                {
                    return -1;
                }

                // Если ячейка занята - переход к следующей.
                if (Cells[i, j].Enabled)
                {
                    Cells[i, j].Text = "X";                

                    // Проверка равенства всех элементов строки.
                    for (int cols = 0; cols < Size; cols++)
                    {
                        // Если после подстановки выявлено неравенство - опасности нет.
                        if (Cells[i, cols].Text != Cells[i, 0].Text)
                            return -1;                        
                    }

                    // Возврат состояния до подмены.
                    Cells[i, j].Text = "";

                    // MessageBox.Show($"Срочно блокируй {i + 1} строку - опасен {j} столбец");

                    // Неравенства не было, значит подстановка приводит к опасной ситуации.
                    return j;

                }

            }

            // NowEquality($"Совпадение элементов {i + 1} строки");

            return -1; // до этого момента уже должен выйти. //true;
        }

        // !!! Проверяя столбец, возвращает индекс опасной строки или -1.                        
        public override int ReviseCols(int position)
        {           

            int j = position % Size;

            // Поочерёдная подстановка значения в каждую ячейку столбца.
            for (int i = 0; i < Size; i++)
            {
                // Если есть "мой знак" - совпадение невозможно.
                if (Cells[i, j].Text == "O")
                {
                    return -1;
                }

                // Если ячейка занята - переход к следующей.
                if (Cells[i, j].Enabled)
                {
                    Cells[i, j].Text = "X";

                    // Проверка равенства всех элементов столбца.
                    for (int rows = 0; rows < Size; rows++)
                    {

                        if (Cells[rows, j].Text != Cells[0, j].Text)
                            return -1;
                    }

                    // Возврат состояния до подмены.
                    Cells[i, j].Text = "";

             //       MessageBox.Show($"Срочно блокируй {j + 1} столбец - опасна {i} строка");

                    // Неравенства не было, значит подстановка приводит к опасной ситуации.
                    return i;
                }
            }

            // NowEquality($"Совпадение элементов {j + 1} столбца");
           

            return -1; // до этого момента уже должен выйти. //true;
        }

        // Проверяет элементы главной диагонали матрицы на равенство первому элементу в диагонали.
        // Если индексы изменённого элемента не равны - диагональ не изменялась, можем пропустить проверку.
        // Получает индексы порядковый введённого номер элемента, вычисляет индексы.
        // Возвращает ложь если значение любого элемента диагонали - не равно значению первого элемента диагонали.
        // Предварительно проверяется было ли изменение в первом элементе диагонали. Т.к. одинаковое значение
        // во всех ячейках диагонали, которое используется по умолчанию - приводит к неверному результату проверки. 
        public override bool ReviseMainDiag(int position)
        {
            int I = position / Size;
            int J = position % Size;


            if (I != J)
            {
                return false;
            }
            else
            {
                if (Cells[0, 0].Text == "")
                {
                    return false;
                }

                for (int i = 0; i < Size; i++)
                {
                    if ((Cells[i, i].Text != Cells[0, 0].Text))
                        return false;
                }

                // NowEquality("Совпадение элементов главной диагонали");
                MessageBox.Show("Срочно блокируй главную диагональ");

                return true;
            }
        }

        // Проверяет элементы побочной диагонали матрицы на равенство первому элементу в диагонали.            
        // Получает порядковый номер изменённого элемента, вычисляет индексы.
        // Возвращает ложь если значение любого элемента диагонали - не равно значению первого элемента диагонали.
        // Предварительно проверяется было ли изменение в первом элементе диагонали. Т.к. одинаковое значение
        // во всех ячейках диагонали, которое используется по умолчанию - приводит к неверному результату проверки. 
        public override bool ReviseSecDiag(int position)
        {
            int I = position / Size;
            int J = position % Size;

            if (J != (Size - (I + 1)))
            {
                return false;
            }
            else
            {
                if (Cells[0, Size - 1].Text == "")
                {
                    return false;
                }

                for (int i = 0; i < Size; i++)
                {
                    if (Cells[i, Size - (i + 1)].Text != Cells[0, Size - 1].Text)
                        return false;
                }
            }

            // NowEquality("Совпадение элементов побочной диагонали");
            MessageBox.Show("Срочно блокируй побочную диагонали");

            return true;
        }

    }
}

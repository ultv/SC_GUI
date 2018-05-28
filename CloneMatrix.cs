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
  
        // Проверяет элементы строки на равенство первому элементу в строке.
        // Получает индексы порядковый номер изменённой строки, вычисляет индексы.
        // Возвращает ложь если значение любого элемента строки - не равно значению первого элемента этой строки.            
        public override bool ReviseRows(int position)
        {

            int i = position / Size;

            for (int j = 0; j < Size; j++)
            {
                if(Cells[i,j].Enabled)
                {
                    Cells[i, j].Text = "X";

                    for (int jj = 0; jj < Size; jj++)
                    {

                        if (Cells[i, jj].Text != Cells[i, 0].Text)
                            return false;
                    }

                    Cells[i, j].Text = "";
                }                
            }
            
            // NowEquality($"Совпадение элементов {i + 1} строки");
            MessageBox.Show($"Срочно блокируй {i + 1} строку");

            return true;
        }

        // Проверяет элементы столбца на равенство первому элементу в столбце.
        // Получает индексы порядковый номер измнённого столбца, вычисляет индексы.
        // Возвращает ложь если значение любого элемента столбца - не равно значению первого элемента этого столбца.            
        public override bool ReviseCols(int position)
        {
            int j = position % Size;


            for (int i = 0; i < Size; i++)
            {
                if (Cells[i, j].Text != Cells[0, j].Text)
                    return false;
            }

            // NowEquality($"Совпадение элементов {j + 1} столбца");
            MessageBox.Show($"Срочно блокируй {j + 1} столбец");

            return true;
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

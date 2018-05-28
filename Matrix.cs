using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_GUI
{
    public class Matrix
    {
        public int Size { get; set; }
        public Button[,] Cells { get; set; }

        public delegate void Equality(string message);
        public event Equality NowEquality;
        
        public Matrix(int size)
        {
            Size = size;
            Cells = new Button[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cells[i, j] = new Button();             
                }
            }

        }

        public Matrix(Form1 form, Panel panel, int size)
        {
            Size = size;
            Cells = new Button[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {             
                    Cells[i, j] = new Button();

                    Cells[i, j].Height = 75;
                    Cells[i, j].Width = 75;
                    Cells[i, j].Top = i * 75 + 25;
                    Cells[i, j].Left = j * 75 + 5;
                    Cells[i, j].Font = new Font("Arial", 30);
                    Cells[i, j].Name = (i * size + j).ToString();                    
                    Cells[i, j].Click += form.Button_Click;                    
                    Cells[i, j].MouseEnter += form.Button_MouseEnter;
                    Cells[i, j].MouseLeave += form.Button_MouseLeave;

                    panel.Controls.Add(Cells[i, j]);
                }
            }
        }

        // Проверяет элементы строки на равенство первому элементу в строке.
        // Получает индексы порядковый номер изменённой строки, вычисляет индексы.
        // !!! Не использовать значение return как индекс совпавшей ячейки. Реализовано только для класса наследника.            
        public virtual int ReviseRows(int position)
        {
            
            int i = position / Size;            

            for (int j = 0; j < Size; j++)
            {
                if (Cells[i, j].Text != Cells[i, 0].Text)
                    return -1;
            }

            NowEquality($"Совпадение элементов {i + 1} строки");            

            return 1;
        }

        // Проверяет элементы столбца на равенство первому элементу в столбце.
        // Получает индексы порядковый номер измнённого столбца, вычисляет индексы.
        // !!! Не использовать значение return как индекс совпавшей ячейки. Реализовано только для класса наследника.            
        public virtual int ReviseCols(int position)
        {
            int j = position % Size;


            for (int i = 0; i < Size; i++)
            {
                if (Cells[i, j].Text != Cells[0, j].Text)
                    return -1;
            }

            NowEquality($"Совпадение элементов {j + 1} столбца");            
            return 1;
        }

        // Проверяет элементы главной диагонали матрицы на равенство первому элементу в диагонали.
        // Если индексы изменённого элемента не равны - диагональ не изменялась, можем пропустить проверку.
        // Получает индексы порядковый введённого номер элемента, вычисляет индексы.        
        // Предварительно проверяется было ли изменение в первом элементе диагонали. Т.к. одинаковое значение
        // во всех ячейках диагонали, которое используется по умолчанию - приводит к неверному результату проверки.
        // !!! Не использовать значение return как индекс совпавшей ячейки. Реализовано только для класса наследника.            
        public virtual int ReviseMainDiag(int position)
        {
            int I = position / Size;
            int J = position % Size;


            if (I != J)
            {
                return -1;
            }                
            else
            {
                if (Cells[0, 0].Text == "")
                {
                    return -1;
                }
                    
                for (int i = 0; i < Size; i++)
                {
                    if ((Cells[i, i].Text != Cells[0, 0].Text))
                        return -1;
                }

                NowEquality("Совпадение элементов главной диагонали");
                return 1;
            }
        }

        // Проверяет элементы побочной диагонали матрицы на равенство первому элементу в диагонали.            
        // Получает порядковый номер изменённого элемента, вычисляет индексы.        
        // Предварительно проверяется было ли изменение в первом элементе диагонали. Т.к. одинаковое значение
        // во всех ячейках диагонали, которое используется по умолчанию - приводит к неверному результату проверки.
        // !!! Не использовать значение return как индекс совпавшей ячейки. Реализовано только для класса наследника.            
        public virtual int ReviseSecDiag(int position)
        {
            int I = position / Size;
            int J = position % Size;

            if(J != (Size - (I + 1)))
            {
                return -1;
            }                
            else
            {
                if (Cells[0, Size - 1].Text == "")
                {
                    return -1;
                }
                    
                for (int i = 0; i < Size; i++)
                {
                    if (Cells[i, Size - (i + 1)].Text != Cells[0, Size - 1].Text)
                        return -1;
                }
            }

            NowEquality("Совпадение элементов побочной диагонали");
            return 1;
        }

    }
}

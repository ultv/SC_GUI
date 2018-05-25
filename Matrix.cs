using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    // Массив кнопок с индексами.
    // Кнопки создаются динамически и выводятся на форму.
    public class Matrix
    {
        public int Size { get; set; }
        public ButtonIJ[,] btns;
        public Panel panelButtonIJ;

        public delegate void Equality(string message);
        public event Equality EqualityRows;
        public event Equality EqualityCols;
        public event Equality EqualityMainDiag;
        public event Equality EqualitySecDiag;        
        //public event Equality NotVictory;

        public Matrix(Form1 form, int size, int top, int left)
        {
            Size = size;
            btns = new ButtonIJ[size, size];

            panelButtonIJ = new Panel();
            panelButtonIJ.AutoSize = true;
            form.Controls.Add(panelButtonIJ);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    btns[i, j] = new ButtonIJ(i, j, top, left);

                    panelButtonIJ.Controls.Add(btns[i, j]);
                }
            }

            Label namePlayer = new Label();
            namePlayer.Text = "Имя";
            panelButtonIJ.Controls.Add(namePlayer);

            panelButtonIJ.Visible = false;
        }

        // Проверяет элементы строки на равенство первому элементу в строке.
        // Получает индекс изменённой строки.
        // Возвращает ложь если значение любого элемента строки - не равно значению первого элемента этой строки.            
        public bool ReviseRows(int i)
        {
            for (int j = 0; j < Size; j++)
            {
                if (btns[i, j].Text != btns[i, 0].Text)
                    return false;
            }

            EqualityRows("Совпадение элементов строки");
            
            return true;
        }

        // Проверяет элементы столбца на равенство первому элементу в столбце.
        // Получает индекс изменённого столбца.
        // Возвращает ложь если значение любого элемента столбца - не равно значению первого элемента этого столбца.            
        public bool ReviseCols(int j)
        {
            for (int i = 0; i < Size; i++)
            {
                if (btns[i, j].Text != btns[0, j].Text)
                    return false;
            }

            EqualityCols("Совпадение элементов столбца");
            return true;
        }

        // Проверяет элементы главной диагонали матрицы на равенство первому элементу в диагонали.
        // Если индексы вводимого элемента не равны - диагональ не изменялась, можем пропустить проверку.
        // Получает индексы введённого элемента.
        // Возвращает ложь если значение любого элемента диагонали - не равно значению первого элемента диагонали.
        // Предварительно проверяется было ли изменение в первом элементе диагонали. Т.к. одинаковое значение
        // во всех ячейках диагонали, которое используется по умолчанию - приводит к неверному результату проверки. 
        public bool ReviseMainDiag(int rows, int col)
        {
            if (rows != col)
                return false;
            else
            {
                if (btns[0, 0].Text == "")
                    return false;

                for (int i = 0; i < Size; i++)
                {
                    if ((btns[i, i].Text != btns[0, 0].Text))
                        return false;
                }

                EqualityMainDiag("Совпадение элементов главной диагонали");
                return true;
            }
        }

        // Проверяет элементы побочной диагонали матрицы на равенство первому элементу в диагонали.            
        // Получает индексы введённого элемента.
        // Возвращает ложь если значение любого элемента диагонали - не равно значению первого элемента диагонали.
        // Предварительно проверяется было ли изменение в первом элементе диагонали. Т.к. одинаковое значение
        // во всех ячейках диагонали, которое используется по умолчанию - приводит к неверному результату проверки. 
        public bool ReviseSecDiag(int rows, int col)
        {
            if (btns[0, Size - 1].Text == "")
                return false;

            for (int i = 0; i < Size; i++)
            {
                if (btns[i, Size - (i + 1)].Text != btns[0, Size - 1].Text)
                    return false;
            }

            EqualitySecDiag("Совпадение элементов побочной диагонали");
            return true;
        }

    }
}

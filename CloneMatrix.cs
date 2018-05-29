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

        // Проверяя строку, возвращает индекс опасного столбца или -1.        
        // !!! Возможность атаки ищем по всем строкам.
        public int AttRows(out int returnedI)
        {
          //  int i = position / Size;

            for(int i = 0; i < Size; i++)
            {
                // Поочерёдная подстановка значения в каждую ячейку строки.
                for (int j = 0; j < Size; j++)
                {
                    // Если есть "мой знак" - совпадение невозможно.
                    if (Cells[i, j].Text == "X") // "O" - блокировка, "X" - атака
                    {
                        returnedI = 0; ///
                        return -1;
                    }

                    // Если ячейка занята - переход к следующей.
                    if (Cells[i, j].Enabled)
                    {
                        Cells[i, j].Text = "O"; // "X" - блокировка, "O" - атака

                        // Проверка равенства всех элементов строки.
                        for (int cols = 0; cols < Size; cols++)
                        {
                            // Если после подстановки выявлено неравенство - опасности нет.
                            if (Cells[i, cols].Text != Cells[i, 0].Text)
                            {
                                returnedI = 0; ///
                                return -1;
                            }                            
                        }

                        // Возврат состояния до подмены.
                        Cells[i, j].Text = "";

                        // Неравенства не было, значит подстановка приводит к заполнению строки О-О-О.
                        returnedI = i;
                        return j;
                    }
                }
            }

            // до этого момента уже должен выйти.            
            returnedI = 0;
            return -1;
        }

                
        // Проверяя строку, возвращает индекс опасного столбца или -1.            
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
                    
                    // Неравенства не было, значит подстановка приводит к опасной ситуации.
                    return j;
                }
            }

            // до этого момента уже должен выйти.
            return -1;
        }
        

        // Проверяя столбец, возвращает индекс опасной строки или -1.                        
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
             
                    // Неравенства не было, значит подстановка приводит к опасной ситуации.
                    return i;
                }
            }
            
            // до этого момента уже должен выйти.
            return -1;
        }

        // Проверяя главную диагонадь, возвращает строковый индекс опасной ячейки или -1. 
        public override int ReviseMainDiag(int position)
        {
            int I = position / Size;
            int J = position % Size;
            
            // Поочерёдная подстановка значения в каждую ячейку главной диагонали.
            for (int i = 0; i < Size; i++)
            {
                // Если есть "мой знак" - совпадение невозможно.
                if (Cells[i, i].Text == "O")
                {
                    return -1;
                }

                // Если ячейка занята - переход к следующей.
                if (Cells[i, i].Enabled)
                {
                    Cells[i, i].Text = "X";

                    // Проверка равенства всех элементов главной диагонали.
                    for (int rows = 0; rows < Size; rows++)
                    {

                        if (Cells[rows, rows].Text != Cells[0, 0].Text)
                            return -1;
                    }

                    // Возврат состояния до подмены.
                    Cells[i, i].Text = "";
                  
                    // Неравенства не было, значит подстановка приводит к опасной ситуации.
                    // i и j одинаковые.
                    return i;
                }
            }

            // до этого момента уже должны выйти.
            return -1;

        }

        // Проверяя побочную диагонадь, возвращает строковый индекс опасной ячейки или -1. 
        public override int ReviseSecDiag(int position)
        {
            int I = position / Size;
            int J = position % Size;            

            // Поочерёдная подстановка значения в каждую ячейку главной диагонали.
            for (int i = 0; i < Size; i++)
            {
                // Если есть "мой знак" - совпадение невозможно.
                if (Cells[i, Size - (i + 1)].Text == "O")
                {
                    return -1;
                }

                // Если ячейка занята - переход к следующей.
                if (Cells[i, Size - (i + 1)].Enabled)
                {
                    Cells[i, Size - (i + 1)].Text = "X";

                    // Проверка равенства всех элементов главной диагонали.
                    for (int rows = 0; rows < Size; rows++)
                    {

                        if (Cells[rows, Size - (rows + 1)].Text != Cells[0, Size - 1].Text)
                            return -1;
                    }

                    // Возврат состояния до подмены.
                    Cells[i, Size - (i + 1)].Text = "";

                    // Неравенства не было, значит подстановка приводит к опасной ситуации.                   
                    return i;
                }
            }

            // до этого момента уже должны выйти.
            return -1;

        }
       
    }
}

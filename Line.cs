using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class Line
    {
        private int Position { get; set; }
        private int Size { get; set; }
        private int SumX { get; set; }
        private int SumO { get; set; }        
        public Cell[] Cells { get; set; }

        public Line() { }  

        public Line(Form1 form, Panel panel, int size, int position)
        {
            Size = size;            
            Cells = new Cell[size];
            int offset = 25;

            for(int i = 0; i < size; i++)
            {
                Cells[i] = new Cell(form, position * size + i);
                Cells[i].Butt.Top = 75 * position + offset;

                panel.Controls.Add(Cells[i].Butt);
            }
        }

        public delegate void EqualityX();
        public event EqualityX NowEqualityXO;

        /// <summary>
        /// Возвращает сумму значений "Х" во всех ячейках строки. 
        /// </summary>
        /// <returns></returns>
        public int KnowSumX(int size)
        {
            int sum = 0;
            
            for (int i = 0; i < size; i++)
            {
                sum = sum + Cells[i];
            }

            if (sum == 2)
            {
                // надо атаковать или блокировать.
            }

            if (sum == 3)
            {
                NowEqualityXO();
            }
                return sum;
        }

        /// <summary>
        /// Возвращает сумму значений "O" во всех ячейках строки. 
        /// </summary>
        /// <returns></returns>
        public int KnowSumO(int size)
        {
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                sum = sum - Cells[i];
            }

            if (sum == 2)
            {
                // надо атаковать или блокировать.
            }
            if (sum == 3)
            {
                NowEqualityXO();
            }
            return sum;
        }
    }
}

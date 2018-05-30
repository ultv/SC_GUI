using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class Line : Cell
    {        
        public int SumX { get; set; }
        public int SumO { get; set; }
        public int Length { get; set; }
        public Cell[] Cells { get; set; }

        public Line() { }

        public delegate void EqualityX();
        public event EqualityX NowEqualityXO;        

        public Line(Form1 form, Panel panel, int length, int posInCube) : base (form, 0, posInCube * length)
        {
            Length = length;
            PosInCube = posInCube;

            Cells = new Cell[length];

            for(int i = 0; i < length; i++)
            {
                Cells[i] = new Cell(form, i, posInCube * length);

                panel.Controls.Add(Cells[i]);
            }
        }

        /// <summary>
        /// Возвращает сумму значений "Х" во всех ячейках строки. 
        /// </summary>
        /// <returns></returns>
        public int KnowSumX()
        {
            int summ = Cells[0] + Cells[1] + Cells[2];
            if (summ == 3)
            {
                NowEqualityXO();
            }
                return summ;
        }

        /// <summary>
        /// Возвращает сумму значений "O" во всех ячейках строки. 
        /// </summary>
        /// <returns></returns>
        public int KnowSumO()
        {
            int summ = Cells[0] - Cells[1] - Cells[2];
            if (summ == 3)
            {
                NowEqualityXO();
            }
            return summ;
        }
    }
}

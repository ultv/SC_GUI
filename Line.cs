using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_GUI
{
    class Line : Cell
    {
        public int Position { get; set; }
        public int SumX { get; set; }
        public int SumO { get; set; }
        public int Length { get; set; }
        public Cell[] Cells { get; set; }

        public Line(int length, int position)
        {
            Length = length;
            Position = position;

            Cells = new Cell[length];

            for(int i = 0; i < length; i++)
            {
                Cells[i] = new Cell(i);
            }
        }
    }
}

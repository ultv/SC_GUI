using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class Cube
    {
        public int Size { get; set; }
        public int SumX { get; set; }
        public int SumO { get; set; }
        public Line[] cells;

        public Cube(Panel panel, int size)
        {
            Size = size;

            /*
            for (int i = 0; i < size; i++)
            {
                Cells[i] = new Line(size, i);
            }
            */

            cells = new Line[size];

            for (int i = 0; i < size; i++)
            {
                cells[i] = new Line(size, i);                
                panel.Controls.Add(cells[i]);
             
            }

        }
    }



    
}

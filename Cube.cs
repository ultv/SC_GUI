using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    /// <summary>
    /// Разрабатывается для замены Matrix.
    /// Size куба равна Length линии.     
    /// </summary>   
    class Cube : Line
    {
        private int SumX { get; set; }
        private int SumO { get; set; }

        public Line[] lines;

        public Cube(Form1 form, Panel panel, int size)
        {         
            lines = new Line[size];

            for (int i = 0; i < size; i++)
            {
                lines[i] = new Line(form, panel, size, i);        
                panel.Controls.Add(lines[i].Cells[i].Butt);             
            }

        }
        
    }



    
}

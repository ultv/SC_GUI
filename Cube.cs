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
      //  public int SumXX { get; set; }
      //  public int SumOO { get; set; }
        public Line[] lines;

        public Cube(Form1 form, Panel panel, int size)
        {         
            lines = new Line[size];

            for (int i = 0; i < size; i++)
            {
                lines[i] = new Line(form, panel, size, i);
                lines[i].Cells[0].Top = 75 * i + 125;
                lines[i].Cells[1].Top = 75 * i + 125;
                lines[i].Cells[2].Top = 75 * i + 125;

                panel.Controls.Add(lines[i]);             
            }

        }

        
    }



    
}

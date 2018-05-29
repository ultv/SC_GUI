using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_GUI
{
    //
    class Cell : Button
    {
        public int Position { get; set; }

        public Cell() { }

        public Cell(int position)
        {
            Position = position;
            Text = "";
            Height = 75;
            Width = 75;
            Font = new Font("Arial", 30);
        }
    }
}

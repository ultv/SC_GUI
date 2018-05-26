using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    class Matrix
    {
        public int Size { get; set; }
        public int[] Cells;

        public Matrix(Panel panel, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int[] IJ = new int[] { i, j };
                    Button btn = new Button();
                    btn.Tag = IJ;
                    btn.Height = 75;
                    btn.Width = 75;
                    btn.Top = i * 75 + 70;
                    btn.Left = j * 75 + 7;
                    int[] readIJ = (int[])btn.Tag;
                    btn.Text = readIJ[0].ToString() + " - " + readIJ[1].ToString();

                    panel.Controls.Add(btn);
                   
                }
            }
        }
    }
}

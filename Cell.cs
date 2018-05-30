using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CS_GUI
{
    /// <summary>
    /// "Ячейка с кнопкой". Из ячеек будут формироваться "Линии" класса Line.
    /// </summary>
    class Cell : Button
    {
        protected int PosInLine { get; set; }
        public int PosInCube { get; set; }

        public Cell() { Text = "???"; }

        public Cell(Form1 form, int posInLine, int posOffset)
        {
            PosInLine = PosInLine;
            PosInCube = posOffset + posInLine;
            Text = ""; ///position.ToString();
            Height = 75;
            Width = 75;
            Left = posInLine * 75 + 7;
            Font = new Font("Arial", 30);
            Click += form.Cell_Click;
            MouseEnter += form.Button_MouseEnter;
            MouseLeave += form.Button_MouseLeave;
        }

        /// <summary>
        /// Возвращает сумму значений "Х" в двух ячейках.
        /// </summary>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <returns></returns>
        public static int operator +(Cell cell1, Cell cell2)
        {
            int resultX = 0;

            if (cell1.Text == "X")
                resultX++;
            if (cell2.Text == "X")
                resultX++;

            return resultX;
        }

        /// <summary>
        /// Возвращает сумму значений "Х" предыдущей операции сложения и ячейки.
        /// Принимает значение предыдущей операции сложения.
        /// </summary>
        /// <param name="summ"></param>
        /// <param name="cell2"></param>
        /// <returns></returns>
        public static int operator +(int resultX, Cell cell2)
        {                        
            if (cell2.Text == "X")
                resultX++;

            return resultX;
        }

        /// <summary>
        /// Возвращает сумму значений "O" в двух ячейках. 
        /// </summary>
        /// <param name="cell1"></param>
        /// <param name="cell2"></param>
        /// <returns></returns>
        public static int operator -(Cell cell1, Cell cell2)
        {
            int resultO = 0;

            if (cell1.Text == "O")
                resultO++;
            if (cell2.Text == "O")
                resultO++;

            return resultO;
        }

        /// <summary>
        /// Возвращает сумму значений "O" предыдущей операции "вычитания" и ячейки.
        /// Принимает значение предыдущей операции "вычитания".
        /// </summary>
        /// <param name="summ"></param>
        /// <param name="cell2"></param>
        /// <returns></returns>
        public static int operator -(int resultO, Cell cell2)
        {
            if (cell2.Text == "O")
                resultO++;

            return resultO;
        }
    }
}

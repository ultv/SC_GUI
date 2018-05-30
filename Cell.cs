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
    class Cell
    {
        private int Position { get; set; }        
        public Button Butt { get; set; }

        public Cell() { }

        public Cell(Form1 form, int position)
        {
            Butt = new Button();
            int offset = 7;

            Position = position;          
            Butt.Text = "";
            Butt.Height = 75;
            Butt.Width = 75;
            Butt.Left = position % 3 * 75 + offset;
            Butt.Font = new Font("Arial", 30);
            Butt.Click += form.Cell_Click;
            Butt.MouseEnter += form.Button_MouseEnter;
            Butt.MouseLeave += form.Button_MouseLeave;
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

            if (cell1.Butt.Text == "X")
                resultX++;
            if (cell2.Butt.Text == "X")
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
            if (cell2.Butt.Text == "X")
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

            if (cell1.Butt.Text == "O")
                resultO++;
            if (cell2.Butt.Text == "O")
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
            if (cell2.Butt.Text == "O")
                resultO++;

            return resultO;
        }
    }
}

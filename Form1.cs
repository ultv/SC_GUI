using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {            
            InitializeComponent();
            Width = 300;
            Height = 520;
            panelAccount.Top = 40;
            panelAccount.Left = 20;

            Matrix mat = new Matrix(panelGame, 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();           
        }
    }
}

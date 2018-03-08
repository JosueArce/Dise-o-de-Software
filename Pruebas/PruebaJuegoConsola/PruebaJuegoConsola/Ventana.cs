using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaJuegoConsola
{
    public partial class Ventana : Form
    {
        public Ventana()
        {
            InitializeComponent();
        }

        private void Ventana_Load(object sender, EventArgs e)
        {
            int size = 8;
            int horizotal = 30;
            int vertical = 30;
            Button[,] buttonArray = new Button[size,size];

            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    buttonArray[i,j] = new Button();
                    buttonArray[i,j].Size = new Size(60, 23);
                    buttonArray[i,j].Location = new Point(horizotal, vertical);
                    buttonArray[i, j].Text = "0";
                    vertical += 30;
                    this.Controls.Add(buttonArray[i,j]);
                }
                horizotal += 80;
                vertical = 30;
            }
            int centro = size / 2;
            buttonArray[centro, centro].Text = "1";
            buttonArray[centro - 1, centro - 1].Text = "1";
            buttonArray[centro - 1, centro].Text = "2";
            buttonArray[centro, centro - 1].Text = "2";
        }
    }
}

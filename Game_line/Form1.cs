using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_line
{
    public partial class Form1 : Form
    {
        public static int[,] a = new int[9, 9];
        public static Label[,] Box = new Label[9, 9];

        public Form1()
        {
            InitializeComponent();
        }

   

        private void Create_Box()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    Box[i, j] = new Label();
                    Box[i, j].Location = new Point(5 + 60 * i, 95 + 60 * j);
                    Box[i, j].Size = new Size(50, 50);

                    Box[i, j].BackgroundImage = new Bitmap("None.bmp");

                    this.Controls.Add(Box[i, j]);
                    Box[i, j].Click += new EventHandler(Box_Click);
                }
        }

        private void Box_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Create_Box();
        }
    }
}

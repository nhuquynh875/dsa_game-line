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
    public partial class Game : Form
    {
        public static int[,] a = new int[9, 9];
        public static Label[,] Box = new Label[9, 9];

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            Create_Box();
            a = Create_matrix();
            Display_matrix(a);
        }

        private void Create_Box()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    Box[i, j] = new Label();
                    Box[i, j].Location = new Point(6 + 60 * i, 95 + 60 * j);
                    Box[i, j].Size = new Size(50, 50);

                    Box[i, j].BackgroundImage = new Bitmap("none.png");

                    this.Controls.Add(Box[i, j]);
                    Box[i, j].Click += new EventHandler(Box_Click);
                }
        }

        public static int[,] Create_matrix()
        {
            Random random = new Random();

            int[,] matrix = new int[9, 9];
            int i, j, remain, count;
            bool stop;

            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++) 
                    matrix[i, j] = 0;

            //create big ball
            count = 81;
            do
            {
                remain = random.Next(count--) + 1;
                stop = false;
                for (i = 0; i < 9; i++)
                {
                    if (stop) break;
                    for (j = 0; j < 9; j++)
                        if (matrix[i, j] == 0)
                        {
                            remain--;
                            if (remain == 0)
                            {
                                matrix[i, j] =  1; 
                                stop = true;
                                break;
                            }
                        }
                }
            } while (count > 76);

            Create_new_ball(matrix);

            return matrix;
        }
        public static void Create_new_ball(int[,] matrix)
        {

            Random random = new Random();
            int count = countEmpty(matrix);
            int tmp, i, j, remain;
            bool stop;

            for (tmp = 0; tmp < 3; tmp++)
            {
                remain = random.Next(count--) + 1;
                stop = false;
                for (i = 0; i < 9; i++)
                {
                    if (stop) break;
                    for (j = 0; j < 9; j++)
                    {
                        if (matrix[i, j] == 0)

                            remain--;
                        if (remain == 0)
                        {
                            matrix[i, j] = -1;
                            stop = true;
                            break;
                        }
                    }
                }
            }
        }

        public void Display_matrix(int[,] matrix)
        {
            for(int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                if (matrix[i, j] != 0)
                {

                    Box[i, j].Image = new Bitmap(Convert.ToString(matrix[i, j]) + ".png");
                }
                else

                    Box[i, j].Image = null;
        }

        private void Box_Click(object sender, EventArgs e)
        {

        }

        public static int countEmpty(int[,] ma)
        {
            int i, j, count = 0;
            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++)
                    if (ma[i, j] <= 0) count++;
            return count;
        }

        public static void  Check_to_end(int[,] ma)
        {
            int count = countEmpty(a);
            if (count <= 3)
            {
                MessageBox.Show("Game over!", "Thông báo");
            }
        }




    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_line
{
    public partial class Game : Form
    {
        public static int[,] a = new int[9, 9];
        public static Label[,] Box = new Label[9, 9];
        public static Label[] Pixel = new Label[9];


        public int Selectcol, Selectrow, Newcol, Newrow;
        public bool isSelect = false;
        private bool isTimerRunning = false;
        private bool stopTimer = false;

        public Queue<Point> shortest_path;
        public Point point;
        public Point lastPoint;

        public static int Score = 0;

        public int timecountofbox = 0;
        public int Timecount = 0;
        public int second = 0;
        public int minute = 0;
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
                    Box[i, j].BackColor = Color.Transparent;
                    Box[i, j].BackgroundImage = new Bitmap("none.png");

                    this.Controls.Add(Box[i, j]);
                    Box[i, j].Click += new EventHandler(Box_Click);
                }
                for (int i = 0; i < 4; i++)
                {
                    Pixel[i] = new Label();
                    Pixel[i].Location = new Point(499 - (i) * 41, 0);
                    Pixel[i].Size = new Size(41, 60);
                    this.Controls.Add(Pixel[i]);
                }
                for (int i = 4; i < 9; i++)
                {
                    Pixel[i] = new Label();
                    Pixel[i].Size = new Size(41, 60);
                    Pixel[i].Location = new Point(165 - (i - 4) * 41, 0);
                    this.Controls.Add(Pixel[i]);
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timecount++;
            second = Timecount / 2;
            minute = second / 60;
            second = second % 60;

            Pixel[4].Image = new Bitmap("so" + Convert.ToString(second % 10) + ".bmp");
            Pixel[5].Image = new Bitmap("so" + Convert.ToString(second / 10) + ".bmp");
            Pixel[7].Image = new Bitmap("so" + Convert.ToString(minute % 10) + ".bmp");
            Pixel[8].Image = new Bitmap("so" + Convert.ToString(minute / 10) + ".bmp");
            Pixel[6].Image = new Bitmap("haicham" + Convert.ToString(Timecount % 2) + ".bmp");


            int score= Score;
            for (int i = 0; i < 4; i++)
            {
                Pixel[i].Image = new Bitmap("so" + Convert.ToString(score % 10) + ".bmp");

                score = score / 10;
            }

        }

        private void Box_Click(object sender, EventArgs e)
        {
            Label boxs = sender as Label;
            Point[] p;

            if (a[(boxs.Location.X - 5) / 60, (boxs.Location.Y - 95) / 60] > 0)
            {
                if (isTimerRunning)
                {
                    timer.Stop();
                    stopTimer = true;
                    Box[Selectcol, Selectrow].Image = new Bitmap(Convert.ToString(a[Selectcol, Selectrow]) + ".png");
                }

                Selectcol = (boxs.Location.X - 5) / 60;
                Selectrow = (boxs.Location.Y - 95) / 60;
                isSelect = true;

                isTimerRunning = true;
                timer.Start();

            }
            else
            {
                if (isSelect)
                {

                    Newcol = (boxs.Location.X - 5) / 60;
                    Newrow = (boxs.Location.Y - 95) / 60;
                    Box[Selectcol, Selectrow].BackgroundImage = new Bitmap("none.png");

                    shortest_path = BFS(a, Selectcol, Selectrow, Newcol, Newrow);

                    if (shortest_path == null)
                        Console.WriteLine("can not move");
                    else
                    {
                        p = new Point[shortest_path.Count];
                        int count = shortest_path.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Point point = shortest_path.Dequeue();
                            p[i] = point;
                            lastPoint = point;

                            Box[p[i].X, p[i].Y].Image = new Bitmap(Convert.ToString(a[Selectcol, Selectrow]) + ".png");
                            Box[p[i].X, p[i].Y].Refresh();
                            System.Threading.Thread.Sleep(100);
                            if (a[p[i].X, p[i].Y] < 0) Box[p[i].X, p[i].Y].Image = new Bitmap(Convert.ToString(a[p[i].X, p[i].Y]) + ".png");
                            else
                                Box[p[i].X, p[i].Y].Image = new Bitmap("none.png");
                            Box[p[i].X, p[i].Y].Refresh();

          
                        }
                        Box[lastPoint.X, lastPoint.Y].Image = new Bitmap(Convert.ToString(a[Selectcol, Selectrow]) + ".png");
                        a[lastPoint.X, lastPoint.Y] = a[Selectcol, Selectrow];

                        a[Selectcol, Selectrow] = 0;


                        Display_matrix(a);
                    }
                }
                isSelect = false;
                isTimerRunning = false;
                Display_matrix(a);
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (stopTimer)
            {
                Box[Selectcol, Selectrow].Image = new Bitmap(Convert.ToString(a[Selectcol, Selectrow]) + ".png");
                stopTimer = false;
                timer.Stop();
                isTimerRunning = false;
                return;
            }

            if (a[Selectcol, Selectrow] > 0)
                if ((timecountofbox % 2) == 0) Box[Selectcol, Selectrow].Image = new Bitmap(Convert.ToString(-a[Selectcol, Selectrow]) + ".png");
                else
                    Box[Selectcol, Selectrow].Image = new Bitmap(Convert.ToString(a[Selectcol, Selectrow]) + ".png");
            else timer.Stop();

            timecountofbox++;
        }

        public static Queue<Point> BFS(int[,] matrix, int x1, int y1, int x2, int y2)
        {
            int[,] visited = new int[9, 9];
            Queue<Point> shortest_path = new Queue<Point>();

            int step = 0;
            int x, y;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (matrix[i, j] > 0) visited[i, j] = -1;
                    else visited[i, j] = 0;
                }
            visited[x1, y1] = 0;
            visited[x2, y2] = 1;
            for (int count = 0; count < 50; count++)
            {
                step++;

                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        if (visited[i, j] == step)
                        {
                            if ((j > 0) && (visited[i, j - 1] == 0)) visited[i, j - 1] = step + 1;
                            if ((j < 8) && (visited[i, j + 1] == 0)) visited[i, j + 1] = step + 1;
                            if ((i > 0) && (visited[i - 1, j] == 0)) visited[i - 1, j] = step + 1;
                            if ((i < 8) && (visited[i + 1, j] == 0)) visited[i + 1, j] = step + 1;
                        }
                    }
            }
            if (visited[x1, y1] == 0) return null;
            else
            {
                x = x1;
                y = y1;
                shortest_path.Enqueue(new Point(x, y));
                step = 0;
                while (step < visited[x1, y1] - 1)
                {

                    if (y > 0) if (visited[x, y - 1] == visited[x, y] - 1)
                        {
                            shortest_path.Enqueue(new Point(x, y - 1));
                            y = y - 1;
                            step++;
                        }

                    if (y < 8) if (visited[x, y + 1] == visited[x, y] - 1)
                        {
                            shortest_path.Enqueue(new Point(x, y + 1));
                            y = y + 1;
                            step++;

                        }

                    if (x > 0) if (visited[x - 1, y] == visited[x, y] - 1)
                        {
                            shortest_path.Enqueue(new Point(x - 1, y));
                            x = x - 1;
                            step++;
                        }

                    if (x < 8) if (visited[x + 1, y] == visited[x, y] - 1)
                        {
                            shortest_path.Enqueue(new Point(x + 1, y));
                            x = x + 1;
                            step++;
                        }
                }
            }

            return shortest_path;

        }

        public static int countEmpty(int[,] ma)
        {
            int i, j, count = 0;
            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++)
                    if (ma[i, j] <= 0) count++;
            return count;
        }




    }

    
}

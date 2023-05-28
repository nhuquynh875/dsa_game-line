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
using System.Collections;
using System.Media;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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

        public bool iscore = false;
        public bool menuDe = false;
        public bool menuBinhthuong = false;
        public bool menuKho = false;
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
                                matrix[i, j] = random.Next(4) + 1;
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
                            matrix[i, j] = -(random.Next(4) + 1);
                            stop = true;
                            break;
                        }
                    }
                }
            }
        }
                
        public void Display_matrix(int[,] matrix)
        {
            for (int i = 0; i < 9; i++)
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


            int score = Score;
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

                        KiemTra(a);
                        if (!iscore)
                        {
                            Tolen(a);
                            KiemTra(a);
                            GameOver(a);
                            Create_new_ball(a);
                        }
                        Display_matrix(a);
                    }
                }
                isSelect = false;
                isTimerRunning = false;
                Display_matrix(a);
            }
        }
        public void Tolen(int[,] matrix)
        {

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (matrix[i, j] < 0)
                    {
                        Box[i, j].Image = new Bitmap(Convert.ToString(-(matrix[i, j])) + ".png");
                        a[i, j] = -matrix[i, j];
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

        private void menuDe_Click(object sender, EventArgs e)
        {
            menuDe= true;
            menuKho= false;
            menuBinhthuong= false;
        }
        private void menuTrung_Click(object sender, EventArgs e)
        {
            menuDe = false;
            menuKho = false;
            menuBinhthuong = true;
        }
        private void menuKho_Click(object sender, EventArgs e)
        {
            menuDe = false;
            menuKho = true;
            menuBinhthuong = false;
        }
        private void helpmenu_click(object sender, EventArgs e)
        {
            GameRule pm = new GameRule();
            pm.ShowDialog();
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
        public void GameOver(int[,] matrix)
        {
            int count = countEmpty(a);
            if (count <= 5) //Chinh lai 3//
            { 
                SavePlayer_Data();
                newGameToolStripMenuItem();
                this.Hide();
                this.Dispose();
                GameOver go = new GameOver();
                go.Show();
            }
        }

        public void newGameToolStripMenuItem()
        {
            timer.Stop();
            timecountofbox = 0;
            Timecount = 0;
            second = Timecount / 2;
            minute = second / 60;
            second = second % 60;
            Score = 0;
            Pixel[4].Image = new Bitmap("so0.bmp");
            Pixel[5].Image = new Bitmap("so0.bmp");
            Pixel[7].Image = new Bitmap("so0.bmp");
            Pixel[8].Image = new Bitmap("so0.bmp");
            Pixel[6].Image = new Bitmap("haicham" + Convert.ToString(Timecount % 2) + ".bmp");

            Pixel[0].Image = null;
            Pixel[1].Image = null;
            Pixel[2].Image = null;
            Pixel[3].Image = null;
            


            Pixel[4].Image = null;
            Pixel[5].Image = null;
            Pixel[7].Image = null;
            Pixel[8].Image = null;
            Pixel[6].Image = null;

        }
        public void KiemTra(int[,] mt)
        {
            ArrayList arraylist = new ArrayList();
            int demngang, demdoc, demcheophai, demcheotrai, x, y;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    //Kiem tra hang ngang
                    x = i;
                    y = j;
                    demngang = 0;
                    while ((x < 8) && (mt[x, y] == mt[x + 1, y]) && (mt[x, y] != 0))
                    {
                        demngang++;
                        x++;
                    }
                    //Kiem tra hang doc
                    x = i;
                    y = j;
                    demdoc = 0;
                    while ((y < 8) && (mt[x, y] == mt[x, y + 1]) && (mt[x, y] != 0))
                    {
                        demdoc++;
                        y++;
                    }
                    //Kiem tra cheo phai
                    x = i;
                    y = j;
                    demcheophai = 0;
                    while ((x < 8) && (y < 8) && (mt[x, y] == mt[x + 1, y + 1]) && (mt[x, y] != 0))
                    {
                        demcheophai++;
                        x++;
                        y++;
                    }

                    // Kiem tra cheo phai
                    x = i;
                    y = j;
                    demcheotrai = 0;
                    while ((x > 0) && (y < 8) && (mt[x, y] == mt[x - 1, y + 1]) && (mt[x, y] != 0))
                    {
                        demcheotrai++;
                        x--;
                        y++;
                    }

                    if (menuDe == true)
                    {
                        if (demngang >= 2)
                        {
                            for (int k = 1; k < (demngang + 1); k++) a[i + k, j] = 0;
                            arraylist.Add(new Point(i, j)); Score += demngang + 1;
                        }
                        else if (demdoc >= 2)
                        {
                            for (int k = 1; k < (demdoc + 1); k++) a[i, j + k] = 0;
                            arraylist.Add(new Point(i, j)); Score += demdoc + 1;
                        }
                        else if (demcheophai >= 2)
                        {
                            for (int k = 1; k < (demcheophai + 1); k++) a[i + k, j + k] = 0; 
                            arraylist.Add(new Point(i, j)); Score += demcheophai + 1;
                        }
                        else if (demcheotrai >= 2)
                        {
                            for (int k = 1; k < (demcheotrai + 1); k++) a[i - k, j + k] = 0;
                            arraylist.Add(new Point(i, j)); Score += demcheotrai + 1;
                        }
                        else if ((demngang > 2) || (demdoc > 2) || (demcheotrai > 2) || (demcheophai > 2)) Score += demcheophai + demcheotrai + demdoc + demngang - 1;
                    }
                    if (menuBinhthuong == true)
                    {
                        if (demngang >= 3)
                        {
                            for (int k = 1; k < (demngang + 1); k++) a[i + k, j] = 0;
                            arraylist.Add(new Point(i, j)); Score += demngang + 1;
                        }
                        else if (demdoc >= 3)
                        {
                            for (int k = 1; k < (demdoc + 1); k++) a[i, j + k] = 0;
                            arraylist.Add(new Point(i, j)); Score += demdoc + 1;
                        }
                        else if (demcheophai >= 3)
                        {
                            for (int k = 1; k < (demcheophai + 1); k++)
                                a[i + k, j + k] = 0; arraylist.Add(new Point(i, j)); Score += demcheophai + 1;
                        }
                        else if (demcheotrai >= 3)
                        {
                            for (int k = 1; k < (demcheotrai + 1); k++) a[i - k, j + k] = 0;
                            arraylist.Add(new Point(i, j)); Score += demcheotrai + 1;
                        }
                        else if ((demngang > 3) || (demdoc > 3) || (demcheotrai > 3) || (demcheophai > 3)) Score += demcheophai + demcheotrai + demdoc + demngang - 1;
                    }
                    if (menuKho == true)
                    {
                        if (demngang >= 4)
                        {
                            for (int k = 1; k < (demngang + 1); k++) a[i + k, j] = 0;
                            arraylist.Add(new Point(i, j)); Score += demngang + 1;
                        }
                        else if (demdoc >= 4)
                        {
                            for (int k = 1; k < (demdoc + 1); k++) a[i, j + k] = 0;
                            arraylist.Add(new Point(i, j)); Score += demdoc + 1;
                        }
                        else if (demcheophai >= 4)
                        {
                            for (int k = 1; k < (demcheophai + 1); k++)
                                a[i + k, j + k] = 0; arraylist.Add(new Point(i, j)); Score += demcheophai + 1;
                        }
                        else if (demcheotrai >= 4)
                        {
                            for (int k = 1; k < (demcheotrai + 1); k++) a[i - k, j + k] = 0;
                            arraylist.Add(new Point(i, j)); Score += demcheotrai + 1;
                        }
                        else if ((demngang > 4) || (demdoc > 4) || (demcheotrai > 4) || (demcheophai > 4)) Score += demcheophai + demcheotrai + demdoc + demngang - 1;
                    }
                }
            for (int k = 0; k < arraylist.Count; k++)
            {
                point = (Point)arraylist[k];
                a[point.X, point.Y] = 0;
                //destroy.Play();
            }

            if (arraylist.Count == 0)
            {
                iscore = false;
            }
            else iscore = true;

            Display_matrix(a);

        }

        private void SavePlayer_Data()
        {
            try
            {
                FileStream stream = new FileStream("Score.txt", FileMode.Append, FileAccess.Write);
                StreamWriter write = new StreamWriter(stream, Encoding.Unicode);//mac dinh la unicode
                write.WriteLine(Player.playerName);
                write.WriteLine(Score);
                write.WriteLine(Timecount);
                write.Flush();// dung de xac dinh: xoa tat ca du lieu tu vung dem va du lieu chi duoc ghi tu vung dem
                write.Close();
                stream.Close();
            }
            catch
            {
                MessageBox.Show("The progress has some difficulties", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}

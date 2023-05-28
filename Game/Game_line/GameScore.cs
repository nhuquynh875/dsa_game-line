using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Media;


namespace Lines2010
{
    public partial class highScore : DevComponents.DotNetBar.Office2007Form
    {
        int i;
        String[] Name = new string[1000000];
        String[] Score = new string[1000000];
        string[] Time = new string[100000];
        public SoundPlayer nhac = new SoundPlayer("WORK.WAV");
        public highScore()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            nhac.Stop();
            this.Close();
        }
        private void Sort(string[] a, string[] b, string[] c)
        {

            string tg;
            for (int j = 0; j < i - 1; j++)
                for (int k = j + 1; k < i; k++)
                {
                    if (Convert.ToInt32(Score[k]) > Convert.ToInt32(Score[j]))
                    {
                        tg = a[k];
                        a[k] = a[j];
                        a[j] = tg;
                        tg = b[k];
                        b[k] = b[j];
                        b[j] = tg;
                    }
                }
        }
        private void ReadData()
        {

            try
            {
                i = 0;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(@"Score.txt");

                Name[i] = sr.ReadLine();
                Score[i] = sr.ReadLine();
                Time[i] = sr.ReadLine();

                while (Name[i] != null)
                {

                    i++;
                    Name[i] = sr.ReadLine();
                    Score[i] = sr.ReadLine();
                    Time[i] = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void High_Scores_Load(object sender, EventArgs e)
        {
            nhac.Play();
            ReadData();
            Sort(Score, Name, Time);
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(15, 10), new Size(300, 200));

            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.BeginUpdate();
            listView1.Items.Clear();
            int result;
            if (i < 10)
            {
                result = i;
            }
            else
            {
                result = 10;

            }
            for (int j = 0; j < result; j++)
            {
                ListViewItem listItem = new ListViewItem(Convert.ToString(j + 1));

                listItem.SubItems.Add(Name[j]);
                listItem.SubItems.Add(Score[j]);
                listItem.SubItems.Add(Time[j]);
                listView1.Items.Add(listItem);
            }
            listView1.Columns.Add("STT", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Score", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Time", -2, HorizontalAlignment.Left);
            listView1.EndUpdate();

            this.Controls.Add(listView1);
        }

        private void HighScore_FormClosed(object sender, FormClosedEventArgs e)
        {
            nhac.Stop();
        }

    }
}

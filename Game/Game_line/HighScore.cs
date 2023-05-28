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

namespace Game_line
{
    public partial class HighScore : Form
    {
        int i;
        String[] Name = new string[1000000];
        String[] Score = new string[1000000];
        string[] Time = new string[100000];
        public HighScore()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
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
                int i = 0;
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Score.txt");

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

        private void HighScore_Load(object sender, EventArgs e)
        {
            ReadData();
            Sort(Score, Name, Time);
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(15, 10), new Size(300, 200));

            
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
            listView1.View = View.Details;
            listView1.Columns.Add("STT", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Họ tên", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Điểm", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Thời gian", -2, HorizontalAlignment.Left);
            for (i = 0; i < /*result*/ listView1.Columns.Count; i++)
            {
                ListViewItem listItem = new ListViewItem(Convert.ToString(2));
                MessageBox.Show("asfasdf");
                listItem.SubItems.Add(Name[i]);
                listItem.SubItems.Add(Score[i]);
                listItem.SubItems.Add(Time[i]);
                listView1.Items.Add(listItem);
                
            }
            
            listView1.EndUpdate();

            this.Controls.Add(listView1);
        }
    }
}

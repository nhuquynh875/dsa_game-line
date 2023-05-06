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
    public partial class highgrade : DevComponents.DotNetBar.Office2007Form
    {
        int i;
        String[] Ten = new string[1000000];
        String[] Diem = new string[1000000];
        string[]ThoiGian = new string[100000];
        public SoundPlayer nhac = new SoundPlayer("WORK.WAV");
        public highgrade()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            nhac.Stop();
            this.Close();
        }
         private void Sort( string[] a,string [] b,string[] c)
        {
          
            string tg;
            for (int j = 0; j < i - 1; j++)
                for (int k = j + 1; k < i; k++)
                {
                    if (Convert.ToInt32(Diem[k]) > Convert.ToInt32(Diem[j]))
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
                StreamReader sr = new StreamReader(@"diem.txt");

                Ten[i] = sr.ReadLine();
                Diem[i] = sr.ReadLine();
                ThoiGian[i] = sr.ReadLine();

                while (Ten[i] != null)
                {

                    i++;
                    Ten[i] = sr.ReadLine();
                    Diem[i] = sr.ReadLine();
                    ThoiGian[i] = sr.ReadLine();
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

        private void Frm_High_Scores_Load(object sender, EventArgs e)
        {
            nhac.Play();
            ReadData();
            Sort(Diem, Ten, ThoiGian);
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

                listItem.SubItems.Add(Ten[j]);
                listItem.SubItems.Add(Diem[j]);
                listItem.SubItems.Add(ThoiGian[j]);
                listView1.Items.Add(listItem);
            }
            listView1.Columns.Add("STT", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("score", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Time", -2, HorizontalAlignment.Left);
            listView1.EndUpdate();

            this.Controls.Add(listView1);
        }

        private void frmDiemCao_FormClosed(object sender, FormClosedEventArgs e)
        {
            nhac.Stop();
        }

    }
    }


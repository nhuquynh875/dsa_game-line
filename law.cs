using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Lines2010
{
    public partial class law : DevComponents.DotNetBar.Office2007Form
    {
        public law()
        {
            InitializeComponent();
        }
        public static SoundPlayer love = new SoundPlayer("nen.WAV");
        private void btn_OK_Click(object sender, EventArgs e)
        {
            love.Stop();
            this.Close();
        }

        private void frmLuatChoi_Load(object sender, EventArgs e)
        {
            love.Play();
        }

        private void frmLuatChoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            love.Stop();
        }
    }
}

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
    public partial class GameRule : Form
    {
        public GameRule()
        {
            InitializeComponent();
        }

        private void OK_click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void Gamerule_Load(object sender, EventArgs e)
        {
            
        }

        private void Gamerule_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

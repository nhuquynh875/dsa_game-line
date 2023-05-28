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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.newGameToolStripMenuItem_Click();
            game.ShowDialog();
            this.Close();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }

        private void Exit_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

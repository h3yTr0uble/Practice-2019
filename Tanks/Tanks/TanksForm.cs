using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    
    public partial class TanksForm : Form
    {
        public static Random rnd = new Random();
        public static int sizeCell = 25;
        private Game newGame = new Game();

        public TanksForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map.Width = 500;
            map.Height = 500;

           
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            newGame.Start(this);
            GameStep.Enabled = true;
        }

        private void GameStep_Tick(object sender, EventArgs e)
        {
            newGame.Step();
        }

        private void TanksForm_KeyDown(object sender, KeyEventArgs e)
        {
            newGame.OnKeyPress(e.KeyCode);
        }


    }
}

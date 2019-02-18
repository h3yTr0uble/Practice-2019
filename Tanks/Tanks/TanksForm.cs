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

        public TanksForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map.Width = 500;
            map.Height = 500;
            //Bitmap backgroundMap = new Bitmap(map.Width, map.Height);
            //Graphics mapGraphics = Graphics.FromImage(backgroundMap);
            //mapGraphics.FillRectangle(Brushes.Black, 0, 0, map.Width, map.Height);
            //for (int i = 0; i < 20; i++)
            //{
            //    mapGraphics.DrawImage(new Bitmap("wall1.png"), 0, i* sizeCell, sizeCell, sizeCell);
            //    mapGraphics.DrawImage(new Bitmap("wall1.png"), 19 * sizeCell, i * sizeCell, sizeCell, sizeCell);
            //    mapGraphics.DrawImage(new Bitmap("wall1.png"), i * sizeCell, 0, sizeCell, sizeCell);
            //    mapGraphics.DrawImage(new Bitmap("wall1.png"), i * sizeCell, 19 * sizeCell, sizeCell, sizeCell);
            //}
            //map.Image = backgroundMap;
        }

    }
}

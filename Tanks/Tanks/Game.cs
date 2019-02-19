using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public class Game
    {
        private static Bitmap backgroundMap;
        private static Graphics mapGraphics;
        private static Kolobok kolobok;
        private static PictureBox map;
        private static List<Wall> Walls = new List<Wall>();

        public void Start(TanksForm fm)
        {
            map = fm.map;
            backgroundMap = new Bitmap(map.Width, map.Height);
            mapGraphics = Graphics.FromImage(backgroundMap);
            mapGraphics.FillRectangle(Brushes.Black, 0, 0, map.Width, map.Height);
            for (int i = 0; i < 20; i++)
            {
                Walls.Add(new Wall(0, i));
                mapGraphics.DrawImage(Walls[i].Img, Walls[i].X, Walls[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                //mapGraphics.DrawImage(wall.Img, 19 * TanksForm.sizeCell, i * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                //mapGraphics.DrawImage(wall.Img, i * TanksForm.sizeCell, 0, TanksForm.sizeCell, TanksForm.sizeCell);
                //mapGraphics.DrawImage(wall.Img, i * TanksForm.sizeCell, 19 * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            }
            kolobok = new Kolobok();
            SubscribeKeyPress();
            mapGraphics.DrawImage(kolobok.Img, kolobok.X * TanksForm.sizeCell, kolobok.Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            map.Image = backgroundMap;
        }

        public void Step()
        {
            mapGraphics.FillRectangle(Brushes.Black, kolobok.X * TanksForm.sizeCell, kolobok.Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            kolobok.Move();
            mapGraphics.DrawImage(kolobok.Img, kolobok.X * TanksForm.sizeCell, kolobok.Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            map.Image = backgroundMap;
        }


        private event KeyEventHandler KeyPress;

        public void OnKeyPress(Keys key)
        {
            KeyPress?.Invoke(kolobok, new KeyEventArgs(key));
        }

        public void SubscribeKeyPress()
        {
            KeyPress += new KeyEventHandler(kolobok.OnKeyPress);
        }
    }
}

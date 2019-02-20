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
using Tanks.Properties;

namespace Tanks
{
    public class Game
    {
        private Bitmap backgroundMap;
        private Graphics mapGraphics;
        private Kolobok kolobok;
        private PictureBox map;
        private List<Wall> Walls = new List<Wall>();
        private List<Apple> Apples = new List<Apple>();
        private List<Shot> ShotsKolobok = new List<Shot>();
        private List<Shot> ShotsTanks = new List<Shot>();
        private List<Tank> Tanks = new List<Tank>();
        public int Score { get; protected set; }
        public bool gameOver { get; protected set; } = false;
        public int Delta { get; protected set; } = 30;
        private string[] example = {"XXXXXXXXXXXXXXXXXXXX",
                                    "X                  X",
                                    "X       XXXX       X",
                                    "X  XX          XX  X",
                                    "X  XX  XX  XX  XX  X",
                                    "X  XX  XXXXXX  XX  X",
                                    "X  XX  XX  XX  XX  X",
                                    "X  XX          XX  X",
                                    "X        XX        X",
                                    "XXX   XX    XX   XXX",
                                    "XXX   XX    XX   XXX",
                                    "X        XX        X",
                                    "X  XX          XX  X",
                                    "X  XX  XX  XX  XX  X",
                                    "X  XX  XXXXXX  XX  X",
                                    "X  XX  XX  XX  XX  X",
                                    "X  XX          XX  X",
                                    "X       XXXX       X",
                                    "X                  X",
                                    "XXXXXXXXXXXXXXXXXXXX"};

        public void Start(TanksForm fm)
        {
            UnSubscribe();
            Apples.Clear();
            Tanks.Clear();
            Walls.Clear();
            ShotsKolobok.Clear();
            kolobok = null;
            gameOver = false;
            Score = 0;
            Delta = 30;
            map = fm.map;
            backgroundMap = new Bitmap(map.Width, map.Height);
            mapGraphics = Graphics.FromImage(backgroundMap);
            mapGraphics.FillRectangle(Brushes.Black, 0, 0, map.Width, map.Height);
            for (int i = 0; i < example.Count(); i++)
            {
                for (int j = 0; j < example[i].Length; j++)
                {
                    if (example[i][j]=='X')
                    {
                        Walls.Add(new Wall(j, i));
                        mapGraphics.DrawImage(Walls.Last().Img, Walls.Last().X * TanksForm.sizeCell, Walls.Last().Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                    }
                }
               
            }


            SpawnApples();

            while (Tanks.Count < 5)
            {
                Tanks.Add(new Tank());
                foreach (var item in Walls)
                {
                    if (Tanks.Last().CollidesWith(item))
                    {
                        Tanks.RemoveAt(Tanks.Count - 1);
                        break;
                    }
                }
            }

            for (int i = 0; i < Apples.Count; i++)
            {
                mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * TanksForm.sizeCell, Apples[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            }

            for (int i = 0; i < 5; i++)
            {
                mapGraphics.DrawImage(Tanks[i].Img, Tanks[i].X * TanksForm.sizeCell, Tanks[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            }

            while(true)
            {
                kolobok = new Kolobok();
                if (!kolobok.CollidesWithWalls(Walls))
                {
                    break;
                }
            }
            
            Subscribe();
            mapGraphics.DrawImage(kolobok.Img, kolobok.X * TanksForm.sizeCell, kolobok.Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            map.Image = backgroundMap;
        }


        public void SpawnApples()
        {
            while (Apples.Count < 5)
            {
                Apples.Add(new Apple());
                foreach (var item in Walls)
                {
                    if (Apples.Last().CollidesWith(item))
                    {
                        Apples.RemoveAt(Apples.Count - 1);
                        break;
                    }
                }

                for (int i = 0; i < Apples.Count; i++)
                {
                    if (Apples.Last().CollidesWith(Apples[i]) && Apples.Last() != Apples[i])
                    {
                        Apples.RemoveAt(Apples.Count - 1);
                        break;
                    }
                }
            }
        }

        public void Step()
        {
            
            while (Delta!= TanksForm.sizeCell + 5)
            {
                for (int i = 0; i < ShotsKolobok.Count; i++)
                {
                    Move(ShotsKolobok[i], Delta);
                }

                Move(kolobok, Delta);

                for (int i = 0; i < Tanks.Count; i++)
                {
                    Move(Tanks[i], Delta);
                }

               

                for (int i = 0; i < Apples.Count; i++)
                {
                    mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * TanksForm.sizeCell, Apples[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                }
                if (gameOver)
                {
                    GameOver();
                }
                Delta += 5;
                map.Image = backgroundMap;
                return;
            }
            kolobok.Move(Walls);
            Delta = 5;
            Move(kolobok, Delta);
            

            for (int i = 0; i < Tanks.Count; i++)
            {
                if (Tanks[i].CollidesWith(kolobok))
                {
                    gameOver = true;
                    return;
                }
                for (int j = 0; j < ShotsKolobok.Count; j++)
                {
                    if (Tanks[i].CollidesWith(ShotsKolobok[j]))
                    {
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].X * TanksForm.sizeCell, Tanks[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        Tanks.RemoveAt(i);
                        ShotsKolobok.RemoveAt(j);
                        i--;
                        j--;
                    }
                }
            }

            for (int i = 0; i < Tanks.Count; i++)
            {
                Tanks[i].Move(Walls, Tanks);
                Move(Tanks[i], Delta);
            }

            for (int i = 0; i < ShotsKolobok.Count; i++)
            {
                ShotsKolobok[i].Move();
                if (ShotsKolobok[i].CollidesWithWalls(Walls))
                {
                    mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[i].OldX * TanksForm.sizeCell, ShotsKolobok[i].OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                    ShotsKolobok.RemoveAt(i);
                    i--;
                }
                
            }


            Delta += 5;
            map.Image = backgroundMap;

            for (int i = 0; i < Apples.Count; i++)
            {
                if (Apples[i].CollidesWith(kolobok))
                {
                    Apples.RemoveAt(i);
                    Score++;
                    break;
                }
            }

            for (int i = 0; i < Tanks.Count; i++)
            {
                if (Tanks[i].CollidesWith(kolobok))
                {
                    gameOver = true;
                    return;
                }


            }

            SpawnApples();
            for (int i = 0; i < Apples.Count; i++)
            {
                mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * TanksForm.sizeCell, Apples[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            }
            map.Image = backgroundMap;
        }


        public void Move(MovebleObj obj, int delta)
        {
            if (obj.OldX < obj.X)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.OldX * TanksForm.sizeCell + delta - 5, obj.OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.OldX * TanksForm.sizeCell + delta, obj.OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                return;
            }
            if (obj.OldX > obj.X)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.OldX * TanksForm.sizeCell - delta + 5, obj.OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.OldX * TanksForm.sizeCell - delta, obj.OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                return;
            }
            if (obj.OldY < obj.Y)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.OldX * TanksForm.sizeCell, obj.OldY * TanksForm.sizeCell + delta - 5, TanksForm.sizeCell, TanksForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.OldX * TanksForm.sizeCell, obj.OldY * TanksForm.sizeCell + delta, TanksForm.sizeCell, TanksForm.sizeCell);
                return;
            }
            if (obj.OldY > obj.Y)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.OldX * TanksForm.sizeCell, obj.OldY * TanksForm.sizeCell - delta + 5, TanksForm.sizeCell, TanksForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.OldX * TanksForm.sizeCell, obj.OldY * TanksForm.sizeCell - delta, TanksForm.sizeCell, TanksForm.sizeCell);
                return;
            }
            if (obj.OldY == obj.Y && obj.OldX > obj.X)
            {
                mapGraphics.FillRectangle(Brushes.Black, obj.OldX * TanksForm.sizeCell, obj.Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                mapGraphics.DrawImage(obj.Img, obj.X * TanksForm.sizeCell, obj.Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                return;
            }

        }


        public void GameOver()
        {
            mapGraphics.DrawImage(new Bitmap(Resources.gameOver), 0, 0, 500, 500);
            map.Image = backgroundMap;
            UnSubscribe();
        }

        private event KeyEventHandler KeyPress;

        public void OnKeyPress(Keys key)
        {
            KeyPress?.Invoke(kolobok, new KeyEventArgs(key));
        }

        public void Subscribe()
        {
            KeyPress += new KeyEventHandler(kolobok.OnKeyPress);
            kolobok.ShootOff += CreateShotKolobok;
        }

        public void UnSubscribe()
        {
            if (KeyPress!=null)
            {
                KeyPress -= new KeyEventHandler(kolobok.OnKeyPress);
            }
        }

        public void CreateShotKolobok(MovebleObj sender)
        {
            switch (sender.DirectionTo)
            {
                case (int)Direction.Down:
                    {
                        ShotsKolobok.Add(new Shot(sender.X, sender.Y+1, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.Left:
                    {
                        ShotsKolobok.Add(new Shot(sender.X-1, sender.Y, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.Right:
                    {
                        ShotsKolobok.Add(new Shot(sender.X+1, sender.Y, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.Up:
                    {
                        ShotsKolobok.Add(new Shot(sender.X, sender.Y-1, sender.DirectionTo, sender));
                        break;
                    }
                default:
                    break;
            }

        }

    }
}

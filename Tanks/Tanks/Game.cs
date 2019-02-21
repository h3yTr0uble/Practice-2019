using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class Game
    {
        private Bitmap backgroundMap;
        private Graphics mapGraphics;
        public Kolobok kolobok { get; protected set; }
        private PictureBox map;
        public List<Wall> Walls { get; protected set; } = new List<Wall>();
        public List<Apple> Apples { get; protected set; } = new List<Apple>();
        public List<Shot> ShotsKolobok { get; protected set; } = new List<Shot>();
        public List<Shot> ShotsTanks { get; protected set; } = new List<Shot>();
        public List<Tank> Tanks { get; protected set; } = new List<Tank>();
        private int applesCount = 5;
        private int tanksCount = 5;
        public int Score { get; protected set; }
        public bool gameOver { get; protected set; } = false;
        public int Delta { get; protected set; } = 30;
        public int DeltaShots { get; protected set; } = 30;
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

        public Game() { }

        public Game(int applesCount, int tanksCount)
        {
            this.applesCount = applesCount;
            this.tanksCount = tanksCount;
        }

        public void Start(TanksForm fm)
        {
            UnSubscribe();
            Apples.Clear();
            Tanks.Clear();
            Walls.Clear();
            ShotsKolobok.Clear();
            ShotsTanks.Clear();
            kolobok = null;
            gameOver = false;
            Score = 0;
            Delta = 30;
            DeltaShots = 30;
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

            while (Tanks.Count < tanksCount)
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

            for (int i = 0; i < Tanks.Count; i++)
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
            while (Apples.Count < applesCount)
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

        

        public void StepOfShots()
        {
            while (DeltaShots != TanksForm.sizeCell + 5)
            {
                for (int i = 0; i < ShotsKolobok.Count; i++)
                {
                    Move(ShotsKolobok[i], DeltaShots);
                }

                for (int i = 0; i < ShotsTanks.Count; i++)
                {
                    Move(ShotsTanks[i], DeltaShots);
                }



                for (int i = 0; i < Apples.Count; i++)
                {
                    mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * TanksForm.sizeCell, Apples[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                }

                DeltaShots += 5;
                map.Image = backgroundMap;
                return;
            }

          
            DeltaShots = 5;
           


            for (int j = 0; j < ShotsTanks.Count; j++)
            {
                if (kolobok.CollidesWith(ShotsTanks[j]))
                {
                    gameOver = true;
                    break;
                }
            }

            for (int i = 0; i < Tanks.Count; i++)
            {
                
                for (int j = 0; j < ShotsKolobok.Count; j++)
                {
                    if (Tanks[i].CollidesWith(ShotsKolobok[j]))
                    {
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].OldX * TanksForm.sizeCell, Tanks[i].OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].X * TanksForm.sizeCell, ShotsKolobok[j].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].X * TanksForm.sizeCell, Tanks[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].OldX * TanksForm.sizeCell, ShotsKolobok[j].OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        Tanks.RemoveAt(i);
                        ShotsKolobok.RemoveAt(j);
                        i--;
                        j--;
                        break;
                    }
                }
               
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

            for (int i = 0; i < ShotsTanks.Count; i++)
            {
                ShotsTanks[i].Move();
                if (ShotsTanks[i].CollidesWithWalls(Walls))
                {
                    mapGraphics.FillRectangle(Brushes.Black, ShotsTanks[i].OldX * TanksForm.sizeCell, ShotsTanks[i].OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                    ShotsTanks.RemoveAt(i);
                    i--;
                    continue;
                }
                if (kolobok.CollidesWith(ShotsTanks[i]))
                {
                    gameOver = true;
                    break;
                }
            }


            for (int i = 0; i < Tanks.Count; i++)
            {
                for (int j = 0; j < ShotsKolobok.Count; j++)
                {
                    if (Tanks[i].CollidesWith(ShotsKolobok[j]))
                    {
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].OldX * TanksForm.sizeCell, Tanks[i].OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].X * TanksForm.sizeCell, ShotsKolobok[j].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, Tanks[i].X * TanksForm.sizeCell, Tanks[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        mapGraphics.FillRectangle(Brushes.Black, ShotsKolobok[j].OldX * TanksForm.sizeCell, ShotsKolobok[j].OldY * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
                        Tanks.RemoveAt(i);
                        ShotsKolobok.RemoveAt(j);
                        i--;
                        j--;
                        break;
                    }
                }
            }



            for (int i = 0; i < Apples.Count; i++)
            {
                if (Apples[i].CollidesWith(kolobok))
                {
                    Apples.RemoveAt(i);
                    Score++;
                    break;
                }
                mapGraphics.DrawImage(Apples[i].Img, Apples[i].X * TanksForm.sizeCell, Apples[i].Y * TanksForm.sizeCell, TanksForm.sizeCell, TanksForm.sizeCell);
            }

            SpawnApples();
            DeltaShots += 5;
            map.Image = backgroundMap;
        }

        public void Step()
        {

            while (Delta != TanksForm.sizeCell + 5)
            {
                

                Move(kolobok, Delta);

                for (int i = 0; i < Tanks.Count; i++)
                {
                    Move(Tanks[i], Delta);
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
                Tanks[i].Move(Walls, Tanks);
                
                if (Tanks[i].CollidesWith(kolobok))
                {
                    gameOver = true;
                    return;
                }
                Move(Tanks[i], Delta);
            }

            Delta += 5;
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
            for (int i = 0; i < Tanks.Count; i++)
            {
                Tanks[i].ShootOff += CreateShotTank;
            }
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
            for (int i = 0; i < ShotsKolobok.Count-1; i++)
            {
                if (ShotsKolobok.Last().CollidesWith(ShotsKolobok[i]))
                {
                    ShotsKolobok.RemoveAt(ShotsKolobok.Count - 1);
                    return;
                }
            }
            if (ShotsKolobok.Last().CollidesWithWalls(Walls))
            {
                ShotsKolobok.RemoveAt(ShotsKolobok.Count - 1);
                return;
            }
        }


        public void CreateShotTank(MovebleObj sender)
        {
            switch (sender.DirectionTo)
            {
                case (int)Direction.Down:
                    {
                        ShotsTanks.Add(new Shot(sender.X, sender.Y + 1, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.Left:
                    {
                        ShotsTanks.Add(new Shot(sender.X - 1, sender.Y, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.Right:
                    {
                        ShotsTanks.Add(new Shot(sender.X + 1, sender.Y, sender.DirectionTo, sender));
                        break;
                    }
                case (int)Direction.Up:
                    {
                        ShotsTanks.Add(new Shot(sender.X, sender.Y - 1, sender.DirectionTo, sender));
                        break;
                    }
                default:
                    break;
            }
            if (ShotsTanks.Last().CollidesWithWalls(Walls))
            {
                ShotsTanks.RemoveAt(ShotsTanks.Count - 1);
            }
        }
    }
}

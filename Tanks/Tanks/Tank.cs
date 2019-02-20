using System;
using System.Collections.Generic;
using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    public class Tank: MovebleObj
    {
        private Random rnd = new Random();
        public Tank() : base()
        {
        }

        public Tank(int x, int y) : base(x, y)
        {
        }

        public event CreateShot ShootOff;

        public void Move(List<Wall> Walls, List<Tank> Tanks)
        {
            if (rnd.NextDouble() < 0.3)
            {
                IdentifyDirection(TanksForm.rnd.Next(0, 4));
            }

            if (rnd.NextDouble() < 0.15)
            {
                ShootOff?.Invoke(this);
            }


            switch (DirectionTo)
            {
                case (int)Direction.Down:
                    {
                        OldY = Y;
                        OldX = X;
                        Y++;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            Y--;
                            IdentifyDirection((int)Direction.Up);
                        }
                        break;
                    }
                case (int)Direction.Left:
                    {
                        OldY = Y;
                        OldX = X;
                        X--;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            X++;
                            IdentifyDirection((int)Direction.Right);
                        }
                        break;
                    }
                case (int)Direction.Right:
                    {
                        OldY = Y;
                        OldX = X;
                        X++;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            X--;
                            IdentifyDirection((int)Direction.Left);
                        }
                        break;
                    }
                case (int)Direction.Up:
                    {
                        OldY = Y;
                        OldX = X;
                        Y--;
                        if (CollidesWithWalls(Walls) || CollidesWithTanks(Tanks))
                        {
                            Y++;
                            IdentifyDirection((int)Direction.Down);
                        }
                        break;
                    }
                default:
                    break;
            }
            ChangePicture();
        }


        public bool CollidesWithTanks(List<Tank> Tanks)
        {
            for (int i = 0; i < Tanks.Count; i++)
            {
                if (CollidesWith(Tanks[i]) && this!=Tanks[i])
                {
                    return true;
                }
            }
            return false;
        }


        public override void ChangePicture()
        {
            if (Img == null)
            {
                Img = new Bitmap(Resources.tankLeft);
            }
            switch (DirectionTo)
            {
                case (int)Direction.Up:
                    {
                        Img = Resources.tankUp;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        Img = Resources.tankDown;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        Img = Resources.tankRight;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        Img = Resources.tankLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

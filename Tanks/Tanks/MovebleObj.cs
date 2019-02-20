using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public abstract class MovebleObj:Obj
    {
        public int DirectionTo { get; set; }
        public MovebleObj() : base()
        {
            DirectionTo = TanksForm.rnd.Next(0, 4);
            ChangePicture();
        }

        public MovebleObj(int x, int y) : base(x, y)
        {
            DirectionTo = TanksForm.rnd.Next(0, 4);
            ChangePicture();
        }

        public void IdentifyDirection(int direction)
        {
            switch (direction)
            {
                case (int)Direction.Down:
                    {
                        DirectionTo = (int)Direction.Down;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        DirectionTo = (int)Direction.Left;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        DirectionTo = (int)Direction.Right;
                        break;
                    }
                case (int)Direction.Up:
                    {
                        DirectionTo = (int)Direction.Up;
                        break;
                    }
                default:
                    break;
            }
            ChangePicture();
        }

        public virtual void Move(List<Wall> Walls, List<Tank> Tanks)
        {
            switch (DirectionTo)
            {
                case (int)Direction.Down:
                    {
                        Y++;
                        if (CollidesWithWalls(Walls))
                        {
                            Y--;
                            IdentifyDirection((int)Direction.Up);
                        }
                        break;
                    }
                case (int)Direction.Left:
                    {
                        X--;
                        if (CollidesWithWalls(Walls))
                        {
                            X++;
                            IdentifyDirection((int)Direction.Right);
                        }
                        break;
                    }
                case (int)Direction.Right:
                    {
                        X++;
                        if (CollidesWithWalls(Walls))
                        {
                            X--;
                            IdentifyDirection((int)Direction.Left);
                        }
                        break;
                    }
                case (int)Direction.Up:
                    {
                        Y--;
                        if (CollidesWithWalls(Walls))
                        {
                            Y++;
                            IdentifyDirection((int)Direction.Down);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public bool CollidesWithWalls(List<Wall> Walls)
        {
            foreach (var item in Walls)
            {
                if (CollidesWith(item))
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void ChangePicture();
    }
}

using System.Collections.Generic;

namespace Tanks
{
    public abstract class MovebleObj:Obj
    {
        public int OldX { get; protected set; }
        public int OldY { get; protected set; }
        public int DirectionTo { get; set; }

        public delegate void CreateShot(MovebleObj sender);

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

        public MovebleObj(int x, int y, int direction) : base(x, y)
        {
            DirectionTo = direction;
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

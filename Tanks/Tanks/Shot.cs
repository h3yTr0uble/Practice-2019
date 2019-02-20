using System.Drawing;
using Tanks.Properties;

namespace Tanks
{
    public class Shot : MovebleObj
    {
        public MovebleObj Sender { get; protected set; }
        public Shot() : base()
        {
        }

        public Shot(int x, int y) : base(x, y)
        {
            OldX = x;
            OldY = y;
        }

        public Shot(int x, int y, int direction) : base(x, y, direction)
        {
            OldX = x;
            OldY = y;
        }

        public Shot(int x, int y, int direction, MovebleObj sender) : base(x, y, direction)
        {
            OldX = x;
            OldY = y;
            Sender = sender;
        }

        public void Move()
        {
            switch (DirectionTo)
            {
                case (int)Direction.Down:
                    {
                        OldY = Y;
                        OldX = X;
                        Y++;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        OldY = Y;
                        OldX = X;
                        X--;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        OldY = Y;
                        OldX = X;
                        X++;
                        break;
                    }
                case (int)Direction.Up:
                    {
                        OldY = Y;
                        OldX = X;
                        Y--;
                        break;
                    }
                default:
                    break;
            }
            ChangePicture();
        }

        public override void ChangePicture()
        {
            if (Img == null)
            {
                Img = new Bitmap(Resources.shotRight);
            }
            switch (DirectionTo)
            {
                case (int)Direction.Up:
                    {
                        Img = Resources.shotUp;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        Img = Resources.shotDown;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        Img = Resources.shotRight;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        Img = Resources.shotLeft;
                        break;
                    }
                default:
                    break;
            }
        }

       
    }
}

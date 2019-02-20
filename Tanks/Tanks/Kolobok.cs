using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks
{
    public class Kolobok:MovebleObj
    {
        public Kolobok():base()
        {
        }

        public Kolobok(int x, int y) : base(x, y)
        {
        }
        

        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (sender is Kolobok)
            {
                switch (e.KeyData)
                {
                    case Keys.Up:
                    case Keys.W:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Up);
                            break;
                        }
                    case Keys.Down:
                    case Keys.S:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Down);
                            break;
                        }
                    case Keys.Left:
                    case Keys.A:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Left);
                            break;
                        }
                    case Keys.Right:
                    case Keys.D:
                        {
                            ((Kolobok)sender).IdentifyDirection((int)Direction.Right);
                            break;
                        }
                    default:
                        break;
                }

               
            }
        }


        public override void ChangePicture()
        {
            if (Img==null)
            {
                Img = new Bitmap(Resources.kolobokLeft);
            }
            switch (DirectionTo)
            {
                case (int)Direction.Up:
                    {
                        Img = Resources.kolobokUp;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        Img = Resources.kolobokDown;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        Img = Resources.kolobokRight;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        Img = Resources.kolobokLeft;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

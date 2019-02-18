using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Obj
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; protected set; }

        public Obj()
        {
            X = TanksForm.rnd.Next(0, 20);
            Y= TanksForm.rnd.Next(0, 20);
        }

        public Obj(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected bool CheckCollides(int x, int y)
        {
            if (X + TanksForm.sizeCell >= x && X <= x)
            {
                if (Y + TanksForm.sizeCell >= y && Y <= y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CollidesWith(Obj obj)
        {
            if (CheckCollides(obj.X, obj.Y) ||
                CheckCollides(obj.X + TanksForm.sizeCell, obj.Y) ||
                CheckCollides(obj.X + TanksForm.sizeCell, obj.Y + TanksForm.sizeCell) ||
                CheckCollides(obj.X, obj.Y + TanksForm.sizeCell))
                return true;

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Tank:Obj
    {
        public int Direction { get; set; }
        public Tank() : base()
        {
            Direction = TanksForm.rnd.Next(0, 4);
        }

        public Tank(int x, int y) : base(x, y)
        {
            Direction = TanksForm.rnd.Next(0, 4);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Kolobok:Obj
    {
        public int Direction { get; set; }
        public Kolobok():base()
        {
            Direction = TanksForm.rnd.Next(0, 4);
        }

        public Kolobok(int x, int y) : base(x, y)
        {
            Direction= TanksForm.rnd.Next(0, 4);
        }
    }
}

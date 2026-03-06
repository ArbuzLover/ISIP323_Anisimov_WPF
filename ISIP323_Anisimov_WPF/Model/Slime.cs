using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Slime : Enemy
    {
        public Slime() : base(15, 10, 2,2)
        {
            Name = "Слизень(слайм)";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Skelet : Enemy
    {
        public Skelet() : base(40, 10, 5 , 0)
        {
            Name = "Скелет";
            IgnoreDefense = true;
        }
    }
}

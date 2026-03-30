using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Mag : Enemy
    {
        public Mag() : base(25, 15, 2, 0, "./Images/Mag.jpg")
        {
            Name = "Маг";
            CanFreeze = true;
            FreezeChance = 15;
            
        }

    }
}

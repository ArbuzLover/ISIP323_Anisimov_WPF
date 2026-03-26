using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Skelet : Enemy
    {
        public Skelet() : base(40, 10, 5 , 0, "/Images/Skelet.jpg")
        {
            Name = "Скелет";
            IgnoreDefense = true;
           
        }
    }
}

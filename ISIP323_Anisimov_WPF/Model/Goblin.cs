using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Goblin : Enemy
    {
        public Goblin() : base(30, 12, 3, 0, "./Images/Goblin.jpg")
        {
            Name = "Гоблин";
            HasCrit = true;
            CritChance = 20;
            ImagePath = "./Images/Goblin.jpg";
        }

    }
}

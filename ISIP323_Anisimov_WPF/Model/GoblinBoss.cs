using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class GoblinBoss : Goblin
    {
        public GoblinBoss()
        {
            Name = "ВВГ Гоблин-Босс";
            MaxHP = 30 * 2;
            CurrentHP = MaxHP;
            Attack = (int)(12 * 1.5);
            Defense = (int)(3 * 1.2);
            CritChance += 10;
            ImagePath = "/Images/GoblinBoss.jpg";
        }

    }
}

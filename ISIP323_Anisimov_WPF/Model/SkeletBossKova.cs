using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class SkeletBossKova : Skelet
    {
        public SkeletBossKova()
        {
            Name = "Скелет-Ковальский";
            MaxHP = (int)(40 * 2.5);
            CurrentHP = MaxHP;
            Attack = (int)(10 * 1.3);
            Defense = (int)(5 * 1.4);
            ImagePath = "/Images/BossKoval.jpg";
        }

    }
}

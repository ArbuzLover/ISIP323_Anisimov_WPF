using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class SkeletBossPest : Skelet
    {
        public SkeletBossPest()
        {
            Name = "Скелет-Пестов";
            MaxHP = (int)(40 * 1.3);
            CurrentHP = MaxHP;
            Attack = (int)(10 * 1.8);
            Defense = (int)(5    * 0.6);
            FreezeChance = 15;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Anisimov_WPF
{
    internal class Core
    {
        public static OnlineCinemaPr14Entities3 Context = new OnlineCinemaPr14Entities3();


        public static Users CurrentUser { get; set; }
        public static Sessions CurrentSession { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Anisimov_WPF
{
    public static class Zakaz
    {
        public static string model { get; set; }
        public static double C = 0; // цена авто
        public static string engine { get; set; }
        public static string color { get; set; }
        public static List<string> Options { get; set; }
        public static double sum = 0;
        public static double r = 0.1;
        public static double P = C * 0.3;
        public static string Name { get; set; }
        public static string Telephone { get; set; }
        public static string Email { get; set; }
        //модель, двигатель, цвет, опции, параметры кредита, контактные данные
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP323_Anisimov_WPF
{
    static class Zakaz
    {
        static string model { get; set; }
        static double C = 0; // цена авто
        static string engine { get; set; }
        static string color { get; set; }
        static List<string> Options { get; set; }
        static double sum = 0;
        static double r = 0.1;
        static double P = C * 0.3;
        static string Name { get; set; }
        static string Telephone { get; set; }
        static string Email { get; set; }
        //модель, двигатель, цвет, опции, параметры кредита, контактные данные
    }
}

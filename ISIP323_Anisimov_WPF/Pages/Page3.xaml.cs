using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISIP323_Anisimov_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        List<Product> Basket;
        string Name, Email, Address;
        public Page3(List<Product> basket)
        {
            Basket = basket;
            InitializeComponent();
            TextZakaz();
        }
        private void EmailUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email = EmailUser.Text;
        }

        private void AddresUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            Address = AddresUser.Text;
        }



        private void NameUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name = NameUser.Text;
        }
        int countProducts1 = 0, countProducts2 = 0, countProducts3 = 0;
        bool iter1 = true, iter2 = true, iter3 = true;
        void TextZakaz()
        {
            string zakaz = $"";
            foreach (var item in Basket)
            {
                if (item.ID == 1) 
                { 
                    countProducts1++;
                    if (iter1) { Product1.Content = $"{item.Name} за {item.Price} "; iter1 = false; }
                }
                else if (item.ID == 2) 
                { 
                    countProducts2++;
                    if (iter2) { Product2.Content = $"{item.Name} за {item.Price} "; iter2 = false; }
                }
                else if (item.ID == 3) 
                { 
                    countProducts3++;
                    if (iter3) { Product1.Content = $"{item.Name} за {item.Price} "; iter3 = false; }
                }

            }
            Product1.Content += $"{countProducts1}";
            Product2.Content += $"{countProducts2}";
            Product3.Content += $"{countProducts3}";


            if (countProducts1 < 0) { Product1.Visibility = Visibility.Hidden; }
            if (countProducts2 < 0) { Product1.Visibility = Visibility.Hidden; }
            if (countProducts3 < 0) { Product1.Visibility = Visibility.Hidden; }


        }
    }
}


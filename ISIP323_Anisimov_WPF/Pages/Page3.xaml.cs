using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
       
        void TextZakaz()
        {
            string zakaz = "";
            foreach (var item in Basket)
            {
                
            }
            ZakazTexbBlock.Text = "Вы заказали" + zakaz;
        }

    }
}

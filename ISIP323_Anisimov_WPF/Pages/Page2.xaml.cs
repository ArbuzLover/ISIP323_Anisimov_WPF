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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        List<Product> Basket;
        public Page2(List <Product> basket)
        {
            InitializeComponent();
            Basket = basket;
            
            BasketListBox.ItemsSource = Basket;
        }


        private void Page3Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3(Basket));
        }
    }
}

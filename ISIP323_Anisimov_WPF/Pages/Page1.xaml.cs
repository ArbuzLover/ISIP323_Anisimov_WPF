using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Product1Image.Source = new BitmapImage(new Uri(products., UriKind.Relative));

        }

        public static List<Product> products = Core.Context.Product.ToList();
        public static List<Product> Basket;

        private void Product1ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in products)
            {
                if(item.ID == 1) { Basket.Add(item); }
            }
            
        }

        private void Product2ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in products)
            {
                if (item.ID == 2) { Basket.Add(item); }
            }
        }

        private void Product3ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in products)
            {
                if (item.ID == 3) { Basket.Add(item); }
            }
        }
        

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(Basket));
        }


        string GetPath(List <Product> product)
        {

            return pr;
        }
    }
}

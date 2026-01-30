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
            ProductListBox.ItemsSource = products;
        }



        public static List<Product> products = Core.Context.Product.ToList();
        public static List<Product> Basket = new List<Product>();
                
        private void Product1ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Basket.Add(ProductListBox.SelectedItem as Product);


        }

 
        

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(Basket));
        }

        
    }
}

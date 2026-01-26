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
            IntializeSetku();
        }

        public void IntializeSetku()
        {
            Product1Image.Source = new BitmapImage(new Uri(GetPath(products, 1), UriKind.Relative));
            Product1Name.Text = GetName(products, 1);
            Product1Price.Text = GetPrice(products, 1);

            Product2Image.Source = new BitmapImage(new Uri(GetPath(products, 2), UriKind.Relative));
            Product2Name.Text = GetName(products, 2);
            Product2Price.Text = GetPrice(products, 2);


            Product3Image.Source = new BitmapImage(new Uri(GetPath(products, 3), UriKind.Relative));
            Product3Name.Text = GetName(products, 3);
            Product3Price.Text = GetPrice(products, 3);
        }


        public static List<Product> products = Core.Context.Product.ToList();
        public static List<Product> Basket = new List<Product>();
                
        private void Product1ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddToBasket(products, Basket,1);


        }

        private void Product2ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddToBasket(products, Basket,2);
        }

        private void Product3ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddToBasket(products, Basket,3);
        }
        

        private void Page2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(Basket));
        }


        private string GetPath(List<Product> product, int id)
        {
            foreach (var item in product)
            {
                if (id == item.ID) { return item.Path.ToString(); }
            }
            return "";
            
        }

        string GetName(List<Product> product, int id)
        {
            foreach (var item in product)
            {
                if (id == item.ID) { return item.Name; }
               
            }
            return "";
        }


        string GetPrice(List<Product> product, int id)
        {
            foreach (var item in product)
            {
                if (id == item.ID) { return item.Price.ToString(); }

            }
            return "";
        }


        void AddToBasket(List<Product> products, List<Product> Basket, int id) 
        {
            Product newProduct = new Product();
            foreach (var item in products)
            {
                if (item.ID == id)
                {
                    newProduct.ID = item.ID;
                    newProduct.Name = item.Name;
                    newProduct.Price = item.Price;
                    Basket.Add(newProduct);
                }
            }
        }
    }
}

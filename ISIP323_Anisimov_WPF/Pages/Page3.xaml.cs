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

        private void OformlenButton_Click(object sender, RoutedEventArgs e)
        {
            if (Basket.Count > 0 & !(Name == null) & !(Email == null) & !(Address == null))
            {
                Order NewOrder = new Order()
                {
                    FIO = Name,
                    Email = Email,
                    Address = Address

                };
                Core.Context.Order.Add(NewOrder);
                Core.Context.SaveChanges();
                SortBasket();
                int kolv = 0;
                foreach (var item in sort)
                {
                    if (item.ID == 1) { kolv = countProducts1; }
                    else if (item.ID == 2) { kolv = countProducts2; }
                    else if (item.ID == 3) { kolv = countProducts3; }
                    OrderProducts orderProducts = new OrderProducts()
                    {
                        OrderID = NewOrder.ID,
                        ProductID = item.ID,
                        Count = kolv

                    };
                    Core.Context.OrderProducts.Add(orderProducts);
                    Core.Context.SaveChanges();
                }
                
                
                MessageBox.Show("Заказ оформлен!");
                OformlenButton.IsEnabled = false;
            }
            else { MessageBox.Show("Заполнены не все данные!!"); }
        }

        int countProducts1 = 0, countProducts2 = 0, countProducts3 = 0;

        void TextZakaz()
        {
            bool iter1 = true, iter2 = true, iter3 = true;
            int sum = 0;
            
            foreach (var item in Basket)
            {
                if (item.ID == 1)
                {
                    countProducts1++;
                    if (iter1) { Product1.Text = $"{item.Name} за {item.Price} "; iter1 = false; }
                }
                else if (item.ID == 2)
                {
                    countProducts2++;
                    if (iter2) { Product2.Text = $"{item.Name} за {item.Price} "; iter2 = false; }
                }
                else if (item.ID == 3)
                {
                    countProducts3++;
                    if (iter3) { Product3.Text = $"{item.Name} за {item.Price} "; iter3 = false; }
                }
                sum += item.Price;

            }
            Product1.Text += $"{countProducts1} шт";
            Product2.Text += $"{countProducts2} шт";
            Product3.Text += $"{countProducts3} шт";


            if (countProducts1 == 0) { Product1.Visibility = Visibility.Collapsed; }
            if (countProducts2 == 0) { Product2.Visibility = Visibility.Collapsed; }
            if (countProducts3 == 0) { Product3.Visibility = Visibility.Collapsed; }
            Itog.Text += $"{sum}";

        }

        List<Product> sort = new List<Product>();

        void SortBasket()
        {
            
            bool sortiter1 = true, sortiter2 = true, sortiter3 = true;
            foreach (var item in Basket)
            {
                if (item.ID == 1)
                {
                    if (sortiter1) { sort.Add(item); sortiter1 = false; }
                    else continue;
                }
                else if (item.ID == 2)
                {
                    if (sortiter2) { sort.Add(item); sortiter2 = false; }
                    else continue;
                }
                else if (item.ID == 3)
                {

                    if (sortiter3) { sort.Add(item); sortiter3 = false; }
                    else continue;
                }
            }
        }
    }
}


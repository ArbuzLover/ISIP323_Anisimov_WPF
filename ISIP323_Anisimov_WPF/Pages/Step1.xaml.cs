using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для Step1.xaml
    /// </summary>
    public partial class Step1 : Page
    {
        public Step1()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem choice = ((sender as ListBox).SelectedItem as ListBoxItem);
            tb.Content = "Вы выбрали: " + choice.Content.ToString() + ".";
            Zakaz.engine = choice.Content.ToString();
            ToStep2Button.Visibility = Visibility.Visible;



        }

        private void ModelButton1_Checked(object sender, RoutedEventArgs e)
        {
            Zakaz.model = ModelButton1.Content.ToString();
            Zakaz.C = 50000;
            BigImage.Source = Image1.Source;
            Bottom.Visibility = Visibility.Visible;

            Zakaz.sum += Zakaz.C;
            
        }

        private void ModelButton2_Checked(object sender, RoutedEventArgs e)
        {
            Zakaz.model = ModelButton2.Content.ToString();
            Zakaz.C = 30000;
            BigImage.Source = Image2.Source;
            Bottom.Visibility = Visibility.Visible;
            Zakaz.sum += Zakaz.C;
        }

        private void ModelButton3_Checked(object sender, RoutedEventArgs e)
        {
            Zakaz.model = ModelButton3.Content.ToString();
            Zakaz.C = 7000;
            BigImage.Source = Image3.Source;
            Bottom.Visibility = Visibility.Visible;
            Zakaz.sum += Zakaz.C;
        }

        private void ModelButton4_Checked(object sender, RoutedEventArgs e)
        {
            Zakaz.model = ModelButton4.Content.ToString();
            Zakaz.C = 4000;
            BigImage.Source = Image4.Source;
            Bottom.Visibility = Visibility.Visible;
            Zakaz.sum += Zakaz.C;
        }


        private void ToStep2Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Step2());
            
        }
    }
}

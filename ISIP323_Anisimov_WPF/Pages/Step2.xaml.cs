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
    /// Логика взаимодействия для Step2.xaml
    /// </summary>
    public partial class Step2 : Page
    {
        public Step2()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            ListBoxItem choice = ((sender as ListBox).SelectedItem as ListBoxItem);
            tb.Content = "Вы выбрали: " + choice.Content.ToString();
            Zakaz.color = choice.Content.ToString();
            //Zakaz.sum = +Convert.ToInt32(Zakaz.engine);
            //ToStepButton.Visibility = Visibility.Visible;
            if (choice == ListBoxItem1) Zakaz.sum -= 1000;
            else if (choice == ListBoxItem2) Zakaz.sum += 0;
            else if (choice == ListBoxItem3) Zakaz.sum += 1000;
            else if (choice == ListBoxItem4) Zakaz.sum += 2000;
            else if (choice == ListBoxItem5) Zakaz.sum += 10000;
      
        }


        private void SaveSelectedOptions()
        {
            Zakaz.Options = new List<string>();

            if (Option1.IsChecked == true) Zakaz.Options.Add("Кожаный салон (+150)");
            if (Option2.IsChecked == true) Zakaz.Options.Add("Панорамная крыша (+200)");
            if (Option3.IsChecked == true) Zakaz.Options.Add("Подогрев сидений (+50)");
            if (Option4.IsChecked == true) Zakaz.Options.Add("Мигалка (+75)");
            if (Option5.IsChecked == true) Zakaz.Options.Add("Пушки (+40)");
            if (Option6.IsChecked == true) Zakaz.Options.Add("Камера заднего вида (+30)");
            if (Option7.IsChecked == true) Zakaz.Options.Add("Дилдо под сидениями (+1000000)");
        }



        public double CalculateOptionsPrice()
        {
            double total = 0;

            if (Option1.IsChecked == true) total += 150;
            if (Option2.IsChecked == true) total += 200;
            if (Option3.IsChecked == true) total += 50;
            if (Option4.IsChecked == true) total += 75;
            if (Option5.IsChecked == true) total += 40;
            if (Option6.IsChecked == true) total += 30;
            if (Option7.IsChecked == true) total += 1000000;

            return total;
        }

        
    }
}

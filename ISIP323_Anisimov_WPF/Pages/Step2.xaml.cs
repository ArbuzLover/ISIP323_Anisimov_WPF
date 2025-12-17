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
            Zakaz.engine = choice.Content.ToString();
            //Zakaz.sum = +Convert.ToInt32(Zakaz.engine);
            //ToStepButton.Visibility = Visibility.Visible;
            if (choice == ListBoxItem1) Zakaz.sum -= 1000;
            else if (choice == ListBoxItem2) Zakaz.sum += 0;
            else if (choice == ListBoxItem3) Zakaz.sum += 1000;
            else if (choice == ListBoxItem4) Zakaz.sum += 2000;
            else if (choice == ListBoxItem5) Zakaz.sum += 10000;
      
        }
    }
}

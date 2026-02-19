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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public List<Users> users = Core.Context.Users.ToList();
        public RegPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegLoginTextBox.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (Core.Context.Users.Any(u => u.Login == RegLoginTextBox.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                return;
            }

            if (FirstRegPassTextBox.Text != SecondRegPassTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (string.IsNullOrWhiteSpace(FirstRegPassTextBox.Text))
            {
                MessageBox.Show("Введите пароль");
                return;
            }


            var newUser = new Users
            {
                Login = RegLoginTextBox.Text,
                Password = FirstRegPassTextBox.Text,
            };

            Core.Context.Users.Add(newUser);
            Core.Context.SaveChanges();

            MessageBox.Show("Регистрация прошла успешно!");
            NavigationService.Navigate(new LoginPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}

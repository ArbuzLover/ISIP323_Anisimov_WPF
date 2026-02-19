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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private Users _user;
        public Profile(Users user)
        {
            InitializeComponent();
            _user = user;
            LoadData();
        }
        private void LoadData()
        {
            LoginText.Text = _user.Login;

            using (var db = new OnlineCinemaPr14Entities4())
            {
                var tickets = db.Tickets
                    .Include(t => t.Places)
                        .ThenInclude(s => s.SessionSeats)
                            .ThenInclude(ss => ss.Session)
                                .ThenInclude(se => se.Movie)
                    .Include(t => t.Seat)
                        .ThenInclude(s => s.SessionSeats)
                            .ThenInclude(ss => ss.Session)
                                .ThenInclude(se => se.Hall)
                    .Where(t => t.UserId == _user.ID)
                    .Select(t => new
                    {
                        Movie = t.Seat.SessionSeats.First().Session.Movie.MovieName,
                        Hall = t.Seat.SessionSeats.First().Session.Hall.Name,
                        Date = t.Seat.SessionSeats.First().Session.StartDateTime.HasValue
                            ? t.Seat.SessionSeats.First().Session.StartDateTime.Value.ToString("dd.MM.yyyy HH:mm")
                            : "Время не указано",
                        Seat = $"Ряд {t.Seat.RowNumber}, Место {t.Seat.SeatNumber}",
                        Price = t.FinalPrice.HasValue ? $"{t.FinalPrice.Value:N0} ₽" : "—",
                        Status = t.Status ?? "Оплачен"
                    })
                    .ToList();

                TicketsList.ItemsSource = tickets;


            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            _user = null;
            NavigationService.Navigate(new LoginPage());
            while (NavigationService.CanGoBack)
            {
                NavigationService.RemoveBackEntry();
            }
            MessageBox.Show("Вы успешно вышли из аккаунта");

        }
    }
}

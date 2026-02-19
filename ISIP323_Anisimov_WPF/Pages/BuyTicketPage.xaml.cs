using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
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
using static System.Collections.Specialized.BitVector32;

namespace ISIP323_Anisimov_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для BuyTicketPage.xaml
    /// </summary>
    public partial class BuyTicketPage : Page
    {
        private Sessions _session;
        private Users _user;
        private OnlineCinemaPr14Entities4 _db = new OnlineCinemaPr14Entities4();

        public BuyTicketPage(Sessions session, Users user)
        {
            InitializeComponent();
            _session = session;
            _user = user;
            LoadSeats();
            UpdateInfo();
        }

        private void LoadSeats()
        {
            // Получаем все места для зала
            var seats = _db.Places
                .Where(p => p.IDHall == _session.IDHall)
                .ToList();

            foreach (var seat in seats)
            {
                // Проверяем, занято ли место через отдельный запрос к BusyPlaces
                bool isPurchased = _db.BusyPlaces
                    .Any(bp => bp.IDPlace == seat.ID && bp.IDSession == _session.ID);

                var button = new Button
                {
                    // ИСПРАВЛЕНО: убраны лишние фигурные скобки
                    Content = $"{seat.Row}-{seat.Number}",

                    Width = 45,
                    Height = 45,
                    Margin = new Thickness(3),
                    Tag = seat,
                    Background = isPurchased ? Brushes.Gray : Brushes.LightGreen,
                    IsEnabled = !isPurchased
                };

                // Добавляем обработчик события и кнопку на форму
                button.Click += Seat_Click;
                SeatsControl.Items.Add(button);
            }
        }

        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var seat = button?.Tag as Places;

            if (seat != null && button.IsEnabled)
            {
                if (button.Background == Brushes.LightGreen)
                {
                    button.Background = Brushes.Orange;
                    // Добавить в список выбранных
                }
                else if (button.Background == Brushes.Orange)
                {
                    button.Background = Brushes.LightGreen;
                    // Удалить из списка выбранных
                }
            }
        }

        private void UpdateInfo()
        {
            var selected = SeatsControl.Items
                .Cast<Button>()
                .Where(b => b.Background == Brushes.Orange)
                .ToList();

            SelectedSeatsText.Text = $"Выбрано мест: {selected.Count}";
            TotalPriceText.Text = $"Итого: {selected.Count * 500:N0} ₽";
            BuyButton.IsEnabled = selected.Count > 0;
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = SeatsControl.Items
                .Cast<Button>()
                .Where(b => b.Background == Brushes.Orange)
                .ToList();

            if (!selected.Any()) return;

            foreach (var btn in selected)
            {
                var seat = btn.Tag as Places;

                var ticket = new Tickets
                {
                    IDUser = _user.ID,
                    IDPlace = seat.ID,
                    Price = 500,
                    IDSession = _session.ID
                };

                _db.Tickets.Add(ticket);
                btn.Background = Brushes.Gray;
                btn.IsEnabled = false;
            }

            _db.SaveChanges();
            MessageBox.Show("Билеты успешно куплены!");
            UpdateInfo();
        }


    }
}

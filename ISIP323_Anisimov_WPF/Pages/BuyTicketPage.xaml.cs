using System;
using System.Collections.Generic;
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
        private OnlineCinemaPr14Entities3 _db = new OnlineCinemaPr14Entities3();

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
            var seats = _db.Places
        .Include(p => p.Hall)
        .Include(p => p.BusyPlaces)
        .ThenInclude(bp => bp.Session)
        .Where(p => p.BusyPlaces.Any(bp => bp.IDSession == _session.ID))
        .ToList();

            foreach (var seat in seats)
            {
                // Проверяем, есть ли билет на это место (занято/куплено)
                bool isPurchased = seat.BusyPlaces.Any(bp => bp.IDSession == _session.ID);

                var button = new Button
                {
                    Content = $"{seat.Row}-{seat.Number}",
                    Width = 45,
                    Height = 45,
                    Margin = new Thickness(3),
                    Tag = seat,
                    Background = isPurchased ? Brushes.Gray : Brushes.LightGreen,
                    IsEnabled = !isPurchased
                };

                button.Click += Seat_Click;
                SeatsControl.Items.Add(button);
            }
        }

        private void Seat_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var seat = btn.Tag as Places;

            if (btn.Background == Brushes.LightGreen)
                btn.Background = Brushes.Orange;
            else if (btn.Background == Brushes.Orange)
                btn.Background = Brushes.LightGreen;

            UpdateInfo();
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

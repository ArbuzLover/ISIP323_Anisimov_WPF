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
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
       
        public Films ChooseFilm { get; set; }
        public List<Sessions> SessionsBD = Core.Context.Sessions.ToList();
        public FilmPage(Films chooseFilm)
        {
            InitializeComponent();
           ChooseFilm = chooseFilm;
            DataContext = this;
            GenresListBox.ItemsSource = ChooseFilm.Genres;
           List<Sessions> SessionsBD1 = (List<Sessions>)SessionsBD.Where(u => u.IDFilm == ChooseFilm.ID).ToList();
        SessionsListBox.ItemsSource = SessionsBD1;
        }

        private void SessionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Core.CurrentUser == null)
            {
                MessageBox.Show("Войдите в аккаунт для продолжения!");
            }
            else
            
            if (SessionsListBox.SelectedItem != null && NavigationService != null)
            {
                Core.CurrentSession = SessionsListBox.SelectedItem as Sessions;
                NavigationService.Navigate(new BuyTicketPage(Core.CurrentSession, Core.CurrentUser));
            }
        }
    }
}

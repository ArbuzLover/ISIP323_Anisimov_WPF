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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<Films> FilmsBD = Core.Context.Films.ToList();
        public MainPage()
        {
            InitializeComponent();
            FilmsListBox.ItemsSource = FilmsBD;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Films> MoviesRating = (List<Films>)FilmsBD.OrderByDescending(u => u.RateFilm).ToList();
            FilmsListBox.ItemsSource = MoviesRating;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Films> MoviesRating = (List<Films>)FilmsBD.OrderByDescending(u => u.Name).ToList();
            FilmsListBox.ItemsSource = MoviesRating;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

            List<Films> moviesSearch = FilmsBD.Where(p => p.Name.ToLower().Contains(Search.Text.ToLower())).ToList();
            FilmsListBox.ItemsSource = moviesSearch;
        }

        private void FilmsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (FilmsListBox.SelectedItem is Films selectedFilm)
            {

                NavigationService.Navigate(new FilmPage(selectedFilm));

            }
        }
        
    }
}

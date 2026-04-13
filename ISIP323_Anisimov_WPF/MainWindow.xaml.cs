using ISIP323_Anisimov_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ISIP323_Anisimov_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        public MainWindow()
        {
            InitializeComponent();
            Logs.ItemsSource = Game.GameLogs;
            CurrentTurn.Text = "Этаж: " + Game.turn;
            Armor.DataContext = Game.Currentplayer;
            Weapon.DataContext = Game.Currentplayer;
            HPTextBlock.DataContext = Game.Currentplayer;
            HPProgressBar.Value = Game.Currentplayer.HP;
            HPProgressBar.Maximum = Game.Currentplayer.MaxHP;
            EnemyListBox.DataContext = Game.EnemyList;
            
           
            
        }
       
        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            Game.MainGame(this);
        }

        private void Defend_Click(object sender, RoutedEventArgs e)
        {
        }

        public bool BattleChoice()
        {
           
            ChoiceAtackOrDefend:
                MessageBoxResult result = MessageBox.Show("Ваш ход! Да - Атака, Нет - Защита: ", "Важный вопрос!", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    return true;
                }
                else if (result == MessageBoxResult.No)
                {
                    return false;
                }
             else { Game.GameLogs.Add("Неверный ввод!"); goto ChoiceAtackOrDefend; }
        }

        public void UpdateUI()
        {
            
            HPProgressBar.Value = Game.Currentplayer.HP;    
        }

        private void EnemyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}

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
            Game.MainGame(this);
            Logs.ItemsSource = Game.GameLogs;
            CurrentTurn.Text = "Этаж: " + Game.turn;
            Armor.DataContext = Game.Currentplayer;
            Weapon.DataContext = Game.Currentplayer;
            HPTextBlock.DataContext = Game.Currentplayer;
            HPProgressBar.Value = Game.Currentplayer.HP;
            HPProgressBar.Maximum = Game.Currentplayer.MaxHP;
            EnemyListBox.ItemsSource = Game.EnemyList;
            
           
            
        }

        
        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null)
            {
                Game.BattleChoice = true;
            }
            else MessageBox.Show("Выберите врага!");
        }

        private void Defend_Click(object sender, RoutedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null)
            {
                Game.BattleChoice = false;
            }
            MessageBox.Show("Выберите врага!");
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

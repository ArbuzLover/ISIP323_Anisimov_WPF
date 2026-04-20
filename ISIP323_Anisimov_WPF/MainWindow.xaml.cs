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
            EnemyListBox.ItemsSource = Game.EnemyList;
            
           
            
        }

        
        private void Attack_Click(object sender, RoutedEventArgs e)
        {

            if (EnemyListBox.SelectedItem != null)
            {
                Enemy ChoiceEnemy = EnemyListBox.SelectedItem as Enemy;
                if (!Game.Currentplayer.IsFrozen)
                {

                    
                    int dmg = Game.Currentplayer.Weapon.Damage - ChoiceEnemy.Defense;
                    if (dmg < 1) dmg = 1;
                    ChoiceEnemy.CurrentHP -= dmg;
                    Game.GameLogs.Add($"Вы нанесли {dmg} урона {ChoiceEnemy.Name}! HP врага: {ChoiceEnemy.CurrentHP}/{ChoiceEnemy.MaxHP}");
                   
                    
                }

                else
                {
                    Game.GameLogs.Add("Вы пропускаете ход из-за заморозки!");
                    Game.Currentplayer.IsFrozen = false;
                }
                if (!ChoiceEnemy.IsAlive())
                { 
                    Game.EnemyList.Remove(ChoiceEnemy); 
                    if(Game.EnemyList.Count == 0)
                    {

                    }
                }
                else
                {
                    ChoiceEnemy.AttackPlayer(Game.Currentplayer, Game.rnd);
                }
                UpdateUI();
            }

            else MessageBox.Show("Выберите врага!");
        }

        private void Defend_Click(object sender, RoutedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null)
            {   
                Enemy ChoiceEnemy = EnemyListBox.SelectedItem as Enemy;
                if (!Game.Currentplayer.IsFrozen)
                {


                    

                    if (!Game.Currentplayer.TryDodge(Game.rnd))
                    {
                        Game.Currentplayer.BlockNextAttack = true;
                        Game.GameLogs.Add("Уклонение не удалось, блок уменьшит получаемый урон!");                       
                    }
                }
                else
                {
                    Game.GameLogs.Add("Вы пропускаете ход из-за заморозки!");
                    Game.Currentplayer.IsFrozen = false;
                }
                    if (!ChoiceEnemy.IsAlive())
                    { Game.EnemyList.Remove(ChoiceEnemy); }
                    else
                    {
                        ChoiceEnemy.AttackPlayer(Game.Currentplayer, Game.rnd);
                    }
                UpdateUI();
            }
            MessageBox.Show("Выберите врага!");
        }


        public void UpdateUI()
        {
            
            HPProgressBar.Value = Game.Currentplayer.HP;
            Armor.DataContext = Game.Currentplayer;
            Weapon.DataContext = Game.Currentplayer;
        }

        

        private void EnemyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            StartButton.Visibility = Visibility.Collapsed;
            MainGame(this);
            
        }

        static void MainGame(MainWindow CurrentAction)
        {
            Player player = Game.Currentplayer;


            while (player.IsAlive())
            {
                Game.turn++;
                Game.GameLogs.Add($"===== Ход {Game.turn} =====");
                bool isBossTurn = (Game.turn % 10 == 0);
                bool chestEvent = Game.rnd.Next(2) == 0;

                if (chestEvent && !isBossTurn)
                {
                    Game.GameLogs.Add("Вы нашли сундук");
                    Game.OpenChest(player, CurrentAction);
                }
                else
                {

                    if (isBossTurn) { Game.CurrentEnemy = EnemyFactory.CreateBossEnemy(); }
                    else
                    {
                        int rand = Game.rnd.Next(3);
                        switch (rand)
                        {
                            case 0:
                                {
                                    Game.CurrentEnemy = EnemyFactory.CreateEnemy();
                                    Game.EnemyList.Add(Game.CurrentEnemy);

                                    break;
                                }
                            case 1:
                                {
                                    Game.CurrentEnemy = EnemyFactory.CreateEnemy();
                                    Game.EnemyList.Add(Game.CurrentEnemy);
                                    Game.CurrentEnemy = EnemyFactory.CreateEnemy();
                                    Game.EnemyList.Add(Game.CurrentEnemy);

                                    break;
                                }
                            case 2:
                                {
                                    Game.CurrentEnemy = EnemyFactory.CreateEnemy();
                                    Game.EnemyList.Add(Game.CurrentEnemy);
                                    Game.CurrentEnemy = EnemyFactory.CreateEnemy();
                                    Game.EnemyList.Add(Game.CurrentEnemy);
                                    Game.CurrentEnemy = EnemyFactory.CreateEnemy();
                                    Game.EnemyList.Add(Game.CurrentEnemy);

                                    break;
                                }
                            default:
                                break;
                        }

                        Game.Battle(player, Game.EnemyList, CurrentAction);
                        if (!player.IsAlive()) break;
                    }
                }

                Game.GameLogs.Add($"Конец! Вы прошли {Game.turn} ходов.");
            }
        }










    }
}

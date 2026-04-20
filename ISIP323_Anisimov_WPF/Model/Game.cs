using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Game
    {
        public static Random rnd = new Random();

        public static ObservableCollection<string> GameLogs = new ObservableCollection<string> { };
        public static int turn = 0;
        public static Player Currentplayer = new Player("Герой", 100, new Weapon("палец 20",20), new Armor("Броня-кожа 10", 10));
        public static Enemy CurrentEnemy = new Goblin();
        public static ObservableCollection<Enemy> EnemyList = new ObservableCollection<Enemy> { };
        public static bool BattleChoice = false;

        public static void OpenChest(Player player, MainWindow CurrentAction)
        {

            int roll = rnd.Next(3);
            if (roll == 0)
                player.Heal();
            else if (roll == 1)
            {
                int atk = rnd.Next(5, 50);
                Weapon NewWeapon = new Weapon($"меч + {atk}", atk);
                player.EquipWeapon(NewWeapon, CurrentAction);
            }
            else
            {
                int def = rnd.Next(1, 99);
                Armor NewArmor = new Armor($"Броня + {def}", def);
                player.EquipArmor(NewArmor, CurrentAction);
            }
        }

        public static void Battle(Player player, ObservableCollection <Enemy> Listenemy, MainWindow CurrentAction)
        {
            Enemy ChoiceEnemy = CurrentAction.EnemyListBox.SelectedItem as Enemy;
            foreach (var item in Listenemy)
            {
                GameLogs.Add($"Вы столкнулись с {item.Name}");
            }

            while (player.IsAlive() && Listenemy.Count !=0)
            {
               
                }

                else
                {
                    GameLogs.Add("Вы пропускаете ход из-за заморозки!");
                    player.IsFrozen = false;
                }
                if (!ChoiceEnemy.IsAlive())
                { Listenemy.Remove(ChoiceEnemy); }
                else
                {
                    ChoiceEnemy.AttackPlayer(player, rnd);
                }
            }

            if (player.IsAlive())
                GameLogs.Add($"Выйграл нах!");
                
            else
                GameLogs.Add("Сдох нах");
        }

        public static void MainGame(MainWindow CurrentAction)
        {
            Player player = Currentplayer;


            while (player.IsAlive())
            {
                turn++;
                GameLogs.Add($"===== Ход {turn} =====");
                bool isBossTurn = (turn % 10 == 0);
                bool chestEvent = rnd.Next(2) == 0;

                if (chestEvent && !isBossTurn)
                {
                    GameLogs.Add("Вы нашли сундук");
                    OpenChest(player, CurrentAction);
                }
                else
                {

                    if (isBossTurn) { CurrentEnemy = EnemyFactory.CreateBossEnemy(); }
                    else
                    {
                        int rand = rnd.Next(3);
                        switch (rand)
                        {
                            case 0:
                                {
                                    CurrentEnemy = EnemyFactory.CreateEnemy();
                                    EnemyList.Add(CurrentEnemy);
                                    
                                    break;
                                }
                            case 1:
                                {
                                    CurrentEnemy = EnemyFactory.CreateEnemy();
                                    EnemyList.Add(CurrentEnemy);
                                    CurrentEnemy = EnemyFactory.CreateEnemy();
                                    EnemyList.Add(CurrentEnemy);
                                    
                                    break;
                                }
                            case 2:
                                {
                                    CurrentEnemy = EnemyFactory.CreateEnemy();
                                    EnemyList.Add(CurrentEnemy);
                                    CurrentEnemy = EnemyFactory.CreateEnemy();
                                    EnemyList.Add(CurrentEnemy);
                                    CurrentEnemy = EnemyFactory.CreateEnemy();
                                    EnemyList.Add(CurrentEnemy);
                                    
                                    break;
                                }
                            default:
                                break;
                        }

                        //Battle(player, EnemyList, CurrentAction);
                        if (!player.IsAlive()) break;
                    }
                }

                GameLogs.Add($"Конец! Вы прошли {turn} ходов.");
            }
        }
    }
}

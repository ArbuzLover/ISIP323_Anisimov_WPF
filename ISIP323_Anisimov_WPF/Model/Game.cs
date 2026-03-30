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
        static Random rnd = new Random();

        public static ObservableCollection <string> GameLogs = new ObservableCollection<string> { };
        public static int turn = 0;
        public static Player Currentplayer = new Player("Герой", 100, new Weapon("палец 5", 5), new Armor("Броня-кожа 5", 5));
        public static Enemy CurrentEnemy = new Goblin();
        public static void OpenChest(Player player , MainWindow CurrentAction)
        {
            
            int roll = rnd.Next(3);
            if (roll == 0)
                player.Heal();
            else if (roll == 1)
            {
                int atk = rnd.Next(5, 50);
                Weapon NewWeapon = new Weapon($"меч + {atk}", atk);
                player.EquipWeapon(NewWeapon);
            }
            else
            {
                int def = rnd.Next(1, 99);
                Armor NewArmor = new Armor($"Броня + {def}", def);
                player.EquipArmor(NewArmor);
            }
        }

        public static void Battle(Player player, Enemy enemy, MainWindow CurrentAction)
        {
            GameLogs.Add($"Вы столкнулись с {enemy.Name}!");
            while (player.IsAlive() && enemy.IsAlive())
            {
                if (!player.IsFrozen)
                {
                   
                    GameLogs.Add("Ваш ход! Да - Атака, Нет - Защита: ");

                        
                        if (CurrentAction.BattleChoice() == true)
                        {
                            int dmg = player.Weapon.Damage - enemy.Defense;
                            if (dmg < 1) dmg = 1;
                            enemy.CurrentHP -= dmg;
                            GameLogs.Add($"Вы нанесли {dmg} урона {enemy.Name}! HP врага: {enemy.CurrentHP}/{enemy.MaxHP}");
                        CurrentAction.UpdateUI();
                        }
                        else if (CurrentAction.BattleChoice() == false)
                        {
                            if (!player.TryDodge(rnd))
                            {
                                player.BlockNextAttack = true;
                                GameLogs.Add("Уклонение не удалось, блок уменьшит получаемый урон!");
                                CurrentAction.UpdateUI();
                        }
                        }
                        else { GameLogs.Add("Неверный ввод!"); }

                }

                else
                {
                    GameLogs.Add("Вы пропускаете ход из-за заморозки!");
                   player.IsFrozen = false;
                }

                if (enemy.IsAlive())
                    enemy.AttackPlayer(player, rnd);
            }

            if (player.IsAlive())
                GameLogs.Add($"Выйграл нах {enemy.Name}!");
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
                    else { CurrentEnemy = EnemyFactory.CreateEnemy(); }

                    Battle(player, CurrentEnemy, CurrentAction);
                    if (!player.IsAlive()) break;
                }
                player.HP = -1;
            }

            GameLogs.Add($"Конец! Вы прошли {turn} ходов.");
        }
    }
}

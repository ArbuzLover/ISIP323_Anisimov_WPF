using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Game
    {
        static Random rnd = new Random();

        public static ObservableCollection <string> GameLogs = new ObservableCollection<string> { };

        public static void OpenChest(Player player)
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

        public static void Battle(Player player, Enemy enemy)
        {
            GameLogs.Add($"Вы столкнулись с {enemy.Name}!");
            while (player.IsAlive() && enemy.IsAlive())
            {
                if (!player.IsFrozen)
                {
                    GameLogs.Add("Ваш ход! 1 - Атака, 2 - Защита: ");
                    string choice = Console.ReadLine().Trim();

                    if (choice == "1")
                    {
                        int dmg = player.Weapon.Damage - enemy.Defense;
                        if (dmg < 1) dmg = 1;
                        enemy.CurrentHP -= dmg;
                        GameLogs.Add($"Вы нанесли {dmg} урона {enemy.Name}! HP врага: {enemy.CurrentHP}/{enemy.MaxHP}");
                    }
                    else if (choice == "2")
                    {
                        if (!player.TryDodge(rnd))
                        {
                            player.BlockNextAttack = true;
                            GameLogs.Add("Уклонение не удалось, блок уменьшит получаемый урон!");
                        }
                    }
                    else { GameLogs.Add("Неверный ввод!"); continue; }
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

        public static void MainGame()
        {
            Player player = new Player("Герой", 100, new Weapon("палец 5", 5), new Armor("Броня-кожа 5", 5));
            int turn = 0;

            while (player.IsAlive())
            {
                turn++;
                GameLogs.Add($"===== Ход {turn} =====");
                bool isBossTurn = (turn % 10 == 0);
                bool chestEvent = rnd.Next(2) == 0;

                    if (chestEvent && !isBossTurn)
                    {
                        GameLogs.Add("Вы нашли сундук");
                        OpenChest(player);
                    }
                    else
                    {
                        Enemy enemy;
                        if (isBossTurn) { enemy = EnemyFactory.CreateBossEnemy(); }
                       else { enemy = EnemyFactory.CreateEnemy(); }

                        Battle(player, enemy);
                        if (!player.IsAlive()) break;
                    }

            }

            GameLogs.Add($"Конец! Вы прошли {turn} ходов.");
        }
    }
}

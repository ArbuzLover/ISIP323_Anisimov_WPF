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
                player.Heal(CurrentAction);
            else if (roll == 1)
            {
                int atk = rnd.Next(5, 50);
                Weapon NewWeapon = new Weapon($"меч {atk}", atk);
                player.EquipWeapon(NewWeapon, CurrentAction);
            }
            else
            {
                int def = rnd.Next(1, 99);
                Armor NewArmor = new Armor($"Броня {def}", def);
                player.EquipArmor(NewArmor, CurrentAction);
            }
        }

        private static TaskCompletionSource<bool> battleCompletionSource;

        public static async Task Battle(Player player, ObservableCollection<Enemy> Listenemy, MainWindow CurrentAction)
        {
            foreach (var item in Listenemy)
            {
                GameLogs.Add($"Вы столкнулись с {item.Name}");
            }

            // Создаем источник для ожидания
            battleCompletionSource = new TaskCompletionSource<bool>();

            // Ждем пока враги не закончатся
            await battleCompletionSource.Task;

            if (player.IsAlive())
                GameLogs.Add($"Выйграл нах!");
            else
                GameLogs.Add("Сдох нах");
        }

        // Добавьте этот метод для сигнала о том, что враги кончились
        public static void CheckEnemiesAndContinue(Player player)
        {
            if (Game.EnemyList.Count == 0 || !player.IsAlive())
            {
                battleCompletionSource?.TrySetResult(true);
            }
        }

    }
}

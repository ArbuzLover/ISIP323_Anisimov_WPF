using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Player
    {
        public string Name;
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public bool IsFrozen = false;
        public bool BlockNextAttack = false;
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Player(string name, int hp, Weapon weapon, Armor armor)
        {
            Name = name;
            MaxHP = hp;
            HP = hp;
            Weapon = weapon;
            Armor = armor;
        }

        public void Heal( MainWindow CurrentAction)
        {
            MessageBox.Show($"Вы нашли лечебное зелье и восстановили {MaxHP-HP} HP");
            HP = MaxHP;
            CurrentAction.UpdateUI();
            Game.GameLogs.Add($"Вы использовали лечебное зелье, HP восстановлено до {HP}");
        }

        public void EquipWeapon(Weapon newWeapon, MainWindow CurrentAction)
        {
            MessageBoxResult result = MessageBox.Show($"Вы нашли оружие: {newWeapon.Name} (Атака {newWeapon.Damage})\n Ваше текущее оружие: {Weapon.Name}  (Атака {Weapon.Damage})", "Важный вопрос!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Weapon = newWeapon;
                CurrentAction.Weapon.Text = $"{Weapon.Name}";
                Game.GameLogs.Add($"Вы экипировали {Weapon.Name}");
            }
            else if (result == MessageBoxResult.No)
            {
                Game.GameLogs.Add("Вы оставили текущее оружие.");
            }
           CurrentAction.UpdateUI();
        }

        public void EquipArmor(Armor newArmor, MainWindow CurrentAction)
        {
            MessageBoxResult result = MessageBox.Show($"Вы нашли доспехи: {newArmor.Name} (Защита {newArmor.Defense})\n Ваши текущие доспехи: {Armor.Name} (Защита {Armor.Defense})", "Важный вопрос!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Armor = newArmor;
                CurrentAction.Armor.Text = $"{Armor.Name}";
                Game.GameLogs.Add($"Вы экипировали {Armor.Name}");
            }
            else if (result == MessageBoxResult.No)
            {
                Game.GameLogs.Add("Ничо не надел");
                
            }
            CurrentAction.UpdateUI();
        }

        public bool TryDodge(Random rnd)
        {
            int chance = rnd.Next(100);
            if (chance < 40)
            {
                Game.GameLogs.Add("Вы успешно увернулись от следующей атаки");
                return true;
            }
            return false;
        }

        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP < 0) HP = 0;
            Game.GameLogs.Add($"Вы получили {dmg} урона. HP: {HP}/{MaxHP}");
        }

        public bool IsAlive()
        {
            return HP > 0;
        }

    }
}

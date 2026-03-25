using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ISIP323_Anisimov_WPF.Model
{
    internal class Player
    {
        public string Name;
        public int MaxHP;
        public int HP;
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

        public void Heal()
        {
            HP = MaxHP;
            Game.GameLogs.Add($"Вы использовали лечебное зелье, HP восстановлено до {HP}");
        }

        public void EquipWeapon(Weapon newWeapon)
        {
            Game.GameLogs.Add($"Вы нашли оружие: {newWeapon.Name} (Атака +{newWeapon.Damage})");
            Game.GameLogs.Add($"Ваше текущее оружие: {Weapon.Name}  (Атака + {Weapon.Damage})");
            Game.GameLogs.Add("Вы хотите заменить оружие? (1 - Да, 2 - Нет): ");
            
            string choice = Console.ReadLine().Trim();
            if (choice == "1")
            {
                Weapon = newWeapon;
                Game.GameLogs.Add($"Вы экипировали {Weapon.Name}");
            }
            else
            {
                Game.GameLogs.Add("Вы оставили текущее оружие.");
            }
        }

        public void EquipArmor(Armor newArmor)
        {
            Game.GameLogs.Add($"Вы нашли доспехи: {newArmor.Name} (Защита +{newArmor.Defense})");
            Game.GameLogs.Add($"Ваши текущие доспехи: {Armor.Name} (Защита +{Armor.Defense})");
            Game.GameLogs.Add("Вы хотите заменить доспехи? (1 - Да, 2 - Нет): ");
            string choice = Console.ReadLine().Trim();
            if (choice == "1")
            {
                Armor = newArmor;
                Game.GameLogs.Add($"Вы экипировали {Armor.Name}");
            }
            else
            {
                Game.GameLogs.Add("Ничо не надел");
            }
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

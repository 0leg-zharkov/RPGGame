using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Interfaces;


namespace TestRPGGame.Weapons
{
    internal class Weapon : IWeapon
    {
        protected int damage;
        protected string name;
        protected string type;

        public int Damage { get => damage; set => damage = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }

        public Weapon(Enums.Weapons weapon)
        {
            ChooseWeaponType(weapon);
        }

        private void ChooseWeaponType(Enums.Weapons weapon)
        {
            switch (weapon)
            {
                case Enums.Weapons.sword:
                    damage = 3;
                    name = "меч";
                    type = "chopping";
                    break;
                case Enums.Weapons.stick:
                    damage = 3;
                    name = "дубина";
                    type = "crushing";
                    break;
                case Enums.Weapons.knife:
                    damage = 2;
                    name = "кинжал";
                    type = "stabbing";
                    break;
                case Enums.Weapons.axe:
                    damage = 4;
                    name = "топор";
                    type = "chopping";
                    break;
                case Enums.Weapons.spear:
                    damage = 3;
                    name = "копье";
                    type = "stabbing";
                    break;
                case Enums.Weapons.legendary_sword:
                    damage = 10;
                    name = "легендарный меч";
                    type = "chopping";
                    break;
                default:
                    damage = 0;
                    name = "";
                    type = "";
                    break;
            }
        }

        public virtual void PrintWeaponStats()
        {
            //Если будет время, можно будет добавить тип наносимого урона
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("============");
            Console.WriteLine($"Наименование: {name}");
            Console.WriteLine($"Урон: {damage}");
            Console.WriteLine("============");
            Console.ResetColor();
        }
    }
}

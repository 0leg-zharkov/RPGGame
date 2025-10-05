using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Weapons;
using TestRPGGame.Enemies;

namespace TestRPGGame.PlayerClasses
{
    internal class GameType
    {
        protected int health;
        protected int damage;
        protected int changedDamage;
        protected int dexterity;
        protected int level;
        protected bool isFightFlag;
        protected bool isSetLvlBonusFlag;
        protected string name;
        protected Weapon weapon;

        public int Health { get => health; set => health = value; }
        public int Damage { get => damage; set => damage = value; }
        public int Level { get => level; set => level = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int ChangedDamage { get => changedDamage; set => changedDamage = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }

        public GameType()
        {
            isFightFlag = false;
            isSetLvlBonusFlag = false;
            level = 0;
            changedDamage = 0;
            name = "";
        }

        public virtual void GameClassUseEffects(int numberOfFightStep, bool isPlayerDexterityHigher, bool isPlayerStrengthHigher, Enemy enemy)
        {
        }

        public virtual void GameClassResetEffects()
        {
            if (isFightFlag)
            {
                changedDamage = 0;
                isFightFlag = false;
            }
        }

        public virtual void PrintBonusInfo(string firstLvlText, string secondLvlText, string thirdLvlText)
        {
            Console.WriteLine($"Класс: {name} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Получаемое здоровье за каждый уровень: {health}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Бонус на 1 уровне: \n {firstLvlText} ");
            Console.WriteLine($"Бонус на 2 уровне: \n {secondLvlText} ");
            Console.WriteLine($"Бонус на 3 уровне: \n {thirdLvlText} ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Enemies;
using TestRPGGame.Managers;
using TestRPGGame.Weapons;

namespace TestRPGGame.PlayerClasses
{
    internal class Warrior : GameType
    {
        public Warrior() : base()
        {
            health = 5;
            weapon = new CommonSword();
            damage = weapon.Damage;
            name = "воин";
        }

        private void FirstLvlBonus(int numberOfFightStep)
        {
            if (numberOfFightStep == 1) changedDamage = weapon.Damage;
            else changedDamage = 0;
        }

        public override void GameClassUseEffects(int numberOfFightStep, bool isPlayerDexterityHigher, bool isPlayerStrengthHigher, Enemy enemy)
        {
            if (level < 1) return;
            switch (level)
            {
                case 1:
                    FirstLvlBonus(numberOfFightStep);
                    break;
                case 2:
                    // SecondLvlBonus();
                    isSetLvlBonusFlag = true;
                    break;
                default:
                    break;
            }
            isFightFlag = true;
        }

        public override void PrintBonusInfo(string firstLvlText, string secondLvlText, string thirdLvlText)
        {
            base.PrintBonusInfo(new TextsManager().WarriorFirstLvlBonus, new TextsManager().WarriorSecondLvlBonus, new TextsManager().WarriorThirdLvlBonus);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Enemies;
using TestRPGGame.Weapons;
using TestRPGGame.Managers;

namespace TestRPGGame.PlayerClasses
{
    internal class Outlaw : GameType
    {
        public Outlaw() : base()
        {
            health = 4;
            weapon = new Knife();
            damage = weapon.Damage;
            isFightFlag = false;
            isSetLvlBonusFlag = false;
            level = 0;
            name = "разбойник";
        }

        private void FirstLvlBonus(bool isPlayerDexterityHigher) => changedDamage = isPlayerDexterityHigher && !isFightFlag ? 1 : 0;

        private void ThirdLvlBonus(int stepNumber, Enemy enemy)
        {
            enemy.GetPoisonDamage(stepNumber);
        }

        public override void GameClassUseEffects(int numberOfFightStep, bool isPlayerDexterityHigher, bool isPlayerStrengthHigher, Enemy enemy)
        {
            if (level < 1) return;
            switch (level)
            {
                case 1:
                    FirstLvlBonus(isPlayerDexterityHigher);
                    break;
                case 3:
                    ThirdLvlBonus(numberOfFightStep, enemy);
                    break;
                default:
                    break;
            }
            isFightFlag = true;
        }

        public override void PrintBonusInfo(string firstLvlText, string secondLvlText, string thirdLvlText)
        {
            base.PrintBonusInfo(new TextsManager().OutlawFirstLvlBonus, new TextsManager().OutlawSecondLvlBonus, new TextsManager().OutlawThirdLvlBonus);
        }
    }
}

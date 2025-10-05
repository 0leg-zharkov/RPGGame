using TestRPGGame.Enemies;
using TestRPGGame.Managers;
using TestRPGGame.Weapons;

namespace TestRPGGame.PlayerClasses
{
    internal class Barbarian : GameType
    {
        public Barbarian() : base()
        {
            health = 6;
            weapon = new Stick();
            damage = weapon.Damage;
            name = "варвар";
        }

        private void FirstLvlBonus(int numberOfFightStep)
        {
            if (numberOfFightStep == 1) changedDamage = 2;
            if (numberOfFightStep == 4) changedDamage = -1;
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

        public override void GameClassResetEffects()
        {
            base.GameClassResetEffects();
        }

        public override void PrintBonusInfo(string firstLvlText, string secondLvlText, string thirdLvlText)
        {
            base.PrintBonusInfo(new TextsManager().BarbFirstLvlBonus, new TextsManager().BarbSecondLvlBonus, new TextsManager().BarbThirdLvlBonus);
        }
    }
}

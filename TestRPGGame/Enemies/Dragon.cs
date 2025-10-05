using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.PlayerClasses;
using TestRPGGame.Weapons;

namespace TestRPGGame.Enemies
{
    internal class Dragon : Enemy
    {
        private static int fireDamage = 3;
        private int baseDamage;

        public Dragon()
        {
            health = 20;
            weaponDamage = 4;
            baseDamage = weaponDamage;
            strength = 3;
            dexterity = 3;
            stamina = 3;
            prizeWeapon = new LegendarySword();
        }

        public override void InvokeEffects(Player player, int fightStep)
        {
            if (fightStep % 3 == 0)
            {
                weaponDamage += fireDamage;
            }
            else weaponDamage = baseDamage;
        }
    }
}

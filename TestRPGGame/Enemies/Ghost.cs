using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.PlayerClasses;
using TestRPGGame.Weapons;

namespace TestRPGGame.Enemies
{
    internal class Ghost : Enemy
    {
        public Ghost()
        {
            health = 6;
            weaponDamage = 3;
            strength = 1;
            dexterity = 3;
            stamina = 1;
            prizeWeapon = new CommonSword();
        }

        public override void InvokeEffects(Player player, int fightStep)
        {
            if (player.Dexterity < dexterity)
            {
                weaponDamage = 4;
            }
        }
    }
}

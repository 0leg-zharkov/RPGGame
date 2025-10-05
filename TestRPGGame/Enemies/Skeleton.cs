using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Weapons;

namespace TestRPGGame.Enemies
{
    internal class Skeleton : Enemy
    {
        public Skeleton()
        {
            health = 10;
            weaponDamage = 2;
            strength = 2;
            dexterity = 2;
            stamina = 1;
            isCrushable = true;
            prizeWeapon = new Stick();
        }
    }
}

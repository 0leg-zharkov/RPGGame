using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Weapons;

namespace TestRPGGame.Enemies
{
    internal class Slime : Enemy
    {
        public Slime()
        {
            health = 8;
            weaponDamage = 1;
            strength = 3;
            dexterity = 1;
            stamina = 2;
            isChoppable = false;
            prizeWeapon = new Spear();
        }
    }
}

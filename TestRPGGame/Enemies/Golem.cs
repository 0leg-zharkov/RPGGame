using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.PlayerClasses;
using TestRPGGame.Weapons;

namespace TestRPGGame.Enemies
{
    internal class Golem : Enemy
    {
        public Golem()
        {
            health = 10;
            weaponDamage = 1;
            strength = 3;
            dexterity = 1;
            stamina = 3;
            isStoneSkin = true;
            prizeWeapon = new Axe();
        }
    }
}

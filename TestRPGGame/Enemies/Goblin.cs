using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Weapons;

namespace TestRPGGame.Enemies
{
    internal class Goblin : Enemy
    {
        public Goblin()
        {
            health = 5;
            weaponDamage = 2;
            strength = 1;
            dexterity = 1;
            stamina = 1;
            prizeWeapon = new Knife();
        }
    }
}

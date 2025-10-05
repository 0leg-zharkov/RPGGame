using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Interfaces;

namespace TestRPGGame.Weapons
{
    internal class CommonSword : Weapon
    {
        public CommonSword() : base(Enums.Weapons.sword) {}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Enums;

namespace TestRPGGame.Interfaces
{
    internal interface IPlayer
    {

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Stamina { get; set; }

        public int Health { get; set; }

        void CheckWeapon(TestRPGGame.Enums.Weapons weapon);


    }
}

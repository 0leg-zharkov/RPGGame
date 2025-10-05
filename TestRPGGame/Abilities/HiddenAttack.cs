using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRPGGame.Abilities
{
    internal class HiddenAttack
    {
        private bool isBonusActivated;

        public HiddenAttack() 
        {
            this.isBonusActivated = false;
        }

        public void ActivateBonus() 
        {
            isBonusActivated = true;
        }


    }
}

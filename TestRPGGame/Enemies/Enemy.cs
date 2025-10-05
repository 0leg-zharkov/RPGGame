using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Weapons;
using TestRPGGame.PlayerClasses;

namespace TestRPGGame.Enemies
{
    internal class Enemy
    {
        protected int health;
        protected int weaponDamage;
        protected int strength;
        protected int dexterity;
        protected int stamina;
        protected bool isCrushable;
        protected bool isChoppable;
        protected bool isStealthAttack;
        protected bool isStoneSkin;
        protected Weapon prizeWeapon;
        //protected bool isPoisoned;

        public int Health { get => health; set => health = value; }
        public int WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Stamina { get => stamina; set => stamina = value; }
        //public bool IsPoisoned { get => isPoisoned; set => isPoisoned = value; }
        public bool IsCrushable { get => isCrushable; set => isCrushable = value; }
        public bool IsChoppable { get => isChoppable; set => isChoppable = value; }
        public bool IsStealthAttack { get => isStealthAttack; set => isStealthAttack = value; }
        public bool IsStoneSkin { get => isStoneSkin; set => isStoneSkin = value; }
        public Weapon PrizeWeapon { get => prizeWeapon; set => prizeWeapon = value; }

        public Enemy()
        {
            isCrushable = false;
            isChoppable = true;
            isStealthAttack = false;
            isStoneSkin = false;
        }

        public virtual void GetPoisonDamage(int fightStep)
        {
            health -= fightStep + 1;
        }

        public virtual void InvokeEffects(Player player, int fightStep)
        {

        }
    }
}

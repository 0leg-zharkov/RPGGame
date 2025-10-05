using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Enemies;
using TestRPGGame.Interfaces;
using TestRPGGame.Managers;
using TestRPGGame.Weapons;

namespace TestRPGGame.PlayerClasses
{
    internal class Player
    {
        #region Поля
        private static Player instance;

        private GameType outlaw = new Outlaw();
        private GameType barbarian = new Barbarian();
        private GameType warrior = new Warrior();

        private GameType[] perses = new GameType[3];

        private Weapon weapon;
        private int strength;
        private int dexterity;
        private int stamina;
        private int health;
        private int weaponDamage;
        private bool hasStoneSkin;
        private bool hasShield;
        private int lvl;
        #endregion

        #region Свойства
        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Stamina { get => stamina; set => stamina = value; }
        public int WeaponDamage { get => weaponDamage; set => weaponDamage = value; }
        public int Health { get => health; set => health = value; }
        public bool HasStoneSkin { get => hasStoneSkin; set => hasStoneSkin = value; }
        public bool HasShield { get => hasShield; set => hasShield = value; }
        public Weapon Weapon { get => weapon; set => weapon = value; }
        public int Level { get => lvl; }
        #endregion

        private Player(string characterType)
        {
            lvl = 0;
            perses[0] = outlaw;
            perses[1] = barbarian;
            perses[2] = warrior;
            //stats[0] - strength, stats[1] - dexterity, stats[2] - stamina
            int[] stats = new RandomManager().ReturnStartStats();

            //Здесь распределится weapon
            int[] characterStats = CheckPrimaryCharacter(characterType);

            this.weaponDamage = weapon.Damage;
            this.strength = stats[0];
            this.dexterity = stats[1];
            this.stamina = stats[2];
            this.health = characterStats[0] + this.stamina;

            this.hasStoneSkin = false;
            this.hasShield = false;
        }

        public static Player GetInstance(string characterType)
        {
            //if (instance == null) instance = new Player(characterType);
            return instance == null ? new Player(characterType) : instance;
        }

        public void CheckWeapon(Enums.Weapons weapon)
        {
            throw new NotImplementedException();
        }

        public void SetWeapon(string weaponName)
        {
            //Дописать для всех типов оружия
            switch (weaponName) 
            {
                case "Кинжал":
                    weapon = new Knife();
                    break;
                case "Меч":
                    weapon = new CommonSword();
                    break;
                case "Дубина":
                    weapon = new Stick();
                    break;
                default:
                    break;
            }
        }

        //возвращает числовой массив стат разных персов в порядке: stamina, strength
        private int[] CheckPrimaryCharacter(string characterName)
        {
            int[] stats = new int[2] { 0, 0 };

            switch (characterName)
            {
                case "разбойник":
                    weapon = outlaw.Weapon;
                    stats[0] = outlaw.Health;
                    break;
                case "варвар":
                    weapon = barbarian.Weapon;
                    stats[0] = barbarian.Health;
                    break;
                case "воин":
                    weapon = warrior.Weapon;
                    stats[0] = warrior.Health;
                    break;
                default:
                    break;
            }
            return stats;
        }

        public void InvokeEffects(int numberOfFightStep, bool isPlayerDexterityHigher, bool isPlayerStrengthHigher, Enemy enemy)
        {
            foreach (GameType pers in perses)
            {
                if (pers.Level > 0)
                {
                    pers.GameClassUseEffects(numberOfFightStep, isPlayerDexterityHigher, isPlayerStrengthHigher, enemy);
                    weaponDamage += pers.ChangedDamage;
                }
            }
            //outlaw.GameClassUseEffects(numberOfFightStep, isPlayerDexterityHigher, isPlayerStrengthHigher, enemy);

            //BarbarianEffects(barbarianLvl)
            //WarriorEffects(warriorLvl)
            //weapon.Damage = outlaw.Damage;
            //dexterity = outlaw.Dexterity;
        }

        public void ResetEffects()
        {
            foreach (GameType pers in perses) pers.GameClassResetEffects();
        }

        // TODO: добавить создание соответствующих объектов типов классов персонажей
        public void UpClassLvl(string characterName)
        {
            ++lvl;
            switch (characterName)
            {
                case "разбойник":
                    outlaw.Level += 1;
                    if (outlaw.Level == 2) dexterity += 1;
                    break;
                case "варвар":
                    barbarian.Level += 1;
                    if (barbarian.Level == 2) hasStoneSkin = true;
                    if (barbarian.Level == 3) ++stamina;
                    break;
                case "воин":
                    warrior.Level += 1;
                    if (warrior.Level == 2) hasShield = true;
                    if (warrior.Level == 3) ++strength;
                    break;
                default:
                    break;
            }
        }

        private void CheckCharacter()
        {

        }

        public void PrepareBeforeAttack()
        {
            foreach (GameType pers in perses)
            {
                if (pers.Level > 0)
                {
                    pers.Weapon = weapon;
                    pers.Dexterity = dexterity;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Enemies;
using TestRPGGame.PlayerClasses;
using TestRPGGame.Weapons;

namespace TestRPGGame.Managers
{
    internal class FightManager
    {
        public Player Player { get; set; }

        private Enemy enemy;
        private int dexteritySum;
        private Random random = new Random();
        private int hitChance;
        private bool isPlayerDexterityHigher;
        private bool isPlayerStrengthHigher;
        private bool isPlayerDead;
        private bool isEnemyDead;
        private int numberOfFightStep;

        public Enemy Enemy{ get => enemy; set => enemy = value; }

        // TODO: добавить в конструктор enemy и не забывать его обновлять в конце схватки
        public FightManager(Player player, Enemy enemy)
        {
            numberOfFightStep = 0;
            Player = player;
            this.enemy = enemy;
            isPlayerDead = false;
            isEnemyDead = false;
            SetFlags();
        }

        public void PlayerAttack()
        {
            //переделать логику - нужно учитвать бонусы за лвл
            Player.InvokeEffects(numberOfFightStep, isPlayerDexterityHigher, isPlayerStrengthHigher, enemy);
            enemy.Health -= GetPlayerAttackDamage();
        }

        public void EnemyAttack()
        {
            enemy.InvokeEffects(Player, numberOfFightStep);
            Player.Health -= GetEnemyAttackDamage();
        }

        private int GetPlayerAttackDamage()
        {
            SetHitChance();

            if (hitChance < enemy.Dexterity) return 0;
            else
            {
                int damage = Player.Strength + Player.WeaponDamage;
                if (enemy.IsCrushable) damage *= 2;
                if (!enemy.IsChoppable) damage -= Player.WeaponDamage;
                if (enemy.IsStoneSkin) damage -= enemy.Stamina;
                return damage;
            }
        }

        private int GetEnemyAttackDamage()
        {
            SetHitChance();

            if (hitChance < Player.Dexterity) return 0;
            else
            {       
                int damage = enemy.Strength + enemy.WeaponDamage;

                if (Player.HasShield && Player.Strength > enemy.Strength) damage -= 3;

                if (Player.HasStoneSkin) damage -= Player.Stamina;
                
                if (damage < 0) damage = 0;
                
                return damage;
            }
        }

        private void SetHitChance()
        {
            dexteritySum = Player.Dexterity + Enemy.Dexterity;
            hitChance = random.Next(1, dexteritySum);
        }

        private void SetDexterityFlag()
        {
            if (Player.Dexterity > enemy.Dexterity || Player.Dexterity == enemy.Dexterity) isPlayerDexterityHigher = true;
            else isPlayerDexterityHigher = false;
        }

        private void SetStrenghtFlag()
        {
            if (Player.Strength > enemy.Strength) isPlayerStrengthHigher = true;
            else isPlayerStrengthHigher = false;
        }

        private void SetFlags()
        {
            SetDexterityFlag();
            SetStrenghtFlag();
        }

        private void prepareBeforePlayerAttack()
        {

        }

        public void Fight()
        {
            Player.PrepareBeforeAttack();

            if (isPlayerDexterityHigher)
            {
                while(!isPlayerDead && !isEnemyDead)
                {
                    ++numberOfFightStep;
                    PlayerAttack();
                    CheckHp();
                    if (isPlayerDead || isEnemyDead) break;
                    EnemyAttack();
                    CheckHp();
                    if (isPlayerDead || isEnemyDead) break;
                }
                
            }
            else
            {
                while (!isPlayerDead && !isEnemyDead)
                {
                    ++numberOfFightStep;
                    EnemyAttack();
                    CheckHp();
                    if (isPlayerDead || isEnemyDead) break;
                    PlayerAttack();
                    CheckHp();
                    if (isPlayerDead || isEnemyDead) break;
                }
            }

            numberOfFightStep = 0;
        }
        
        private void CheckHp()
        {
            if (Player.Health <= 0) isPlayerDead = true;
            if (enemy.Health <= 0) isEnemyDead = true;
        }

        public bool IsPlayerWon()
        {
            if (!isPlayerDead) return true;
            return false;
        }
    }
}

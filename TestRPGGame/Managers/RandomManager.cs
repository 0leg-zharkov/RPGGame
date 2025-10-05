using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//класс для определения стартовых стат игрока
namespace TestRPGGame.Managers
{
    internal class RandomManager
    {
        private static Random random = new Random();

        private int enemyNum;

        private int strength;
        private int dexterity;
        private int stamina;

        public int EnemyNum { get { return enemyNum; } }

        public RandomManager()
        {
            strength = random.Next(1, 3);
            dexterity = random.Next(1, 3);
            stamina = random.Next(1, 3);

            enemyNum = random.Next(1, 7);
        }

        public int[] ReturnStartStats() 
        { 
            return new int[] { strength, dexterity, stamina }; 
        }
    }
}

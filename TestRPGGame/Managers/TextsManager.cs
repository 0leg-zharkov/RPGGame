using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestRPGGame.Enemies;
using TestRPGGame.PlayerClasses;

namespace TestRPGGame.Managers
{
    internal class TextsManager
    {
        private GameType outlaw = new Outlaw();
        private GameType barbarian = new Barbarian();
        private GameType warrior = new Warrior();
        List<GameType> perses = new List<GameType>();

        //про разбойника
        private static string outlawFirstLvlBonus = "Скрытая атака: \n +1 к урону, если ловкость персонажа выше ловкости цели";
        private static string outlawSecondLvlBonus = "Ловкость +1";
        private static string outlawThirdLvlBonus = "Яд: Наносит дополнительные +1 урона на втором ходу, +2 на третьем и так далее.";

        //про воина
        private static string warriorFirstLvlBonus = "Порыв к действию: \n В первый ход наносит двойной урон оружием";
        private static string warriorSecondLvlBonus = "Щит: \n -3 к получаемому урону, если сила персонажа выше силы атакующего";
        private static string warriorThirdLvlBonus = "Сила +1";

        //про варвара
        private static string barbFirstLvlBonus = "Ярость: \n +2 к урону в первые 3 хода, потом -1 к урону";
        private static string barbSecondLvlBonus = "Каменная кожа: \n Получаемый урон снижается на значение выносливости";
        private static string barbThirdLvlBonus = "Выносливость +1";

        public string OutlawFirstLvlBonus { get { return outlawFirstLvlBonus; } }
        public string OutlawSecondLvlBonus { get { return outlawSecondLvlBonus; } }
        public string OutlawThirdLvlBonus { get { return outlawThirdLvlBonus; } }

        public string WarriorFirstLvlBonus { get { return warriorFirstLvlBonus; } }
        public string WarriorSecondLvlBonus { get { return warriorSecondLvlBonus; } }
        public string WarriorThirdLvlBonus { get { return warriorThirdLvlBonus; } }

        public string BarbFirstLvlBonus { get { return barbFirstLvlBonus; } }
        public string BarbSecondLvlBonus { get { return barbSecondLvlBonus; } }
        public string BarbThirdLvlBonus { get { return barbThirdLvlBonus; } }

        public TextsManager()
        {
            perses.Add(outlaw);
            perses.Add(warrior);
            perses.Add(barbarian);
        }

        public void PrintBonusesInfo(bool begingInfo = true)
        {
            if (begingInfo)
            {
                foreach (GameType pers in perses)
                {
                    pers.PrintBonusInfo("", "", "");
                    Console.WriteLine("Начальное оружие: ");
                    pers.Weapon.PrintWeaponStats();
                    Console.WriteLine();
                }
            }
            else foreach (GameType pers in perses) pers.PrintBonusInfo("", "", "");
        }

        public void PrintAgain()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Я тебя не очень понимаю, напиши ответ заново.");
            Console.ResetColor();
        }

        public void PrintUpLvlText()
        {
            Console.WriteLine("Теперь ты можешь увеличить уровень персонажа! \n" +
                "Ты можешь увеличить уровень своего нынешнего класса либо начать развивать в себе вторую личность!) \n" +
                "Напоминаю тебе ТТХ различных классов. \n\n");
            PrintBonusesInfo(false);
            Console.WriteLine();
            Console.WriteLine("Напиши наименование класса, чтобы увеличить уровень этого класса.");
        }

        public void PrintGameOverText(bool isLost)
        {
            if (isLost) Console.WriteLine("О нет, враг оказался сильней! Ты останешься героем для всех. \n ");
            else Console.WriteLine("Ты справился, каждый враг разбит! \n");

            Console.WriteLine(
                    " Хочешь повторить приключения заново? \n " +
                    " Если хочешь повторить приключения заново, то напиши 'да'. " +
                    " Если хочешь закончить игру, напиши 'нет'.");
        }
    }
}

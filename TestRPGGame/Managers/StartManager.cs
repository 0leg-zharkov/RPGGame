using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TestRPGGame.PlayerClasses;

namespace TestRPGGame.Managers
{
    internal class StartManager
    {
        private Player player;
        private string className = "";

        public StartManager() 
        {
            Initialize();
        }

        public void Start() 
        {
            //подумать над вступительной фразой
            Console.WriteLine("Здравствуй, путник! Выбери перса. Для выбора персонажа напиши его название: разбойник");
            className = Console.ReadLine(); //Здесь добавить обработчик исключений

            Console.WriteLine($"Отлично, ты выбрал персонажа {className}");
        }

        private void Initialize()
        {
            //stats[0] - strength, stats[1] - dexterity, stats[2] - stamina
            int[] stats = new RandomManager().ReturnStartStats();
        }
    }
}

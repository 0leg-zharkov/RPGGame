using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestRPGGame.Enemies;
using TestRPGGame.PlayerClasses;
using static System.Net.Mime.MediaTypeNames;

namespace TestRPGGame.Managers
{
    //По-хорошему, все тексты бы в отдельный текстМанагер выделить
    internal class GameManager
    {
        private int fightsAmount;
        private static int winAmount = 5;
        private bool isLost;
        private bool isGameFinished;
        private TextsManager texts;

        private Enemy enemy;
        //private bool isPlayerWon;
        public Player Player { get; set; }
        public bool IsGameFinished { get => isGameFinished; set => isGameFinished = value; }

        public GameManager() 
        {
            texts = new TextsManager();
        }

        public void StartGame() 
        {
            string className = GetCharacterType();
            Player = Player.GetInstance(className);
            Player.UpClassLvl(className);
            //enemy = DistributeEnemy();
            fightsAmount = 0;
            isLost = false;
            isGameFinished = false;
            BeginFights();
        }

        //возвращает класс игрока в начале игры
        private string GetCharacterType()
        {            
            //подумать над вступительной фразой
            Console.WriteLine("Здравствуй, путник! Выбери перса. Для выбора персонажа напиши его название. " +
                "\n На выбор сегодня следующие персонажи: разбойник, варвар, воин.");
            Console.WriteLine("А вот и их статы!");
            texts.PrintBonusesInfo();

            string className = GetClassType();
            //className = "воин";
            Console.WriteLine($"Отлично, ты выбрал персонажа {className}");
            
            return className;
        }

        private Enemy DistributeEnemy()
        {
            int enemyNumber = new RandomManager().EnemyNum;
            Enemy enemy = new Enemy();
            
            switch (enemyNumber)
            {
                case 1:
                    enemy = new Goblin();
                    Console.WriteLine("На нас выскочил гоблин!");
                    break;
                case 2:
                    enemy = new Skeleton();
                    Console.WriteLine("Да как этот гоблин ходит!? У него же мыщц даже нет!");
                    break;
                case 3:
                    enemy = new Slime();
                    Console.WriteLine("А где у него мозги? Зато у него точно есть идея!");
                    break;
                case 4:
                    enemy = new Ghost();
                    Console.WriteLine("Я думал каспер добрый! Что ж, придется порешать этого призрака!");
                    break;
                case 5:
                    enemy = new Golem();
                    Console.WriteLine("ГООООООЛЕМ!");
                    break;
                case 6:
                    enemy = new Dragon();
                    Console.WriteLine("Где же всё злато этого дракона? Говорит, что достанется только через его труп, представь.");
                    break;
                default:
                    break;
            }

            return enemy;
        }

        public void BeginFight()
        {
            enemy = DistributeEnemy();
            ++fightsAmount;
            FightManager fightManager = new FightManager(Player, enemy);
            fightManager.Fight();
            if (fightManager.IsPlayerWon())
            {
                Console.WriteLine("goida");
                GetPrizeForWin();
                if (Player.Level < 3) UpLvl(); 
            }
            else
            {
                Console.WriteLine("ne goida");
                isLost = true;
            }
        }

        public void BeginFights()
        {
            while (fightsAmount < winAmount && !isLost) BeginFight();
            GetFinishOrContinueAnswer();
        }

        private void GetPrizeForWin()
        {
            Console.WriteLine($"У врага оказался {enemy.PrizeWeapon.Name}! ");
            Console.WriteLine("На всякий случай покажу тебе ТТХ твоего и вражеского оружия.");
            Console.WriteLine($"У тебя сейчас {Player.Weapon.Name}.");
            Player.Weapon.PrintWeaponStats();
            Console.WriteLine($"А у врага {enemy.PrizeWeapon.Name}");
            enemy.PrizeWeapon.PrintWeaponStats();
            Console.WriteLine($"\n Если хочешь заменить свое оружие на оружие врага, напиши слово 'да'." +
                $"\n Если хочешь сражаться с нынешним оружием, напиши слово 'нет'. ");
            string answer = "";
            while (true)
            {
                answer = Console.ReadLine();

                if (answer.ToLower() == "да")
                {
                    Player.Weapon = enemy.PrizeWeapon;
                    Console.WriteLine("Отлично! Он его все равно не заслуживал.");
                    break;
                }
                else if (answer.ToLower() == "нет")
                {
                    Console.WriteLine("С этим уже привычно, понимаю тебя!");
                    break;
                }
                else
                {
                    texts.PrintAgain();
                }
            }
        }

        private void UpLvl()
        {
            texts.PrintUpLvlText();
            Player.UpClassLvl(GetClassType());
        }

        private string GetClassType()
        {
            string className = "";    
            while (true)
            {
                className = Console.ReadLine();

                if (className.ToLower() == "разбойник" || className.ToLower() == "воин" || className.ToLower() == "варвар") break;
                else texts.PrintAgain();
            }
            return className;
        }

        //Вопросы в конце игры
        private void GetFinishOrContinueAnswer()
        {
            texts.PrintGameOverText(isLost);
            string answer = Console.ReadLine();
            if (answer == "нет") isGameFinished = true;
            else StartGame();
        }
    }
}

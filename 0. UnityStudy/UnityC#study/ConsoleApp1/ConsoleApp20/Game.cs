using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    public enum GameMode
    {
        None = 0,
        Lobby,
        Town,
        Feild,

    }
    internal class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player;
        private Monster monster;
        private Random rand = new Random();
        public void Process()
        {
            switch(mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProceesTown();
                    break;
                case GameMode.Feild:
                    break;
            }
        }
        public void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요!" );
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    player = new Knight();
                    break;
                case "2":
                    player = new Archer();
                    break;
                case "3":
                    player = new Mage();
                    break;
            }
            mode = GameMode.Town;
        }
        public void ProceesTown()
        {
            Console.WriteLine("마을에 입장했습니다.");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Feild;
                    break;

                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }
        public void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다.");
            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정 확률로 마을 돌아가기");

            CreateRandomMonster();
            string r;
        }

        private void CreateRandomMonster()
        {
            int randValue = rand.Next(0, 3);

            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다.");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 생성되었습니다.");
                    break;
            }
        }
    }
}

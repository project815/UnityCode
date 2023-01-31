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
    }
}

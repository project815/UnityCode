using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading;

namespace CSharp
{
    class Program
    {
        enum Job
        {
            None = 0,
            Night = 1,
            Archer = 2,
            Mage = 3,
        }
        enum MonsterType
        {
            Slime = 0,
            Orc = 1,
            Skeleton = 2,
        }

        struct Player
        {
            public int hp;
            public int attack;
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }

        static Job ChooseJob()
        {
            Console.WriteLine("직업을 선택하세요!");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");

            string input = Console.ReadLine();

            Job job = Job.None;
            switch (input)
            {
                case "1":
                    job = Job.Night;
                    break;
                case "2":
                    job = Job.Archer;
                    break;
                case "3":
                    job = Job.Mage;
                    break;
            }
            return job;
        }
        static void CreatePlayer(Job job, out Player player)
        {
            //
            switch(job)
            {
                //기사 100 / 10, 궁수 75 /12, 법사 50, 15
                case Job.Night:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case Job.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case Job.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);

            switch(randMonster)
            {
                case (int)MonsterType.Slime:
                    Console.WriteLine("슬라임이 나타났습니다.");
                    monster.hp = 20;
                    monster.attack = 2;
                    break;
                case (int)MonsterType.Orc:
                    Console.WriteLine("오크가 나타났습니다.");
                    monster.hp = 40;
                    monster.attack = 4;
                    break;
                case (int)MonsterType.Skeleton:
                    Console.WriteLine("스켈레톤이 나타났습니다.");
                    monster.hp = 30;
                    monster.attack = 3;
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }

        }
        static void EnterGame(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("마을에 접속했습니다.");
                Console.WriteLine("[1] 필드로 간다");
                Console.WriteLine("[2] 로비로 돌아가기");

                string input = Console.ReadLine();

                //로직 1.
                if(input == "1")
                {
                    EnterField (ref player);
                }
                else if(input == "2")
                {
                    break;
                }

                //로직 2.
                //switch(input)
                //{
                //    case " 1":
                //        //EnterField();
                //        break;
                //    case "2":
                //        return; //switch문 안에서 break로는 while을 못 벗어남.
                //}
            }
        }
        static void Fight(ref Player player, ref Monster monster)
        {
            while(true)
            {
                //플레이어가 몬스터 공격
                monster.hp -= player.attack;
                if(monster.hp <= 0)
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"남은 체력 : {player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                if(player.hp <= 0)
                {
                    Console.WriteLine("졌습니다.");
                    break;
                }

            }
        }
        static void EnterField(ref Player player)
        {
            Console.WriteLine("필드에 접속했습니다.!");
            Monster monster;
            CreateRandomMonster(out monster);
            Console.WriteLine("[1] 전투 모드로 돌입");
            Console.WriteLine("[2] 일정확률로 마을로 도망");

            string input = Console.ReadLine();
            if(input =="1")
            {
                Fight(ref player, ref monster);
            }
            else if(input =="2") 
            {
                //33%
                Random rand = new Random();
                int randValue = rand.Next(0, 101);

                if(randValue <= 33)
                {
                    Console.WriteLine("도망치는데 성공했습니다.");
                }
                else
                {
                    Fight(ref player, ref monster);
                }
            }
        }
        static void Main(string[] args)
        {
            Player player;

            Job job = Job.None;

            while (true)
            {
                job = ChooseJob();

                if(job != Job.None)
                {
                    CreatePlayer(job, out player);
                    EnterGame(ref player);
                }
            }
        }
    }
}
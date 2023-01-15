using System;
using System.ComponentModel;
using System.Globalization;

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

        struct Player
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
        static void CreateUnit(Job job, out Player player)
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
        static void Main(string[] args)
        {
            Player player;

            Job job = Job.None;

            int hp;
            int attack;

            while (job == Job.None)
            {
                job = ChooseJob();

                CreateUnit(job, out player);
                Console.WriteLine($"hp : {player.hp} attack : {player.attack}");
            }
        }
    }
}
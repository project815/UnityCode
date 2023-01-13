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
        static void Main(string[] args)
        {
            Job job = Job.None; 
            while (job == Job.None)
            {
                job = ChooseJob();
            }
        }
    }
}
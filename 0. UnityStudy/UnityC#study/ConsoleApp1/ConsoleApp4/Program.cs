using System;
using System.ComponentModel;
using System.Globalization;

namespace CSharp
{
    class Program
    {
        enum Choice
        {
            Rock = 1,
            Paper = 2,
            Scissors = 0,
        }
        //
        static void Main(string[] args)
        {
            //const int ROCK = 1;
            //const int PAPER = 2;
            //const int SCISSORS = 0;

            Random rand = new Random();
            int aiChoice = rand.Next(0, 3); // 0~2  사이의 값

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case (int)Choice.Scissors:
                    Console.WriteLine("당신의 선택은 가위입니다.");
                    break;
                case (int)Choice.Rock:
                    Console.WriteLine("당신의 선택은 바위입니다.");
                    break;
                case (int)Choice.Paper:
                    Console.WriteLine("당신의 선택은 보입니다.");
                    break;
            }
            switch (aiChoice)
            {
                case 0:
                    Console.WriteLine("컴퓨터의 선택은 가위입니다.");
                    break;
                case 1:
                    Console.WriteLine("컴퓨터의 선택은 바위입니다.");
                    break;
                case 2:
                    Console.WriteLine("컴퓨터의 선택은 보입니다.");
                    break;
            }

            //if (choice == aiChoice) Console.WriteLine("무승부입니다.");
            //else
            //{
            //    switch(choice)
            //    {
            //        case 0:
            //            if (aiChoice == 1) Console.WriteLine("당신이 졌습니다.");
            //            else Console.WriteLine("당신이 이겼습니다.");
            //            break;
            //        case 1:
            //            if (aiChoice == 2) Console.WriteLine("당신이 졌습니다.");
            //            else Console.WriteLine("당신이 이겼습니다.");
            //            break;
            //        case 2:
            //            if (aiChoice == 0) Console.WriteLine("당신이졌습니다.");
            //            else Console.WriteLine("당신이 이겼습니다/");
            //            break;
            //    }
            //}

            //이게 더 좋은 것 같다
            if (choice == aiChoice) Console.WriteLine("무승부입니다.");
            else if (choice == 0 && aiChoice == 1) Console.WriteLine("당신이 졌습니다.");
            else if (choice == 1 && aiChoice == 2) Console.WriteLine("당신이 졌습니다.");
            else if (choice == 2 && aiChoice == 0) Console.WriteLine("당신이 졌습니다.");
            else Console.WriteLine("당신이 이겼습니다.");
        }
    }
}
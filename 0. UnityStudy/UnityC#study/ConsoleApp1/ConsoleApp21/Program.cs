using System;
using System.Runtime.Serialization.Formatters;

namespace CSharp
{
    class Player
    {

    }
    class Monster
    {
        
    }
    class Program
    {
        //
        Player player;
        Monster monster;
        static void Main(string[] args)
        {
            int a;

            int[] scores = new int[5] { 10, 20, 30, 40, 50};

            int[] scores2 = new int[5];
            scores2 = scores;
            scores2[0] = 9999;
            scores[1] = 2;
            scores[2] = 3;
            scores[3] = 4;
            scores[4] = 5;

            for(int i = 0; i <5; i ++)
            {
                Console.WriteLine(scores[i]);
            }

            foreach(int score in scores)
            {
                Console.WriteLine(score);
            }
        }
    }
}
using System;
using System.Runtime.Serialization.Formatters;

namespace CSharp
{

    class Program
    {
        static int GetHightestScore(int[] scores)
        {
            int num = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if(num < scores[i])
                {
                    num = scores[i];
                }
            }
            return num;
        }
        static float GetAverageScore(int[] scores)
        {
            if (scores.Length == 0) { return 0; }

            float num = 0;
            for(int i = 0; i < scores.Length; i++)
            {
                num += scores[i];
            }

            return num / scores.Length;
        }
        static int GetIndexOf(int[] scores, int value)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Sort(int[] scores)
        {
            for(int i = 0; i < scores.Length - 1; i++)
            {
                for(int j = 1 + i; j < scores.Length; j++)
                {
                    if (scores[i] > scores[j])
                    {
                        int tmp = scores[i];
                        scores[i] = scores[j];
                        scores[j] = tmp;
                    }
                }
            }
            for(int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i] + " ");
            }
        }

        class Map
        {
            int[,] titles = {
                {1, 1, 1, 1, 1},
                {1, 0, 0, 0, 1},
                {1, 0, 0, 0, 1},
                {1, 0, 0, 0, 1},
                {1, 1, 1, 1, 1},
            };
            public void Render()
            {
                var defalutColor = Console.ForegroundColor;
                for (int y = 0; y < titles.GetLength(1); y++)
                {
                    for(int x = 0; x < titles.GetLength(0); x++)
                    {
                        if (titles[y, x] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write("\u25cf");
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = defalutColor;
            }
        }
        static void Main(string[] args)
        {
            int[] value = { 10, 30, 53, 60, 20 };

            int hightestNum = GetHightestScore(value);
            float averageNum =  GetAverageScore(value);
            int indexOfNum = GetIndexOf(value ,53); //60
            Sort(value);

            int[,] arr = new int[2, 3] { { 1,2,3,}, { 4, 5, 6} };
            Map map = new Map();
            map.Render();
        }
    }
}
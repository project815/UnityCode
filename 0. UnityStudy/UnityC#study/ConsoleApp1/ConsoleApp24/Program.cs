using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CSharp
{
    class Monster
    {
        public int _id;
        public Monster(int id)
        {
            _id = id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> monsterList = new List<int>();

            //hashTable
            //아주 큰 박스 [ . . .. . . . . .. ..... .]
            //박스 여러개를 쪼개 놓는다 [1 ~ 10] [11 ~ 20] [21 ~ 30] [31 ~40] [] [] [] []
            //777번 공?
            //메모리를 내주고 성능을 취한다.

            //Key => Value
            //Dictionary 
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            for(int i = 0; i < 1000; i++)
            {
                dic.Add(i, new Monster(i));
            }

            Monster mon;
            bool found = dic.TryGetValue(20000, out mon);
            bool found2 = dic.TryGetValue(999, out mon);
            //Monster mon = dic[20000];

            dic.TryAdd(1, new Monster(999999));
            dic[1]._id = 9999;
            dic[5] = new Monster(4);
            dic[44] = new Monster(32);
            //100만 개!!
        }
    }
}
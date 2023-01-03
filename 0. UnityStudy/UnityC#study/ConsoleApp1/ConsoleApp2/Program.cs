using System;

namespace CSharp
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            //int hp = 100;

            //+, -, *, /, %
            //hp = (1 +  2) * 100;

            //hp = 100 % 3;
            //++, --연산
            //Console.WriteLine(hp);

            //< <= > >= == !=

            //bool b = hp < 100;

            int hp = 100;
            int level = 50;

            bool isAlive = (hp > 0);
            bool isHightLevel = (level >= 40);

            //&& AND || OR ! NOT
            //a = 살아있는 고렙 유저인가요?
            bool a = isAlive && isHightLevel;

            //b = 살아있거나, 고렙유저이거나 둘중 하나인가요?
            bool b = isAlive || isHightLevel;

            //c = 죽은 유저인가요?
            bool c = !isAlive;
        }
    }
}
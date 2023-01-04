using System;

namespace CSharp
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            int num = 4;
            
            // << >> &(and) |(or) ^(xor) ~(not)

            num = num << 1; // 비트 연산 왼쪽으로 비트를 옮김
            num = num >> 1; // 비트 연산 오른쪽으로 비트를 옮김

            //오른쪽으로 비트연산을 옮긴다면, 맨 처음에 있는 부호비트가 있는 변수의 경우는 어떻게 될까?
            //부호비트에1을 옮기고 부호비트1는 유지한다.

            //그래서 부호비트가 없는 unsigned로 맞춰서 사용하는 게 편하기 때문이다.

            //&
            //둘다 1이면 1 둘중하나, 둘다 0이면 0

            //|
            //둘 중 하나가 1이면 1 둘다 0이면 0

            //~
            //하나만 보고 하는데, 1이면 0, 0이면 1로

            //^
            //두 값이 서로 다르면 1, 서로 같으면 0

            //비트연산 > id를 만들 떄,
            //

            int id = 123;

            int key = 401;
            int a = id ^ key;
            int b = a ^ key; //컴퓨터 보안에 사용되기도 한다.

            Console.WriteLine(num);
        }
    }
}
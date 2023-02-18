using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace CSharp
{
    //delegate
    class Program
    {
        //업체 사장 - 사장 비서 ->우리의 연락처, 용건(인자를 넘겨주고) <- 연락 주세요.(콜백)

        //함수자체를 인자로 넘기는 것.
        delegate int Onclicked();
        //delegate -> 형식은 형식인데, 함수 자체를 인자로 넘겨주는 그런 형식
        //반환은 int, 입력은 void
        //Onclicked가 delegate형식의 이름이다.

        //UI
        static void ButtonPressed(Onclicked clickedFuntion/*함수 자체를 인자로 넘겨주고*/)
        {
            clickedFuntion();
            //함수 호출();
        }

        //[10 20 40 50 30]

        static int TestDelegate()
        {
            Console.WriteLine("HelloDelegate");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("HelloDelegate2");
            return 0;
        }
        static void Main(string[] args)
        {
            ButtonPressed(TestDelegate);
            Onclicked test = new Onclicked(TestDelegate); //chaining 가능!
            test += TestDelegate2;
            ButtonPressed(test);
        }
    }
}

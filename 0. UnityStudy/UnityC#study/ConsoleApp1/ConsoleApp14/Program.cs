using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CSharp
{
    public class Knight
    {
        static public int a = 0; // 객체에 종속적이지 않고 다른 객체가 모두 공유

        
        public int hp;
        public int attack;
        static public void test()
        {
            //this.hp사용 불가.
            //static 함수는 객체에 종속되지 않음 함수이다. 그런데 객체의 변수를 접근하는 것은 논리상 맞지 않음
            a = 50;
        }
        public Knight()
        {
            a++;
            hp = 100;
            attack = 20;
            Console.WriteLine("생성자 호출1");

        }
        public Knight(int hp) : this() // :this() 자주 사용하진 않지만 이런 문법이 있다.
                                       //사용시, this(). Knight()생성자를 먼저 실행하고 Knight(int hp)가 실행된다.
        {
            this.hp = hp;
            Console.WriteLine("생성자 호출2");
        }
        //~Knight() //사용하지 않는 것이 좋다. 가비지 컬렉션이 자동으로 불리기 떄문.
        //{
        //    a--;
        //    Console.WriteLine("소멸자 호출");
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Knight.a);
            Knight knight = new Knight();
            Console.WriteLine(Knight.a);
            Knight knight1 = new Knight(1000);
            Console.WriteLine(Knight.a);
            Knight.test(); //클래스에 종속적임.
            knight.hp = 100; //객체에 종속적임.
            Console.WriteLine(Knight.a);
        }
    }
}
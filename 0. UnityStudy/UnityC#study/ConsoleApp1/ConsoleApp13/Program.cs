using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading;

namespace CSharp
{
    public class Knight
    {
        public int hp;
        public int attack;

        public Knight()
        {
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Knight knight1 = new Knight(1000);
            Console.WriteLine(knight.hp + " : " + knight.attack);
            Console.WriteLine(knight1.hp + " : " + knight1.attack);
        }
    }
}
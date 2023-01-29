using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CSharp
{
    //OPP(은닉성, 다형성, 상속성!)
    //!!상속성!!
    public class Player //부모 클래스, 기반클래스
    {
        static public int a = 0;
        public int id;
        public int hp;
        public int attack;
        public Player()
        {
            Console.WriteLine("Player 생성자 호출1");
        }
        public Player(int hp)
        {
            this.hp = hp;
            Console.WriteLine("Player hp 생성자 호출1");
        }

        public void Move()
        {
            Console.WriteLine("Player Move");
        }
        public void Attack()
        {
            Console.WriteLine("Player Attack");
        }
    }

    public class Knight : Player
    {
        static public void test()
        {
            //this.hp사용 불가.
            //static 함수는 객체에 종속되지 않음 함수이다. 그런데 객체의 변수를 접근하는 것은 논리상 맞지 않음
            a = 50;
        }

        int c;
        
        public Knight() : base(100)
        {
            this.c = 30;
            base.hp = c; //부모 접근 > base
            Console.WriteLine("Knight 생성자 호출1");
        }
        public Knight(int hp) : this() 

            
        {
            this.hp = hp;
            Console.WriteLine("생성자 호출2");
        }
    }
    public class Mage : Player // 자식클래스, 파생클래스
    {

    }
    public class Archer : Player
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.Move();
            knight.Attack();
        }
    }
}
using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading;

namespace CSharp
{
    //객체(OPP Object Oriented Programing)
    
    //Knight

    //속성 : hp, attack, current pos
    //기능 : Move, Attack, Die, 

    //참조
    class Player
    {
        static public int counter = 1;
        public int id;
        public int hp;
        public int attack;
    }

    //복사
    struct Mage
    {
        public int hp;
        public int attack;
    }
    
    class Archer
    { 
            public int hp;
        public int attack;
    }

    class Knight
    {
        public int hp;
        public int attack;

        public Knight Clone()
        {
            Knight knight = new Knight();
            knight.hp = hp;
            knight.attack = attack;
            return knight;
        }

        public void Move()
        {
            Console.WriteLine("Kinght Move");
        }
        public void Attack()
        {
            Console.WriteLine("Kinght Attack");
        }
    }
    class Program
    {
        static void KillNight(Knight knight) //참조
        {
            knight.hp = 0;
        }
        static void KillMage(Mage mage) //값복사
        {
            mage.hp = 0;
        }

        static void Main(string[] args)
        {
            Mage mage;
            mage.hp = 100;
            mage.attack = 50;
            
            Mage mage2 = mage;
            mage2.hp = 0;

            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 20;
            
            Knight knight2 = knight; //참조  >>> knight2의 값이 바뀌면 knight의 값도 바뀜.
            knight2.hp = 0;

            Knight knight3 = new Knight(); //복사 >>> 새로운 객체를 생성하여 값을 복사.
            knight3.hp = knight.hp;
            knight3.attack = knight.attack;
            knight3.attack = 0;

            //knight3과 같은 작업의 중복을 줄이기 위해서
            //클래스 내부에서 Clone하는 함수를 만들어 준다.(깊은 복사)
            Knight knight4 = knight.Clone();
            knight4.hp = 200;

            //KillMage(mage);
            //KillNight(knight);


            //얕은 복사, 깊은 복사?
        }
    }
}
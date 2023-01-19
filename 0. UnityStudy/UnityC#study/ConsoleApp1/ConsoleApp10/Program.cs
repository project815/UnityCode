using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Threading;

namespace CSharp
{
    //객체(OPP Object Oriented Programing)
    
    //Knight

    //속성 : hp, attack, pos
    //기능 : Move, Attack, Die, 

    class Player
    {
        static public int counter = 1;
        public int id;
        public int hp;
        public int attack;

    }
    class Mage
    {

    }
    class Archer
    { 
    
    }

    class Knight
    {
        public int hp;
        public int attack;

        Knight()
        {

        }
        static public Knight CreateKnight()
        {
            Knight knight = new Knight();

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
        static void Main(string[] args)
        {
            Knight knight = new Knight();

            knight.hp = 100;
            knight.attack = 20;
            knight.Move();
            knight.Attack();
        }
    }
}
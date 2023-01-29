using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CSharp
{
    //다형성!
    class Player
    {
        protected int hp;
        protected int attack;
        public virtual void Move() //성능상에는 그리 좋은 편은 아니다!.
        {
            Console.WriteLine("Player Move");
        }
    }
    class Knight : Player
    {
        //public new void Move()
        //{
        //    Console.WriteLine("Knight Move");
        //}
        public override void Move()
        {
            Console.WriteLine("Knight Move");
        }
    }
    class Mage : Player
    {
        public int mp;

        //public new void Move() 
        //{
        //    Console.WriteLine("Player Move");
        //}
        public override void Move()
        {
            base.Move();
            Console.WriteLine("Mage Move");
        }
    }
    class Archer : Player
    {
        public int attack;
        public sealed override void Move() //Archer를 상속받은 것은 더이상 오버라이딩하지 말아라라는 문법.
        {
            Console.WriteLine("Archer Move");
        }
    }
    class Program
    {
        static public void EnterFeild(Player player)
        {
            player.Move(); //Player클래스로 넘어왔지만
            //매개변수로 넘어오는 클래스에 맞춰져서 함수 실행됨.
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            Knight knight = new Knight();
            Mage mage = new Mage();
            Archer archer = new Archer();

            //player.Move();
            //knight.Move();
            //mage.Move();
            EnterFeild(knight);
            EnterFeild(mage);
            EnterFeild(archer);

        }
    }
}
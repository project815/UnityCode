using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CSharp
{
    //클래스 형식 변환

    //부모 <> 자식 클래스 형식 변환
    //is, as 사용가능. >> as가 더 깔끔하니깐 더 많이 쓴다고 함.
    //null은 없다는 뜻.
    //
    class Player
    {
        protected int hp;
        protected int attack;
    }
    class Knight : Player
    {

    }
    class Mage : Player
    {
        public int mp;

    }
    class Program
    {
        //비효율적이다!!!!!!!!!!!!!!!!!!!!!!
        //static void EnterGame(Knight knight)
        //{
        //}
        //static void EnterGame(Mage mage)
        //{
        //}
        //대신!

        public Player FindPlayerById(int id)
        {
            //id에 해당하는 플레이어 탐색
            return null; //못찾으면 null return 
        }
        static void EnterGame(Player player) // Player를 상속받는 클래스도 매개변수로 넣을 수 있음.
        {
            //! 그런데 넘어온 Player타입이 Knight인지? Mage인지? 모름!!
            //Knight knight = (Knight)player; //Knight클래스를 넘기면 okay, but Mage클래스라면 null를 뱉는다.

            //확인 할 수 있는 방법?!
            bool isKnight = player is Knight;
            Console.WriteLine("isKnight : " + isKnight);
            if(player is Knight) //is는 bool값을 내보낸다. player가 Knight클래스 형태이면
            {
                Knight knight = (Knight)player;
            }

            bool isMage = player is Mage;
            Console.WriteLine("isMage : " + isMage);
            if (player is Mage)
            {
                Mage mage = (Mage)player;
            }

            if(player as Knight != null)
            {
                Knight knight1 = player as Knight;
            }

            Mage mage2 = player as Mage;
            if(mage2 != null)
            {
                mage2.mp = 100;
                Console.WriteLine("mage.mp : " + mage2.mp);
            }
        }
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            //knight가 선언되면 스택메모리에 knight라는 변수가 생성
            //애당초 Knight는 클래스로 ref타입, 즉 참조 형식이다.

            //new Knight는 힙영역에 실제 knight의 본체가 생성됨.

            //스택 메모리 knight에서는 힙영역의 주소를 참조하고 있는 상태이다.
            //knight. 을 하면 주소에 접근하여 실제 나이트 본체를 사용함.
            Mage mage= new Mage();

            Player p1 = mage; //자식 -> 부모 캐스팅 항상 가능
            mage = (Mage)p1; //부모 -> 자식 캐스팅 될 수도 있고 안 될 수도 있고.

            EnterGame(knight);
            EnterGame(mage);

        }
    }
}
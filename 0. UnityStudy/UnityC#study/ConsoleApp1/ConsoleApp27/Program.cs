using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CSharp
{
    //interface
    class Program
    {
        abstract class Monster
        {
            public abstract void Shout(); //개념적으로만 존재합니다.
            //이것으로 반드시 사용해라라는 의미를 전달한다.
        }
        interface IFlyable
        {
            void Fly();
        }
        class Orc : Monster
        {
            public override void Shout()
            {
                Console.WriteLine("feferfffasdf");
            }
        }

        //날아다니는 오크를 만든다고 가정
        //다중 상속. 문제점이 있음. >> 
        //class SkeltonOrc : Orc, Skelton
        //{
        //    //어떤 Shout를 불리게 될 것인가? 구조가 깨짐!!
        //}
        //C#에서는 다중 상속을 막아둠. c++은 가능함.
        //같은 인터페이스를 가진 상속받아서 문제임.
        //그러면 인터페이스는 상속받지만 그 안에 구현된 내용은 니가 알아서 처리해!
        //

        //특정 클래스 인터페이스가 
        //추상 클래스, 인터페이스를 사용하는 이유 특정 클래스가 내가 원하는 인터페이스에 특정 시그니처의 기능을 활용하기를 원해서 사용함. 
        //방법 중 하나가 class에 abstract를 붙여서 추상화하는 것이었다.
        //그런데 여러개의 부모를 가질 수없음(다중 상속 불가)
        // 사용 범위가 좁아짐 >>그래서 interface로 사용하는 것이 더 넓게 사용할 수 있다.
        class FlyableOrc : Orc, IFlyable
        {
            public void Fly()
            {

            }
        }

        static void DoFly(FlyableOrc orc)
        {
            orc.Fly();
        }

        class Skelton : Monster
        {
            public override void Shout()
            {
                Console.WriteLine("asdfsdfsadf");
            }
            //public override void Shout()
            //{
            //    Console.WriteLine("asdfasdfsdf");
            //}
            //Skelton은 Monster클래스를 virtual함수를 상속받아 구현한다.
            //하지만virtual로 선언되어있는 함수를 반드시 구현할 의무는 없다. 없어도 오류는 아님.
            //반드시 선언해야 하는 함수로 만들려면 abstract를 추가해준다.
            //abstract로 선언하면 Monster자체를 new로 생성할 순 없다.
        }

        static void Main(string[] args)
        {
            // Monster m = new Monster();
            IFlyable flyable = new FlyableOrc();
            FlyableOrc orc = new FlyableOrc();
            DoFly(orc);
        }
    }
}

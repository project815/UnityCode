using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CSharp
{
    //OPP(은닉성, 다형성, 상속성!)
    //은닉성

    //핸들 차문 페달
    //엔진 기름 장치 <-- 외부노출X!

    //접근한정자.
    //public, private, protected, internal, protected internal
    class SuperCar
    {
        protected int speed; //상속받은 클래스에서만 접근가능함.
    }
    class Car : SuperCar
    {
        public int hp;

        public void ScretFunction()
        {

        }

        private int attack;

        public void SetAttack(int attack)
        {
            this.attack = attack;
        }

        public void Speed(int speed)
        {
            this.speed = speed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.hp = 100;
            car.ScretFunction(); //<<- 외부노출?! >> private!

            car.SetAttack(100);
            //Why? attack변수를 public으로 하고 바로 접근하지 않고 public함수를 통해 값을 접근하는가?
            //나중에 디버깅 시 함수내부에 브레이크 포인트를 걸고 호출을 스택으로 오류를 찾기 용이하다.

            car.Speed(100);
            //car.speed; >> protected로 선언되어 접근 불가
        }
    }
}
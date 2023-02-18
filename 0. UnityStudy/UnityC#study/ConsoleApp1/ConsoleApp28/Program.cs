using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace CSharp
{
    //property
    //객체지향 -> 은닉성
    class Program
    {
        class Knight
        {
            protected int hp;

            public int Hp
            {
                get { return hp; }
                private set { this.hp = value; } //defalut는 value
            }
            ////Getter Get함수
            //public int GetHp() { return hp; }
            ////Setter Set함수
            //public void SetHp(int hp) { this.hp = hp; } // hp를 여기서 수정하면 된다는 보장이 생김.
        
            //Get, Set함수 대신 프로터티 사용하면 줄여서 사용가능

            //자동 구현 프로터티도 있다!!!!더 간단

            public int HP { get; private set;}
            //내부구현은 아래 코드와 매우 유사함.
            private int _hp;
            public int GetHp() { return _hp; }
            public void SetHp(int value) { _hp = value; }
        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();

            //knight.Hp = 100; >>private로 선언해서 외부 수정 불가.
            int hp = knight.Hp;

            int _hp = knight.HP;
            //knight.HP = hp; //private로 선언되어있음.
        }
    }
}

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CSharp
{
    class Program
    {
        class MyList<T>
        {
            T[] arr = new T[10];
            public T GetItem(int i)
            {
                return arr[i];
            }
        }
        class MyFloatList
        {
            float[] arr = new float[10];
        }
        class MyTwoList<T, K>
        {
            T[] arr = new T[10];
            K num;
        }
        class Monster
        {

        }
        static void Test<T>(T input)
        {

        }
        static void Main(string[] args)
        {

            //나의 리스트를 만들려고 할 때, 다양한 자료형에 대응해줘야한다.
            //어떻게 할 수 있을까??
            //1. 다양한 자료형에 대응되는 여러 클래스를 만드는 방법 : 너무 많은 타입 형태가 있음
            //2. 모든 타입에 대응되는 Object타입을 사용하는 방법 : 성능상의 문제가 많이 있다., 참조타입이기 때문에 힙영역에 메모리 할당 및 생성되고 넣고 꺼내놓고 하는 것은 복잡한 과정이 필요하다.
            //3. Generic을 사용해보자.
            //클래스에 형태에 구애받지 않는 클래스.
            var obj3 = 4;
            var obj4 = "Helloworld";

            object obj = 3;// >참조 타입 박싱 : 메모리 상 힙에 만들고 꺼내올 때 힙에서 꺼내고 오고 하는 게 성능 상 좋지 않음.
            object obj2 = "HelloWorld";

            int num = (int)obj;// >복사 타입 언박싱
            string str = (string)obj2;

            //int, string 등은 object를 상속받아 사용됨.

            //Generic
            MyList<int> list = new MyList<int>();
            int num3 = list.GetItem(1);
            MyList<float> floatlist = new MyList<float>();
            MyList<Monster> monsterlist = new MyList<Monster>();


            Test<int>(1);
            Test<float>(30.4f);

            MyTwoList<int, string> myTwoList= new MyTwoList<int, string>();
          }
    }
}
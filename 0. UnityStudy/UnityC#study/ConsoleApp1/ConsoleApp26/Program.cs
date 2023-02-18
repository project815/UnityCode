using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace CSharp
{
    //Generic 일반화.
    class Program
    {
        class MyintList
        {
            int[] arr = new int[10];
        }
        class MyfloatList
        {
            float[] arr = new float[10];
        }
        class MyShortList
        {
            short[] arr = new short[10];
        }
        class MyMonsterList
        {
            Monster[] arr = new Monster[10];  
        }

        class Monster
        {
            
        }

        class MyList
        {
            Object[] arr = new Object[10]; // >> 별로 좋은 방법이 아님!!!!!!!!!!!!!
        }


        class MyList<T>
        {
            T[] arr = new T[10];

            public T GetItem(int i)
            {
                return arr[i];
            }
        }
        static void Test<T>(T input)
        {

        }
        class MyList<T, K>
        {
            T[] arr1 = new T[10];
            K[] arr2 = new K[10];
        }

        class MyListWhere<T> where T : struct //어떤 T든 상관없지만 struct형식이어야 한다.
                                        //: Monster클래스는 그것을 상속받은 클래스
        {

        }
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            //string, int타입을 우리가 정할 수 있다.

            var obj3 = 3;
            var obj4 = "helloworld"; //컴파일이 때려맞춤.

            Object obj = 3;
            Object obj2 = "HelloWorld"; //Object형식으로 바뀜 //힙영역에 참조타입
            //힙에 영역을 할당해서 데이터를 집어넣고 빼올 때 힙에 있는 숫자는 스택으로 빼서 사용함.

            //상속떄문에 그럼.
            //int, string은 Object을 상속받아서 사용됨.
            //
            int num = (int)obj;
            string str = (string)obj2; //스택, 복사타입


            MyList<int> myinList = new MyList<int>();
            MyList<short> myshortList= new MyList<short>();
            MyList<Monster> mymonsterList = new MyList<Monster>();

            Monster mon = mymonsterList.GetItem(0);
            //Monster타입으로 선언되어있음. >> 반환값은 Monster타입

            //함수Generic
            Test<int>(3);
            Test<float>(2.3f);

            //generic하나 이상도 됨.ex. Dictionary
           

        }
    }
}
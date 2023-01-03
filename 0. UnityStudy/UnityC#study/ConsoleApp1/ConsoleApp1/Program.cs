using System;

namespace CSharp
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            //Console.WriteLine("HelloWorld!");
            //int hp;

            //byte(1바이트 0~255) short(2바이트 -3만~3만) int(4바이트 -21억~21억) long(8바이트)
            //sbyte(1바이트 -128~127) ushort(2바이트 0~6만) uint(4바이트0~43억) ulong(8바이트)


            //10진수
            //00 01 02 03 04 05 06 07 08 09 
            //10

            //2진수
            //0b00 0b01 0b10 0b11 0b100

            //16진수
            //0~15 0~9, a, b, c, d, e, f
            //0x00 0x01 0x02 ..0x0F
            //0x10

            //2진수 > 16진수

            //0b 1000 1111 >>> 0x8F

            //1바이트 크기임. //컴퓨터가 연산할 때 비트보다 바이트단위가 더 빠르다고 함.
            //bool b;
            //b = true;
            //b = false;

            ////소수 4바이트
            //float f = 3.14f;

            ////8바이트
            //double d = 3.14f;

            ////2바이트
            //char c = 'a';
            //string str = "HelloWorld123안뇽";
            //hp = 100;

            //int weight;
            //weight = 200;

            //Console.WriteLine("Hello World! {0}, {0}", hp, weight);

            //형식변환
            // 1. 바구니 크기가 다른 경우
            int a = 100;
            short b = (short)a;
            // - int크기가 더 큰데, 작은 곳으로 옮기는 경우

            short c = 100;
            int d = c;
            // - short크기가 더 작은데, 큰 곳으로 옮기는 경우 문제없음.

            int g = 0xFFFF;
            short h = (short)g;
            //0xFFFF의 숫자는 2바이트크기, 그러나 short는 1바이트 크기이다. 결과적으로 -1이 됨.

            // 2. 바구니 크기는 같긴 한데, 부호가 다른 경우
            byte e = 255;
            sbyte f = (sbyte)e;
            //0x FF = 0b11111111 = -1
            //데이터의 크기는 다르지만 데이터 형식에 따라 데이터를 담는 범위가 달라짐.


            // 3. 소수
            float x = 3.1414f;
            double y = x;
            //정확한 숫자보다 인접한 숫자가 될 가능성이 높다.
       }
    }
}
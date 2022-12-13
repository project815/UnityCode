using System;

namespace CSharp
{
    class Program
    {
        //
        static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld!");
            int hp;

            //byte(1바이트 0~255) short(2바이트 -3만~3만) int(4바이트 -21억~21억) long(8바이트)
            //sbyte(1바이트 -128~127) ushort(2바이트 0~6만) uint(4바이트0~43억) ulong(8바이트)

            hp = 100;

            int weight;
            weight = 200;

            Console.WriteLine("Hello World! {0}, {0}", hp, weight);
        }
    }
}
using System;
using System.ComponentModel;
using System.Globalization;

namespace CSharp
{
    class Program
    {
        static void AddOne(ref int number)
        {
            number += 1;
        }
        static int AddOne2( int number)
        {
            return number += 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void Divide(int a , int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;

        }
        static void Main(string[] args)
        {
            int num = 20;

            Program.AddOne(ref num);
            Console.WriteLine(num);

            num = Program.AddOne2(num);
            Console.WriteLine(num);

            int num1 = 1;
            int num2 = 2;

            Console.WriteLine(num1 + " : " + num2);
            Program.Swap(ref num1, ref num2);
            Console.WriteLine(num1 + " : " + num2);

            int num3 = 10;
            int num4 = 3;

            int result1;
            int result2;
            Program.Divide(num3, num4, out result1, out result2);

            Console.WriteLine(result1 + " : " + result2);
        }
    }
}
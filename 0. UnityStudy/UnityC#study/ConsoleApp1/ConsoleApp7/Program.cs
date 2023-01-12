using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Globalization;

namespace CSharp
{
    class Program
    {

        static int Factorial(int n)
        {
            int tmp = n;

            while (tmp > 1)
            {
                n *= tmp - 1;
                tmp--;
            }
            return n;
        }
        static void Main(string[] args)
        {
            //구구단
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine(i + " * " + j + " = " + i * j);
                }
                Console.WriteLine("\n");
            }

            for(int i = 0; i < 5; i++ )
            {
                for(int j = 0; j <= i; j ++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine(Program.Factorial(5));
        }
    }
}

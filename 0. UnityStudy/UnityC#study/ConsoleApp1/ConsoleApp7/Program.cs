using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Globalization;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 9; i++)
            {
                for(int j = 1; j <= 9; j++)
                {
                    Console.WriteLine(i + " * " + j + " = " + i * j);
                }
                Console.WriteLine("\n");
            }    
        }
    }
}

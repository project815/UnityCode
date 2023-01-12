using System;
using System.ComponentModel;
using System.Globalization;

namespace CSharp
{
    class Program
    {
        static void Print(int value)
        {
            Console.WriteLine(value);
        }
        static int Add(int a, int b)
        {
            int ret = a + b;
            Print(ret);
            return ret;
        }
        
        static void Main(string[] args)
        {
            Program.Add(3, 4);
            Program.Add(1, 4);
            Program.Add(3, 4);
            Program.Add(3, 4);
            Program.Add(3, 4);
        }
    }
}
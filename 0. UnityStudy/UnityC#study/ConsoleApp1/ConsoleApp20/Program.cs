using ConsoleApp20;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Knight();
            Player player2 = new Archer();

            Monster monster1 = new Orc();

            int damage = player1.GetAttack();
            monster1.OnDamage(damage);
        }
    }
}
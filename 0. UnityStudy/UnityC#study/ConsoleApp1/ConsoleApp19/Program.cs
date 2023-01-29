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
            string name = "Harry Potter";

            //찾기
            bool found = name.Contains("Harry");
            int index = name.IndexOf('P'); // 없으면 -1

            //변형
            name = name + " Junior";

            string lowerString = name.ToLower();
            string upperString = name.ToUpper();

            string replaceString =  name.Replace('r', 'i');

            //분할
            string[] splitString = name.Split(new char[] { ' ' });
            string subString = name.Substring(5);
        }
    }
}
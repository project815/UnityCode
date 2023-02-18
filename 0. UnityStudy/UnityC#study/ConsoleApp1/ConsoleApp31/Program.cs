using ConsoleApp29;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace CSharp
{
    //delegate
    class Program
    {
       static void OnInputTest()
        {
            Console.WriteLine("InputRecevied");
        }
        static void Main(string[] args)
        {
            InputManager inputmanager = new InputManager();
            inputmanager.inputKey_delegate += OnInputTest;
            inputmanager.inputKey_delegate += OnInputTest;
            inputmanager.inputKey_delegate();

            inputmanager.inputKey_event += OnInputTest;
            //inputmanager.inputKey_event();
            //event를 추가하면 구독또는 구독취소가 가능하다.
            //하지만 delegate와 달리 직접inputmanger.inputKey로 접근하는 것은 불가능하다.
            //
            while (true)
            {
                inputmanager.Update();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class InputManager
    {
        public delegate void OnInputKey();
        public event OnInputKey inputKey;
        public void Update()
        {
            if (Console.KeyAvailable == false)
                return;
            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.A)
            {
                //모두한테 알려준다.
                inputKey();
            }
        }
    }
}

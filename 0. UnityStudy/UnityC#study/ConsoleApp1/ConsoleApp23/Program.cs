using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[1000]; // 배열의 크기를 정하지 않고?!
            arr[0] = 1;

            List<int> list = new List<int>();
            //추가.
            for(int i = 0; i < 5; i++)
            {
                list.Add(i);
            }
            foreach(int num in list)
            {
                Console.WriteLine(num);
            }

            //삽입.
            list.Insert(2, 999);
            foreach (int num in list)
            {
                Console.WriteLine(num);
            }

            //삭제.
            bool sucess =list.Remove(3); //value가 3인 것 첫번째 삭제
            list.RemoveAt(0); // 0번쨰 인덱스 삭제
            list.Clear(); //전체 삭제.
        }
    }
}
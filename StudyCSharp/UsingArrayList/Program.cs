using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);    // 리스트 맨 마지막 추가
            }

            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            list.RemoveAt(2);   //인덱스위치 값 삭제

            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            list.Insert(4, 4.5);    // 인덱스위치에 값 추가

            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            list.Clear();   // 전체 삭제
            Console.WriteLine("Clear");

            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
        }
    }
}

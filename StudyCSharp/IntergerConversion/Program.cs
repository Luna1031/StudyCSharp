using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergerConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte a = sbyte.MaxValue;
            Console.WriteLine($"a = {a}");

            int b = a;
            Console.WriteLine($"b = {b}");

            int x = 128;
            Console.WriteLine($"x = {x}");

            sbyte y = (sbyte)x;     //명시적 형변환 만약, Overflow가 발생한다면 그건 개발자의 책임으로 넘긴다
            Console.WriteLine($"y = {y}");
        }
    }
}

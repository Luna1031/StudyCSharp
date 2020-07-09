using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UsingDelegate
{
    delegate int MyDelegate(int a, int b);

    class Calculator
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }

        public int Minus(int a, int b)
        {
            return a - b;
        }
}
    class Program
    {
        static void Main(string[] args)
        {
            // 이전까지 직접 호출하는 방식
            Calculator calc = new Calculator();
            Console.WriteLine(calc.Plus(3, 5));
            Console.WriteLine(calc.Minus(4, 3));

            // 대리자 - 값이 아닌 코드자체를 넘기고싶을 때 사용
            MyDelegate CallBack = new MyDelegate(calc.Plus);
            Console.WriteLine(CallBack(4, 5));

        }
    }
}

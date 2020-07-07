using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfElseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("숫자 입력 :");
            string input = Console.ReadLine();      // 입력받는 자료형은 무조건 전부 다 string형임
            int number;
            if(int.TryParse(input, out number))
            {
                if (number % 2 == 0)
                    Console.WriteLine($"{number}는 짝수");
                else
                    Console.WriteLine($"{number}는 홀수");
            }
            else
            {
                Console.WriteLine("입력값이 숫자가 아님");
                return;
            }
        }
    }
}

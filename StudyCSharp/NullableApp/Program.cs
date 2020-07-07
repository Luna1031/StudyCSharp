using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            double? b = null;
            float? c = null;
            string s = null;

            if(a.HasValue)
            {
                Console.WriteLine(a.Value);     //없는데 화면에 출력하라고하면 에러나기때매 if문 안으로 넣어줌
            }
            Console.WriteLine(b == null);
            Console.WriteLine(string.IsNullOrEmpty(s));    // 문자열은 이렇게 확인함 = 예전 방식 Console.WriteLine(s == null || s == "")
            Console.WriteLine(string.IsNullOrWhiteSpace(s));    // 개발자들이 공백을 하도 많이 써서 만들어진 메소드

            c = 3.141592F;
            if(c.HasValue)
            {
                Console.WriteLine($"c = {c.Value}");
            }
        }
    }
}

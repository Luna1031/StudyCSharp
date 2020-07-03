using System;

namespace StringNumConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12345;
            string b = a.ToString();
            Console.WriteLine($"b = {b}");

            float c = 3.141592f;
            string d = c.ToString();
            Console.WriteLine($"d = {d}");

            string e = "123456";
            //int f = Convert.ToInt32(e);     //int f; bool = int.TryParse(e, out f); => 실행하면 에러는 안남, 그냥 Parse는 에러남
            //Console.WriteLine($"f = {f}");
            int f;
            if (int.TryParse(e, out f))
                Console.WriteLine($"f = {f}");      //이 방식을 사용하는 이유 :DB에서 값을 가져올 때 유용함
            else
                Console.WriteLine("f 변환시 에러 발생, 문자열 확인");
           
            string g = "3:141592";
            // float h = float.Parse(g);
            // Console.WriteLine($"h = {h}");
            float h;
            if (float.TryParse(g, out h))
                Console.WriteLine($"h = {h}");
            else
                Console.WriteLine("g 변환시 에러 발생, 문자열 확인");
        }
    }
}

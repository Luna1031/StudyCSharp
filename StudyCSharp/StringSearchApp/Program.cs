using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Good Morning";
            Console.WriteLine(greeting);

            Console.WriteLine($"IndexOf 'Good' : {greeting.IndexOf("Good")}");
            Console.WriteLine($"LastIndexOf 'Good' : {greeting.LastIndexOf("Good")}");

            Console.WriteLine($"IndexOf 'n' : {greeting.IndexOf('n')}");
            Console.WriteLine($"LastIndexOf 'n' : {greeting.LastIndexOf('n')}");

            Console.WriteLine($"Startswith 'Good' : {greeting.StartsWith("Good")}");
            Console.WriteLine($"StartsWith 'Morning' : {greeting.StartsWith("Morning")}");

            Console.WriteLine($"Contains 'Good' : {greeting.Contains("Good")}");

            Console.WriteLine($"Replace 'Morning' to 'Evening' : " + $"{greeting.Replace("Morning", "Evening")}");

            if(greeting.Contains("Morning"))
            {
                greeting.Replace("Morning", "Evening");
            }

            Console.WriteLine($"ToLower : {greeting.ToLower()}");
            Console.WriteLine($"ToUpper : {greeting.ToUpper()}");

            Console.WriteLine($"Insert : {greeting.Insert(greeting.IndexOf("Morning") - 1, " Very")}");

            Console.WriteLine($"Remove : '{"I don't love u".Remove(2, 6)}'");

            Console.WriteLine($"Trim : '{"No Space".Trim()}'");
            Console.WriteLine($"Trim : '{"No Space".TrimStart()}'");
            Console.WriteLine($"Trim : '{"No Space".TrimEnd()}'");

            string codes = " MSFT, GOOG, AMZN, AAPL, RHT";
            var result = codes.Split(',');     // 자른다 - > ,(콤마)로 잘라서 result에 대입하고 배열로 만든다
            foreach (var item in result)
            {
                Console.WriteLine($"each item {item}");
            }
            foreach(var item in result)
            {
                Console.WriteLine($"each item '{item}'");
            }
            Console.WriteLine($"substring : {greeting.Substring(0, 4)}");   // 0~4의 문자만 씀
            Console.WriteLine($"substring : {greeting.Substring(5)}");      // 5부터 끝까지

            Console.WriteLine(string.Format("{0}DEF", "ABC"));      // DEF가 원래 있는 값 ABC가 넣으려고 하는 값
            Console.WriteLine(string.Format("{0, -10}DEF", "ABC"));
            Console.WriteLine(string.Format("{0, 10}DEF", "ABC"));

            DateTime dt = DateTime.Now;
            Console.WriteLine(string.Format("{0 : yyyy-MM-dd HH:bb:ss}", dt));

            decimal mvalue = 27000000m;

        }
    }
}

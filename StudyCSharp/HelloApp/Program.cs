using System;
using static System.Console;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                WriteLine("ex :HelloApp.exe <이름>");
                return;
            }
            WriteLine("Hello, {0}!", args[0]);  // {0}에다가 args[0]을 넣겠다, 옛날 방식
            WriteLine($"Hello, {args[0]}!");    // 최신 형태
        }
    }
}

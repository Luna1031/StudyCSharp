﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            int x = 100, y = 0;

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(arr[i]);
                }

                y = 2;
                Console.WriteLine($"{x / y}");

                string origin = "RR";
                int val = int.Parse(origin);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"예외 1 발생 :{ex.Message}");
                ex.HelpLink = "https://docs.microsoft.com/ko-kr/dotnet/api/system.indexoutofrangeexception?view=netcore-3.1";
                Console.WriteLine($"도움말 링크 :{ex.HelpLink}");
            }

            catch(DivideByZeroException ex)
            {
                Console.WriteLine($"예외 2 발생 :{ex.Message}");
            }

            catch(Exception ex)
            {
                Console.WriteLine($"??????????? :{ex.Message}");
            }

            Console.WriteLine("종료");
        }
    }
}

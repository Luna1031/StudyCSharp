using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingApp
{
    class Program
    {
        static int Plus(int a, int b)
        {
            return a + b;
        }

        static int Plus(int a, int b, int c)
        {
            return a + b + c;
        }

        static double Plus(double a, double b)
        {
            return a + b;
        }

        static double Plus(double a, double b, double c)
        {
            return a + b + c;
        }

        static float Plus(float a, float b)
        {
            return a + b;
        }

        static float Plust(float a, float b, float c)
        {
            return a + b + c;
        }

        static int Sum(params int[] args)
        {
            int res = 0;
            foreach(var item in args)
            {
                res += item;
            }
            return res;
        }

        static void MyMethod(string arg1 = "", string arg2 = "")
        {
            Console.WriteLine("MyMethod A");
        }

        static void MyMethod()
        {
            Console.WriteLine("MyMethod B");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Plus(3.14f, 2.56f));
            Console.WriteLine(Plus(3.14, 2.56));

            int sum = Sum(3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine($"{sum}");

            MyMethod();
            MyMethod("H", "I");
        }
    }
}

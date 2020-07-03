using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 3.158654887987987987987987546548321546;
            Console.WriteLine($"a = {a}");

            double b = (double)a;
            Console.WriteLine($"b = {b}");

            double dmax = float.MaxValue;
            Console.WriteLine($"dmax = {dmax}");

            float fmax = (float)dmax;
            Console.WriteLine($"fmax = {fmax}");
        }
    }
}

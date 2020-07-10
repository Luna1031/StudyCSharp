using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UsingFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;     // == { return 10;};
            Console.WriteLine($"func1() = {func1()}");
            Console.WriteLine($"type of func1() = {func1}");

            Func<int, int> func2 = (x) => x * 2;     // == (int x) => { return x * 2; };
            Console.WriteLine($"func2() = {func2(4)}");

            try
            {
                Func<double, double, int> func3 = (x, y) =>
                {
                    if (y == 0)
                    {
                        throw new Exception("Divide by zero");
                    }
                    return (int)(x / y);
                };
                Console.WriteLine($"func3() = {func3(22, 0)}");
            }

            catch (Exception ex)
            {
                Console.WriteLine("ERR");
            }
        }
    }
}

using System;
using System.Diagnostics.Eventing.Reader;
using static System.Console;

namespace IntegerType
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            sbyte a = sbyte.MaxValue;
            byte b = byte.MinValue;

            short c = short.MinValue;
            ushort d = ushort.MaxValue;

            int e = int.MinValue;
            uint f = uint.MaxValue;

            long g = long.MaxValue;
            ulong h = ulong.MaxValue;
            ulong i = 20_000_000_000;

            Console.WriteLine(i);
            */

            byte a = 240;
            WriteLine($"a = {a}");
            byte b = 0b1111_1111;
            WriteLine($"b = {b}");
            byte c = 0xFF;
            WriteLine($"c = {c}");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = ("슈퍼맨", 56, "크립톤");
            Console.WriteLine($"{a.Item1}, {a.Item2}, {a.Item3}");
            Console.WriteLine($"{a.Item1.GetType()}, {a.Item2.GetType()}, {a.Item3.GetType()}");

            var b = (Name: "이예은", Age: 28, Home: "양산");
            Console.WriteLine($"{b.Age}, {b.Name}, {b.Home}");

            b = a;
            Console.WriteLine($"{b.Age}, {b.Name}, {b.Home}");

            var (name, age, home) = b;
            Console.WriteLine($"{name}, {age}, {home}");
        }
    }
}

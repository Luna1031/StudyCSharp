using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            strings.Add("Hello");
            strings.Add("Bye");
            strings.Add("Hi");
            List<string> subs = new List<string> { "Banana", "Melon" };
            strings.AddRange(subs);     // strings에 들어있는 값을 전부 다 넣어줌

            var i = 0;
           foreach(var item in strings)
            {
                Console.WriteLine($"{++i} item : {item}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingThrow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomething(1);
                DoSomething(2);
                DoSomething(3);
                DoSomething(4);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"예외발생 :{ex.Message}");
            }

            finally
            {
                Console.WriteLine("일단 수행");
            }
        }

        private static void DoSomething(int arg)
        {
            if(arg < 10)
            {
                Console.WriteLine($"arg :{arg}");
            }
            else
            {
                throw new Exception
                {
                    HelpLink = "http://www.naver.com",
                    Source = "UsingThrow line 34",

                };
            }
        }
    }
}

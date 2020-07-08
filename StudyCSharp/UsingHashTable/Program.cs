using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht["이름"] = "이예은";
            ht["주소"] = "경남 양산시";
            ht["번호"] = "01093511508";
            ht["신장"] = "159.9cm";
            ht["결혼"] = false;

            Console.WriteLine($"{ht["신장"]:0.0}");

            ArrayList list = new ArrayList { 123, 456, 789 };
        }
    }
}

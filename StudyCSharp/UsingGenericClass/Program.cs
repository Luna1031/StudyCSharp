using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericClass
{
    class MyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    Console.WriteLine($"Array Resized :{array.Length}");
                }
                array[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return array.Length;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> strList = new MyList<string>();
            strList[0] = "abc";
            strList[1] = "def";
            strList[2] = "ghi";
            strList[3] = "jkl";

            for (int i = 0; i < strList.Length; i++)
            {
                Console.WriteLine(strList[i]);
            }

            MyList<float> floatList = new MyList<float>();
            floatList[0] = 1.21212f;
            floatList[1] = 2.32456f;

            for (int i = 0; i < floatList.Length; i++)
            {
                Console.WriteLine(floatList[i]);
            }
        }
    }
}

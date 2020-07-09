using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParameters
{
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }

        public StructArray(int size)
        {
            Array = new T[size];    // 배열인데 배열이 T타입이다...
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }

        public RefArray(int size)
        {
            Array = new T[size];
        }
    }

    class Base { }

    class Derived : Base { }

    class BaseArray<U> where U : Base   // U 는 Base만 쓸 수 있다
    {
        public U[] Array { get; set; }

        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T> (T[] source) where T : U
        {
            source.CopyTo(Array, 0);
        }
    }
    class Program
    {
        public static T CreatedInstance<T>() where T : new()
        {
            return new T();
        }
           
        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);

            // StructArray<string> b = new StructArray<string>(3); 스트링은 참조형식이라서 사용못함 where  T : struct이기 때문에

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreatedInstance<Base>();   // Base도 가능, Derived도 가능

            BaseArray<Derived> e = new BaseArray<Derived>(3);
        }
    }
}

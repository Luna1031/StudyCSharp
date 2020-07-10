using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExMember
{
    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        /* 아래 람다식과 같은 기능의 생성자
        public FriendList()
        {
            Console.WriteLine("FriendList()");
        }
        */

        public FriendList() => Console.WriteLine("FriendList()");
        ~FriendList() => Console.WriteLine("~FriendList()");

        public int Capacity
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("Lulu");
            obj.Add("Jinx");
            obj.Add("Nami");
            obj.Add("Sena");
            obj.Add("Lulu");
            obj.PrintAll();

            Console.WriteLine("---------------");

            obj.Capacity = 10;
            obj[0] = "Niko";
            obj.PrintAll();

            Console.WriteLine("---------------");

            obj.Remove("Nami");
            obj.PrintAll();
        }
    }
}

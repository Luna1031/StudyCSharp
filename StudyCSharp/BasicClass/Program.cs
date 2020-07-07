using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BasicClass
{
    class Cat
    {
        public string Name;
        public Color Color;

        public Cat()
        {
            Name = "";
            Color = Color.Transparent;
        }

        /// <summary>
        /// 고앵쓰
        /// </summary>
        /// <param name="name">고앵쓰 이름</param>
        /// <param name="color">고앵쓰 색깔</param>
        public Cat(string name, Color color)
        {
            Name = name;
            Color = color;
        }

        ~Cat()
        {
            Console.WriteLine("Destruct");
        }


        public void Meow()
        {
            Console.WriteLine($"{Name}, 애용");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat Kitty = new Cat();      // 인스턴스화
            Kitty.Name = "끼리";
            Kitty.Color = Color.White;
            Kitty.Meow();
            Console.WriteLine($"{Kitty.Name} : {Kitty.Color}");

            Cat Nero = new Cat("니로", Color.Black);
            Nero.Meow();
            Console.WriteLine($"{Nero.Name} : {Nero.Color}");
        }
    }
}

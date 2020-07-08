using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Property
{
    /*  옛날방식
    class BirthdayInfo
    {
        private string name;
        private DateTime birthday;

        public void SetBirthday(DateTime birthday)
        {
            this.birthday = birthday;
        }

        public DateTime GetBirthdaty(DateTime birthday)
        {
            return birthday;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
    }
    */

    class BirthdayInfo
    {
        private DateTime birthday;

        public string Name { get; set; }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                if (value.Year >= DateTime.Now.Year)
                {
                    birthday = DateTime.Now;
                }
                else
                {
                    birthday = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo bi = new BirthdayInfo();
            
            bi.Name = "이예은";
            bi.Birthday = new DateTime(1993, 10, 31);

            Console.WriteLine($"{bi.Name}, {bi.Birthday}출생");
            Console.WriteLine($"{bi.Age}세");

            // bi.SetName("이예은");
            // bi.SetBirthday(new DateTime(1993, 10, 31));
            //Console.WriteLine($"{bi.GetName()}, {bi.GetBirthday()} 출생");

            var myInstance = new { Name = "이예은", Home = "양산" };
            Console.WriteLine($"{myInstance.Name}, {myInstance.Home}");

            var v = new { Subject = "수학", Scores = new int[] { 99, 88, 77 } };
            Console.WriteLine($"{v.Subject}");
            foreach(var item in v.Scores)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}

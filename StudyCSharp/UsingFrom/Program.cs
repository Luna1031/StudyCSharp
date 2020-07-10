using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UsingFrom
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Subject
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int[] nums = { 9, 2, 6, 7, 5, 3, 7, 8, 1, 10 };
            var result = from    n in nums     // nums 배열에서 n 하나 씩 빼온다는 의미
                         where   n % 2 == 0
                         orderby n ascending
                         select  n;            // 강박적인 띄워쓰기

            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }
            */
            /*
            List<Profile> profiles = new List<Profile>
            {
                new Profile { Name = "정우성", Height = 186 },
                new Profile { Name = "장동건", Height = 182 },
                new Profile { Name = "고현정", Height = 172 }
            };

            var newProfiles = from    item in profiles
                              where   item.Height < 175
                              orderby item.Name
                              select new
                              {
                                  Name = item.Name,
                                  InchHeight = item.Height * 0.393
                              };

            foreach (var item in newProfiles)
            {
                Console.WriteLine($"'{item.Name}', {item.InchHeight} inch");
            }
            */

            List<Subject> subjects = new List<Subject>
            {
                new Subject { Name = "연두반", Score = new int[] {99, 80, 70, 24, 58}},
                new Subject { Name = "분홍반", Score = new int[] {60, 45, 58, 72}},
                new Subject { Name = "파랑반", Score = new int[] {90, 30, 58, 94}},
                new Subject { Name = "노랑반", Score = new int[] {91, 88, 0}},
            };

            var newSubjects = from s in subjects
                                from d in s.Score
                                where d < 60
                                orderby d
                                select new { s.Name, Lowest = d };

            foreach (var item in newSubjects)
            {
                Console.WriteLine($"Drop :{item.Name}, {item.Lowest}");
            }
        }
    }
}

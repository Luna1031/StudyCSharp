using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingYield
{
    class MyEnumerator
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        public IEnumerator GetEnumerator()
        {
            yield return nums[0];
            yield return nums[1];
            yield return nums[2];
            // yield break;
            yield return nums[3];
            yield return nums[4];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyEnumerator();
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }
}

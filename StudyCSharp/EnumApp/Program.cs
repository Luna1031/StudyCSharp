using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumApp
{
    class Program
    {
        enum DialogResult       // 상수형태이다 - Int값으로 매핑된다, 값을 대입해서 지정해줄 수 있다
        {
            YES = 10,
            NO = 20,
            CANCEL = 30,
            CONFIRM = 40,
            OK = 50
        }
        static void Main(string[] args)
        {
            // Console.WriteLine(DialogResult.OK);
            // Console.WriteLine((int)DialogResult.OK);
            DialogResult result = DialogResult.YES;
            if(result == DialogResult.YES)
            {
                Console.WriteLine("GET YES");
            }
        }
    }
}

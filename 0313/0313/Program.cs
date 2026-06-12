using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0313
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello C# Programming");
            Console.Write("Hello C# Programming");
            Console.WriteLine("2601110285");
            Console.WriteLine("김유민입니다.");
            Console.WriteLine("\"안녕\"\t하세요");
            Console.WriteLine((int)'가');
            Console.WriteLine((int)'힣');
            Console.WriteLine('가'+'힣');
            Console.WriteLine((int)'A');
            Console.WriteLine((int)'B');
            Console.WriteLine((char)66);
            int time = 10;
            Console.WriteLine((9 < time) && (time < 12));
            Console.WriteLine(DateTime.Now.Hour > 9 || DateTime.Now.Hour < 12);
            Console.WriteLine(DateTime.Now.Hour > 9 && DateTime.Now.Hour < 12);

            //Console.WriteLine("안녕하세요"[100]);                             코드 실행 중 발생하는 오류 ( 문자열이 5갠데 100 )
        }
    }
}
